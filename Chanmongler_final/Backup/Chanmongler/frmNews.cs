using System;
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
    public partial class frmNews : Form {
        public frmNews() {
            InitializeComponent();
        }

        string DownloadError;
        private void frmNews_Load(object sender, EventArgs e) {
            DownloadError = txtNews.Text;
            txtNews.Text = "Downloading news...";
            this.Show(); Application.DoEvents();

            try {
                txtNews.Text = new System.Net.WebClient().DownloadString(
                    frmMain.PrgDomain + "Chanmongler_news.php");
                txtNews.SelectionStart = 0;
                txtNews.SelectionLength = 0;
            }
            catch {
                txtNews.Text = DownloadError;
                txtNews.SelectionStart = 0;
                txtNews.SelectionLength = 0;
            }
        }
    }
}
