namespace SciDBomb
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCharCount = new System.Windows.Forms.TextBox();
            this.radNumbers = new System.Windows.Forms.RadioButton();
            this.radChars = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThreads = new System.Windows.Forms.TextBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbRequested = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbRequesting = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbFailed = new System.Windows.Forms.Label();
            this.lbDownloaded = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbDownloading = new System.Windows.Forms.Label();
            this.lbConnecting = new System.Windows.Forms.Label();
            this.lbIdle = new System.Windows.Forms.Label();
            this.lbTotalThreads = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tThreadState = new System.Windows.Forms.Timer(this.components);
            this.tDownload = new System.Windows.Forms.Timer(this.components);
            this.tCleanup = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.GetIP_IP = new System.Windows.Forms.TextBox();
            this.GetIP_Go = new System.Windows.Forms.Button();
            this.GetIP_URL = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target URL";
            // 
            // txtURL
            // 
            this.txtURL.FormattingEnabled = true;
            this.txtURL.Items.AddRange(new object[] {
            "http://www.scientologytoday.org/subscribe/subscribe_action.vm?action=subscribe&ma" +
                "il=lulz@lulz.lulz&givenname=for%20great%20justice&cacheBreaker=1337",
            "http://www.scientology.org/html/en_US/feature/search/index.html?query=#rand#+&ind" +
                "ex=cos%2Ccos_rtc&go.x=16&go.y=13"});
            this.txtURL.Location = new System.Drawing.Point(6, 19);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(602, 21);
            this.txtURL.TabIndex = 0;
            this.txtURL.Text = "http://www.scientology.org/html/en_US/feature/search/index.html?query=#rand#+&ind" +
                "ex=cos%2Ccos_rtc&go.x=16&go.y=13";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCharCount);
            this.groupBox2.Controls.Add(this.radNumbers);
            this.groupBox2.Controls.Add(this.radChars);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(84, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "#rand#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "x";
            // 
            // txtCharCount
            // 
            this.txtCharCount.Location = new System.Drawing.Point(24, 71);
            this.txtCharCount.Name = "txtCharCount";
            this.txtCharCount.Size = new System.Drawing.Size(54, 20);
            this.txtCharCount.TabIndex = 2;
            this.txtCharCount.Text = "16";
            // 
            // radNumbers
            // 
            this.radNumbers.AutoSize = true;
            this.radNumbers.Location = new System.Drawing.Point(6, 42);
            this.radNumbers.Name = "radNumbers";
            this.radNumbers.Size = new System.Drawing.Size(67, 17);
            this.radNumbers.TabIndex = 3;
            this.radNumbers.Text = "Numbers";
            this.radNumbers.UseVisualStyleBackColor = true;
            // 
            // radChars
            // 
            this.radChars.AutoSize = true;
            this.radChars.Checked = true;
            this.radChars.Location = new System.Drawing.Point(6, 19);
            this.radChars.Name = "radChars";
            this.radChars.Size = new System.Drawing.Size(76, 17);
            this.radChars.TabIndex = 2;
            this.radChars.TabStop = true;
            this.radChars.Text = "Characters";
            this.radChars.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtTimeout);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtThreads);
            this.groupBox3.Location = new System.Drawing.Point(102, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(68, 97);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Power";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Timeout";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(6, 71);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(56, 20);
            this.txtTimeout.TabIndex = 5;
            this.txtTimeout.Text = "15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Threads";
            // 
            // txtThreads
            // 
            this.txtThreads.Location = new System.Drawing.Point(6, 32);
            this.txtThreads.Name = "txtThreads";
            this.txtThreads.Size = new System.Drawing.Size(56, 20);
            this.txtThreads.TabIndex = 3;
            this.txtThreads.Text = "10";
            // 
            // cmdStart
            // 
            this.cmdStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdStart.Location = new System.Drawing.Point(176, 63);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(450, 258);
            this.cmdStart.TabIndex = 3;
            this.cmdStart.Text = "S T A R T\r\n\r\n B O M B I N G";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbRequested);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.lbRequesting);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.lbFailed);
            this.groupBox4.Controls.Add(this.lbDownloaded);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.lbDownloading);
            this.groupBox4.Controls.Add(this.lbConnecting);
            this.groupBox4.Controls.Add(this.lbIdle);
            this.groupBox4.Controls.Add(this.lbTotalThreads);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(12, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 142);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thread status";
            // 
            // lbRequested
            // 
            this.lbRequested.Location = new System.Drawing.Point(82, 107);
            this.lbRequested.Name = "lbRequested";
            this.lbRequested.Size = new System.Drawing.Size(70, 13);
            this.lbRequested.TabIndex = 17;
            this.lbRequested.Text = "Not started";
            this.lbRequested.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Requested";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbRequesting
            // 
            this.lbRequesting.Location = new System.Drawing.Point(82, 55);
            this.lbRequesting.Name = "lbRequesting";
            this.lbRequesting.Size = new System.Drawing.Size(70, 13);
            this.lbRequesting.TabIndex = 15;
            this.lbRequesting.Text = "Not started";
            this.lbRequesting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Requesting";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbFailed
            // 
            this.lbFailed.Location = new System.Drawing.Point(82, 120);
            this.lbFailed.Name = "lbFailed";
            this.lbFailed.Size = new System.Drawing.Size(70, 13);
            this.lbFailed.TabIndex = 13;
            this.lbFailed.Text = "Not started";
            this.lbFailed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDownloaded
            // 
            this.lbDownloaded.Location = new System.Drawing.Point(82, 94);
            this.lbDownloaded.Name = "lbDownloaded";
            this.lbDownloaded.Size = new System.Drawing.Size(70, 13);
            this.lbDownloaded.TabIndex = 12;
            this.lbDownloaded.Text = "Not started";
            this.lbDownloaded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(82, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 11;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDownloading
            // 
            this.lbDownloading.Location = new System.Drawing.Point(82, 68);
            this.lbDownloading.Name = "lbDownloading";
            this.lbDownloading.Size = new System.Drawing.Size(70, 13);
            this.lbDownloading.TabIndex = 10;
            this.lbDownloading.Text = "Not started";
            this.lbDownloading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbConnecting
            // 
            this.lbConnecting.Location = new System.Drawing.Point(82, 42);
            this.lbConnecting.Name = "lbConnecting";
            this.lbConnecting.Size = new System.Drawing.Size(70, 13);
            this.lbConnecting.TabIndex = 9;
            this.lbConnecting.Text = "Not started";
            this.lbConnecting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIdle
            // 
            this.lbIdle.Location = new System.Drawing.Point(82, 29);
            this.lbIdle.Name = "lbIdle";
            this.lbIdle.Size = new System.Drawing.Size(70, 13);
            this.lbIdle.TabIndex = 8;
            this.lbIdle.Text = "Not started";
            this.lbIdle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTotalThreads
            // 
            this.lbTotalThreads.Location = new System.Drawing.Point(82, 16);
            this.lbTotalThreads.Name = "lbTotalThreads";
            this.lbTotalThreads.Size = new System.Drawing.Size(70, 13);
            this.lbTotalThreads.TabIndex = 7;
            this.lbTotalThreads.Text = "Not started";
            this.lbTotalThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Failed";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Downloaded";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 4;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Downloading";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Connecting";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Idle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total count";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tThreadState
            // 
            this.tThreadState.Interval = 10;
            this.tThreadState.Tick += new System.EventHandler(this.tThreadState_Tick);
            // 
            // tDownload
            // 
            this.tDownload.Interval = 10;
            this.tDownload.Tick += new System.EventHandler(this.tDownload_Tick);
            // 
            // tCleanup
            // 
            this.tCleanup.Enabled = true;
            this.tCleanup.Interval = 10000;
            this.tCleanup.Tick += new System.EventHandler(this.tCleanup_Tick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "www.Praetox.com";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.GetIP_IP);
            this.groupBox5.Controls.Add(this.GetIP_Go);
            this.groupBox5.Controls.Add(this.GetIP_URL);
            this.groupBox5.Location = new System.Drawing.Point(680, 40);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 100);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Find IP";
            // 
            // GetIP_IP
            // 
            this.GetIP_IP.Location = new System.Drawing.Point(6, 47);
            this.GetIP_IP.Name = "GetIP_IP";
            this.GetIP_IP.Size = new System.Drawing.Size(100, 20);
            this.GetIP_IP.TabIndex = 2;
            // 
            // GetIP_Go
            // 
            this.GetIP_Go.Location = new System.Drawing.Point(119, 19);
            this.GetIP_Go.Name = "GetIP_Go";
            this.GetIP_Go.Size = new System.Drawing.Size(75, 23);
            this.GetIP_Go.TabIndex = 1;
            this.GetIP_Go.Text = "button1";
            this.GetIP_Go.UseVisualStyleBackColor = true;
            this.GetIP_Go.Click += new System.EventHandler(this.GetIP_Go_Click);
            // 
            // GetIP_URL
            // 
            this.GetIP_URL.Location = new System.Drawing.Point(6, 21);
            this.GetIP_URL.Name = "GetIP_URL";
            this.GetIP_URL.Size = new System.Drawing.Size(100, 20);
            this.GetIP_URL.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 333);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "OhLawds v";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radChars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCharCount;
        private System.Windows.Forms.RadioButton radNumbers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThreads;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbFailed;
        private System.Windows.Forms.Label lbDownloaded;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbDownloading;
        private System.Windows.Forms.Label lbConnecting;
        private System.Windows.Forms.Label lbIdle;
        private System.Windows.Forms.Label lbTotalThreads;
        private System.Windows.Forms.Timer tThreadState;
        private System.Windows.Forms.Label lbRequesting;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer tDownload;
        private System.Windows.Forms.Timer tCleanup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbRequested;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox txtURL;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox GetIP_IP;
        private System.Windows.Forms.Button GetIP_Go;
        private System.Windows.Forms.TextBox GetIP_URL;
    }
}

