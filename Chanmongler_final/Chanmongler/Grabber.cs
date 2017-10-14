using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

/*  Chanmongler -- chanstyle imageboard downloader and searcher
 *  Copyright (C) 2008,2009  Praetox (http://praetox.com/)
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace Chanmongler {
    public class Grabber {
        public Uri uri;
        public bool alloc;
        public string path;
        public bool givestr;
        Random rnd = new Random();
        Socket socket;

        public int srvRsp = 0;
        public int curByte = 0;
        public int dataLen = 0;

        public Ex ex;
        public bool done;
        public string ret;
        public State state;
        public enum State { Connecting, Requesting, Downloading, Completed, Failed };
        public enum Ex { None, IOError, Rejected, ConnLost, NotFound, BlankFile, CutFile };

        public Grabber(string suri) : this(suri, "", false, true) {}
        public Grabber(string suri, string path, bool alloc, bool givestr) {
            done = false; state = State.Connecting; uri = new Uri(suri);
            this.givestr = givestr; this.alloc = alloc; this.path = path;
            ex = Ex.None;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e) {
            try {
                //Create socket
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint RHost = new IPEndPoint(Dns.GetHostEntry(uri.Host).AddressList[0], uri.Port);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 30000);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 30000);

                //Create/send request
                state = State.Connecting;
                try {
                    socket.Connect(RHost);
                }
                catch {
                    throwEx(Ex.Rejected);
                    return;
                }
                state = State.Requesting;
                string Host = uri.Host;
                if (uri.Port != 80) Host
                    += ":" + uri.Port;
                string ReqStr = "GET " + uri.PathAndQuery + " HTTP/1.0\r\n" +
                    "Host: " + Host + "\r\n" + "Keep-Alive: close" + "\r\n\r\n";
                socket.Send(Encoding.UTF8.GetBytes(ReqStr));
                if (!ParseHeader()) {
                    throwEx(Ex.ConnLost);
                    return;
                }

                //Create streams, etc
                FileStream fs = null;
                MemoryStream ms = null;
                string tmpPath = "";
                if (givestr) ms = new MemoryStream();
                if (path != "") {
                    //Temporary file in case something craps itself
                    do tmpPath = "_tmp\\wanr_" + RandomChars(12) + ".tmp";
                    while (File.Exists(tmpPath));
                    fs = new FileStream(tmpPath, FileMode.Create);
                    if (path != "" && dataLen > 0 && alloc) {
                        padStream(fs, dataLen); fs.Flush();
                        fs.Seek(0, SeekOrigin.Begin);
                    }
                }

                //Download file
                byte[] buf = new byte[16384]; int iRange;
                while ((iRange = socket.Receive(buf, 0, 16384, SocketFlags.None)) > 0) {
                    curByte += iRange; state = State.Downloading;
                    if (path != "") fs.Write(buf, 0, iRange);
                    if (givestr) ms.Write(buf, 0, iRange);
                }
                socket.Close();
                if (path != "") {
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }

                //No data? Fuck.
                if (curByte == 0) {
                    System.IO.File.Delete(tmpPath);
                    if (ms != null) ms.Dispose();
                    throwEx(Ex.BlankFile); return;
                }

                //Return string?
                if (givestr) {
                    ret = Encoding.UTF8.
                        GetString(ms.GetBuffer());
                    ms.Close(); ms.Dispose();
                }

                if (path != "")
                    System.IO.File.Move(tmpPath, path);
                state = State.Completed; done = true;
            }
            catch {
                throwEx(Ex.IOError);
            }
        }
        private bool ParseHeader() {
            try {
                byte[] bytes = new byte[1]; string Header = "";
                while (socket.Receive(bytes, 0, 1, SocketFlags.None) > 0) {
                    Header += Encoding.UTF8.GetString(bytes, 0, 1);
                    if (bytes[0] == '\n' && Header.EndsWith("\r\n\r\n"))
                        break;
                }
                string[] aHeader = Header.Replace("\r", "").Split('\n');
                for (int a = 0; a < aHeader.Length; a++) {
                    string[] data = new string[2];
                    int ofs = aHeader[a].IndexOf(": ");
                    if (ofs > 0) {
                        data[0] = aHeader[a].Substring(0, ofs);
                        data[1] = aHeader[a].Substring(ofs + 2);
                        if (data[0] == "Content-Length")
                            dataLen = Convert.ToInt32(data[1]);
                    }
                    else {
                        if (aHeader[a].ToLower().Contains(" 404 not found")) {
                            throwEx(Ex.NotFound); return false;
                        }
                    }
                }
                return true;
            }
            catch {
                //wrExThrow("Header parse error");
                return false;
            }
        }

        void padStream(Stream sm, int bytes) {
            byte[][] pad = new byte[][]{
                new byte[262144],
                new byte[4096],
                new byte[64],
                new byte[1]};
            for (int a = 0; a < pad.Length; a++)
                while (bytes >= pad[a].Length) {
                    sm.Write(pad[a], 0, pad[a].Length);
                    bytes -= pad[a].Length;
                }
        }
        string RandomChars(int Count) {
            string ret = "";
            for (int a = 0; a < Count; a++) {
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
        void throwEx(Ex ex) {
            if (this.ex == Ex.None) {
                this.ex = ex;
                state = State.Failed;
                done = true;
            }
        }
    }
    public class Grabberd {
        public Uri uri;
        public bool alloc;
        public string path;
        public bool givestr;
        Random rnd = new Random();
        WebProxy proxy;

        public int srvRsp = 0;
        public int curByte = 0;
        public int dataLen = 0;

        public bool done;
        public string ret;
        public State state;
        public Ex ex = Ex.None;
        public enum State { Connecting, Requesting, Downloading, Completed, Failed };
        public enum Ex { None, IOError, Rejected, ConnLost, NotFound, BlankFile, CutFile };

        public Grabberd(string suri) : this(suri, "", null, false, true) { }
        public Grabberd(string suri, string path, WebProxy proxy, bool alloc, bool givestr) {
            this.uri = new Uri(suri); this.path = path;
            this.alloc = alloc; this.givestr = givestr;
            this.proxy = proxy; ex = Ex.None;
            state = State.Connecting; done = false;
            try { if (File.Exists(path)) File.Delete(path); }
            catch { throwEx(Ex.IOError); return; }
            System.Threading.Thread th = new System.Threading.Thread(
                new ThreadStart(doit)); th.Start();
        }
        void doit() {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.ReadWriteTimeout = 30000;
            req.Timeout = 30000;
            if (proxy != null) {
                //I can has proxy
                req.Proxy = proxy;
            }
            HttpWebResponse rsp = null;
            try { rsp = (HttpWebResponse)req.GetResponse(); }
            catch (WebException ex) {
                if (ex.Status == WebExceptionStatus.ProtocolError &&
                    ((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound) {
                    throwEx(Ex.NotFound); return;
                }
                throwEx(Ex.Rejected); return;
            }
            dataLen = Convert.ToInt32(rsp.Headers["Content-Length"]);
            state = State.Downloading;

            FileStream fs = null;
            MemoryStream ms = null;
            string tmpPath = "";
            if (givestr) ms = new MemoryStream();
            if (path != "") {
                //Temporary file in case something craps itself
                do tmpPath = "_tmp\\wanr_" + RandomChars(12) + ".tmp";
                while (File.Exists(tmpPath));
                fs = new FileStream(tmpPath, FileMode.Create);
                if (path != "" && dataLen > 0 && alloc) {
                    padStream(fs, dataLen); fs.Flush();
                    fs.Seek(0, SeekOrigin.Begin);
                }
            }

            int iRange = 0;
            byte[] buf = new byte[16384];
            Stream sm = rsp.GetResponseStream();
            while ((iRange = sm.Read(buf, 0, buf.Length)) > 0) {
                curByte += iRange; //Read from stream
                if (path != "") fs.Write(buf, 0, iRange);
                if (givestr) ms.Write(buf, 0, iRange);
            }
            if (curByte == 0) {
                //Oh god fucking damnit.
                if (ms != null) ms.Dispose();
                if (fs != null) { fs.Dispose(); File.Delete(tmpPath); }
                throwEx(Ex.BlankFile); return;
            }

            if (path != "") {
                //Save file to disk
                fs.Flush(); fs.Close(); fs.Dispose();
            }
            if (givestr) {
                //Return response string
                byte[] byt = ms.ToArray();
                ret = Encoding.UTF8.GetString(byt);
                ms.Close(); ms.Dispose();
            }
            if (curByte == dataLen || dataLen == 0) {
                //Everything is FABULOUS
                state = State.Completed; done = true;
                if (path != "") File.Move(tmpPath, path);
            }
            else { //Fuck
                state = State.Failed; done = true;
                if (path != "") File.Delete(tmpPath);
                throwEx(Ex.CutFile);
            }
        }
        void padStream(Stream sm, int bytes) {
            byte[][] pad = new byte[][]{
                new byte[262144],
                new byte[4096],
                new byte[64],
                new byte[1]};
            for (int a = 0; a < pad.Length; a++)
                while (bytes >= pad[a].Length) {
                    sm.Write(pad[a], 0, pad[a].Length);
                    bytes -= pad[a].Length;
                }
        }
        string RandomChars(int Count) {
            string ret = "";
            for (int a = 0; a < Count; a++) {
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
        void throwEx(Ex ex) {
            this.ex = ex;
            state = State.Failed;
            done = true;
        }
    }
}
