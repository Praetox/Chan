using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;

namespace SciDBomb
{
    public class HttpData
    {
        public WebHeaderCollection Headers;
        public string Html;
    }

    public class WebReq
    {
        public WebHeaderCollection Headers = new WebHeaderCollection();
        private WebHeaderCollection outHeaders = new WebHeaderCollection(); private string Postdata = "";
        public ReqState State = ReqState.Ready; public double Progress; public int cSize = 1024;
        public Uri URI; private string Filename = ""; private bool ReturnStr = false;
        public string Response = ""; private long cLength; public string SentPacket = "";
        private Socket socket; private Random rnd = new Random(); string ConMode = "GET";
        public bool isReady = true; private int iTimeout = -1; private string tmpPath = "tmp/";

        public enum ReqState { Ready, Connecting, Requesting, Downloading, Completed, Failed };

        public void Request(Uri Url, WebHeaderCollection cHeaders, string sPostdata, string sFilename, bool bReturnStr)
        {
            isReady = false; State = ReqState.Connecting;
            URI = Url; Filename = sFilename; ReturnStr = bReturnStr;
            Headers = new WebHeaderCollection();
            outHeaders["Host"] = URI.Host;
            outHeaders["Keep-Alive"] = "close";
            for (int a = 0; a < cHeaders.Count; a++)
            {
                outHeaders.Add(cHeaders.GetKey(a) + ": " + cHeaders.Get(a));
            }
            if (sPostdata != "")
            {
                ConMode = "POST"; Postdata = sPostdata;
                outHeaders.Add("Content-Length: " + Postdata.Length);
            }

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint RHost = new IPEndPoint(Dns.GetHostEntry(URI.Host).AddressList[0], URI.Port);
                if (iTimeout != -1)
                {
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, iTimeout);
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, iTimeout);
                    BackgroundWorker bwTimeout = new BackgroundWorker();
                    bwTimeout.DoWork += new DoWorkEventHandler(bwTimeout_DoWork);
                    bwTimeout.RunWorkerAsync();
                }
                State = ReqState.Connecting; socket.Connect(RHost); State = ReqState.Requesting;
                if (ConMode == "POST") outHeaders.Add("Content-Type: application/x-www-form-urlencoded");
                string ReqStr = ConMode + " " + URI.PathAndQuery + " HTTP/1.0\r\n" + outHeaders;
                if (ConMode == "POST") ReqStr += Postdata;
                SentPacket = ReqStr + "\r\n\r\n>";
                byte[] bPck = System.Text.Encoding.ASCII.GetBytes(ReqStr);
                foreach (byte btPck in bPck)
                    SentPacket += btPck + " ";
                socket.Send(System.Text.Encoding.ASCII.GetBytes(ReqStr));
                if (ParseHeader())
                {
                    string tFName = "";
                    do
                        tFName = tmpPath + "wanr_" + RandomChars(20) + ".tmp";
                    while (File.Exists(tFName));
                    FileStream streamOut = File.Open(tFName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                    BinaryWriter writer = new BinaryWriter(streamOut);
                    byte[] RecvBuffer = new byte[cSize]; int nBytes, nTotalBytes = 0;
                    while ((nBytes = socket.Receive(RecvBuffer, 0, cSize, SocketFlags.None)) > 0)
                    {
                        nTotalBytes += nBytes; State = ReqState.Downloading;
                        Progress = Math.Round(((double)100 - ((double)cLength - (double)nTotalBytes) * (double)100 / (double)cLength), 1);
                        writer.Write(RecvBuffer, 0, nBytes);
                        if (ReturnStr) Response += Encoding.ASCII.GetString(RecvBuffer, 0, nBytes);
                    }
                    writer.Close(); streamOut.Close(); streamOut.Dispose(); socket.Close();

                    long tStart = Tick();
                    if (!File.Exists(tFName)) wrErrlog("Poll1 false");
                    while (!File.Exists(tFName))
                    {
                        System.Threading.Thread.Sleep(10);
                        if (Tick() > tStart + 2000) break;
                    }
                    if (!File.Exists(tFName)) wrErrlog("Poll2 false");
                    if (File.Exists(tFName))
                    {
                        if (ReturnStr)
                        {
                            System.IO.StreamReader strmIn = new System.IO.StreamReader(tFName, Encoding.GetEncoding("iso-8859-1"));
                            Response = strmIn.ReadToEnd(); strmIn.Close(); strmIn.Dispose();
                        }
                        if (Filename != "") { File.Delete(Filename); File.Move(tFName, Filename); } else File.Delete(tFName);
                    }
                }
            }
            catch (Exception ex)
            {
                wrExThrow(ex.Message, ex.StackTrace);
            }
            State = ReqState.Completed; Progress = 100; isReady = true;
        }

        public void Request(String sURL, WebHeaderCollection cHeaders, string sPostdata, string sFilename, bool bReturnStr)
        {
            if (!sURL.ToLower().StartsWith("http://")) sURL = "http://" + sURL;
            Request(new Uri(sURL), cHeaders, sPostdata, sFilename, bReturnStr);
        }

        private bool ParseHeader()
        {
            try
            {
                byte[] bytes = new byte[10]; string Header = "";
                while (socket.Receive(bytes, 0, 1, SocketFlags.None) > 0)
                {
                    Header += Encoding.ASCII.GetString(bytes, 0, 1);
                    if (bytes[0] == '\n' && Header.EndsWith("\r\n\r\n"))
                        break;
                }
                MatchCollection matches = new Regex("[^\r\n]+").Matches(Header.TrimEnd('\r', '\n'));
                for (int n = 1; n < matches.Count; n++)
                {
                    string[] strItem = matches[n].Value.Split(new char[] { ':' }, 2);
                    if (strItem.Length > 0)
                        Headers[strItem[0].Trim()] = strItem[1].Trim();
                }
                if (Headers["Content-Length"] != null) cLength = int.Parse(Headers["Content-Length"]);
                return true;
            }
            catch
            {
                wrExThrow("Header parse error");
                return false;
            }
        }

        public void SetTimeout(int Timeout)
        {
            iTimeout = Timeout;
        }
        private void bwTimeout_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(iTimeout);
            if (State != ReqState.Connecting) return;
            wrExThrow("Connection timeout");
        }

        private static long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
        private string RandomChars(int Count)
        {
            string ret = "";
            for (int a = 0; a < Count; a++)
            {
                int ThisRnd = rnd.Next(1, 63);
                if (ThisRnd >= 1 && ThisRnd <= 26)
                    ThisRnd += 64;
                else if (ThisRnd >= 27 && ThisRnd <= 52)
                    ThisRnd += 97 - 27;
                else if (ThisRnd >= 53 && ThisRnd <= 62)
                    ThisRnd += 48 - 53;
                ret += (char)ThisRnd;
            }
            return ret;
        }
        private static String Byte2Str(byte[] Value)
        {
            int len = 0; for (len = Value.Length; len > 0; len--) if (Value[len - 1] != 0) break;
            string ret = ""; for (int a = 0; a < len; a++) ret += (char)Value[a];
            //byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = Value[a];
            return ret; //System.Text.Encoding.ASCII.GetString(buf);
        }
        private void wrErrlog(string msg)
        {
            string errMessage = System.DateTime.Now.ToShortDateString() + " - " +
                                System.DateTime.Now.ToLongTimeString() + "\r\n" +
                                msg + "\r\n\r\n";
            /*try
            {
                FileStream fs = new FileStream("errors_browser.txt", FileMode.Append);
                fs.Write(System.Text.Encoding.ASCII.GetBytes(errMessage), 0, errMessage.Length);
                fs.Close(); fs.Dispose();
            }
            catch { }*/
        }
        private void wrExThrow(string msg, string trace)
        {
            string exMessage = msg;
            Response = "<WebReq_Error>" + msg + "</WebReq_Error>";
            if (Filename != "")
            {
                FileStream fs = new FileStream(Filename, FileMode.Create);
                fs.Write(System.Text.Encoding.ASCII.GetBytes(Response), 0, Response.Length);
                fs.Close(); fs.Dispose();
            }
            if (trace.Contains(":line "))
                trace = trace.Substring(trace.IndexOf(":line ") + 6);
            else
                trace = "";
            if (trace != "") exMessage += "\r\nSTACK TRACING --> " + trace;
            wrErrlog(exMessage);
            socket.Close(); State = ReqState.Failed; Progress = 100; isReady = true;
        }
        private void wrExThrow(string msg)
        {
            wrExThrow(msg, "");
        }
    }
}
