using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chanmongler
{
    public partial class frmNews : Form
    {
        public frmNews()
        {
            InitializeComponent();
        }

        string DownloadError;

        private void frmNews_Load(object sender, EventArgs e)
        {
            DownloadError = txtNews.Text;
            txtNews.Text = "Downloading news...";
            this.Show(); Application.DoEvents();

            try
            {
                txtNews.Text = new System.Net.WebClient().DownloadString(
                    frmMain.PrgDomain + "Chanmongler_news.php");
                txtNews.SelectionStart = 0;
                txtNews.SelectionLength = 0;
            }
            catch
            {
                txtNews.Text = DownloadError;
                txtNews.SelectionStart = 0;
                txtNews.SelectionLength = 0;
            }
        }
    }
}
