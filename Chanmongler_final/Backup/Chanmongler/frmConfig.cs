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
    public partial class frmConfig : Form {
        public frmConfig(Config cfg) {
            InitializeComponent();
            this.cfg = cfg;
        }
        Config cfg;
        string defPath = "Saving images to own directory.";

        private void frmConfig_Load(object sender, EventArgs e) {
            string sAppPath = Application.StartupPath;
            if (!sAppPath.EndsWith("\\")) sAppPath += "\\";

            cbSubfolder_Site.Checked = cfg.bSubfolder_Site;
            cbSubfolder_Thread.Checked = cfg.bSubfolder_Thread;
            cbPrefix_Board.Checked = cfg.bPrefix_Board;
            cbPrefix_Thread.Checked = cfg.bPrefix_Thread;

            cbTagsToPath.Checked = cfg.bTagsToPath;
            cbTagsOnAdd.Checked = cfg.bTagOnAdd;
            cbHtmlSave.Checked = cfg.bHtmlSave;
            cbHtmlLocal.Checked = cfg.bHtmlLocal;
            
            cbPath_MoveDead.Checked = cfg.bMoveDead;
            cbHotkeys.Checked = cfg.bHotkeys;
            cbAutosave.Checked = cfg.bAutosave;
            cbTrayMessages.Checked = cfg.bTrayMessages;
            cbWhenDone_Alert.Checked = cfg.bWhenDone_Alert;
            cbWhenDone_Exit.Checked = cfg.bWhenDone_Exit;

            if (cfg.iPerf_Threads > 1)
                txPerf_Threads.Text = cfg.iPerf_Threads + "";
            cbPerf_Threads.Checked = (cfg.iPerf_Threads > 1);
            if (cfg.iAuto_Check >= 0)
                txAuto_Check.Text = cfg.iAuto_Check + "";
            cbAuto_Check.Checked = (cfg.iAuto_Check >= 0);
            if (cfg.iError_Retry >= 0)
                txError_Retries.Text = cfg.iError_Retry + "";
            cbError_Retry.Checked = (cfg.iError_Retry >= 0);

            if (cfg.sPath == sAppPath)
                lbPath_Path.Text = defPath;
            else lbPath_Path.Text = cfg.sPath;
        }
        private void ControlsToCfg() {
            string sAppPath = Application.StartupPath;
            if (!sAppPath.EndsWith("\\")) sAppPath += "\\";

            if ((cbPerf_Threads.Checked && !z.OnlyContains(txPerf_Threads.Text, "1234567890")) ||
                (cbAuto_Check.Checked && !z.OnlyContains(txAuto_Check.Text, "1234567890"))) {
                MessageBox.Show("The following text fields may" + "\r\n" +
                    "only contain characters 0 to 9." + "\r\n\r\n" +
                    "Multiple simultaneous downloads" + "\r\n" +
                    "Check for new files (variable multiplier)",
                    "Could not save settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            cfg.bSubfolder_Site = cbSubfolder_Site.Checked;
            cfg.bSubfolder_Thread = cbSubfolder_Thread.Checked;
            cfg.bPrefix_Board = cbPrefix_Board.Checked;
            cfg.bPrefix_Thread = cbPrefix_Thread.Checked;

            cfg.bTagsToPath = cbTagsToPath.Checked;
            cfg.bTagOnAdd = cbTagsOnAdd.Checked;
            cfg.bHtmlSave = cbHtmlSave.Checked;
            cfg.bHtmlLocal = cbHtmlLocal.Checked;

            cfg.bMoveDead = cbPath_MoveDead.Checked;
            cfg.bHotkeys = cbHotkeys.Checked;
            cfg.bAutosave = cbAutosave.Checked;
            cfg.bTrayMessages = cbTrayMessages.Checked;
            cfg.bWhenDone_Alert = cbWhenDone_Alert.Checked;
            cfg.bWhenDone_Exit = cbWhenDone_Exit.Checked;

            if (cbPerf_Threads.Checked)
                cfg.iPerf_Threads = Convert
                    .ToInt32(txPerf_Threads.Text);
            else cfg.iPerf_Threads = 1;

            if (cbAuto_Check.Checked)
                cfg.iAuto_Check = Convert
                    .ToInt32(txAuto_Check.Text);
            else cfg.iPerf_Threads = -1;

            if (cbError_Retry.Checked)
                cfg.iError_Retry = Convert
                    .ToInt32(txError_Retries.Text);
            else cfg.iError_Retry = -1;
        }

        private void cActivateConfig_Click(object sender, EventArgs e) {
            if (!FuckThisShit()) return;
            ControlsToCfg(); this.Close();
        }
        private void cRememberConfig_Click(object sender, EventArgs e) {
            if (!FuckThisShit()) return;
            ControlsToCfg(); cfg.Save();
        }
        bool FuckThisShit() {
            if (!cbSubfolder_Thread.Checked &&
                cbPath_MoveDead.Checked) {
                MessageBox.Show("If you don't want subfolders for each thread," + "\r\n" +
                    "please disable \"Move dead threads to _dead\".", "Lol issues");
                return false;
            }
            if (!cbSubfolder_Thread.Checked) {
                if (DialogResult.No == MessageBox.Show(
                    "If you don't enable \"Subfolder for each thread\"," + "\r\n" +
                    "the thread thumbnail feature won't work." + "\r\n\r\n" +
                    "You sure you want that?", "Lol issues",
                    MessageBoxButtons.YesNo)) return false;
            }
            return true;
        }

        private void cmPath_Change_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            if (fbd.SelectedPath != "") {
                cfg.sPath = fbd.SelectedPath;
                cfg.sPath = cfg.sPath.Replace("/", "\\");
                if (!cfg.sPath.EndsWith("\\")) cfg.sPath += "\\";
                lbPath_Path.Text = cfg.sPath;
            }
        }
    }
}
