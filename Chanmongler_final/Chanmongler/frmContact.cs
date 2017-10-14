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
    public partial class frmContact : Form {
        public frmContact() {
            InitializeComponent();
        }

        string std;

        private void frmContact_Load(object sender, EventArgs e) {
            std = txtBody.Text;
        }

        private void cmdSend_Click(object sender, EventArgs e) {
            if (txtBody.Text == std) {
                MessageBox.Show(
                    "You didn't change the default message." + "\r\n" +
                    "Your actions makes no sense.", "Lolwut");
                return;
            }
            if (txtMail.Text == "@hotmail.com" || txtMail.Text == "") {
                if (DialogResult.No == MessageBox.Show(
                    "If you don't enter a real email address, I won't be able to answer.\r\n\r\n" +
                    "Are you sure you wanna stay anonymous?", "Lolwut", MessageBoxButtons.YesNo)) return;
            }

            cmdSend.Enabled = false;
            WebBrowser wb = new WebBrowser();
            wb.Navigate("about:blank"); Application.DoEvents();

            try {
                wb.Navigate(frmMain.PrgDomain + "Chanmongler_msg.php"); Application.DoEvents();
                while (wb.IsBusy) { Application.DoEvents(); System.Threading.Thread.Sleep(1); }
                wb.Document.GetElementById("mName").SetAttribute("value", txtName.Text);
                wb.Document.GetElementById("mMail").SetAttribute("value", txtMail.Text);
                wb.Document.GetElementById("mBody").SetAttribute("value", txtBody.Text);
                wb.Document.GetElementById("lulz").InvokeMember("click"); Application.DoEvents();
                while (wb.IsBusy) { Application.DoEvents(); System.Threading.Thread.Sleep(1); }
                if (!wb.DocumentText.Contains("%FUKKEN_SAVED%")) throw new Exception();
                MessageBox.Show("Your message has been sent.");
            }
            catch {
                MessageBox.Show("Message could not be sent." +
                                "\r\n\r\n" +
                                "My website is down, lol");
            }
        }
    }
}