namespace Chanmongler
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.cbTrayMessages = new System.Windows.Forms.CheckBox();
            this.cbWhenDone_Exit = new System.Windows.Forms.CheckBox();
            this.cbWhenDone_Alert = new System.Windows.Forms.CheckBox();
            this.cbHotkeys = new System.Windows.Forms.CheckBox();
            this.cRememberConfig = new System.Windows.Forms.Button();
            this.cbPrefix_Thread = new System.Windows.Forms.CheckBox();
            this.cbPrefix_Board = new System.Windows.Forms.CheckBox();
            this.cbSubfolder_Thread = new System.Windows.Forms.CheckBox();
            this.cbSubfolder_Site = new System.Windows.Forms.CheckBox();
            this.cActivateConfig = new System.Windows.Forms.Button();
            this.cmPath_Change = new System.Windows.Forms.Button();
            this.lbPath_Path = new System.Windows.Forms.Label();
            this.tInitiateValues = new System.Windows.Forms.Timer(this.components);
            this.cbPerf_Threads = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txPerf_Threads = new System.Windows.Forms.TextBox();
            this.cbAuto_Check = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txAuto_Check = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbPath_MoveDead = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbAutosave = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbError_Retry = new System.Windows.Forms.CheckBox();
            this.txError_Retries = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbTagsOnAdd = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTagsToPath = new System.Windows.Forms.CheckBox();
            this.cbHtmlLocal = new System.Windows.Forms.CheckBox();
            this.cbHtmlSave = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTrayMessages
            // 
            this.cbTrayMessages.AutoSize = true;
            this.cbTrayMessages.Checked = true;
            this.cbTrayMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTrayMessages.Location = new System.Drawing.Point(192, 25);
            this.cbTrayMessages.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbTrayMessages.Name = "cbTrayMessages";
            this.cbTrayMessages.Size = new System.Drawing.Size(134, 17);
            this.cbTrayMessages.TabIndex = 37;
            this.cbTrayMessages.Tag = "c5";
            this.cbTrayMessages.Text = "Show messages in tray";
            this.tTip.SetToolTip(this.cbTrayMessages, "Show those nice and helpful bubbles at the\r\nbottom right of your screen. Wait wha" +
                    "t?\r\nOn second thought, why not disable this.");
            this.cbTrayMessages.UseVisualStyleBackColor = true;
            // 
            // cbWhenDone_Exit
            // 
            this.cbWhenDone_Exit.AutoSize = true;
            this.cbWhenDone_Exit.Location = new System.Drawing.Point(192, 71);
            this.cbWhenDone_Exit.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbWhenDone_Exit.Name = "cbWhenDone_Exit";
            this.cbWhenDone_Exit.Size = new System.Drawing.Size(142, 17);
            this.cbWhenDone_Exit.TabIndex = 36;
            this.cbWhenDone_Exit.Tag = "c5";
            this.cbWhenDone_Exit.Text = "Exit when transfers finish";
            this.tTip.SetToolTip(this.cbWhenDone_Exit, "Exit application when transfers are completed");
            this.cbWhenDone_Exit.UseVisualStyleBackColor = true;
            // 
            // cbWhenDone_Alert
            // 
            this.cbWhenDone_Alert.AutoSize = true;
            this.cbWhenDone_Alert.Checked = true;
            this.cbWhenDone_Alert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWhenDone_Alert.Location = new System.Drawing.Point(192, 48);
            this.cbWhenDone_Alert.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbWhenDone_Alert.Name = "cbWhenDone_Alert";
            this.cbWhenDone_Alert.Size = new System.Drawing.Size(124, 17);
            this.cbWhenDone_Alert.TabIndex = 34;
            this.cbWhenDone_Alert.Tag = "c5";
            this.cbWhenDone_Alert.Text = "Enable audible alerts";
            this.tTip.SetToolTip(this.cbWhenDone_Alert, "Nags you with a horrible DING! whenever mongler Awesome in\r\nthe beginning, but so" +
                    "on becomes a living hell. Your funeral, mate.");
            this.cbWhenDone_Alert.UseVisualStyleBackColor = true;
            // 
            // cbHotkeys
            // 
            this.cbHotkeys.AutoSize = true;
            this.cbHotkeys.Checked = true;
            this.cbHotkeys.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHotkeys.Location = new System.Drawing.Point(20, 25);
            this.cbHotkeys.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbHotkeys.Name = "cbHotkeys";
            this.cbHotkeys.Size = new System.Drawing.Size(130, 17);
            this.cbHotkeys.TabIndex = 33;
            this.cbHotkeys.Tag = "c5";
            this.cbHotkeys.Text = "Enable global hotkeys";
            this.tTip.SetToolTip(this.cbHotkeys, "Enable hotkeys. If you uncheck this, it means\r\nyou fail at life and you should fe" +
                    "el bad.");
            this.cbHotkeys.UseVisualStyleBackColor = true;
            // 
            // cRememberConfig
            // 
            this.cRememberConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cRememberConfig.ForeColor = System.Drawing.Color.White;
            this.cRememberConfig.Location = new System.Drawing.Point(7, 7);
            this.cRememberConfig.Name = "cRememberConfig";
            this.cRememberConfig.Size = new System.Drawing.Size(174, 23);
            this.cRememberConfig.TabIndex = 19;
            this.cRememberConfig.Tag = "c3";
            this.cRememberConfig.Text = "Remember configuration";
            this.tTip.SetToolTip(this.cRememberConfig, "If you click here, Chanmongler will remember this\r\nconfiguration for years to com" +
                    "e. That is, until you\r\nchange and resave it or delete the settings.ini file.");
            this.cRememberConfig.UseVisualStyleBackColor = false;
            this.cRememberConfig.Click += new System.EventHandler(this.cRememberConfig_Click);
            // 
            // cbPrefix_Thread
            // 
            this.cbPrefix_Thread.AutoSize = true;
            this.cbPrefix_Thread.Location = new System.Drawing.Point(192, 48);
            this.cbPrefix_Thread.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbPrefix_Thread.Name = "cbPrefix_Thread";
            this.cbPrefix_Thread.Size = new System.Drawing.Size(158, 17);
            this.cbPrefix_Thread.TabIndex = 31;
            this.cbPrefix_Thread.Tag = "c5";
            this.cbPrefix_Thread.Text = "Thread ID as filename prefix";
            this.tTip.SetToolTip(this.cbPrefix_Thread, resources.GetString("cbPrefix_Thread.ToolTip"));
            this.cbPrefix_Thread.UseVisualStyleBackColor = true;
            // 
            // cbPrefix_Board
            // 
            this.cbPrefix_Board.AutoSize = true;
            this.cbPrefix_Board.Checked = true;
            this.cbPrefix_Board.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrefix_Board.Location = new System.Drawing.Point(192, 25);
            this.cbPrefix_Board.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbPrefix_Board.Name = "cbPrefix_Board";
            this.cbPrefix_Board.Size = new System.Drawing.Size(138, 17);
            this.cbPrefix_Board.TabIndex = 30;
            this.cbPrefix_Board.Tag = "c5";
            this.cbPrefix_Board.Text = "Board as filename prefix";
            this.tTip.SetToolTip(this.cbPrefix_Board, "This will add a prefix to all filenames, consisting\r\nof the board\'s \"name\". Altho" +
                    "ugh this is usually a\r\nsingle letter, it varies across *chans.\r\n\r\neg: b, w, h, e" +
                    "tc");
            this.cbPrefix_Board.UseVisualStyleBackColor = true;
            // 
            // cbSubfolder_Thread
            // 
            this.cbSubfolder_Thread.AutoSize = true;
            this.cbSubfolder_Thread.Checked = true;
            this.cbSubfolder_Thread.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubfolder_Thread.Location = new System.Drawing.Point(20, 48);
            this.cbSubfolder_Thread.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbSubfolder_Thread.Name = "cbSubfolder_Thread";
            this.cbSubfolder_Thread.Size = new System.Drawing.Size(146, 17);
            this.cbSubfolder_Thread.TabIndex = 29;
            this.cbSubfolder_Thread.Tag = "c5";
            this.cbSubfolder_Thread.Text = "Subfolder for each thread";
            this.tTip.SetToolTip(this.cbSubfolder_Thread, "This will create one folder for each thread.\r\nIf the site-box (above this one) is" +
                    " ticked, this\r\nfolder will naturally appear within the site folder.\r\n\r\neg: b-862" +
                    "741, w-74829 etc");
            this.cbSubfolder_Thread.UseVisualStyleBackColor = true;
            // 
            // cbSubfolder_Site
            // 
            this.cbSubfolder_Site.AutoSize = true;
            this.cbSubfolder_Site.Checked = true;
            this.cbSubfolder_Site.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSubfolder_Site.Location = new System.Drawing.Point(20, 25);
            this.cbSubfolder_Site.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbSubfolder_Site.Name = "cbSubfolder_Site";
            this.cbSubfolder_Site.Size = new System.Drawing.Size(132, 17);
            this.cbSubfolder_Site.TabIndex = 28;
            this.cbSubfolder_Site.Tag = "c5";
            this.cbSubfolder_Site.Text = "Subfolder for each site";
            this.tTip.SetToolTip(this.cbSubfolder_Site, "This will create one folder for each site.\r\n\r\neg: 4chan, 711chan etc");
            this.cbSubfolder_Site.UseVisualStyleBackColor = true;
            // 
            // cActivateConfig
            // 
            this.cActivateConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cActivateConfig.ForeColor = System.Drawing.Color.White;
            this.cActivateConfig.Location = new System.Drawing.Point(187, 7);
            this.cActivateConfig.Name = "cActivateConfig";
            this.cActivateConfig.Size = new System.Drawing.Size(174, 23);
            this.cActivateConfig.TabIndex = 27;
            this.cActivateConfig.Tag = "c3";
            this.cActivateConfig.Text = "Activate configuration";
            this.tTip.SetToolTip(this.cActivateConfig, "Activates the configuration without saving it. Remember\r\nthat this won\'t affect t" +
                    "he performance options.");
            this.cActivateConfig.UseVisualStyleBackColor = false;
            this.cActivateConfig.Click += new System.EventHandler(this.cActivateConfig_Click);
            // 
            // cmPath_Change
            // 
            this.cmPath_Change.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmPath_Change.ForeColor = System.Drawing.Color.White;
            this.cmPath_Change.Location = new System.Drawing.Point(7, 59);
            this.cmPath_Change.Name = "cmPath_Change";
            this.cmPath_Change.Size = new System.Drawing.Size(354, 23);
            this.cmPath_Change.TabIndex = 38;
            this.cmPath_Change.Tag = "c3";
            this.cmPath_Change.Text = "Change directory";
            this.tTip.SetToolTip(this.cmPath_Change, "If you don\'t want your images to land in mongler\'s\r\nown folder, click here to set" +
                    " your own target.");
            this.cmPath_Change.UseVisualStyleBackColor = false;
            this.cmPath_Change.Click += new System.EventHandler(this.cmPath_Change_Click);
            // 
            // lbPath_Path
            // 
            this.lbPath_Path.ForeColor = System.Drawing.Color.White;
            this.lbPath_Path.Location = new System.Drawing.Point(7, 22);
            this.lbPath_Path.Name = "lbPath_Path";
            this.lbPath_Path.Size = new System.Drawing.Size(354, 34);
            this.lbPath_Path.TabIndex = 26;
            this.lbPath_Path.Tag = "c5";
            this.lbPath_Path.Text = "Saving images to own directory.";
            this.lbPath_Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tInitiateValues
            // 
            this.tInitiateValues.Enabled = true;
            this.tInitiateValues.Interval = 1;
            // 
            // cbPerf_Threads
            // 
            this.cbPerf_Threads.AutoSize = true;
            this.cbPerf_Threads.Checked = true;
            this.cbPerf_Threads.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPerf_Threads.Location = new System.Drawing.Point(21, 25);
            this.cbPerf_Threads.Margin = new System.Windows.Forms.Padding(16, 3, 3, 9);
            this.cbPerf_Threads.Name = "cbPerf_Threads";
            this.cbPerf_Threads.Size = new System.Drawing.Size(180, 17);
            this.cbPerf_Threads.TabIndex = 38;
            this.cbPerf_Threads.Tag = "c5";
            this.cbPerf_Threads.Text = "Multiple simultaneous downloads";
            this.tTip.SetToolTip(this.cbPerf_Threads, "This vastly increases speed on most sites, but\r\na few hosts have decided to block" +
                    " this using varying\r\nmeans. If your downloads get raep\'d, uncheck this.");
            this.cbPerf_Threads.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(7, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(354, 28);
            this.label4.TabIndex = 38;
            this.label4.Tag = "c4";
            this.label4.Text = "Press \"Remember configuration\" after changing this value.\r\nYou must restart Chanm" +
                "ongler for the change to take effect.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txPerf_Threads
            // 
            this.txPerf_Threads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txPerf_Threads.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txPerf_Threads.ForeColor = System.Drawing.Color.White;
            this.txPerf_Threads.Location = new System.Drawing.Point(277, 22);
            this.txPerf_Threads.Name = "txPerf_Threads";
            this.txPerf_Threads.Size = new System.Drawing.Size(84, 20);
            this.txPerf_Threads.TabIndex = 37;
            this.txPerf_Threads.Tag = "c1";
            this.txPerf_Threads.Text = "6";
            this.tTip.SetToolTip(this.txPerf_Threads, "The maximum amount of downloads at any given time.\r\nDon\'t set it too high, as you" +
                    " won\'t earn anything on it.\r\n\'sides, too high values here rapes the chan\'s serve" +
                    "r. :(");
            // 
            // cbAuto_Check
            // 
            this.cbAuto_Check.AutoSize = true;
            this.cbAuto_Check.Checked = true;
            this.cbAuto_Check.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAuto_Check.Location = new System.Drawing.Point(21, 25);
            this.cbAuto_Check.Margin = new System.Windows.Forms.Padding(16, 3, 3, 9);
            this.cbAuto_Check.Name = "cbAuto_Check";
            this.cbAuto_Check.Size = new System.Drawing.Size(196, 17);
            this.cbAuto_Check.TabIndex = 38;
            this.cbAuto_Check.Tag = "c5";
            this.cbAuto_Check.Text = "Check for new files every x seconds";
            this.tTip.SetToolTip(this.cbAuto_Check, "Why press Alt+3 manually all the time?");
            this.cbAuto_Check.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(7, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(354, 28);
            this.label8.TabIndex = 38;
            this.label8.Tag = "c4";
            this.label8.Text = "The lower limit is the number of threads added, multiplied by 10 seconds.\r\n3 thre" +
                "ads would mean 30 seconds, while 12 threads = 2 minutes.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txAuto_Check
            // 
            this.txAuto_Check.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txAuto_Check.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txAuto_Check.ForeColor = System.Drawing.Color.White;
            this.txAuto_Check.Location = new System.Drawing.Point(277, 22);
            this.txAuto_Check.Name = "txAuto_Check";
            this.txAuto_Check.Size = new System.Drawing.Size(84, 20);
            this.txAuto_Check.TabIndex = 37;
            this.txAuto_Check.Tag = "c1";
            this.txAuto_Check.Text = "300";
            this.tTip.SetToolTip(this.txAuto_Check, "If you wish to autoget at a higher interval\r\nthan the minimum, then please go ahe" +
                    "ad.");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbPath_MoveDead);
            this.panel2.Controls.Add(this.cmPath_Change);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lbPath_Path);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(15, 15);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(370, 114);
            this.panel2.TabIndex = 54;
            this.panel2.Tag = "c2";
            // 
            // cbPath_MoveDead
            // 
            this.cbPath_MoveDead.AutoSize = true;
            this.cbPath_MoveDead.Checked = true;
            this.cbPath_MoveDead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPath_MoveDead.Location = new System.Drawing.Point(7, 88);
            this.cbPath_MoveDead.Name = "cbPath_MoveDead";
            this.cbPath_MoveDead.Size = new System.Drawing.Size(220, 17);
            this.cbPath_MoveDead.TabIndex = 39;
            this.cbPath_MoveDead.Tag = "c5";
            this.cbPath_MoveDead.Text = "Move dead threads to the \"_dead\" folder";
            this.tTip.SetToolTip(this.cbPath_MoveDead, "When threads die, they are moved for sorting purposes.");
            this.cbPath_MoveDead.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(7, 4);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(354, 15);
            this.label11.TabIndex = 35;
            this.label11.Tag = "c4";
            this.label11.Text = "Storage path";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbSubfolder_Site);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cbSubfolder_Thread);
            this.panel1.Controls.Add(this.cbPrefix_Thread);
            this.panel1.Controls.Add(this.cbPrefix_Board);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(15, 141);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(370, 74);
            this.panel1.TabIndex = 55;
            this.panel1.Tag = "c2";
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(7, 4);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(354, 15);
            this.label10.TabIndex = 35;
            this.label10.Tag = "c4";
            this.label10.Text = "Naming convention";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cbAutosave);
            this.panel3.Controls.Add(this.cbTrayMessages);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.cbWhenDone_Exit);
            this.panel3.Controls.Add(this.cbWhenDone_Alert);
            this.panel3.Controls.Add(this.cbHotkeys);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(15, 227);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(370, 97);
            this.panel3.TabIndex = 56;
            this.panel3.Tag = "c2";
            // 
            // cbAutosave
            // 
            this.cbAutosave.AutoSize = true;
            this.cbAutosave.Checked = true;
            this.cbAutosave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutosave.Location = new System.Drawing.Point(20, 48);
            this.cbAutosave.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbAutosave.Name = "cbAutosave";
            this.cbAutosave.Size = new System.Drawing.Size(119, 17);
            this.cbAutosave.TabIndex = 38;
            this.cbAutosave.Tag = "c5";
            this.cbAutosave.Text = "Autosave thread list";
            this.tTip.SetToolTip(this.cbAutosave, "Saves the threadlist after each download session.");
            this.cbAutosave.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(7, 4);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(354, 15);
            this.label12.TabIndex = 35;
            this.label12.Tag = "c4";
            this.label12.Text = "General configuration";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.cbPerf_Threads);
            this.panel4.Controls.Add(this.txPerf_Threads);
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(397, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(6);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4);
            this.panel4.Size = new System.Drawing.Size(370, 91);
            this.panel4.TabIndex = 57;
            this.panel4.Tag = "c2";
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.Location = new System.Drawing.Point(7, 4);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(354, 15);
            this.label13.TabIndex = 35;
            this.label13.Tag = "c4";
            this.label13.Text = "Performance configuration";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cbAuto_Check);
            this.panel5.Controls.Add(this.txAuto_Check);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.label8);
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(397, 118);
            this.panel5.Margin = new System.Windows.Forms.Padding(6);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(4);
            this.panel5.Size = new System.Drawing.Size(370, 91);
            this.panel5.TabIndex = 58;
            this.panel5.Tag = "c2";
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.Color.Silver;
            this.label15.Location = new System.Drawing.Point(7, 4);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(354, 15);
            this.label15.TabIndex = 35;
            this.label15.Tag = "c4";
            this.label15.Text = "Automation configuration";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.cRememberConfig);
            this.panel6.Controls.Add(this.cActivateConfig);
            this.panel6.ForeColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(397, 371);
            this.panel6.Margin = new System.Windows.Forms.Padding(6);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(4);
            this.panel6.Size = new System.Drawing.Size(370, 39);
            this.panel6.TabIndex = 59;
            this.panel6.Tag = "c2";
            // 
            // cbError_Retry
            // 
            this.cbError_Retry.AutoSize = true;
            this.cbError_Retry.Checked = true;
            this.cbError_Retry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbError_Retry.Location = new System.Drawing.Point(21, 25);
            this.cbError_Retry.Margin = new System.Windows.Forms.Padding(16, 3, 3, 9);
            this.cbError_Retry.Name = "cbError_Retry";
            this.cbError_Retry.Size = new System.Drawing.Size(208, 17);
            this.cbError_Retry.TabIndex = 38;
            this.cbError_Retry.Tag = "c5";
            this.cbError_Retry.Text = "Do x retries on server error (empty files)";
            this.tTip.SetToolTip(this.cbError_Retry, "Will try to redownload blank files.\r\nIf no luck, file gets baleeted.");
            this.cbError_Retry.UseVisualStyleBackColor = true;
            // 
            // txError_Retries
            // 
            this.txError_Retries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txError_Retries.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txError_Retries.ForeColor = System.Drawing.Color.White;
            this.txError_Retries.Location = new System.Drawing.Point(277, 22);
            this.txError_Retries.Name = "txError_Retries";
            this.txError_Retries.Size = new System.Drawing.Size(84, 20);
            this.txError_Retries.TabIndex = 37;
            this.txError_Retries.Tag = "c1";
            this.txError_Retries.Text = "3";
            this.tTip.SetToolTip(this.txError_Retries, "If you wish to autoget at a higher interval\r\nthan the minimum, then please go ahe" +
                    "ad.");
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.checkBox1);
            this.panel7.Controls.Add(this.cbError_Retry);
            this.panel7.Controls.Add(this.txError_Retries);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.label19);
            this.panel7.ForeColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(397, 221);
            this.panel7.Margin = new System.Windows.Forms.Padding(6);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(4);
            this.panel7.Size = new System.Drawing.Size(370, 109);
            this.panel7.TabIndex = 60;
            this.panel7.Tag = "c2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(20, 83);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(16, 4, 3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(310, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Tag = "c5";
            this.checkBox1.Text = "Assume that truncated files are corrupted (...they usually are)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(7, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(354, 15);
            this.label9.TabIndex = 35;
            this.label9.Tag = "c4";
            this.label9.Text = "Error handling";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.Color.Silver;
            this.label19.Location = new System.Drawing.Point(7, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(354, 28);
            this.label19.TabIndex = 38;
            this.label19.Tag = "c4";
            this.label19.Text = "Sometimes the server might shit itself and send you a blank file.\r\nEnable to kill" +
                " off 0kb files  (this is why we can have nice things).";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cbTagsOnAdd);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.cbTagsToPath);
            this.panel8.Controls.Add(this.cbHtmlLocal);
            this.panel8.Controls.Add(this.cbHtmlSave);
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(15, 336);
            this.panel8.Margin = new System.Windows.Forms.Padding(6);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(4);
            this.panel8.Size = new System.Drawing.Size(370, 74);
            this.panel8.TabIndex = 61;
            this.panel8.Tag = "c2";
            // 
            // cbTagsOnAdd
            // 
            this.cbTagsOnAdd.AutoSize = true;
            this.cbTagsOnAdd.Checked = true;
            this.cbTagsOnAdd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTagsOnAdd.Location = new System.Drawing.Point(20, 25);
            this.cbTagsOnAdd.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbTagsOnAdd.Name = "cbTagsOnAdd";
            this.cbTagsOnAdd.Size = new System.Drawing.Size(141, 17);
            this.cbTagsOnAdd.TabIndex = 28;
            this.cbTagsOnAdd.Tag = "c5";
            this.cbTagsOnAdd.Text = "Ask for subfolder on add";
            this.tTip.SetToolTip(this.cbTagsOnAdd, "When you add a thread, it\r\nwill ask you for a subfolder.");
            this.cbTagsOnAdd.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 15);
            this.label1.TabIndex = 35;
            this.label1.Tag = "c4";
            this.label1.Text = "Thread organizing";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbTagsToPath
            // 
            this.cbTagsToPath.AutoSize = true;
            this.cbTagsToPath.Checked = true;
            this.cbTagsToPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTagsToPath.Location = new System.Drawing.Point(20, 48);
            this.cbTagsToPath.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbTagsToPath.Name = "cbTagsToPath";
            this.cbTagsToPath.Size = new System.Drawing.Size(130, 17);
            this.cbTagsToPath.TabIndex = 29;
            this.cbTagsToPath.Tag = "c5";
            this.cbTagsToPath.Text = "Folders based on tags";
            this.tTip.SetToolTip(this.cbTagsToPath, "Checked: Threads are put in subfolders based on entered tags.\r\nUnchecked: Entered" +
                    " tags are stored (CSV-formatted) in tags.txt");
            this.cbTagsToPath.UseVisualStyleBackColor = true;
            // 
            // cbHtmlLocal
            // 
            this.cbHtmlLocal.AutoSize = true;
            this.cbHtmlLocal.Checked = true;
            this.cbHtmlLocal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHtmlLocal.Location = new System.Drawing.Point(192, 48);
            this.cbHtmlLocal.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbHtmlLocal.Name = "cbHtmlLocal";
            this.cbHtmlLocal.Size = new System.Drawing.Size(119, 17);
            this.cbHtmlLocal.TabIndex = 31;
            this.cbHtmlLocal.Tag = "c5";
            this.cbHtmlLocal.Text = "Localize HTML files";
            this.tTip.SetToolTip(this.cbHtmlLocal, "HTML files are modified to display thumbnails.");
            this.cbHtmlLocal.UseVisualStyleBackColor = true;
            // 
            // cbHtmlSave
            // 
            this.cbHtmlSave.AutoSize = true;
            this.cbHtmlSave.Checked = true;
            this.cbHtmlSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHtmlSave.Location = new System.Drawing.Point(192, 25);
            this.cbHtmlSave.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.cbHtmlSave.Name = "cbHtmlSave";
            this.cbHtmlSave.Size = new System.Drawing.Size(105, 17);
            this.cbHtmlSave.TabIndex = 30;
            this.cbHtmlSave.Tag = "c5";
            this.cbHtmlSave.Text = "Save HTML files";
            this.tTip.SetToolTip(this.cbHtmlSave, "The thread html\'s are saved to thread directory.");
            this.cbHtmlSave.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(394, 344);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 15);
            this.label2.TabIndex = 62;
            this.label2.Tag = "c4";
            this.label2.Text = "Colour themes removed due to aids.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(782, 425);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chanmongler - Config";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cRememberConfig;
        private System.Windows.Forms.CheckBox cbTrayMessages;
        private System.Windows.Forms.CheckBox cbWhenDone_Exit;
        private System.Windows.Forms.CheckBox cbWhenDone_Alert;
        private System.Windows.Forms.CheckBox cbHotkeys;
        private System.Windows.Forms.CheckBox cbPrefix_Thread;
        private System.Windows.Forms.CheckBox cbPrefix_Board;
        private System.Windows.Forms.CheckBox cbSubfolder_Thread;
        private System.Windows.Forms.CheckBox cbSubfolder_Site;
        private System.Windows.Forms.Button cActivateConfig;
        private System.Windows.Forms.Label lbPath_Path;
        private System.Windows.Forms.Button cmPath_Change;
        private System.Windows.Forms.Timer tInitiateValues;
        private System.Windows.Forms.TextBox txPerf_Threads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbPerf_Threads;
        private System.Windows.Forms.CheckBox cbAuto_Check;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txAuto_Check;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox cbError_Retry;
        private System.Windows.Forms.TextBox txError_Retries;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox cbPath_MoveDead;
        private System.Windows.Forms.CheckBox cbAutosave;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox cbTagsOnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbTagsToPath;
        private System.Windows.Forms.CheckBox cbHtmlLocal;
        private System.Windows.Forms.CheckBox cbHtmlSave;
        private System.Windows.Forms.Label label2;
    }
}