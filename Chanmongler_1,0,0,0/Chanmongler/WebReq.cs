using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;

namespace Chanmongler
{
    public class WebReq
    {
        private WebHeaderCollection Headers;
        public ReqState State = ReqState.Ready; public double Progress; public int cSize = 1024;
        public Uri URI; private string Filename = ""; private bool ReturnStr = false;
        public string Response = ""; private long cLength;
        private Socket socket; private Random rnd = new Random();
        public bool isReady = true;

        public enum ReqState { Ready, Connecting, Requesting, Downloading, Completed };

        public void Request(Uri Url, string sFilename, bool bReturnStr)
        {
            isReady = false; State = ReqState.Connecting;
            URI = Url; Filename = sFilename; ReturnStr = bReturnStr;
            Headers = new WebHeaderCollection();
            Headers["Host"] = URI.Host;
            Headers["Keep-Alive"] = "close";

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
                State = ReqState.Connecting; socket.Connect(RHost); State = ReqState.Requesting;
                string ReqStr = "GET " + URI.PathAndQuery + " HTTP/1.0\r\n" + Headers;
                socket.Send(System.Text.Encoding.ASCII.GetBytes(ReqStr));
                ParseHeader();

                string tFName = "";
                do
                    tFName = "Chanmongler_" + RandomChars(6) + ".tmp";
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
                writer.Close(); streamOut.Close(); socket.Close();
                if (Filename != "") File.Move(tFName, Filename);
            }
            catch { }
            State = ReqState.Completed; Progress = 100;
            isReady = true;
        }
        public void Request(String sURL, string sFilename, bool bReturnStr)
        {
            if (!sURL.ToLower().StartsWith("http://")) sURL = "http://" + sURL;
            Request(new Uri(sURL), sFilename, bReturnStr);
        }

        private void ParseHeader()
        {
            byte[] bytes = new byte[10]; string Header = ""; Headers = new WebHeaderCollection();
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
        }

        public void SetTimeout(int Timeout)
        {
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, Timeout * 1000);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, Timeout * 1000);
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
    }
}
