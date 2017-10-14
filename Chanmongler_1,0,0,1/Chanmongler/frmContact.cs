using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Chanmongler
{
    public partial class frmContact : Form
    {
        public frmContact()
        {
            InitializeComponent();
        }

        string std;

        private void cmdSend_Click(object sender, EventArgs e)
        {
            if (txtBody.Text == std)
            {
                MessageBox.Show(
                    "Even though the default message perfectly represents your feelings...\n\n" +
                    "Atleast change it a little bit. It'll be more fun to read then. ^^", "Lolwut");
                return;
            }
            if (txtMail.Text == "@hotmail.com")
            {
                if (DialogResult.No == MessageBox.Show(
                    "If you don't enter a real email address, I won't be able to answer.\r\n\r\n" +
                    "Are you sure you wanna send?", "Lolwut", MessageBoxButtons.YesNo)) return;
            }

            cmdSend.Enabled = false;
            WebBrowser wb = new WebBrowser();
            wb.Navigate("about:blank"); Application.DoEvents();

            try
            {
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
            catch
            {
                MessageBox.Show("Message could not be sent." +
                                "\r\n\r\n" + 
                                "My website is down, lol");
            }
        }

        private void frmContact_Load(object sender, EventArgs e)
        {
            std = txtBody.Text;
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            frmMain.bBoardUnlocked = true;
            this.Dispose();
        }
    }
}
