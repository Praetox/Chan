using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace triforce {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Stop();
            string wut = textBox1.Text;
            if (wut == "") return;
            wut = format(wut).Replace("\r\n", "<br />\r\n");
            Clipboard.Clear(); Clipboard.SetText(wut);
        }
        private string format(string wut) {
            wut = wut.Replace("w", "▲");
            wut = wut.Replace(".", "­"); //240
            wut = wut.Replace("1", " "); //255
            wut = wut.Replace("-", "" + (char)0x3000);
            return wut;
        }

        private void button1_Click(object sender, EventArgs e) {
            string wut = textBox1.Text;
            System.IO.File.WriteAllText("triforce_a.txt", wut, Encoding.UTF8);
            wut = format(wut);
            System.IO.File.WriteAllText("triforce_b.txt", wut, Encoding.UTF8);
        }
    }
}
