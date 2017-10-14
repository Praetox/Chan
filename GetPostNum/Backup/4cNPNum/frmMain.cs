using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4cNPNum
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        private void tHotkeys_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.Scroll) == -32767)
            {
                string src = new System.Net.WebClient().DownloadString(
                    "http://zip.4chan.org/a/imgboard.html");
                src = src
                    .Replace("¤", "")
                    .Replace("\" class=\"quotejs\">No.</a><a href=\"", "¤");
                string[] pa = src
                    .Substring(src.IndexOf("¤")+1)
                    .Split('¤');
                for (int a = 0; a < pa.Length; a++)
                {
                    pa[a] = pa[a]
                        .Replace("¤", "")
                        .Replace(".html#q", "¤")
                        .Split('¤')[1];
                    pa[a] = pa[a]
                        .Split('"')[0];
                }
                int iRet = 0;
                for (int a = 0; a < pa.Length; a++)
                {
                    int iTmp = Convert.ToInt32(pa[a]);
                    if (iTmp > iRet) iRet = iTmp;
                }
                iRet+=2;

                SendKeys.Send("" + iRet);
            }
        }
    }
}
