using System;
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
    public partial class frmSearch : Form {
        public frmSearch() {
            InitializeComponent();
        }

        private ChanInf[] Chans = frmMain.Chans;
        public static long lBoardsChecked = 0;
        public static long lBoardsTotal = 1;
        public static long lThreadsChecked = 0;
        public static long lThreadsTotal = 9001;
        public static long lFound = 0;
        public static string sFoundURL = "";
        public static string sFoundCtx = "";
        public static string sFoundWrd = "";
        public static System.DateTime dtLastSearch = System.DateTime.Now;
        Random rnd = new Random();

        private void GUI() {
            lbThreads.Text = lBoardsChecked + " / " + lBoardsTotal;
            lbThreads.Text = lThreadsChecked + " / " + lThreadsTotal;
            lbFound.Text = lFound + "";
            Application.DoEvents();
        }
        private void GUI(string vl) {
            lbStatus.Text = vl; GUI();
        }
        private void frmSearch_Load(object sender, EventArgs e) {
            cbChan.Items.Clear();
            for (int a = 0; a < Chans.Length; a++) {
                cbChan.Items.Add(Chans[a].p02_sName);
            }
            cbChan.SelectedIndex = 0;
        }
        private void cbChan_SelectedIndexChanged(object sender, EventArgs e) {
            cbBoard.Items.Clear();
            int iChan = cbChan.SelectedIndex;
            for (int a = 0; a < Chans[iChan].bBoards.Length; a++) {
                cbBoard.Items.Add(Chans[iChan].bBoards[a].a01_sName +
                    " - " + Chans[iChan].bBoards[a].a02_sDesc);
            }
            cbBoard.SelectedIndex = 0;
        }
        private void cmdDoSearch_Click(object sender, EventArgs e) {
            try {
                string[] saTerm = z.Split(txTerm.Text.ToLower(), "; ");
                int iChan = cbChan.SelectedIndex; ChanInf thChan = Chans[iChan];
                int iBoard = cbBoard.SelectedIndex; BoardInf thBoard = Chans[iChan].bBoards[iBoard];
                sFoundWrd = ""; sFoundURL = ""; sFoundCtx = "";
                lBoardsChecked = 0; lThreadsChecked = 0; lFound = 0; GUI("Downloading board pages");
                string AllURLs = "\n";

                Grabber[] WRB = new Grabber[thBoard.b04_sURL_IndexP_C];
                for (int a = 0; a < WRB.Length; a++) {
                    string ReqURL = thBoard.b01_sURL_Index;
                    string sURLP_1 = thBoard.b02_sURL_IndexP_1; if (sURLP_1 == "!null~") sURLP_1 = "";
                    string sURLP_2 = thBoard.b03_sURL_IndexP_2; if (sURLP_2 == "!null~") sURLP_2 = "";
                    if (a > 0) ReqURL = sURLP_1 + a + sURLP_2;

                    //I don't remember why this is here, and I
                    //can't be arsed to figure it out either. Meh.
                    System.Threading.Thread.Sleep(rnd.Next(10, 50));
                    WRB[a] = new Grabber(ReqURL);
                }
                while (true) {
                    bool bDone = true;
                    for (int a = 0; a < WRB.Length; a++) {
                        if (!WRB[a].done) bDone = false;
                    }
                    System.Threading.Thread.Sleep(100);
                    if (bDone) break;
                }
                GUI("Parsing board pages");
                for (int a = 0; a < WRB.Length; a++) {
                    string bHTML = WRB[a].ret;
                    if (WRB[a].ex == Grabber.Ex.NotFound)
                        throw new Exception("Error 404: File does not exist");

                    string sSTmp = "";
                    sSTmp = thBoard.c01_sS_Threads_1;
                    if (sSTmp != "!null~") bHTML = bHTML.Substring(bHTML.IndexOf(sSTmp) + sSTmp.Length);
                    sSTmp = thBoard.c02_sS_Threads_2;
                    if (sSTmp != "!null~") bHTML = bHTML.Substring(0, bHTML.IndexOf(sSTmp));

                    string[] saTURLs = z.Split(bHTML, thBoard.c03_sS_Threads);
                    string[] TURLs = new string[saTURLs.Length - 1];
                    for (int b = 0; b < TURLs.Length; b++) {
                        TURLs[b] = saTURLs[b + 1];
                        sSTmp = thBoard.c04_sS_ThreadURL_1;
                        if (sSTmp != "!null~") TURLs[b] = TURLs[b].Substring(TURLs[b].IndexOf(sSTmp) + sSTmp.Length);
                        sSTmp = thBoard.c05_sS_ThreadURL_2;
                        if (sSTmp != "!null~") TURLs[b] = TURLs[b].Substring(0, TURLs[b].IndexOf(sSTmp));
                        sSTmp = thBoard.b05_sURL_Thread;
                        if (sSTmp != "!null~") TURLs[b] = sSTmp + TURLs[b];

                        if (!AllURLs.Contains("\n" + TURLs[b] + "\n"))
                            AllURLs += TURLs[b] + "\n";
                    }
                }

                GUI("Downloading / parsing threads");
                AllURLs = AllURLs.TrimStart('\n');
                while (AllURLs != "") {
                    string thURLs = "";
                    for (int a = 0; a < 10; a++) {
                        if (AllURLs != "") {
                            thURLs += AllURLs.Substring(0, AllURLs.IndexOf("\n")) + "\n";
                            AllURLs = AllURLs.Substring(AllURLs.IndexOf("\n") + 1);
                        }
                    }
                    string[] saURLs = thURLs.TrimEnd('\n').Split('\n');
                    Grabber[] WR = new Grabber[saURLs.Length];
                    for (int b = 0; b < WR.Length; b++) {
                        //See last comment. Also, there's something
                        //strangely familiar with this code... Hurrr
                        System.Threading.Thread.Sleep(rnd.Next(10, 50));
                        WR[b] = new Grabber(saURLs[b]);
                    }
                    while (true) {
                        bool bDone = true;
                        int olThreadsChecked = 0;
                        for (int b = 0; b < WR.Length; b++) {
                            if (WR[b].done) olThreadsChecked++;
                            else bDone = false;
                        }
                        lThreadsChecked += olThreadsChecked; GUI();
                        lThreadsChecked -= olThreadsChecked;
                        System.Threading.Thread.Sleep(100);
                        if (bDone) break;
                    }
                    lThreadsChecked += WR.Length;
                    for (int b = 0; b < WR.Length; b++) {
                        string thHTML = WR[b].ret.ToLower();
                        for (int c = 0; c < saTerm.Length; c++) {
                            if (thHTML.Contains(saTerm[c])) {
                                sFoundWrd += saTerm[c] + "\n";
                                sFoundURL += WR[b].uri.AbsoluteUri + "\n";
                                thHTML = thHTML.Replace("\r", "").Replace("\n", "")
                                               .Replace("<br />", " .. ");
                                thHTML = System.Text.RegularExpressions.Regex
                                               .Replace(thHTML, "<(.|\n)*?>", " - ");
                                int StartOfs = thHTML.IndexOf(saTerm[c]) - 40;
                                if (StartOfs < 0) StartOfs = 0;
                                int TotLen = 40 + saTerm[c].Length;
                                if (StartOfs != 0) TotLen += 40;
                                if (StartOfs + TotLen > thHTML.Length) {
                                    StartOfs = 0; TotLen = thHTML.Length;
                                }
                                sFoundCtx += thHTML.Substring(StartOfs, TotLen) + "\n";
                            }
                        }
                    }
                    string[] saFound = sFoundURL.TrimEnd('\n').Split('\n');
                    lFound = saFound.Length;
                    if (saFound[0] == "") lFound = 0;
                    lBoardsChecked++; GUI();
                }
                sFoundWrd = sFoundWrd.TrimEnd('\n');
                sFoundURL = sFoundURL.TrimEnd('\n');
                sFoundCtx = sFoundCtx.TrimEnd('\n');
                dtLastSearch = System.DateTime.Now;
                MessageBox.Show(
                    "Found " + lFound + " instances across " + lThreadsChecked + " threads." + "\r\n\r\n" +
                    "(multiple hits of same word in same threads not counted)");
            }
            catch (Exception ex) {
                MessageBox.Show("Oh snap, something went wrong." + "\r\n\r\n" + ex.Message);
            }
        }
        private void cmdViewResults_Click(object sender, EventArgs e) {
            string ret =
                "<html>" + "\r\n" +
                "  <head>" + "\r\n" +
                "    <title>Chanmongler Search Results</title>" + "\r\n" +
                "    <style type=\"text/css\" media=\"screen\">" + "\r\n" +
                "      td { padding: 3px; }" + "\r\n" +
                "    </style>" + "\r\n" +
                "  </head>" + "\r\n" +
                "  <body><center>" + "\r\n" +
                "    <font size=+3>" + "\r\n" +
                "      Search completed at " + dtLastSearch.ToShortDateString() +
                " - " + dtLastSearch.ToLongTimeString() + "\r\n" +
                "    </font>" + "\r\n" +
                "    <br><br>" + "\r\n" +
                "    <table border=2>" + "\r\n";
            string[] saFoundWrd = sFoundWrd.Split('\n');
            string[] saFoundURL = sFoundURL.Split('\n');
            string[] saFoundCtx = sFoundCtx.Split('\n');
            for (int a = 0; a < saFoundURL.Length; a++) {
                ret +=
                    "      <tr>" + "\r\n" +
                    "        <td>" + saFoundWrd[a] + "</td>" + "\r\n" +
                    "        <td><a href=\"" + saFoundURL[a] + "\">" + saFoundURL[a] + "</td>" + "\r\n" +
                    "        <td>" + saFoundCtx[a] + "</td>" + "\r\n" +
                    "      </tr>" + "\r\n";
            }
            ret +=
                "    </table>" + "\r\n" +
                "    <a href=\"" + frmMain.ToxDomain + "\">" + "\r\n" +
                "      <font color=\"#777777\">" + "\r\n" +
                "        Praetox Technologies" + "\r\n" +
                "      </font>" + "\r\n" +
                "    </a>" + "\r\n" +
                "  </body>" + "\r\n" +
                "</html>";

            try {
                System.IO.File.WriteAllText("srch.html", ret, Encoding.UTF8);
                System.Diagnostics.Process.Start("srch.html");
            }
            catch {
                MessageBox.Show(
                    "Unable to view the search result website." + "\r\n" +
                    "\r\n" +
                    "Did you forget to close the previous search results?");
            }
        }
    }
}
