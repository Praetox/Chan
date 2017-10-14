using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

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
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        #region API shit
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        #endregion
        #region Global defines
        //I know this is sad. Don't bother commenting.
        public static ChanInf[] Chans = new ChanInf[0];
        public static Grabber[] Clients = new Grabber[0];
        public static ThreadInf[] tiThreads = new ThreadInf[0];
        public static long lLastIteration = DateTime.Now.Ticks / 10000000;
        public static string sDeadThreads = "";
        public static string dQueURLs = "", dQuePaths = "", dQueNames = "";
        public static bool bIntDownload = false;
        public static bool bIntHotkeys = false;
        public static bool bIntThrState = false;
        public static bool bIntRetry = false;
        public static bool bIsParsing = false;
        public static bool bIsDownloading = false;
        public static string PrgDomain = "http://tox.awardspace.us/div/";
        public static string ToxDomain = "http://www.praetox.com/";
        public static Random rnd = new Random();
        public static bool bChgSkin = false;

        public static string[] ClientLastFUrl = new string[0];
        public static string[] ClientLastPath = new string[0];
        public static string[] ClientLastName = new string[0];
        public static int[] ClientRetries = new int[0];

        public static long lThreadsChecked = 0;
        public static long lFilesLeft = 0;
        public static long lFilesDownloading = 0;
        public static long lFilesRetried = 0;
        public static long lFilesSkipped = 0;
        public static double dSpeed = 0;
        public static string[] saTips = new string[0];
        public static int iTip = -1;
        #endregion

        private void GUI() {
            lbThreads.Text = lThreadsChecked + " / " + tiThreads.Length;
            lbDownloading.Text = lFilesDownloading + " / " + Clients.Length;
            lbRemaining.Text = "" + (lFilesLeft + lFilesDownloading);
            lbRetry.Text = lFilesRetried + "";
            lbSkip.Text = lFilesSkipped + "";
            Application.DoEvents();
        }
        private void GUI(string vl) {
            lbStatus.Text = vl; GUI();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            Panel pnlLoading = new Panel();
            Label lblLoading = new Label();
            this.Controls.Add(pnlLoading);
            pnlLoading.Dock = DockStyle.Fill;
            pnlLoading.BringToFront();
            pnlLoading.Visible = true;
            pnlLoading.Controls.Add(lblLoading);
            lblLoading.Dock = DockStyle.Fill;
            lblLoading.ForeColor = Color.White;
            lblLoading.Font = new Font("Arial", 22);
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            lblLoading.Text = "Loading";
            lblLoading.Visible = true;

            if (System.Diagnostics.Process.GetProcessesByName(
                System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1) {
                MessageBox.Show("Chanmongler is already running, you know." + "\r\n" +
                    "What you just did is madness. You should feel bad.",
                    "OH GOD, WHY WOULD YOU DO THAT?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                fnKillApp();
            }

            z.Init(); this.Text += z.sAppVer;
            this.Show(); Application.DoEvents();

            lblLoading.Text = "Creating temp directory"; Application.DoEvents();
            if (!System.IO.Directory.Exists(z.sAppPath + "_tmp"))
                System.IO.Directory.CreateDirectory(z.sAppPath + "_tmp");

            lblLoading.Text = "Looking for chanfiles"; Application.DoEvents();
            if (!System.IO.Directory.Exists(Application.StartupPath + "/_cfg")) {
                MessageBox.Show(
                    "Could not access configuration files." + "\r\n" +
                    "\r\n" +
                    "This is most likely because Chanmongler was started directly from an archive." + "\r\n" +
                    "If this is the case, extract Chanmongler somewhere and try again.",
                    "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                fnKillApp();
            }

            lblLoading.Text = "Loading chanfiles"; Application.DoEvents();
            while (!LoadChanFiles()) Application.DoEvents();

            lblLoading.Text = "Creating tray icon"; Application.DoEvents();
            nIco.Icon = this.Icon;
            nIco.Text = "Chanmongler";
            nIco.Visible = true;
            MenuItem[] mnuList = new MenuItem[5];
            mnuList[0] = new MenuItem("Add thread", mnuAddThread);
            mnuList[1] = new MenuItem("Download all", mnuDownloadAll);
            mnuList[2] = new MenuItem("Search...", mnuSearch);
            //mnuList[4] = new MenuItem("", mnuEaster);
            //mnuList[5] = new MenuItem("4chan.org/b/", mnu4chanB);
            mnuList[3] = new MenuItem("Praetox.com", mnuPraetoxCom);
            mnuList[4] = new MenuItem("Exit", mnuExit);
            nIco.ContextMenu = new ContextMenu(mnuList);

            lblLoading.Text = "Loading settings"; Application.DoEvents();
            z.cfg = new Config(); z.cfg.Load();

            lblLoading.Text = "Preparing resources"; Application.DoEvents();
            Clients = new Grabber[z.cfg.iPerf_Threads];
            ClientRetries = new int[Clients.Length];
            ClientLastFUrl = new string[Clients.Length];
            ClientLastPath = new string[Clients.Length];
            ClientLastName = new string[Clients.Length];
            for (int a = 0; a <= Clients.GetUpperBound(0); a++) {
                ClientRetries[a] = 0;
                ClientLastFUrl[a] = "";
                ClientLastPath[a] = "";
                ClientLastName[a] = "";
            }
            lblLoading.Dispose(); pnlLoading.Dispose();
            tThreadState.Start(); tDownload.Start();

            if (!System.IO.File.Exists("settings.ini")) {
                this.Visible = false;
                Form fHelp = new frmHelp();
                fHelp.ShowDialog();
                System.IO.File.WriteAllText("settings.ini", "");
            }
            cmdThreads_Load_Click(new object(), new EventArgs());

            BackgroundWorker bwFormLoad = new BackgroundWorker();
            bwFormLoad.DoWork += new DoWorkEventHandler(bwFormLoad_DoWork);
            bwFormLoad.RunWorkerAsync();

            tRetry.Enabled = true;
            tAutoIterate.Enabled = true;
            tHotkeys.Enabled = true;
        }
        void bwFormLoad_DoWork(object sender, DoWorkEventArgs e) {
            try {
                bool bSiteCheckOK = true;
                string suri = PrgDomain + "Chanmongler_version.php?cv=" + z.sAppVer;
                Grabber WR = new Grabber(suri);
                long lGetStart = z.Tick();
                while (!WR.done && bSiteCheckOK) {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(100);
                    if (z.Tick() > lGetStart + 10000) bSiteCheckOK = false;
                }
                string wrh = WR.ret;
                if (!bSiteCheckOK) throw new Exception("wat");
                if (WR.ex != Grabber.Ex.None) throw new Exception("wat");

                if (!wrh.Contains("<VERSION>" + z.sAppVer + "</VERSION>")) {
                    string sNewVer = z.Split(z.Split(wrh, "<VERSION>")[1], "</VERSION>")[0];
                    bool GetUpdate = (DialogResult.Yes == MessageBox.Show(
                        "A new version (" + sNewVer + ") is available. Update?",
                        "Updater", MessageBoxButtons.YesNo));
                    if (GetUpdate) {
                        string UpdateLink = new System.Net.WebClient().DownloadString(
                            ToxDomain + "inf/Chanmongler_link.html").Split('%')[1];
                        System.Diagnostics.Process.Start(UpdateLink + z.sAppVer);
                        Application.Exit();
                    }
                }
                if (wrh.Contains("</tip>")) {
                    wrh = wrh.Substring(wrh.IndexOf("<tip>") + "<tip>".Length);
                    saTips = z.Split(wrh, "<tip>");
                    for (int a = 0; a < saTips.Length; a++) {
                        saTips[a] = z.Split(saTips[a], "</tip>")[0];
                    }
                    iTip = rnd.Next(0, saTips.Length);
                }
            }
            catch {
                saTips = new string[] { "Fuck fuck fuck oh shit fuck. 404 while trying to load tips." };
                MessageBox.Show("Couldn't check for updates.", "Oh snap");
            }
        }
        public Bitmap ResizeBitmap(Bitmap bPic, int iX, int iY, bool bKeepAspect, int iScaleMode, bool bEnlargen) {
            if (!bEnlargen) {
                //No reason to enlargen images.
                //Besides, enlargening is VERY slow.
                if (iX > bPic.Width) iX = bPic.Width;
                if (iY > bPic.Height) iY = bPic.Height;
            }
            if (iX < 1) iX = 1; if (iY < 1) iY = 1;
            if (bKeepAspect) {
                double dRaX = (double)bPic.Width / (double)iX;
                double dRaY = (double)bPic.Height / (double)iY;
                if (dRaX > dRaY) iY = (int)Math.Round((double)iX /
                    ((double)bPic.Width / (double)bPic.Height));
                if (dRaY > dRaX) iX = (int)Math.Round((double)iY *
                    ((double)bPic.Width / (double)bPic.Height));
            }
            Bitmap bOut = new Bitmap(iX, iY);
            using (Graphics gOut = Graphics.FromImage((Image)bOut)) {
                gOut.SmoothingMode = SmoothingMode.AntiAlias;
                if (iScaleMode == 2) gOut.InterpolationMode = InterpolationMode.High;
                if (iScaleMode == 3) gOut.InterpolationMode = InterpolationMode.NearestNeighbor;
                gOut.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gOut.DrawImage(bPic, 0, 0, iX, iY);
            }
            return bOut;
        }
        public Bitmap imLoad(string sPath) {
            //Opens an image without locking the file
            using (System.IO.FileStream fs = new System.IO.FileStream(
                sPath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                return new Bitmap(fs);
        }
        /*public static int[] SortAlphabetically(string[] vl) {
            int[] ret = new int[vl.Length];
            for (int a = 0; a < ret.Length; a++) {
                ret[a] = a;
            }
            for (int a = vl.Length - 1; a >= 0; a--)
                for (int b = 0; b < a; b++)
                    if (string.Compare(vl[b], vl[b + 1], true) > 0) {
                        int iTmp = ret[b];
                        ret[b] = ret[b + 1];
                        ret[b + 1] = iTmp;
                        string sTmp = vl[b];
                        vl[b] = vl[b + 1];
                        vl[b + 1] = sTmp;
                    }
            return ret;
        }*/
        public static string Timestamp(long iTick) {
            if (iTick < 0) iTick = DateTime.Now.Ticks;
            DateTime dt = new DateTime(iTick);
            return
                dt.Year.ToString("D4").Substring(2) + "." +
                dt.Month.ToString("D2") + "." +
                dt.Day.ToString("D2") + " - " +
                dt.Hour.ToString("D2") + ":" +
                dt.Minute.ToString("D2") + ":" +
                dt.Second.ToString("D2");
        }
        public static string wrSrc(string sURL) {
            try {
                Grabber WR = new Grabber(sURL);
                long lScrapeStart = z.Tick();
                while (!WR.done) {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                    if (z.Tick() > lScrapeStart + 10000)
                        return "null";
                }
                if (WR.ex != Grabber.Ex.None)
                    return "null";
                return WR.ret;
            }
            catch {
                return "null";
            }
        }
        public string MD5File(string sFile) {
            System.IO.FileStream fs = new System.IO.FileStream(
                sFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] bFile = new byte[fs.Length];
            fs.Read(bFile, 0, (int)fs.Length);
            fs.Close(); fs.Dispose();
            return MD5(bFile);
        }
        public string MD5(byte[] bData) {
            System.Security.Cryptography.MD5CryptoServiceProvider crypt =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bRet = crypt.ComputeHash(bData);
            string ret = "";
            for (int a = 0; a < bRet.Length; a++) {
                //string wat = bRet[a].ToString("x2");
                //while (wat.Length < 2) wat = "0" + wat;
                ret += bRet[a].ToString("x2"); //wat;
            }
            crypt.Clear(); return ret;
        }

        private void mnuAddThread(object sender, EventArgs e) {
            fnAddThreadGUI();
        }
        private void mnuDownloadAll(object sender, EventArgs e) {
            IterateAllGUI();
        }
        private void mnuSearch(object sender, EventArgs e) {
            new frmSearch().Show();
        }
        private void mnuEaster(object sender, EventArgs e) {
            //easter egg
        }
        private void mnu4chanB(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://img.4chan.org/b/");
        }
        private void mnuPraetoxCom(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(ToxDomain);
        }
        private void mnuExit(object sender, EventArgs e) {
            fnKillApp();
        }

        private void cmdThreads_Add_Click(object sender, EventArgs e) {
            fnAddThreadGUI();
        }
        private void lbThreads_KeyDown(object sender, KeyEventArgs e) {
            if (lstThreads.SelectedIndex < 0) return;
            if (e.KeyCode == Keys.Delete) {
                fnRemThread(lstThreads.SelectedItem.ToString(), true);
                GUI("Removed single thread");
            }
            if (e.KeyCode == Keys.Enter) {
                cmsThreads_ViewImages_Click(sender, e);
            }
            if (e.KeyCode == Keys.Apps) {
                cmsThreads.Show(Cursor.Position);
            }
        }
        private void cmdThreads_Save_Click(object sender, EventArgs e) {
            string sThreads = "";
            for (int a = 0; a < tiThreads.Length; a++) {
                sThreads +=
                    tiThreads[a].sURL + "\t" +
                    tiThreads[a].sSub + "\t" +
                    tiThreads[a].thrAdded + "\t" +
                    tiThreads[a].lastCheck + "\t" +
                    tiThreads[a].lastDL + "\t" +
                    tiThreads[a].lImages + "\r\n";
            }
            System.IO.File.WriteAllText("threads.dat", sThreads, Encoding.UTF8);
            fnRefreshGUIList(); GUI("Threads saved");
        }
        private void cmdThreads_Load_Click(object sender, EventArgs e) {
            if (!System.IO.File.Exists("threads.dat")) return;
            string sThreads = System.IO.File.ReadAllText
                ("threads.dat", Encoding.UTF8);
            sThreads = sThreads.Replace("\r", "");
            sThreads = sThreads.Trim('\n');
            if (sThreads != "") {
                string[] saThreads = sThreads.Split('\n');
                saThreads = sThreads.Split('\n');
                tiThreads = new ThreadInf[saThreads.Length];
                for (int a = 0; a < saThreads.Length; a++) {
                    tiThreads[a] = new ThreadInf();
                    string[] saThread = saThreads[a].Split('\t');
                    for (int b = 0; b < saThread.Length; b++) {
                        saThread[b] = saThread[b].Trim('\t');
                    }
                    try {
                        tiThreads[a].sURL = saThread[0];
                        tiThreads[a].sSub = saThread[1];
                        tiThreads[a].thrAdded = Convert.ToInt64(saThread[2]);
                        tiThreads[a].lastCheck = Convert.ToInt64(saThread[3]);
                        tiThreads[a].lastDL = Convert.ToInt64(saThread[4]);
                        tiThreads[a].lImages = Convert.ToInt32(saThread[5]);
                    }
                    catch {
                        try {
                            tiThreads[a].sURL = saThread[0];
                            tiThreads[a].sSub = "\\";
                            tiThreads[a].thrAdded = Convert.ToInt64(saThread[1]);
                            tiThreads[a].lastCheck = Convert.ToInt64(saThread[2]);
                            tiThreads[a].lastDL = Convert.ToInt64(saThread[3]);
                            tiThreads[a].lImages = Convert.ToInt32(saThread[4]);
                        }
                        catch { }
                    }
                }
            }
            else {
                tiThreads = new ThreadInf[0];
            }
            fnRefreshGUIList(); GUI("Threads loaded");
        }

        private void cmdIterate_Click(object sender, EventArgs e) {
            IterateAllGUI();
        }
        private void cLoadChanFiles_Click(object sender, EventArgs e) {
            if (LoadChanFiles()) {
                GUI("Reloaded configuration files");
            }
            else {
                GUI("Chanmongler is busy...");
            }
        }
        private void cHelp_Click(object sender, EventArgs e) {
            new frmHelp().Show();
        }
        private void cSearch_Click(object sender, EventArgs e) {
            new frmSearch().Show();
        }
        private void cContact_Click(object sender, EventArgs e) {
            new frmContact().Show();
        }
        private void cNews_Click(object sender, EventArgs e) {
            new frmNews().Show();
        }
        private void cSettings_Click(object sender, EventArgs e) {
            new frmConfig(z.cfg).ShowDialog();
        }

        private void fnKillApp() {
            nIco.Visible = false; nIco.Dispose(); Application.DoEvents();
            Program.Kill();
        }
        private bool fnAddThreadGUI() {
            string ThreadURL = InputBox.Show(
                "Enter the thread URL, then hit enter." + "\r\n" +
                "\r\n" +
                "PROTIP: Hotkeys are way more efficient than using GUI." + "\r\n" +
                "Press the Help-button if you would like to know more.",
                "Adding a new thread", Clipboard.GetText());
            if (ThreadURL == "") return false;
            if (!fnAddThread(ThreadURL)) {
                if (z.cfg.bTrayMessages)
                    nIco.ShowBalloonTip(2000, "Error",
                        "Thread was already added.",
                        ToolTipIcon.Warning);
                GUI("Thread exists");
                return false;
            }
            GUI("Thread added");
            return true;
        }
        private bool fnAddThread(string ThreadURL) {
            ThreadURL = ThreadURL.Split('#')[0];
            if (ThreadURL == "") return false;
            for (int a = 0; a < tiThreads.Length; a++)
                if (tiThreads[a].sURL == ThreadURL)
                    return false;

            ThreadInf[] tiTmp = tiThreads;
            ThreadInf tiAdd = new ThreadInf();
            tiAdd.sURL = ThreadURL;
            tiAdd.thrAdded = DateTime.Now.Ticks / 10000000;
            tiAdd.lastCheck = tiAdd.thrAdded;
            tiAdd.lastDL = tiAdd.thrAdded;
            tiAdd.lImages = 1;

            tiThreads = new ThreadInf[tiTmp.Length + 1];
            tiTmp.CopyTo(tiThreads, 0);
            tiThreads[tiThreads.Length - 1] = tiAdd;
            fnRefreshGUIList();

            string sPath = GetPathByURL(ThreadURL).sPath;
            if (sPath == "") {
                MessageBox.Show("Unknown chan!");
                fnRemThread(ThreadURL, true);
                return false;
            }
            
            if (z.cfg.bTagOnAdd) {
                //Code's already fubar, so I won't bother making
                //the new additions decent either. I just want
                //to get this project out of the way. GAH.
                string sTags = "";
                frmTags ft = new frmTags(ThreadURL);
                ft.ShowDialog();
                if (ft.ssub != "") {
                    lstThreads.SelectedIndex =
                        lstThreads.Items.Count - 1;
                    ThInf_Folder.Text = ft.ssub;
                    ThInf_Folder_TextChanged(
                        new object(), new EventArgs());
                }
                if (ft.sgen != "") sTags += "gen: " + ft.sgen + "\r\n";
                if (ft.ssrc != "") sTags += "src: " + ft.ssrc + "\r\n";
                if (ft.schr != "") sTags += "chr: " + ft.schr + "\r\n";
                if (ft.sart != "") sTags += "art: " + ft.sart + "\r\n";
                System.IO.Directory.CreateDirectory(sPath);
                if (sTags != "" && !z.cfg.bTagsToPath) {
                    System.IO.File.WriteAllText(sPath +
                        "\\tags.txt", sTags, Encoding.UTF8);
                }
            }
            return true;
        }
        private void fnRemThread(string ThreadURL, bool bReGUI) {
            ThreadURL = ThreadURL.Split('#')[0];
            if (ThreadURL == "") return;

            int iOmit = -1;
            for (int a = 0; a < tiThreads.Length; a++) {
                if (tiThreads[a].sURL == ThreadURL) iOmit = a;
            }
            if (iOmit == -1) return;

            ThreadInf[] tiTmp = tiThreads;
            tiThreads = new ThreadInf[tiThreads.Length - 1];
            for (int a = 0; a < tiTmp.Length; a++) {
                if (a < iOmit) tiThreads[a] = tiTmp[a];
                if (a > iOmit) tiThreads[a - 1] = tiTmp[a];
            }
            if (bReGUI) fnRefreshGUIList();
        }
        private bool fnRemDead(bool bIgnoreParsing) {
            if (sDeadThreads == "") return true;
            if (bIsParsing && !bIgnoreParsing)
                return false; bIsParsing = true;

            string[] sThreads = sDeadThreads.Trim('\n').Split('\n');
            for (int a = 0; a < sThreads.Length; a++) {
                if (z.cfg.bMoveDead)
                    fnMoveToDead(sThreads[a]);
                fnRemThread(sThreads[a], false);
            }
            sDeadThreads = ""; fnRefreshGUIList();
            bIsParsing = false; return true;
        }
        private void fnMoveToDead(string sThPath) {
            try {
                string sPath = GetPathByURL(sThPath).sPath;
                if (sPath.StartsWith(z.cfg.sPath)) {
                    string sRelP = sPath.Substring(z.cfg.sPath.Length);
                    string sNewP = z.cfg.sPath + "_dead\\" + sRelP;
                    string sNewD = sNewP.Substring(0, sNewP.LastIndexOf("\\"));
                    System.IO.Directory.CreateDirectory(sNewD);
                    sPath = sPath.Substring(0, sPath.Length - 1);
                    string[] sFiles = System.IO.Directory.GetFiles(sPath);
                    for (int a = 0; a < sFiles.Length; a++) {
                        string sFileN = sFiles[a].Replace("\\", "/");
                        sFileN = sFileN.Substring(sFileN.LastIndexOf("/") + 1);
                        string sNewF = sNewP + sFileN;
                        try {
                            if (System.IO.File.Exists(sNewF))
                                System.IO.File.Delete(sNewF);
                            System.IO.File.Move(sFiles[a], sNewF);
                        }
                        catch {
                            try {
                                System.IO.File.Copy(sFiles[a], sNewF, true);
                                System.IO.File.Delete(sFiles[a]);
                            }
                            catch { }
                        }
                    }
                    try {
                        System.IO.Directory.Delete(sPath, true);
                    }
                    catch { }
                }
            }
            catch { }
        }
        private void fnRefreshGUIList() {
            int OldSel = lstThreads.SelectedIndex;
            lstThreads.Items.Clear();
            if (tiThreads.Length == 0) return;
            for (int a = 0; a < tiThreads.Length; a++) {
                lstThreads.Items.Add(tiThreads[a].sURL);
            }

            Application.DoEvents();
            if (OldSel >= lstThreads.Items.Count)
                OldSel = lstThreads.Items.Count - 1;
            if (OldSel >= 0)
                lstThreads.SelectedIndex = OldSel;
        }

        private bool LoadChanFiles() {
            if (bIsParsing) return false;
            string[] ChanFileList = System.IO.Directory.GetFiles("_cfg/", "*.chan");
            Chans = new ChanInf[ChanFileList.Length];
            for (int a = 0; a < Chans.Length; a++) {
                Chans[a] = new ChanInf();
                string sChan = System.IO.File.ReadAllText(
                    ChanFileList[a], Encoding.UTF8).Replace("\r", "");
                sChan = sChan.TrimEnd('\n');
                while (sChan.Contains("\t\t"))
                    sChan = sChan.Replace("\t\t", "\t");
                string sChanInf = sChan.Split('\n')[1];
                for (int b = 0; b < 4; b++)
                    sChan = sChan.Substring(sChan.IndexOf("\n") + 1);

                string[] saChanInf = sChanInf.Split('\t');
                Chans[a].p01_sIO_Prefix = saChanInf[0];
                Chans[a].p02_sName = saChanInf[1];
                Chans[a].p03_Version = saChanInf[2];
                Chans[a].p04_CMVersion = saChanInf[3];
                Chans[a].p05_Filename = ChanFileList[a].Replace("\\", "/").Split('/')[1];

                string[] saBoards = sChan.Split('\n');
                Chans[a].bBoards = new BoardInf[saBoards.Length];
                for (int b = 0; b < Chans[a].bBoards.Length; b++) {
                    int iCol = -1;
                    Chans[a].bBoards[b] = new BoardInf();
                    string[] saBoard = saBoards[b].Split('\t');
                    try {
                        iCol = 01; Chans[a].bBoards[b].a01_sName = saBoard[0];
                        iCol = 02; Chans[a].bBoards[b].a02_sDesc = saBoard[1];
                        iCol = 03; Chans[a].bBoards[b].a03_sIO_Prefix = saBoard[2];
                        iCol = 04; Chans[a].bBoards[b].b01_sURL_Index = saBoard[3];
                        iCol = 05; Chans[a].bBoards[b].b02_sURL_IndexP_1 = saBoard[4];
                        iCol = 06; Chans[a].bBoards[b].b03_sURL_IndexP_2 = saBoard[5];
                        iCol = 07; Chans[a].bBoards[b].b04_sURL_IndexP_C = Convert.ToInt32(saBoard[6]);
                        iCol = 08; Chans[a].bBoards[b].b05_sURL_Thread = saBoard[7];
                        iCol = 09; Chans[a].bBoards[b].b06_sURL_Image = saBoard[8];
                        iCol = 10; Chans[a].bBoards[b].c01_sS_Threads_1 = saBoard[9];
                        iCol = 11; Chans[a].bBoards[b].c02_sS_Threads_2 = saBoard[10];
                        iCol = 12; Chans[a].bBoards[b].c03_sS_Threads = saBoard[11];
                        iCol = 13; Chans[a].bBoards[b].c04_sS_ThreadURL_1 = saBoard[12];
                        iCol = 14; Chans[a].bBoards[b].c05_sS_ThreadURL_2 = saBoard[13];
                        iCol = 15; Chans[a].bBoards[b].d01_sS_Images_1 = saBoard[14];
                        iCol = 16; Chans[a].bBoards[b].d02_sS_Images_2 = saBoard[15];
                        iCol = 17; Chans[a].bBoards[b].d03_sS_Images = saBoard[16];
                        iCol = 18; Chans[a].bBoards[b].d04_sS_ImageURL_1 = saBoard[17];
                        iCol = 19; Chans[a].bBoards[b].d05_sS_ImageURL_2 = saBoard[18];
                        iCol = 20; Chans[a].bBoards[b].d06_sS_ThumbURL_1 = saBoard[19];
                        iCol = 21; Chans[a].bBoards[b].d07_sS_ThumbURL_2 = saBoard[20];
                        iCol = 22; Chans[a].bBoards[b].e01_sI_Thread_1 = saBoard[21];
                        iCol = 23; Chans[a].bBoards[b].e02_sI_Thread_2 = saBoard[22];
                    }
                    catch {
                        DialogResult dRes = new DialogResult();
                        if (Clients.Length == 0) {
                            dRes = MessageBox.Show(
                                "There's an error in one of your .chan-files." + "\r\n" +
                                "Chanmongler can not ignore this error." + "\r\n\r\n" +
                                "      File:   " + Chans[a].p05_Filename + "\r\n" +
                                "Column:   " + iCol + "\r\n\r\n" +
                                "Do you wish to try again?" + "\r\n" +
                                " YES: I've fixed it!" + "\r\n" +
                                "  NO: Fuck this shit.", "Oh snap",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Exclamation);
                            if (dRes == DialogResult.No) fnKillApp();
                            return false;
                        }
                        else {
                            dRes = MessageBox.Show(
                                "There's an error in one of your .chan-files." + "\r\n" +
                                "Chanmongler can not ignore this error." + "\r\n\r\n" +
                                "      File:   " + Chans[a].p05_Filename + "\r\n" +
                                "Column:   " + iCol + "\r\n\r\n" +
                                "Mongler will not function properly until you rectify" + "\r\n" +
                                "the problems and click \"Reload *.chan\" again.",
                                "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return true;
                        }
                    }
                }
            }
            try {
                for (int b = 0; b < Chans.Length; b++) {
                    if (Chans[b].p04_CMVersion != z.sAppVer)
                        throw new Exception(b + "");
                }
            }
            catch (Exception ex) {
                int i = Convert.ToInt32(ex.Message);
                DialogResult dRes = new DialogResult();
                if (Clients.Length == 0) {
                    dRes = MessageBox.Show(
                        "One or more of your .chan-files (" + Chans[i].p05_Filename + ") are outdated." + "\r\n\r\n" +
                        "Would you like to try again?" + "\r\n" +
                        " YES: I've fixed it!" + "\r\n" +
                        "  NO: Fuck this shit.", "Oh snap",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                    if (dRes == DialogResult.No) fnKillApp();
                    return false;
                }
                else {
                    dRes = MessageBox.Show(
                        "One or more of your .chan-files (" + Chans[i].p05_Filename + ") are outdated." + "\r\n\r\n" +
                        "Mongler will not function properly until you rectify" + "\r\n" +
                        "the problems and click \"Reload *.chan\" again.",
                        "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }
            return true;
        }
        private void IterateAllGUI() {
            if (z.cfg.bTrayMessages)
                nIco.ShowBalloonTip(2000, "Parsing...",
                    "Checking for new files.",
                    ToolTipIcon.Info);
            if (IterateAll()) {
                if (z.cfg.bTrayMessages)
                    nIco.ShowBalloonTip(2000, "Threads checked",
                        "Downloading new files, if any.",
                        ToolTipIcon.Info);
                GUI("Threads checked");
            }
            else {
                if (z.cfg.bTrayMessages)
                    nIco.ShowBalloonTip(2000, "Chanmongler is busy...",
                        "Could not perform action.",
                        ToolTipIcon.Error);
                GUI("Chanmongler is busy...");
            }
        }
        private bool IterateAll() {
            if (bIsParsing) return false; bIsParsing = true;
            lLastIteration = DateTime.Now.Ticks / 10000000;
            GUI("Checking threads");
            lThreadsChecked = 0; GUI();
            DLInf[] tiPics = new DLInf[0];
            for (int a = 0; a < tiThreads.Length; a++) {
                DLInf[] thrPics = GetPictureURLs(tiThreads[a].sURL);
                if (thrPics.Length > 0) {
                    DLInf[] tmpPics = tiPics;
                    tiPics = new DLInf[tiPics.Length + thrPics.Length];
                    tmpPics.CopyTo(tiPics, 0);
                    thrPics.CopyTo(tiPics, tmpPics.Length);
                }
                lThreadsChecked++; GUI();
            }
            if (tiPics.Length > 0) DownloadPictures(tiPics);
            fnRemDead(true);

            if (z.cfg.bAutosave) cmdThreads_Save_Click(new object(), new EventArgs());
            GUI("Threads checked");
            bIsParsing = false;
            return true;
        }
        DLInf GetBoardByURL(string thURL) {
            bool bCBIdentified = false;
            int iChan = 0; int iBoard = 0;
            for (iChan = 0; iChan < Chans.Length; iChan++) {
                for (iBoard = 0; iBoard < Chans[iChan].bBoards.Length; iBoard++) {
                    int iIsCorrect = 0;
                    if (iIsCorrect >= 0)
                        if (Chans[iChan].bBoards[iBoard].e01_sI_Thread_1 != "!null~")
                            if (thURL.StartsWith(Chans[iChan].bBoards[iBoard].e01_sI_Thread_1))
                                iIsCorrect = 1;
                            else iIsCorrect = -1;
                    if (iIsCorrect >= 0)
                        if (Chans[iChan].bBoards[iBoard].e02_sI_Thread_2 != "!null~")
                            if (thURL.EndsWith(Chans[iChan].bBoards[iBoard].e02_sI_Thread_2))
                                iIsCorrect = 1;
                            else iIsCorrect = -1;
                    if (iIsCorrect == 1) bCBIdentified = true;
                    if (bCBIdentified) break;
                }
                if (bCBIdentified) break;
            }
            DLInf diRet = new DLInf();
            diRet.sThURL = thURL;
            if (bCBIdentified) {
                diRet.iBoard = iBoard;
                diRet.iChan = iChan;
            }
            return diRet;
        }
        DLInf GetPathByURL(string thURL) {
            DLInf diRet = GetBoardByURL(thURL);
            int iChan = diRet.iChan;
            int iBoard = diRet.iBoard;
            if (iChan == -1 || iBoard == -1) {
                diRet.iChan = -1;
                diRet.iBoard = -1;
                return diRet;
            }
            ChanInf thChan = Chans[iChan];
            BoardInf thBoard = thChan.bBoards[iBoard];

            string sSubPath = "\\";
            for (int a = 0; a < tiThreads.Length; a++)
                if (tiThreads[a].sURL == thURL)
                    sSubPath = tiThreads[a].sSub;

            diRet.sThID = z.Split(z.Split(thURL,
                thBoard.e01_sI_Thread_1)[1],
                thBoard.e02_sI_Thread_2)[0]
                .Replace("\\", "_").Replace("/", "_").Replace(":", "_")
                .Replace("\"", "_").Replace("*", "_").Replace("?", "_")
                .Replace("<", "_").Replace(">", "_").Replace("|", "_");
            if (z.cfg.bSubfolder_Site) diRet.sPath += thChan.p01_sIO_Prefix + "\\";
            if (sSubPath != "\\") diRet.sPath += sSubPath.Trim('\\', '/') + "\\";
            if (z.cfg.bSubfolder_Thread) diRet.sPath += thBoard.a03_sIO_Prefix + "-" + diRet.sThID + "\\";
            if (z.cfg.bPrefix_Board) diRet.sName += thBoard.a03_sIO_Prefix + "-";
            if (z.cfg.bPrefix_Thread) diRet.sName += diRet.sThID + "-";
            diRet.sPath = z.cfg.sPath + diRet.sPath;
            return diRet;
        }
        DLInf[] GetPictureURLs(string thURL) {
            try {
                DLInf diTmp = GetPathByURL(thURL);
                int iChan = diTmp.iChan;
                int iBoard = diTmp.iBoard;
                if (iChan == -1 || iBoard == -1) {
                    throw new Exception("#01-0001");
                }
                ChanInf thChan = Chans[iChan];
                BoardInf thBoard = thChan.bBoards[iBoard];
                string thID = diTmp.sThID;
                string sPrPath = diTmp.sPath;
                string sPrName = diTmp.sName;

                string thHTML = "";
                Grabber.Ex lastEx = Grabber.Ex.None;
                for (int a = 0; a < z.cfg.iError_Retry; a++) {
                    GUI("Checking thread - attempt #" + (a + 1));
                    Grabber WR = new Grabber(thURL);
                    while (!WR.done) {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(10);
                    }
                    lastEx = WR.ex;
                    thHTML = WR.ret;
                    if (thHTML != null &&
                        thHTML.Length > 4 && (
                        WR.ex == Grabber.Ex.None ||
                        WR.ex == Grabber.Ex.CutFile))
                        break;
                    System.Threading.Thread.Sleep(2000);
                }
                string strEx = "";
                if (lastEx == Grabber.Ex.BlankFile) strEx = "#02-0006";
                if (lastEx == Grabber.Ex.ConnLost) strEx = "#02-0003";
                if (lastEx == Grabber.Ex.IOError) strEx = "#02-0001";
                if (lastEx == Grabber.Ex.NotFound) strEx = "#02-0004_404";
                if (lastEx == Grabber.Ex.Rejected) strEx = "#02-0002";
                if (strEx != "") throw new Exception("#01-0002 - " + strEx);
                if (thHTML.Length < 5) throw new Exception("#02-0006");

                if (!System.IO.Directory.Exists(sPrPath))
                    System.IO.Directory.CreateDirectory(sPrPath);
                if (z.cfg.bHtmlSave)
                    System.IO.File.WriteAllText(sPrPath + "_" +
                        thBoard.a03_sIO_Prefix + "-" + thID + ".html",
                        thHTML, Encoding.UTF8);

                string sSTmp = "";
                string sHtFix = "";
                sSTmp = thBoard.d01_sS_Images_1;
                if (sSTmp != "!null~") {
                    int ofs = thHTML.IndexOf(
                        sSTmp) + sSTmp.Length;
                    sHtFix = thHTML.Substring(0, ofs);
                    thHTML = thHTML.Substring(ofs);
                }
                string sHtFix2 = "";
                sSTmp = thBoard.d02_sS_Images_2;
                if (sSTmp != "!null~") {
                    int ofs = thHTML.IndexOf(
                        sSTmp) + sSTmp.Length;
                    sHtFix2 = thHTML.Substring(ofs);
                    thHTML = thHTML.Substring(0, ofs);
                }

                string[] PURLs = z.Split(thHTML, thBoard.d03_sS_Images);
                DLInf[] ret = new DLInf[PURLs.Length - 1];
                for (int a = 0; a < tiThreads.Length; a++) {
                    if (tiThreads[a].sURL == thURL) {
                        tiThreads[a].lastCheck = DateTime.Now.Ticks / 10000000;
                        tiThreads[a].lImages = PURLs.Length - 1;
                    }
                }

                for (int a = 0; a < ret.Length; a++) {
                    string thImgUrl = PURLs[a + 1];
                    sSTmp = thBoard.d04_sS_ImageURL_1;
                    if (sSTmp != "!null~") thImgUrl = thImgUrl.Substring(thImgUrl.IndexOf(sSTmp) + sSTmp.Length);
                    sSTmp = thBoard.d05_sS_ImageURL_2;
                    if (sSTmp != "!null~") thImgUrl = thImgUrl.Substring(0, thImgUrl.IndexOf(sSTmp));
                    sSTmp = thBoard.b06_sURL_Image;
                    if (sSTmp != "!null~") thImgUrl = sSTmp + thImgUrl;

                    ret[a] = new DLInf();
                    ret[a].sURL = thImgUrl;
                    ret[a].sThURL = thURL;
                    ret[a].iChan = iChan;
                    ret[a].iBoard = iBoard;
                    ret[a].sThID = thID;
                    ret[a].sName = sPrName +
                        thImgUrl.Substring(thImgUrl.LastIndexOf("/") + 1)
                        .Replace("\\", "_").Replace("/", "_").Replace(":", "_")
                        .Replace("\"", "_").Replace("*", "_").Replace("?", "_")
                        .Replace("<", "_").Replace(">", "_").Replace("|", "_");
                    ret[a].sPath = sPrPath;
                }
                if (z.cfg.bHtmlLocal) {
                    string[] images = z.Split(thHTML, thBoard.d03_sS_Images);
                    sHtFix += images[0];
                    for (int a = 1; a < images.Length; a++) {
                        sSTmp = thBoard.d06_sS_ThumbURL_1;
                        if (sSTmp != "!null~") {
                            int ofs = images[a].IndexOf(
                                sSTmp) + sSTmp.Length;
                            sHtFix += images[a].Substring(0, ofs);
                            images[a] = images[a].Substring(ofs);
                        }
                        sHtFix += ret[a - 1].sName;
                        sSTmp = thBoard.d07_sS_ThumbURL_2;
                        if (sSTmp != "!null~") {
                            int ofs = images[a].IndexOf(sSTmp);
                            sHtFix += images[a].Substring(ofs);
                        }
                    }
                    sHtFix += sHtFix2;
                    System.IO.File.WriteAllText(sPrPath + "_" +
                       thBoard.a03_sIO_Prefix + "-" + thID +
                       "th.html", sHtFix, Encoding.UTF8);
                }
                return ret;
            }
            catch (Exception ex) {
                string expl = "There is no known information about this error.";

                if (ex.Message.Contains("#01-0001"))
                    expl = "Unknown link. Missing config file?";
                if (ex.Message.Contains("#01-0002"))
                    expl = "Unknown internal error while connecting to chan.";
                if (ex.Message.Contains("#02-0001"))
                    expl = "Target file is in use.";
                if (ex.Message.Contains("#02-0002"))
                    expl = "Chan actively refuses connection.";
                if (ex.Message.Contains("#02-0003"))
                    expl = "Got no sensible reply from the server.";
                if (ex.Message.Contains("#02-0004"))
                    expl = "HTML " + z.Split(ex.Message, "#02-0004_")[1] + ": Unknown error.";
                if (ex.Message.Contains("#02-0004_404")) {
                    expl = "HTML 404: The thread has died.";
                    sDeadThreads += thURL + "\n";
                }
                if (ex.Message.Contains("#02-0005"))
                    expl = "The connection timed out.";
                if (ex.Message.Contains("#02-0006"))
                    expl = "Server sent a blank reply.";

                if (z.cfg.bTrayMessages)
                    nIco.ShowBalloonTip(2000, "Error",
                        expl + "\r\n\r\n" +
                        "Thread: " + thURL + "\r\n" +
                        "Error code: " + ex.Message,
                        ToolTipIcon.Error);
                return new DLInf[0];
            }
        }
        void DownloadPictures(DLInf[] PURLs) {
            for (int a = 0; a < PURLs.Length; a++) {
                PURLs[a].sPath = z.StripAllOf(PURLs[a].sPath, "/*?\"<>|", "_");
                PURLs[a].sName = z.StripAllOf(PURLs[a].sName, "\\/:*?\"<>|", "_");
                if (!dQueURLs.Contains(PURLs[a].sURL)) {
                    if (!System.IO.File.Exists(PURLs[a].sPath + PURLs[a].sName)) {
                        dQueURLs += PURLs[a].sURL + "\n";
                        dQuePaths += PURLs[a].sPath + "\n";
                        dQueNames += PURLs[a].sName + "\n";
                        for (int b = 0; b < tiThreads.Length; b++) {
                            if (tiThreads[b].sURL == PURLs[b].sThURL) {
                                tiThreads[b].lastDL = DateTime.Now.Ticks / 10000000;
                            }
                        }
                    }
                }
            }
        }

        private void tHotkeys_Tick(object sender, EventArgs e) {
            if (!z.cfg.bHotkeys) return;
            if (bIntHotkeys) return; bIntHotkeys = true;
            if (GetAsyncKeyState(Keys.LMenu) != 0) {
                if (GetAsyncKeyState(Keys.D1) == -32767) {
                    string sFgWnd = "";
                    IntPtr iFgWnd = GetForegroundWindow();
                    System.Diagnostics.Process[] procs =
                        System.Diagnostics.Process.GetProcesses();
                    for (int a = 0; a < procs.Length; a++) {
                        if (procs[a].MainWindowHandle == iFgWnd) {
                            sFgWnd = procs[a].MainWindowTitle;
                            break;
                        }
                    }

                    while (GetAsyncKeyState(Keys.LMenu) != 0) {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(1);
                    }
                    System.Threading.Thread.Sleep(10);
                    string tmp = Clipboard.GetText();
                    Clipboard.Clear(); Application.DoEvents();

                    bool GotThreadID = false;
                    if (sFgWnd.EndsWith(" - Opera")) // Opera //
                    {
                        SendKeys.SendWait("{f8}"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("^c"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("{esc}"); Application.DoEvents();
                        GotThreadID = true;
                    }
                    if (sFgWnd.EndsWith(" - Mozilla Firefox")) // Firefox //
                    {
                        SendKeys.SendWait("{f6}"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("^c"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("{f6}"); Application.DoEvents();
                        GotThreadID = true;
                    }
                    if (sFgWnd.EndsWith(" - Microsoft Internet Explorer")) // IE6 //
                    {
                        SendKeys.SendWait("{f6}"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("^c"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("{f6}"); Application.DoEvents();
                        GotThreadID = true;
                    }
                    if (sFgWnd.EndsWith(" - Windows Internet Explorer")) // IE7 //
                    {
                        SendKeys.SendWait("{f6}"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("^c"); Application.DoEvents();
                        System.Threading.Thread.Sleep(50);
                        SendKeys.SendWait("{f6}"); Application.DoEvents();
                        GotThreadID = true;
                    }
                    if (!GotThreadID) {
                        GUI("Unknown browser");
                        if (z.cfg.bTrayMessages)
                            nIco.ShowBalloonTip(2000, "Error",
                                "Could not get thread from browser." + "\r\n\r\n" +
                                "Please use one of the following browsers:" + "\r\n" +
                                " -  Opera" + "\r\n" +
                                " -  Firefox" + "\r\n" +
                                " -  Internet Explorer 6" + "\r\n" +
                                " -  Internet Explorer 7",
                                ToolTipIcon.Error);
                        Clipboard.Clear();
                        if (tmp != "") Clipboard.SetText(tmp);
                        bIntHotkeys = false; return;
                    }

                    System.Threading.Thread.Sleep(250);
                    string ThreadURL = Clipboard.GetText();
                    Clipboard.Clear();
                    if (tmp != "") Clipboard.SetText(tmp);
                    if (fnAddThread(ThreadURL)) {
                        if (z.cfg.bTrayMessages)
                            nIco.ShowBalloonTip(2000, "Thread added",
                                "The following thread was added from browser:" + "\r\n" +
                                ThreadURL, ToolTipIcon.Info);
                    }
                    else {
                        if (z.cfg.bTrayMessages)
                            nIco.ShowBalloonTip(2000, "Error",
                                "Thread (from browser) was already added.",
                                ToolTipIcon.Error);
                    }
                }
                if (GetAsyncKeyState(Keys.D2) == -32767) {
                    if (fnAddThread(Clipboard.GetText())) {
                        if (z.cfg.bTrayMessages)
                            nIco.ShowBalloonTip(2000, "Thread added",
                                "The following thread was added from clipboard:" + "\r\n" +
                                Clipboard.GetText(), ToolTipIcon.Info);
                    }
                    else {
                        if (z.cfg.bTrayMessages)
                            nIco.ShowBalloonTip(2000, "Error",
                                "Thread (from clipboard) was already added.",
                                ToolTipIcon.Error);
                    }
                }
                if (GetAsyncKeyState(Keys.D3) == -32767) {
                    IterateAllGUI();
                }
                if (GetAsyncKeyState(Keys.D4) == -32767) {
                    new frmSearch().Show();
                }
            }
            bIntHotkeys = false;
        }
        private void tAutoIterate_Tick(object sender, EventArgs e) {
            if (saTips.Length > 0) {
                if (iTip < 0) iTip = saTips.Length - 1;
                if (iTip >= saTips.Length) iTip = 0;
                lbTip.Text = (iTip + 1) + "  -  " + saTips[iTip];
            }

            if (z.cfg.iAuto_Check == -1) return;
            if (bIsParsing || bIsDownloading) return;
            long lAiInterval = tiThreads.Length * 10;
            if (lAiInterval < z.cfg.iAuto_Check)
                lAiInterval = z.cfg.iAuto_Check;

            if ((DateTime.Now.Ticks / 10000000) - (lLastIteration) > lAiInterval) {
                GUI("Auto-iterating threads");
                IterateAll();
            }
        }
        private void tThreadState_Tick(object sender, EventArgs e) {
            if (bIntThrState) return; bIntThrState = true;
            int curDowning = 0;
            for (int a = 0; a < Clients.Length; a++) {
                if (Clients[a] != null && (
                    Clients[a].state == Grabber.State.Connecting ||
                    Clients[a].state == Grabber.State.Requesting ||
                    Clients[a].state == Grabber.State.Downloading))
                    curDowning++;
            }
            if (lFilesDownloading != 0 && curDowning == 0) {
                GUI("All downloads completed");
                if (z.cfg.bWhenDone_Alert) System.Media.SystemSounds.Exclamation.Play();
                if (z.cfg.bTrayMessages)
                    nIco.ShowBalloonTip(2000, "Completed",
                        "All downloads were completed.",
                        ToolTipIcon.Info);
                Application.DoEvents();
                if (z.cfg.bAutosave) cmdThreads_Save_Click(new object(), new EventArgs());
                if (z.cfg.bWhenDone_Exit) fnKillApp();
            }
            if (curDowning == 0)
                bIsDownloading = false;
            else bIsDownloading = true;
            lFilesDownloading = curDowning;
            GUI(); bIntThrState = false;
        }
        private void tDownload_Tick(object sender, EventArgs e) {
            if (bIntDownload) return; bIntDownload = true;
            for (int a = 0; a <= Clients.GetUpperBound(0); a++) {
                if (dQueURLs != "") {
                    if (Clients[a] == null || (
                        Clients[a].done &&
                        Clients[a].ex == Grabber.Ex.None)) {
                        string ReqURL = dQueURLs.Split('\n')[0];
                        string ReqPath = dQuePaths.Split('\n')[0];
                        string ReqName = dQueNames.Split('\n')[0];
                        dQueURLs = dQueURLs.Substring(dQueURLs.IndexOf("\n") + 1);
                        dQuePaths = dQuePaths.Substring(dQuePaths.IndexOf("\n") + 1);
                        dQueNames = dQueNames.Substring(dQueNames.IndexOf("\n") + 1);
                        lFilesLeft = dQueURLs.Split('\n').Length;
                        if (dQueURLs == "") lFilesLeft = 0;
                        ClientRetries[a] = 0;
                        ClientLastFUrl[a] = ReqURL;
                        ClientLastPath[a] = ReqPath;
                        ClientLastName[a] = ReqName;
                        Clients[a] = new Grabber(ReqURL,
                            ReqPath + ReqName, true, false);
                        GUI("Started downloading " + ReqName);
                    }
                }
            }
            bIntDownload = false;
        }
        private void tRetry_Tick(object sender, EventArgs e) {
            if (z.cfg.iError_Retry == -1) return;
            if (bIntRetry) return; bIntRetry = true;
            for (int a = 0; a < Clients.Length; a++) {
                if (Clients[a] != null && Clients[a].done &&
                    Clients[a].ex != Grabber.Ex.None) {
                    if (ClientRetries[a] >= z.cfg.iError_Retry) {
                        lFilesSkipped++;
                        ClientRetries[a] = 0;
                        Clients[a].ret = "skipped";
                        GUI("Skipping " + ClientLastName[a]);
                        System.IO.File.Delete(ClientLastPath[a] + ClientLastName[a]);
                    }
                    else {
                        ClientRetries[a]++;
                        lFilesRetried++;
                        Clients[a] = new Grabber(ClientLastFUrl[a],
                            ClientLastPath[a] + ClientLastName[a], true, false);
                        GUI("Retry #" + ClientRetries[a] + " on " + ClientLastName[a]);
                    }
                }
            }
            bIntRetry = false;
        }

        private void nIco_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (this.Visible) this.Hide(); else this.Show();
        }
        private void cMarkActive_Click(object sender, EventArgs e) {
            string sNotIdentified = "";
            for (int a = 0; a < tiThreads.Length; a++) {
                DLInf diTmp = GetPathByURL(tiThreads[a].sURL);
                int iChan = diTmp.iChan;
                int iBoard = diTmp.iBoard;
                string thID = diTmp.sThID;
                string sThPath = diTmp.sPath;
                if (iChan != -1 && iBoard != -1) {
                    System.IO.Directory.SetLastAccessTime(sThPath, System.DateTime.Now);
                }
                else {
                    sNotIdentified += tiThreads[a].sURL + "\r\n";
                }
            }
            if (sNotIdentified != "") {
                MessageBox.Show(
                    "The following threads are currently added to Chanmongler, however they could not be identified." + "\r\n" +
                    "As mongler is unable to identify the threads, they were not marked as active." + "\r\n" +
                    "If I were you, I'd verify that no chanfiles were missing / damaged." + "\r\n\r\n" +
                    sNotIdentified,
                    "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            GUI("Marked all active folders");
            if (z.cfg.bTrayMessages)
                nIco.ShowBalloonTip(2000, "Marked all active folders",
                    "The attribute \"Last access time\" has been set to \"now\" for all active threads.",
                    ToolTipIcon.Info);
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e) {
            fnKillApp();
        }

        private void lstThreads_SelectedIndexChanged(object sender, EventArgs e) {
            DLInf diTmp = GetPathByURL(lstThreads.SelectedItem.ToString());
            for (int a = 0; a < tiThreads.Length; a++) {
                if (tiThreads[a].sURL == diTmp.sThURL) {
                    ThInf_thrAdded.Text = Timestamp(tiThreads[a].thrAdded * 10000000);
                    ThInf_lastCheck.Text = Timestamp(tiThreads[a].lastCheck * 10000000);
                    ThInf_lastDL.Text = Timestamp(tiThreads[a].lastDL * 10000000);
                    ThInf_ImgCnt.Text = tiThreads[a].lImages + "";
                    ThInf_Folder.Text = tiThreads[a].sSub;

                    try {
                        if (ThInf_picThumb.Image != null) ThInf_picThumb.Image.Dispose();
                        Bitmap bWheee = imLoad(diTmp.sPath + "_thumb.dat");
                        ThInf_picThumb.BackgroundImage = (Image)bWheee;
                    }
                    catch {
                        try {
                            string[] saFiles = System.IO.Directory.GetFiles(diTmp.sPath);
                            for (int b = 0; b < saFiles.Length; b++) {
                                if (saFiles[b].ToLower().EndsWith(".jpg") ||
                                    saFiles[b].ToLower().EndsWith(".jpeg") ||
                                    saFiles[b].ToLower().EndsWith(".gif") ||
                                    saFiles[b].ToLower().EndsWith(".png")) {
                                    Bitmap bWheee = imLoad(saFiles[b]);
                                    Bitmap bThumb = ResizeBitmap(bWheee, ThInf_picThumb.Width,
                                        ThInf_picThumb.Height, true, 2, false);
                                    bWheee.Dispose();

                                    bThumb.Save(diTmp.sPath + "_thumb.jpg");
                                    System.IO.File.Move(
                                        diTmp.sPath + "_thumb.jpg",
                                        diTmp.sPath + "_thumb.dat");
                                    if (ThInf_picThumb.Image != null)
                                        ThInf_picThumb.Image.Dispose();
                                    ThInf_picThumb.BackgroundImage = bThumb as Image;
                                    return;
                                }
                            }
                        }
                        catch { }
                        DummyThumb();
                    }
                }
            }
        }
        private void lstThreads_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (lstThreads.SelectedIndex < 0) return;
                string sThURL = lstThreads.SelectedItem.ToString();
            }
            if (e.Button == MouseButtons.Right) {
                lstThreads.SelectedIndex = lstThreads.IndexFromPoint(e.Location);
                cmsThreads.Show(Cursor.Position);
            }
        }
        private void cmsThreads_OpenFolder_Click(object sender, EventArgs e) {
            if (lstThreads.SelectedIndex < 0) return;
            DLInf diTmp = GetPathByURL(lstThreads.SelectedItem.ToString());
            if (diTmp.iBoard == -1 || diTmp.iChan == -1) {
                MessageBox.Show("Unknown link. Missing chanfile?",
                    "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = "explorer.exe";
                proc.StartInfo.Arguments = "\"" + diTmp.sPath + "\"";
                proc.StartInfo.WindowStyle =
                    System.Diagnostics.ProcessWindowStyle.Maximized;
                proc.Start();
            }
        }
        private void cmsThreads_OpenURL_Click(object sender, EventArgs e) {
            if (lstThreads.SelectedIndex < 0) return;
            System.Diagnostics.Process.Start(
                lstThreads.SelectedItem.ToString());
        }
        private void cmsThreads_ViewImages_Click(object sender, EventArgs e) {
            if (lstThreads.SelectedIndex < 0) return;
            DLInf diTmp = GetPathByURL(lstThreads.SelectedItem.ToString());
            if (diTmp.iBoard == -1 || diTmp.iChan == -1) {
                MessageBox.Show("Unknown link. Missing chanfile?",
                    "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                string[] saFiles = new string[0];
                try {
                    saFiles = System.IO.Directory.GetFiles(diTmp.sPath);
                }
                catch { }
                for (int a = 0; a < saFiles.Length; a++) {
                    if (saFiles[a].ToLower().EndsWith(".jpg") ||
                        saFiles[a].ToLower().EndsWith(".jpeg") ||
                        saFiles[a].ToLower().EndsWith(".gif") ||
                        saFiles[a].ToLower().EndsWith(".png")) {
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.StartInfo.FileName = saFiles[a];
                        proc.StartInfo.WindowStyle =
                            System.Diagnostics.ProcessWindowStyle.Maximized;
                        proc.Start(); return;
                    }
                }
                MessageBox.Show("No images have been saved from this thread.",
                    "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void lstThreads_DoubleClick(object sender, EventArgs e) {
            if (lstThreads.SelectedIndex < 0) return;
            cmsThreads_ViewImages_Click(new object(), new EventArgs());
        }
        private void ThInf_Folder_TextChanged(object sender, EventArgs e) {
            if (ThInf_Folder.Text == "") ThInf_Folder.Text = "\\";
            DLInf diTmp = GetPathByURL(lstThreads.SelectedItem.ToString());
            for (int a = 0; a < tiThreads.Length; a++) {
                if (tiThreads[a].sURL == diTmp.sThURL) {
                    tiThreads[a].sSub = ThInf_Folder.Text;
                }
            }
        }
        private void DummyThumb() {
            if (ThInf_picThumb.Image != null)
                ThInf_picThumb.Image.Dispose();
            Bitmap bDummy = new Bitmap(1, 1);
            bDummy.SetPixel(0, 0, ThInf_picThumb.BackColor);
            ThInf_picThumb.BackgroundImage = bDummy as Image;
        }

        private void fnSortBy(string sSB) {
            string[] sVL = new string[tiThreads.Length];
            for (int a = 0; a < sVL.Length; a++) {
                if (sSB == "url") sVL[a] = tiThreads[a].sURL;
                if (sSB == "add") sVL[a] = tiThreads[a].thrAdded.ToString("D12");
                if (sSB == "chk") sVL[a] = tiThreads[a].lastCheck.ToString("D12");
                if (sSB == "ldl") sVL[a] = tiThreads[a].lastDL.ToString("D12");
                if (sSB == "img") sVL[a] = tiThreads[a].lImages.ToString("D8");
            }
            Array.Sort(sVL, tiThreads);
            fnRefreshGUIList();
            GUI("Sorted threads");
        }
        private void cmsThreads_SortBy_ThreadURL_Click(object sender, EventArgs e) {
            fnSortBy("url");
        }
        private void cmsThreads_SortBy_ThreadAdded_Click(object sender, EventArgs e) {
            fnSortBy("add");
        }
        private void cmsThreads_SortBy_LastCheck_Click(object sender, EventArgs e) {
            fnSortBy("chk");
        }
        private void cmsThreads_SortBy_LastDL_Click(object sender, EventArgs e) {
            fnSortBy("ldl");
        }
        private void cmsThreads_SortBy_ImageCount_Click(object sender, EventArgs e) {
            fnSortBy("img");
        }

        private void lbTipPrev_Click(object sender, EventArgs e) {
            iTip--; tAutoIterate_Tick(new object(), new EventArgs());
        }
        private void lbTipNext_Click(object sender, EventArgs e) {
            iTip++; tAutoIterate_Tick(new object(), new EventArgs());
        }

        private void ThInf_FolderB_Click(object sender, EventArgs e) {
            string root = tiThreads[lstThreads.SelectedIndex].sURL;
            root = GetPathByURL(root).sPath;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = root; fbd.ShowDialog();

            string sub = fbd.SelectedPath;
            if (!sub.StartsWith(root)) return;
            sub = sub.Substring(root.Length);
            ThInf_Folder.Text = sub;
            ThInf_Folder_TextChanged(sender, e);
        }
        private void cDownProg_Click(object sender, EventArgs e) {
            System.Threading.Thread th = new System.
                Threading.Thread(new System.Threading.
                    ThreadStart(ShowDownloaders));
            th.IsBackground = true; th.Start();
        }
        private void ShowDownloaders() {
            //The code is already complete utter shit.
            //Why bother keeping new submissions clean?
            int OffsetX = 8;
            int OffsetY = 8;
            int Margin = 48;
            Form frm = new Form();
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Height = Margin * Clients.Length + OffsetY;
            frm.Width = 640;

            Label[] fn = new Label[Clients.Length];
            Label[] sz = new Label[Clients.Length];
            ProgressBar[] pb = new ProgressBar[Clients.Length];
            for (int a = 0; a < Clients.Length; a++) {
                fn[a] = new Label();
                sz[a] = new Label();
                pb[a] = new ProgressBar();
                fn[a].Visible = true;
                sz[a].Visible = true;
                pb[a].Visible = true;
                fn[a].Size = new Size(574, 16);
                sz[a].Size = new Size(64, 16);
                pb[a].Size = new Size(574, 20);

                fn[a].Text = "(inactive)";
                sz[a].Text = "0 KB";
                pb[a].Maximum = 0;
                pb[a].Value = 0;

                fn[a].Location = new Point(OffsetX, OffsetY + Margin * a + 22);
                sz[a].Location = new Point(OffsetX + 576, OffsetY + Margin * a + 3);
                pb[a].Location = new Point(OffsetX, OffsetY + Margin * a);
                frm.Controls.Add(fn[a]);
                frm.Controls.Add(pb[a]);
                frm.Controls.Add(sz[a]);
            }
            frm.Show(); Application.DoEvents();
            frm.FormBorderStyle = FormBorderStyle.FixedDialog;

            while (frm.Visible) {
                for (int a = 0; a < Clients.Length; a++) {
                    if (Clients[a] == null) continue;

                    int iSzFm = 0;
                    string[] sSzFm = new string[]{
                        "B", "KB", "MB", "GB"};
                    double dSize = Clients[a].dataLen;
                    while (dSize > 1024 && iSzFm < sSzFm.Length - 1) {
                        dSize /= 1024; iSzFm++;
                    }
                    string sSize = dSize.ToString();
                    if (sSize.Length > 5) sSize =
                        sSize.Substring(0, 5);

                    fn[a].Text = ClientLastName[a];
                    sz[a].Text = sSize + " " + sSzFm[iSzFm];
                    pb[a].Maximum = Clients[a].dataLen;
                    pb[a].Value = Clients[a].curByte;
                }
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    public class z {
        public static string sAppVer = Application.ProductVersion;
        public static string sAppPath = Application.StartupPath;
        public static Config cfg;
        public static void Init() {
            sAppPath = sAppPath.Replace("/", "\\");
            if (!sAppPath.EndsWith("\\")) sAppPath += "\\";
            sAppVer = sAppVer.Substring(0, sAppVer.LastIndexOf("."));
        }
        public static string[] Split(string a, string b) {
            return a.Split(new string[] { b },
               StringSplitOptions.None);
        }
        public static long Tick() {
            return System.DateTime.Now.Ticks / 10000;
        }
        public static string absPath(string relPath) {
            return Application.StartupPath + "\\" + relPath;
        }
        public static bool OnlyContains(string str, string vl) {
            //One of the first methods I ever wrote.
            //Crappy, but I can't bring myself to fix it.
            for (int a = 0; a < str.Length; a++)
                if (!vl.Contains("" + str[a])) return false;
            return true;
        }
        public static string StripAllOf(string str, string vl, string fill) {
            //See comment for OnlyContains.
            string ret = str;
            for (int a = 0; a < vl.Length; a++) {
                ret = ret.Replace(vl[a].ToString(), fill);
            }
            return ret;
        }
    }
    public class ChanInf {
        public string p01_sIO_Prefix = "";
        public string p02_sName = "";
        public string p03_Version = "";
        public string p04_CMVersion = "";
        public string p05_Filename = "";
        public BoardInf[] bBoards = new BoardInf[0];
    }
    public class BoardInf {
        public string a01_sName = "";
        public string a02_sDesc = "";
        public string a03_sIO_Prefix = "";

        public string b01_sURL_Index = "";
        public string b02_sURL_IndexP_1 = "";
        public string b03_sURL_IndexP_2 = "";
        public int b04_sURL_IndexP_C = -1;
        public string b05_sURL_Thread = "";
        public string b06_sURL_Image = "";

        public string c01_sS_Threads_1 = "";
        public string c02_sS_Threads_2 = "";
        public string c03_sS_Threads = "";
        public string c04_sS_ThreadURL_1 = "";
        public string c05_sS_ThreadURL_2 = "";

        public string d01_sS_Images_1 = "";
        public string d02_sS_Images_2 = "";
        public string d03_sS_Images = "";
        public string d04_sS_ImageURL_1 = "";
        public string d05_sS_ImageURL_2 = "";
        public string d06_sS_ThumbURL_1 = "";
        public string d07_sS_ThumbURL_2 = "";

        public string e01_sI_Thread_1 = "";
        public string e02_sI_Thread_2 = "";
    }
    public class ThreadInf {
        public string sURL = "";
        public string sSub = "\\";
        public long thrAdded = DateTime.Now.Ticks / 10000000;
        public long lastCheck = DateTime.Now.Ticks / 10000000;
        public long lastDL = DateTime.Now.Ticks / 10000000;
        public long lImages = 1;
    }
    public class DLInf {
        public int iChan = -1;
        public int iBoard = -1;
        public string sURL = "";
        public string sThURL = "";
        public string sThID = "";
        public string sName = "";
        public string sPath = "";
    }
    public class Config {
        public bool bSubfolder_Site;
        public bool bSubfolder_Thread;
        public bool bPrefix_Board;
        public bool bPrefix_Thread;
        public bool bTagsToPath;
        public bool bTagOnAdd;
        public bool bHtmlSave;
        public bool bHtmlLocal;
        public string sPath;
        public bool bMoveDead;
        public bool bHotkeys;
        public bool bAutosave;
        public bool bTrayMessages;
        public bool bWhenDone_Alert;
        public bool bWhenDone_Exit;
        public int iPerf_Threads;
        public int iAuto_Check;
        public int iError_Retry;
        public Config() {
            bSubfolder_Site = true;
            bSubfolder_Thread = true;
            bPrefix_Board = true;
            bPrefix_Thread = false;
            bTagsToPath = false;
            bTagOnAdd = true;
            bHtmlSave = true;
            bHtmlLocal = true;
            sPath = "";
            bMoveDead = true;
            bHotkeys = true;
            bAutosave = false;
            bTrayMessages = true;
            bWhenDone_Alert = true;
            bWhenDone_Exit = false;
            iPerf_Threads = 4;
            iAuto_Check = 300;
            iError_Retry = 3;
        }
        public void Load() {
            z.cfg.sPath = z.sAppPath;
            if (!System.IO.File.Exists("settings.ini")) return;
            string sCfg = System.IO.File.ReadAllText("settings.ini");
            if (sCfg.Contains("<CMVer>")) {
                if (sCfg.Contains("<CMVer>" + z.sAppVer + "</CMVer>")) {
                    if (sCfg.Contains("<Folder-Site>1</Folder-Site>")) bSubfolder_Site = true;
                    if (sCfg.Contains("<Folder-Site>0</Folder-Site>")) bSubfolder_Site = false;
                    if (sCfg.Contains("<Folder-Thread>1</Folder-Thread>")) bSubfolder_Thread = true;
                    if (sCfg.Contains("<Folder-Thread>0</Folder-Thread>")) bSubfolder_Thread = false;
                    if (sCfg.Contains("<File-Board>1</File-Board>")) bPrefix_Board = true;
                    if (sCfg.Contains("<File-Board>0</File-Board>")) bPrefix_Board = false;
                    if (sCfg.Contains("<File-Thread>1</File-Thread>")) bPrefix_Thread = true;
                    if (sCfg.Contains("<File-Thread>0</File-Thread>")) bPrefix_Thread = false;
                    if (sCfg.Contains("<Tags-Path>1</Tags-Path>")) bTagsToPath = true;
                    if (sCfg.Contains("<Tags-Path>0</Tags-Path>")) bTagsToPath = false;
                    if (sCfg.Contains("<Tags-OnAdd>1</Tags-OnAdd>")) bTagOnAdd = true;
                    if (sCfg.Contains("<Tags-OnAdd>0</Tags-OnAdd>")) bTagOnAdd = false;
                    if (sCfg.Contains("<HTML-Save>1</HTML-Save>")) bHtmlSave = true;
                    if (sCfg.Contains("<HTML-Save>0</HTML-Save>")) bHtmlSave = false;
                    if (sCfg.Contains("<HTML-Local>1</HTML-Local>")) bHtmlLocal = true;
                    if (sCfg.Contains("<HTML-Local>0</HTML-Local>")) bHtmlLocal = false;
                    if (sCfg.Contains("<TargetPath>")) {
                        string tsPath = z.Split(z.Split(sCfg, "<TargetPath>")[1], "</TargetPath>")[0];
                        if (tsPath != sPath) sPath = tsPath;
                    }
                    if (sCfg.Contains("<MoveDead>1</MoveDead>")) bMoveDead = true;
                    if (sCfg.Contains("<MoveDead>0</MoveDead>")) bMoveDead = false;
                    if (sCfg.Contains("<GlobalHotkeys>1</GlobalHotkeys>")) bHotkeys = true;
                    if (sCfg.Contains("<GlobalHotkeys>0</GlobalHotkeys>")) bHotkeys = false;
                    if (sCfg.Contains("<Autosave>1</Autosave>")) bAutosave = true;
                    if (sCfg.Contains("<Autosave>0</Autosave>")) bAutosave = false;
                    if (sCfg.Contains("<TrayAlerts>1</TrayAlerts>")) bTrayMessages = true;
                    if (sCfg.Contains("<TrayAlerts>0</TrayAlerts>")) bTrayMessages = false;
                    if (sCfg.Contains("<Done-Alert>1</Done-Alert>")) bWhenDone_Alert = true;
                    if (sCfg.Contains("<Done-Alert>0</Done-Alert>")) bWhenDone_Alert = false;
                    if (sCfg.Contains("<Done-Exit>1</Done-Exit>")) bWhenDone_Exit = true;
                    if (sCfg.Contains("<Done-Exit>0</Done-Exit>")) bWhenDone_Exit = false;
                    if (sCfg.Contains("<DL-Threads>")) {
                        iPerf_Threads = Convert.ToInt32(z.Split(z.Split(
                            sCfg, "<DL-Threads>")[1], "</DL-Threads>")[0]);
                    }
                    if (sCfg.Contains("<Auto-Check>")) {
                        iAuto_Check = Convert.ToInt32(z.Split(z.Split(
                            sCfg, "<Auto-Check>")[1], "</Auto-Check>")[0]);
                    }
                    if (sCfg.Contains("<Error-Retry>")) {
                        iError_Retry = Convert.ToInt32(z.Split(z.Split(
                            sCfg, "<Error-Retry>")[1], "</Error-Retry>")[0]);
                    }
                }
                else {
                    MessageBox.Show(
                        "The settings.ini file is outdated." + "\r\n" +
                        "The configurations will not be loaded.",
                        "Oh snap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        public void Save() {
            string sCfg = "<CMVer>" + z.sAppVer + "</CMVer>\r\n";

            sCfg += "<Folder-Site>";
            sCfg += (bSubfolder_Site) ? "1" : "0";
            sCfg += "</Folder-Site>\r\n";

            sCfg += "<Folder-Thread>";
            sCfg += (bSubfolder_Thread) ? "1" : "0";
            sCfg += "</Folder-Thread>\r\n";

            sCfg += "<File-Board>";
            sCfg += (bPrefix_Board) ? "1" : "0";
            sCfg += "</File-Board>\r\n";

            sCfg += "<File-Thread>";
            sCfg += (bPrefix_Thread) ? "1" : "0";
            sCfg += "</File-Thread>\r\n";

            sCfg += "<Tags-Path>";
            sCfg += (bTagsToPath) ? "1" : "0";
            sCfg += "</Tags-Path>\r\n";

            sCfg += "<Tags-OnAdd>";
            sCfg += (bTagOnAdd) ? "1" : "0";
            sCfg += "</Tags-OnAdd>\r\n";

            sCfg += "<HTML-Save>";
            sCfg += (bHtmlSave) ? "1" : "0";
            sCfg += "</HTML-Save>\r\n";

            sCfg += "<HTML-Local>";
            sCfg += (bHtmlLocal) ? "1" : "0";
            sCfg += "</HTML-Local>\r\n";
            
            sCfg += "<TargetPath>";
            sCfg += sPath;
            sCfg += "</TargetPath>\r\n";

            sCfg += "<MoveDead>";
            sCfg += (bMoveDead) ? "1" : "0";
            sCfg += "</MoveDead>\r\n";

            sCfg += "<GlobalHotkeys>";
            sCfg += (bHotkeys) ? "1" : "0";
            sCfg += "</GlobalHotkeys>\r\n";

            sCfg += "<Autosave>";
            sCfg += (bAutosave) ? "1" : "0";
            sCfg += "</Autosave>\r\n";

            sCfg += "<TrayAlerts>";
            sCfg += (bTrayMessages) ? "1" : "0";
            sCfg += "</TrayAlerts>\r\n";

            sCfg += "<Done-Alert>";
            sCfg += (bWhenDone_Alert) ? "1" : "0";
            sCfg += "</Done-Alert>\r\n";

            sCfg += "<Done-Exit>";
            sCfg += (bWhenDone_Exit) ? "1" : "0";
            sCfg += "</Done-Exit>\r\n";

            sCfg += "<DL-Threads>";
            sCfg += Math.Max(iPerf_Threads, 1);
            sCfg += "</DL-Threads>\r\n";

            sCfg += "<Auto-Check>";
            if (iAuto_Check <= 0) sCfg += "-1";
            else sCfg += iAuto_Check;
            sCfg += "</Auto-Check>\r\n";

            sCfg += "<Error-Retry>";
            sCfg += Math.Max(iError_Retry, 0);
            sCfg += "</Error-Retry>\r\n";

            System.IO.File.WriteAllText("settings.ini", sCfg);
        }
    }
}
