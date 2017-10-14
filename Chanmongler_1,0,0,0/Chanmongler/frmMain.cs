using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chanmongler
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Conversions
        /// <summary>
        /// Returns character from ascii
        /// </summary>
        private string Chr(int id)
        {
            return Convert.ToChar(id).ToString();
        }
        /// <summary>
        /// Returns ascii from character
        /// </summary>
        private int Asc(char id)
        {
            return Convert.ToInt16(id);
        }
        /// <summary>
        /// Converts integer to byte
        /// </summary>
        public byte[] Int2Byte(int Value)
        {
            byte[] rawbuf = BitConverter.GetBytes(Value);
            int a = 0; for (a = rawbuf.Length; a > 0; a--) if (rawbuf[a - 1] != 0) break;
            byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = rawbuf[a];
            return buf;
        }
        /// <summary>
        /// Converts byte to string
        /// </summary>
        public String Byte2Str(byte[] Value)
        {
            int len = 0; for (len = Value.Length; len > 0; len--) if (Value[len - 1] != 0) break;
            string ret = ""; for (int a = 0; a < len; a++) ret += (char)Value[a];
            //byte[] buf = new byte[a]; for (a = 0; a < buf.Length; a++) buf[a] = Value[a];
            return ret; //System.Text.Encoding.ASCII.GetString(buf);
        }
        /// <summary>
        /// Converts string to byte
        /// </summary>
        public byte[] Str2Byte(string Value)
        {
            byte[] ret = new byte[Value.Length];
            for (int a = 0; a < Value.Length; a++) ret[a] = (byte)Value[a];
            return ret;
        }
        #endregion
        #region "Standard" functions
        ///<summary>
        /// Splits msg by delim, returns bit part
        ///</summary>
        public static string Split(string msg, string delim, int part)
        {
            if (msg == "" || msg == null || delim == "" || delim == null) return "";
            for (int a = 0; a < part; a++)
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            if (msg.IndexOf(delim) == -1) return msg;
            return msg.Substring(0, msg.IndexOf(delim));
        }
        ///<summary>
        /// Splits msg by delim, returns string array
        ///</summary>
        public static string[] aSplit(string msg, string delim)
        {
            if (msg == "" || msg == null || delim == "" || delim == null) return new string[0];
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            while (msg.Contains(delim))
            {
                ret[spt] = msg.Substring(0, msg.IndexOf(delim)); spt++;
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length);
            }
            ret[spt] = msg;
            return ret;
        }
        /// <summary>
        /// Alternative aSplit, should be faster
        /// </summary>
        public string[] aSplit2(string msg, string delim)
        {
            int spt = 0; string[] ret = new string[Countword(msg, delim) + 1];
            int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos != -1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    ret[spt] = msg.Substring(0, FoundPos); spt++;
                    msg = msg.Substring(FoundPos + delimLen);
                }
            }
            ret[spt] = msg; return ret;
        }
        ///<summary>
        /// Counts occurrences of delim within msg
        ///</summary>
        public static int Countword(string msg, string delim)
        {
            int ret = 0; if (msg == "" || msg == null || delim == "" || delim == null) return 0;
            while (msg.Contains(delim))
            {
                msg = msg.Substring(msg.IndexOf(delim) + delim.Length); ret++;
            }
            return ret;
        }
        /// <summary>
        /// Alternative Countword, should be faster
        /// </summary>
        public int Countword2(string msg, string delim)
        {
            int ret = 0; int FoundPos = 0; int delimLen = delim.Length;
            while (FoundPos != -1)
            {
                FoundPos = msg.IndexOf(delim);
                if (FoundPos != -1)
                {
                    msg = msg.Substring(FoundPos + delimLen); ret++;
                }
            }
            return ret;
        }
        ///<summary>
        /// Converts a number (vl) into a digit-grouped string
        ///</summary>
        public static string Decimize(string vl)
        {
            string ret = ""; int spt = 0;
            while (vl.Length != 0)
            {
                if (spt == 3)
                {
                    ret = "," + ret; spt = 0;
                }
                ret = vl.Substring(vl.Length - 1, 1) + ret;
                vl = vl.Substring(0, vl.Length - 1);
                spt++;
            }
            return ret;
        }
        ///<summary>
        /// Creates a string containing vl number of spaces
        ///</summary>
        public static string Space(int vl)
        {
            string ret = "";
            for (int a = 0; a < vl; a++)
            {
                ret += " ";
            }
            return ret;
        }
        ///<summary>
        /// Removes all spaces at start and end of vl
        ///</summary>
        public static string unSpace(string vl)
        {
            string ret = vl;
            try
            {
                while (ret.Substring(0, 1) == " ")
                {
                    ret = ret.Substring(1);
                }
                while (ret.Substring(ret.Length - 1) == " ")
                {
                    ret = ret.Substring(0, ret.Length - 1);
                }
                return ret;
            }
            catch
            {
                return "";
            }
        }
        ///<summary>
        /// Removes all newlines at start and end of vl
        /// </summary>
        public static string unNewline(string vl)
        {
            try
            {
                while ((vl.Substring(0, 1) == "\r") || (vl.Substring(0, 1) == "\n"))
                {
                    vl = vl.Substring(1);
                }
                while ((vl.Substring(vl.Length - 1) == "\r") || (vl.Substring(vl.Length - 1) == "\n"))
                {
                    vl = vl.Substring(0, vl.Length - 1);
                }
                return vl;
            }
            catch
            {
                return "";
            }
        }
        ///<summary>
        /// Returns system clock in seconds
        ///</summary>
        public int sTick()
        {
            return (System.DateTime.Now.Hour * 60 * 60) +
                   (System.DateTime.Now.Minute * 60) +
                   (System.DateTime.Now.Second);
        }
        ///<summary>
        /// Sleeps for vl seconds
        ///</summary>
        public void iSlp(int vl)
        {
            long lol = Tick();
            while (Tick() < lol + vl)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
        }
        ///<summary>
        /// Returns system clock in miliseconds
        ///</summary>
        public long Tick()
        {
            return System.DateTime.Now.Ticks / 10000;
        }
        ///<summary>
        /// Returns hh:mm:ss of vl (seconds)
        ///</summary>
        public string s2ms(int vl)
        {
            int iHour = 0; int iMins = 0; int iSecs = vl;
            while (iSecs >= 60)
            {
                iSecs -= 60; iMins++;
            }
            while (iMins >= 60)
            {
                iMins -= 60; iHour++;
            }
            string sHour = Convert.ToString(iHour); sHour = Space(2 - sHour.Length).Replace(" ", "0") + sHour;
            string sMins = Convert.ToString(iMins); sMins = Space(2 - sMins.Length).Replace(" ", "0") + sMins;
            string sSecs = Convert.ToString(iSecs); sSecs = Space(2 - sSecs.Length).Replace(" ", "0") + sSecs;
            return sHour + ":" + sMins + ":" + sSecs;
        }
        /// <summary>
        /// This function returns false and makes regkey if not exist.
        /// </summary>
        private bool Reg_DoesExist(string regPath)
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                key = key.OpenSubKey(regPath, true);
                long lol = key.SubKeyCount;
                return true;
            }
            catch
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser;
                key.CreateSubKey(regPath);
                return false;
            }
        }
        ///<summary>
        /// Returns current date and time
        ///</summary>
        public string TDNow()
        {
            return System.DateTime.Now.ToLongDateString() + " .::. " +
                   System.DateTime.Now.ToLongTimeString();
        }
        ///<summary>
        /// Returns MD5 of vl
        ///</summary>
        public string MD5(string vl)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(vl);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }
        #endregion
        #region File and array manipulation
        /// <summary>
        /// Reads sFile, works with norwegian letters ae oo aa
        /// </summary>
        public string FileRead(string sFile)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(sFile, Encoding.GetEncoding("iso-8859-1"));
                string ret = sr.ReadToEnd();
                while ((ret.Substring(ret.Length - 1) == "\r") || (ret.Substring(ret.Length - 1) == "\n"))
                    ret = ret.Substring(0, ret.Length - 1);
                sr.Close(); sr.Dispose(); return ret;
            }
            catch { return ""; }
        }
        /// <summary>
        /// Writes sVal to sFile, works with norwegian letters ae oo aa
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="sVal"></param>
        public void FileWrite(string sFile, string sVal)
        {
            System.IO.FileStream fs = new System.IO.FileStream(sFile, System.IO.FileMode.Create);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, Encoding.GetEncoding("iso-8859-1"));
            sw.Write(sVal); sw.Close(); sw.Dispose();
        }
        /// <summary>
        /// Sorts vl[] alphabetically, ignores letters other than 0-9 a-z
        /// </summary>
        public string[] SortStringArrayAlphabetically(string[] vl)
        {
            for (int a = vl.GetUpperBound(0); a >= 0; a--)
            {
                for (int b = 0; b < a; b++) //changed "b <= a" to "b < a"
                {
                    if (string.Compare(vl[b], vl[b + 1], true) > 0)
                    {
                        //Swap values
                        string tmp = vl[b].ToString();
                        vl[b] = vl[b + 1];
                        vl[b + 1] = tmp;
                    }
                }
            }
            return vl;
        }
        #endregion

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        private WebReq[] Clients = new WebReq[13];
        private string dQueURLs = "", dQueNames = "";
        private string[] ChanCfg;
        public static bool intDownload = false, bBoardUnlocked = false;
        public static string PrgDomain = "http://tox.awardspace.us/div/";
        public static string ToxDomain = "http://www.praetox.com/";

        private void lg(string vl)
        {
            if (fStatus.Text == vl) return;
            fStatus.Text = vl;
            if (vl.StartsWith("Thread ")) lThread.Text = vl;
            if (vl.StartsWith("Pic. url ")) lPUrl.Text = vl;
            if (vl.StartsWith("Pics left: ")) lPicture.Text = vl;
            Application.DoEvents();
        }
        private void pKillMe()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text += Application.ProductVersion;
            try
            {
                string lol = new System.Net.WebClient().DownloadString(
                    PrgDomain + "Chanmongler_version.php?cv=" + Application.ProductVersion);
                if (!lol.Contains("<VERSION>" + Application.ProductVersion + "</VERSION>"))
                {
                    bool GetUpdate = (DialogResult.Yes == MessageBox.Show(
                        "A new version is available. Update?",
                        "so i herd u liek mudkipz", MessageBoxButtons.YesNo));
                    if (GetUpdate)
                    {
                        string UpdateLink = new System.Net.WebClient().DownloadString(
                            ToxDomain + "inf/Chanmongler_link.html").Split('%')[1];
                        System.Diagnostics.Process.Start(UpdateLink + "?cv=" + Application.ProductVersion);
                        Application.Exit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Couldn't check for updates.\r\n\r\nAlso, cocks.", "A cat is fine too");
            }

            txtPath.Text = Application.StartupPath;
            if (!System.IO.Directory.Exists(Application.StartupPath + "/_cfg"))
            {
                MessageBox.Show(
                    "Could not access configuration files." + "\r\n" +
                    "\r\n" +
                    "This is most likely because Chanmongler was started directly from an archive." + "\r\n" +
                    "If this is the case, extract Chanmongler somewhere and try again.");
                pKillMe();
            }

            string[] Chanlist = System.IO.Directory.GetFiles("_cfg/", "*.chan");
            for (int a = 0; a < Chanlist.Length; a++)
            {
                string Chan = Chanlist[a];
                Chan = Chan.Substring(Chan.IndexOf("/") + 1);
                Chan = Chan.Substring(0, Chan.LastIndexOf("."));
                cbChan.Items.Add(Chan);
            }
            for (int a = 0; a < cbChan.Items.Count; a++)
            {
                if (cbChan.Items[a].ToString() == "4chan") cbChan.SelectedIndex = a;
            }

            for (int a = 0; a <= Clients.GetUpperBound(0); a++)
            {
                Clients[a] = new WebReq();
            }
            tThreadState.Start(); tDownload.Start();
        }

        private void cbChan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Chans = FileRead("_cfg/" + cbChan.Text + ".chan");
            while (Chans.Contains("\t\t")) Chans = Chans.Replace("\t\t", "\t");
            Chans = Chans.Substring(Chans.IndexOf("\n") + 1);
            ChanCfg = Chans.Replace("\r", "").Split('\n');

            cbBoard.Items.Clear();
            for (int a = 0; a < ChanCfg.Length; a++)
            {
                cbBoard.Items.Add(
                    ChanCfg[a].Split('\t')[0] + " - " +
                    ChanCfg[a].Split('\t')[1]);
            }

            cbBoard.SelectedIndex = -1; 
            cbBoard.SelectedIndex = 0;
        }
        private void cmdBoard_Click(object sender, EventArgs e)
        {
            if (bBoardUnlocked)
            {
                tDownload.Stop();
                string[] Threadlist = ReturnThreads(cbBoard.Text);
                int UBound = Threadlist.GetUpperBound(0);
                for (int a = 0; a <= UBound; a++)
                {
                    lg("Thread " + (a + 1) + "/" + (UBound + 1));
                    IterateThread(Threadlist[a]);
                }
                tDownload.Start();
                lg("Board downloaded");
            }
            else
            {
                MessageBox.Show("This feature has been hidden to preserve *chan's bandwidth.");
            }
        }
        private void cmdThread_Click(object sender, EventArgs e)
        {
            IterateThread(txtThread.Text);
            lg("Thread downloaded");
        }

        string[] ReturnThreads(string Board)
        {
            /*try
            {
                string[] ret, BoardURLs; string BoardURL = GetUrlFromBoard(Board);
                string BoardHTML = new System.Net.WebClient().DownloadString(BoardURL);
                BoardURLs = aSplit(BoardHTML, "</a>  &nbsp; [<a href=\"");
                ret = new string[BoardURLs.GetUpperBound(0)];
                for (int a = 1; a <= BoardURLs.GetUpperBound(0); a++)
                    ret[a - 1] = GetUrlFromBoard(Board) + BoardURLs[a].Split('\"')[0];
                return ret;
            }
            catch { MessageBox.Show("Could not open board."); return new string[0]; }*/

            try
            {
                string[] ret, BoardURLs; string BoardURL = GetUrlFromBoard(Board, true);
                string BoardHTML = new System.Net.WebClient().DownloadString(BoardURL);
                if (ChanP(5, -1) != "!null~")
                    BoardHTML = BoardHTML.Substring(BoardHTML.IndexOf(ChanP(5, -1)) + (ChanP(5, -1).Length));
                if (ChanP(6, -1) != "!null~")
                    BoardHTML = BoardHTML.Substring(0, BoardHTML.IndexOf(ChanP(6, -1)));

                BoardURLs = aSplit(BoardHTML, ChanP(7, -1));
                ret = new string[BoardURLs.GetUpperBound(0)];
                for (int a = 0; a < BoardURLs.GetUpperBound(0); a++)
                {
                    ret[a] = BoardURLs[a + 1];
                    if (ChanP(8, -1) != "!null~")
                        ret[a] = ret[a].Substring(ret[a].IndexOf(ChanP(8, -1)) + ChanP(8, -1).Length);
                    if (ChanP(9, -1) != "!null~")
                        ret[a] = ret[a].Substring(0, ret[a].IndexOf(ChanP(9, -1)));
                    ret[a] = GetUrlFromBoard(Board, false) + ret[a];
                }
                return ret;
            }
            catch { MessageBox.Show("Could not open board."); return new string[0]; }
        }
        string[] GetPictureURLs(string ThreadURL)
        {
            try
            {
                string[] ret, PicURLs;
                int Board;
                for (Board = 0; Board < ChanCfg.Length; Board++)
                {
                    if (ChanP(2, Board) == ThreadURL.Substring(0, ChanP(2, Board).Length)) break;
                }
                if (Board >= ChanCfg.Length) Board = -1;
                string ThreadHTML = new System.Net.WebClient().DownloadString(ThreadURL);
                if (ChanP(10, Board) != "!null~")
                    ThreadHTML = ThreadHTML.Substring(ThreadHTML.IndexOf(ChanP(10, Board)) + (ChanP(10, Board).Length));
                if (ChanP(11, Board) != "!null~")
                    ThreadHTML = ThreadHTML.Substring(0, ThreadHTML.IndexOf(ChanP(11, Board)));

                string msgbox = "";
                PicURLs = aSplit(ThreadHTML, ChanP(12, Board));
                ret = new string[PicURLs.GetUpperBound(0)];
                for (int a = 0; a < PicURLs.GetUpperBound(0); a++)
                {
                    ret[a] = PicURLs[a + 1];
                    if (ChanP(13, Board) != "!null~")
                        ret[a] = ret[a].Substring(ret[a].IndexOf(ChanP(13, Board)) + ChanP(13, Board).Length);
                    if (ChanP(14, Board) != "!null~")
                        ret[a] = ret[a].Substring(0, ret[a].IndexOf(ChanP(14, Board)));
                    if (ChanP(4, Board) != "!null~")
                        ret[a] = ChanP(4, Board) + ret[a];
                    msgbox += ret[a] + "\r\n";
                }
                //(ThreadURL + " - " + (msgbox.Split('\n').Length-1) + "\r\n\r\n" + msgbox);
                return ret;
            }
            catch { MessageBox.Show("Could not open thread."); return new string[0]; }
        }
        void DownloadPictures(string[] PictureURLs)
        {
            string Board = "_";
            string DLPath = txtPath.Text + "\\";
            for (int a = 0; a < ChanCfg.Length; a++)
            {
                string tBoard = ChanP(2, a);
                if (tBoard.Length < PictureURLs[0].Length)
                    if (tBoard == PictureURLs[0].Substring(0, tBoard.Length))
                        Board = ChanP(0, a);
            }
            if (Board == "_") Board = cbBoard.Items[cbBoard.SelectedIndex].ToString().Split(' ')[0];
            for (int a = 0; a < PictureURLs.Length; a++)
            {
                lg("Pic. url " + (a + 1) + "/" + (PictureURLs.Length));
                string ThisFName =
                    Board + "-" +
                    PictureURLs[a].Split('/')
                    [PictureURLs[a].Split('/').Length - 1];
                if (!System.IO.File.Exists(DLPath + ThisFName))
                {
                    dQueURLs += PictureURLs[a] + "\n";
                    dQueNames += ThisFName + "\n";
                }
            }
        }
        void IterateThread(string Thread)
        {
            string[] Pics = GetPictureURLs(Thread);
            if (Pics.Length > 0) DownloadPictures(Pics);
        }
        string GetUrlFromBoard(string Board, bool BoardIndex)
        {
            string ret = "";
            Board = Board.Substring(0, Board.IndexOf(" - "));
            for (int a = 0; a < ChanCfg.Length; a++)
            {
                if (Board == ChanCfg[a].Split('\t')[0])
                    if (BoardIndex)
                        ret = ChanP(2, a);
                    else
                        ret = ChanP(3, a);
            }
            if (ret == "!null~") ret = "";
            return ret;
        }
        string ChanP(int iParameter, int iBoard)
        {
            if (iBoard == -1) iBoard = cbBoard.SelectedIndex;
            return ChanCfg[iBoard].Split('\t')[iParameter];
        }

        private void tThreadState_Tick(object sender, EventArgs e)
        {
            string sState = "", sTarget = "";
            for (int a = 0; a <= Clients.GetUpperBound(0); a++)
            {
                string aState = "?";
                if (Clients[a].State == WebReq.ReqState.Ready) aState = "Ready";
                if (Clients[a].State == WebReq.ReqState.Completed) aState = "Completed";
                if (Clients[a].State == WebReq.ReqState.Connecting) aState = "Connecting";
                if (Clients[a].State == WebReq.ReqState.Requesting) aState = "Requesting";

                if (Clients[a].State == WebReq.ReqState.Downloading)
                    sState += Clients[a].Progress + "%\r\n";
                else
                    sState += aState + "\r\n";

                string tsTarget = "" + Clients[a].URI;
                if (tsTarget.Length >= 45)
                    tsTarget = "..." + tsTarget.Substring(tsTarget.Length - 43);
                sTarget += tsTarget + "\r\n";
            }
            lState.Text = sState; lTarget.Text = sTarget;
        }

        private void cDL_All_Click(object sender, EventArgs e)
        {
            tDownload.Start();
        }

        private void tDownload_Tick(object sender, EventArgs e)
        {
            if (intDownload) return; intDownload = true;
            for (int a = 0; a <= Clients.GetUpperBound(0); a++)
            {
                if (dQueURLs != "")
                {
                    if (Clients[a].isReady)
                    {
                        string ReqURL = dQueURLs.Split('\n')[0];
                        string ReqName = dQueNames.Split('\n')[0];
                        dQueURLs = dQueURLs.Replace(ReqURL + "\n", "");
                        dQueNames = dQueNames.Replace(ReqName + "\n", "");
                        lg("Pics left: " + dQueURLs.Split('\n').GetUpperBound(0));
                        Clients[a].Request(ReqURL, txtPath.Text + "\\" + ReqName, false);
                    }
                }
                else
                {
                    lg("Application status");
                }
            }
            intDownload = false;
        }

        /*private void tTroll_Tick(object sender, EventArgs e)
        {
            if (intTroll) return; intTroll = true;
            IterateThread(txtThread.Text);
            lg("Trolled thread");
            intTroll = false;
        }

        private void chkTroll_CheckedChanged(object sender, EventArgs e)
        {
            tTroll.Interval = Convert.ToInt32(txtTroll.Text) * 1000;
            tTroll.Enabled = chkTroll.Checked;
        }*/

        private void txtThread_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtThread.Text = Clipboard.GetText();
        }
        private void cmdPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "") txtPath.Text = fbd.SelectedPath;
        }

        private void cmdContact_Click(object sender, EventArgs e)
        {
            new frmContact().Show();
        }

        private void cmdNews_Click(object sender, EventArgs e)
        {
            new frmNews().Show();
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            txtPath.Text = txtPath.Text.Replace("\\", "/");
            if (txtPath.Text.EndsWith("/"))
            {
                txtPath.Text = txtPath.Text.Substring(0, txtPath.Text.Length - 1);
                txtPath.SelectionLength = 0;
                txtPath.SelectionStart = txtPath.Text.Length;
                txtPath.ScrollToCaret();
            }
        }
    }
}
