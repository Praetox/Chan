using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class frmTags : Form {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public frmTags(string sURL) {
            InitializeComponent();
            this.Text += sURL;
        }
        public string ssub, sgen, ssrc, schr, sart;
        private void frmTags_Load(object sender, EventArgs e) {
            SetForegroundWindow(this.Handle);
            this.Show(); sub.Focus();
        }

        private void sub_KeyUp(object sender, KeyEventArgs e) {
            key(true, e);
        }
        private void gen_KeyUp(object sender, KeyEventArgs e) {
            key(false, e);
        }
        private void src_KeyUp(object sender, KeyEventArgs e) {
            key(false, e);
        }
        private void chr_KeyUp(object sender, KeyEventArgs e) {
            key(false, e);
        }
        private void art_KeyUp(object sender, KeyEventArgs e) {
            key(false, e);
        }
        void key(bool bsub, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.Close(); return;
            }
            Application.DoEvents();
            if (!bsub) {
                sgen = gen.Text; ssrc = src.Text;
                schr = chr.Text; sart = art.Text;
                if (z.cfg.bTagsToPath) {
                    if (sgen == "") sgen = "-";
                    if (ssrc == "") ssrc = "-";
                    if (schr == "") schr = "-";
                    if (sart == "") sart = "-";
                    sub.Text = sart + "\\" + ssrc +
                        "\\" + schr + "\\" + sgen;
                }
            }
            ssub = sub.Text;
        }

        private void go_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
