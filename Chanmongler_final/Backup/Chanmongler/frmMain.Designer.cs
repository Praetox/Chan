namespace Chanmongler
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
            this.lstThreads = new System.Windows.Forms.ListBox();
            this.cmdThreads_Load = new System.Windows.Forms.Button();
            this.cmdThreads_Save = new System.Windows.Forms.Button();
            this.cmdThreads_Add = new System.Windows.Forms.Button();
            this.cMarkActive = new System.Windows.Forms.Button();
            this.cSearch = new System.Windows.Forms.Button();
            this.cLoadChanFiles = new System.Windows.Forms.Button();
            this.cContact = new System.Windows.Forms.Button();
            this.cHelp = new System.Windows.Forms.Button();
            this.cNews = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbRemaining = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbDownloading = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbThreads = new System.Windows.Forms.Label();
            this.cmdIterate = new System.Windows.Forms.Button();
            this.tThreadState = new System.Windows.Forms.Timer(this.components);
            this.tDownload = new System.Windows.Forms.Timer(this.components);
            this.tTip = new System.Windows.Forms.ToolTip(this.components);
            this.cSettings = new System.Windows.Forms.Button();
            this.ThInf_Folder = new System.Windows.Forms.TextBox();
            this.cDownProg = new System.Windows.Forms.Button();
            this.nIco = new System.Windows.Forms.NotifyIcon(this.components);
            this.tHotkeys = new System.Windows.Forms.Timer(this.components);
            this.tAutoIterate = new System.Windows.Forms.Timer(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.ThInf_ImgCnt = new System.Windows.Forms.Label();
            this.ThInf_picThumb = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ThInf_lastCheck = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ThInf_lastDL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ThInf_thrAdded = new System.Windows.Forms.Label();
            this.cmsThreads = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsThreads_SortBy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_SortBy_ThreadURL = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_SortBy_ThreadAdded = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_SortBy_LastCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_SortBy_LastDL = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_SortBy_ImageCount = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_OpenURL = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsThreads_ViewImages = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ThInf_FolderB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.lbSkip = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbRetry = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbTipNext = new System.Windows.Forms.Label();
            this.lbTipPrev = new System.Windows.Forms.Label();
            this.lbTip = new System.Windows.Forms.Label();
            this.tRetry = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ThInf_picThumb)).BeginInit();
            this.cmsThreads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstThreads
            // 
            this.lstThreads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lstThreads.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstThreads.ForeColor = System.Drawing.Color.White;
            this.lstThreads.FormattingEnabled = true;
            this.lstThreads.Location = new System.Drawing.Point(7, 27);
            this.lstThreads.Name = "lstThreads";
            this.lstThreads.Size = new System.Drawing.Size(354, 314);
            this.lstThreads.TabIndex = 0;
            this.lstThreads.Tag = "c1";
            this.tTip.SetToolTip(this.lstThreads, "The threads that Chanmongler will download from when asked.\r\nPROTIP: Select a thr" +
                    "ead and hit the Delete key on your keyboard to remove a thread.");
            this.lstThreads.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstThreads_MouseUp);
            this.lstThreads.SelectedIndexChanged += new System.EventHandler(this.lstThreads_SelectedIndexChanged);
            this.lstThreads.DoubleClick += new System.EventHandler(this.lstThreads_DoubleClick);
            this.lstThreads.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbThreads_KeyDown);
            // 
            // cmdThreads_Load
            // 
            this.cmdThreads_Load.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdThreads_Load.ForeColor = System.Drawing.Color.White;
            this.cmdThreads_Load.Location = new System.Drawing.Point(247, 25);
            this.cmdThreads_Load.Name = "cmdThreads_Load";
            this.cmdThreads_Load.Size = new System.Drawing.Size(114, 23);
            this.cmdThreads_Load.TabIndex = 17;
            this.cmdThreads_Load.Tag = "c3";
            this.cmdThreads_Load.Text = "Load";
            this.tTip.SetToolTip(this.cmdThreads_Load, "Load all saved threads and statistics.");
            this.cmdThreads_Load.UseVisualStyleBackColor = false;
            this.cmdThreads_Load.Click += new System.EventHandler(this.cmdThreads_Load_Click);
            // 
            // cmdThreads_Save
            // 
            this.cmdThreads_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdThreads_Save.ForeColor = System.Drawing.Color.White;
            this.cmdThreads_Save.Location = new System.Drawing.Point(127, 25);
            this.cmdThreads_Save.Name = "cmdThreads_Save";
            this.cmdThreads_Save.Size = new System.Drawing.Size(114, 23);
            this.cmdThreads_Save.TabIndex = 16;
            this.cmdThreads_Save.Tag = "c3";
            this.cmdThreads_Save.Text = "Save";
            this.tTip.SetToolTip(this.cmdThreads_Save, "Save all the added threads, along with the statistics.");
            this.cmdThreads_Save.UseVisualStyleBackColor = false;
            this.cmdThreads_Save.Click += new System.EventHandler(this.cmdThreads_Save_Click);
            // 
            // cmdThreads_Add
            // 
            this.cmdThreads_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdThreads_Add.ForeColor = System.Drawing.Color.White;
            this.cmdThreads_Add.Location = new System.Drawing.Point(7, 25);
            this.cmdThreads_Add.Name = "cmdThreads_Add";
            this.cmdThreads_Add.Size = new System.Drawing.Size(114, 23);
            this.cmdThreads_Add.TabIndex = 13;
            this.cmdThreads_Add.Tag = "c3";
            this.cmdThreads_Add.Text = "Add new";
            this.tTip.SetToolTip(this.cmdThreads_Add, "Add a new thread to the list.");
            this.cmdThreads_Add.UseVisualStyleBackColor = false;
            this.cmdThreads_Add.Click += new System.EventHandler(this.cmdThreads_Add_Click);
            // 
            // cMarkActive
            // 
            this.cMarkActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cMarkActive.ForeColor = System.Drawing.Color.White;
            this.cMarkActive.Location = new System.Drawing.Point(7, 54);
            this.cMarkActive.Name = "cMarkActive";
            this.cMarkActive.Size = new System.Drawing.Size(114, 23);
            this.cMarkActive.TabIndex = 18;
            this.cMarkActive.Tag = "c3";
            this.cMarkActive.Text = "Mark active";
            this.tTip.SetToolTip(this.cMarkActive, "Click here to set the associated folders\' last accessed/loaded time to \"now\".\r\nMa" +
                    "kes finding dead / completed threads easier.");
            this.cMarkActive.UseVisualStyleBackColor = false;
            this.cMarkActive.Click += new System.EventHandler(this.cMarkActive_Click);
            // 
            // cSearch
            // 
            this.cSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cSearch.ForeColor = System.Drawing.Color.White;
            this.cSearch.Location = new System.Drawing.Point(7, 25);
            this.cSearch.Name = "cSearch";
            this.cSearch.Size = new System.Drawing.Size(114, 23);
            this.cSearch.TabIndex = 17;
            this.cSearch.Tag = "c3";
            this.cSearch.Text = "Search";
            this.tTip.SetToolTip(this.cSearch, "Search through all threads in a board for\r\na filename, part of a post, etc.");
            this.cSearch.UseVisualStyleBackColor = false;
            this.cSearch.Click += new System.EventHandler(this.cSearch_Click);
            // 
            // cLoadChanFiles
            // 
            this.cLoadChanFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cLoadChanFiles.ForeColor = System.Drawing.Color.White;
            this.cLoadChanFiles.Location = new System.Drawing.Point(7, 83);
            this.cLoadChanFiles.Name = "cLoadChanFiles";
            this.cLoadChanFiles.Size = new System.Drawing.Size(114, 23);
            this.cLoadChanFiles.TabIndex = 16;
            this.cLoadChanFiles.Tag = "c3";
            this.cLoadChanFiles.Text = "Reload *.chan";
            this.tTip.SetToolTip(this.cLoadChanFiles, "If you change any of your chanfiles,\r\nyou might want to reload them.");
            this.cLoadChanFiles.UseVisualStyleBackColor = false;
            this.cLoadChanFiles.Click += new System.EventHandler(this.cLoadChanFiles_Click);
            // 
            // cContact
            // 
            this.cContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cContact.ForeColor = System.Drawing.Color.White;
            this.cContact.Location = new System.Drawing.Point(247, 83);
            this.cContact.Name = "cContact";
            this.cContact.Size = new System.Drawing.Size(114, 23);
            this.cContact.TabIndex = 15;
            this.cContact.Tag = "c3";
            this.cContact.Text = "Contact me";
            this.tTip.SetToolTip(this.cContact, "Caption says it all, eh?");
            this.cContact.UseVisualStyleBackColor = false;
            this.cContact.Click += new System.EventHandler(this.cContact_Click);
            // 
            // cHelp
            // 
            this.cHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cHelp.ForeColor = System.Drawing.Color.White;
            this.cHelp.Location = new System.Drawing.Point(247, 54);
            this.cHelp.Name = "cHelp";
            this.cHelp.Size = new System.Drawing.Size(114, 23);
            this.cHelp.TabIndex = 14;
            this.cHelp.Tag = "c3";
            this.cHelp.Text = "Help";
            this.tTip.SetToolTip(this.cHelp, "Need help? You\'re better off going to my website,\r\nbut this will atleast give you" +
                    " a push in the right direction.");
            this.cHelp.UseVisualStyleBackColor = false;
            this.cHelp.Click += new System.EventHandler(this.cHelp_Click);
            // 
            // cNews
            // 
            this.cNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cNews.ForeColor = System.Drawing.Color.White;
            this.cNews.Location = new System.Drawing.Point(247, 25);
            this.cNews.Name = "cNews";
            this.cNews.Size = new System.Drawing.Size(114, 23);
            this.cNews.TabIndex = 13;
            this.cNews.Tag = "c3";
            this.cNews.Text = "News";
            this.tTip.SetToolTip(this.cNews, "Changelog, mostly.");
            this.cNews.UseVisualStyleBackColor = false;
            this.cNews.Click += new System.EventHandler(this.cNews_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.ForeColor = System.Drawing.Color.White;
            this.lbStatus.Location = new System.Drawing.Point(7, 22);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(354, 13);
            this.lbStatus.TabIndex = 37;
            this.lbStatus.Tag = "c5";
            this.lbStatus.Text = "No actions have been performed yet.";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Silver;
            this.label12.Location = new System.Drawing.Point(7, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 33;
            this.label12.Tag = "c4";
            this.label12.Text = "Files remaining";
            // 
            // lbRemaining
            // 
            this.lbRemaining.ForeColor = System.Drawing.Color.White;
            this.lbRemaining.Location = new System.Drawing.Point(109, 61);
            this.lbRemaining.Name = "lbRemaining";
            this.lbRemaining.Size = new System.Drawing.Size(72, 13);
            this.lbRemaining.TabIndex = 32;
            this.lbRemaining.Tag = "c5";
            this.lbRemaining.Text = "~";
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Silver;
            this.label10.Location = new System.Drawing.Point(7, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 31;
            this.label10.Tag = "c4";
            this.label10.Text = "Files downloading";
            // 
            // lbDownloading
            // 
            this.lbDownloading.ForeColor = System.Drawing.Color.White;
            this.lbDownloading.Location = new System.Drawing.Point(109, 48);
            this.lbDownloading.Name = "lbDownloading";
            this.lbDownloading.Size = new System.Drawing.Size(72, 13);
            this.lbDownloading.TabIndex = 30;
            this.lbDownloading.Tag = "c5";
            this.lbDownloading.Text = "~";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(7, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 29;
            this.label7.Tag = "c4";
            this.label7.Text = "Threads checked";
            // 
            // lbThreads
            // 
            this.lbThreads.ForeColor = System.Drawing.Color.White;
            this.lbThreads.Location = new System.Drawing.Point(109, 35);
            this.lbThreads.Name = "lbThreads";
            this.lbThreads.Size = new System.Drawing.Size(72, 13);
            this.lbThreads.TabIndex = 28;
            this.lbThreads.Tag = "c5";
            this.lbThreads.Text = "~";
            // 
            // cmdIterate
            // 
            this.cmdIterate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdIterate.ForeColor = System.Drawing.Color.White;
            this.cmdIterate.Location = new System.Drawing.Point(187, 25);
            this.cmdIterate.Name = "cmdIterate";
            this.cmdIterate.Size = new System.Drawing.Size(174, 23);
            this.cmdIterate.TabIndex = 30;
            this.cmdIterate.Tag = "c3";
            this.cmdIterate.Text = "Download all new files";
            this.tTip.SetToolTip(this.cmdIterate, "Does this button really need a tooltip?");
            this.cmdIterate.UseVisualStyleBackColor = false;
            this.cmdIterate.Click += new System.EventHandler(this.cmdIterate_Click);
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
            // cSettings
            // 
            this.cSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cSettings.ForeColor = System.Drawing.Color.White;
            this.cSettings.Location = new System.Drawing.Point(7, 25);
            this.cSettings.Name = "cSettings";
            this.cSettings.Size = new System.Drawing.Size(174, 23);
            this.cSettings.TabIndex = 50;
            this.cSettings.Tag = "c3";
            this.cSettings.Text = "Advanced settings";
            this.tTip.SetToolTip(this.cSettings, "Just to keep thing nice and clean, I shoved\r\nall the advanced stuff over to a dus" +
                    "ty corner.");
            this.cSettings.UseVisualStyleBackColor = false;
            this.cSettings.Click += new System.EventHandler(this.cSettings_Click);
            // 
            // ThInf_Folder
            // 
            this.ThInf_Folder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ThInf_Folder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThInf_Folder.ForeColor = System.Drawing.Color.White;
            this.ThInf_Folder.Location = new System.Drawing.Point(101, 77);
            this.ThInf_Folder.Name = "ThInf_Folder";
            this.ThInf_Folder.Size = new System.Drawing.Size(124, 20);
            this.ThInf_Folder.TabIndex = 46;
            this.ThInf_Folder.Tag = "c1";
            this.tTip.SetToolTip(this.ThInf_Folder, "If you wish to autoget at a higher interval\r\nthan the minimum, then please go ahe" +
                    "ad.");
            this.ThInf_Folder.TextChanged += new System.EventHandler(this.ThInf_Folder_TextChanged);
            // 
            // cDownProg
            // 
            this.cDownProg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cDownProg.ForeColor = System.Drawing.Color.White;
            this.cDownProg.Location = new System.Drawing.Point(127, 25);
            this.cDownProg.Name = "cDownProg";
            this.cDownProg.Size = new System.Drawing.Size(114, 81);
            this.cDownProg.TabIndex = 36;
            this.cDownProg.Tag = "c3";
            this.cDownProg.Text = "Download\r\nprogress";
            this.tTip.SetToolTip(this.cDownProg, "Search through all threads in a board for\r\na filename, part of a post, etc.");
            this.cDownProg.UseVisualStyleBackColor = false;
            this.cDownProg.Click += new System.EventHandler(this.cDownProg_Click);
            // 
            // nIco
            // 
            this.nIco.Text = "notifyIcon1";
            this.nIco.Visible = true;
            this.nIco.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nIco_MouseDoubleClick);
            // 
            // tHotkeys
            // 
            this.tHotkeys.Interval = 1;
            this.tHotkeys.Tick += new System.EventHandler(this.tHotkeys_Tick);
            // 
            // tAutoIterate
            // 
            this.tAutoIterate.Interval = 1000;
            this.tAutoIterate.Tick += new System.EventHandler(this.tAutoIterate_Tick);
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.Color.Silver;
            this.label22.Location = new System.Drawing.Point(7, 61);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 13);
            this.label22.TabIndex = 44;
            this.label22.Tag = "c4";
            this.label22.Text = "Image count";
            // 
            // ThInf_ImgCnt
            // 
            this.ThInf_ImgCnt.ForeColor = System.Drawing.Color.White;
            this.ThInf_ImgCnt.Location = new System.Drawing.Point(98, 61);
            this.ThInf_ImgCnt.Name = "ThInf_ImgCnt";
            this.ThInf_ImgCnt.Size = new System.Drawing.Size(110, 13);
            this.ThInf_ImgCnt.TabIndex = 43;
            this.ThInf_ImgCnt.Tag = "c5";
            this.ThInf_ImgCnt.Text = "9001";
            // 
            // ThInf_picThumb
            // 
            this.ThInf_picThumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ThInf_picThumb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ThInf_picThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThInf_picThumb.Location = new System.Drawing.Point(231, 24);
            this.ThInf_picThumb.Name = "ThInf_picThumb";
            this.ThInf_picThumb.Size = new System.Drawing.Size(130, 82);
            this.ThInf_picThumb.TabIndex = 42;
            this.ThInf_picThumb.TabStop = false;
            this.ThInf_picThumb.Tag = "c1";
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(7, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 39;
            this.label9.Tag = "c4";
            this.label9.Text = "Last check";
            // 
            // ThInf_lastCheck
            // 
            this.ThInf_lastCheck.ForeColor = System.Drawing.Color.White;
            this.ThInf_lastCheck.Location = new System.Drawing.Point(98, 35);
            this.ThInf_lastCheck.Name = "ThInf_lastCheck";
            this.ThInf_lastCheck.Size = new System.Drawing.Size(110, 13);
            this.ThInf_lastCheck.TabIndex = 38;
            this.ThInf_lastCheck.Tag = "c5";
            this.ThInf_lastCheck.Text = "88.88.88 - 88:88:88";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(7, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 37;
            this.label4.Tag = "c4";
            this.label4.Text = "Last download";
            // 
            // ThInf_lastDL
            // 
            this.ThInf_lastDL.ForeColor = System.Drawing.Color.White;
            this.ThInf_lastDL.Location = new System.Drawing.Point(98, 48);
            this.ThInf_lastDL.Name = "ThInf_lastDL";
            this.ThInf_lastDL.Size = new System.Drawing.Size(110, 13);
            this.ThInf_lastDL.TabIndex = 36;
            this.ThInf_lastDL.Tag = "c5";
            this.ThInf_lastDL.Text = "88.88.88 - 88:88:88";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 35;
            this.label2.Tag = "c4";
            this.label2.Text = "Thread added";
            // 
            // ThInf_thrAdded
            // 
            this.ThInf_thrAdded.ForeColor = System.Drawing.Color.White;
            this.ThInf_thrAdded.Location = new System.Drawing.Point(98, 22);
            this.ThInf_thrAdded.Name = "ThInf_thrAdded";
            this.ThInf_thrAdded.Size = new System.Drawing.Size(110, 13);
            this.ThInf_thrAdded.TabIndex = 34;
            this.ThInf_thrAdded.Tag = "c5";
            this.ThInf_thrAdded.Text = "88.88.88 - 88:88:88";
            // 
            // cmsThreads
            // 
            this.cmsThreads.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsThreads_SortBy,
            this.cmsThreads_OpenFolder,
            this.cmsThreads_OpenURL,
            this.cmsThreads_ViewImages});
            this.cmsThreads.Name = "cmsThreads";
            this.cmsThreads.Size = new System.Drawing.Size(164, 92);
            // 
            // cmsThreads_SortBy
            // 
            this.cmsThreads_SortBy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsThreads_SortBy_ThreadURL,
            this.cmsThreads_SortBy_ThreadAdded,
            this.cmsThreads_SortBy_LastCheck,
            this.cmsThreads_SortBy_LastDL,
            this.cmsThreads_SortBy_ImageCount});
            this.cmsThreads_SortBy.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsThreads_SortBy.Name = "cmsThreads_SortBy";
            this.cmsThreads_SortBy.Size = new System.Drawing.Size(163, 22);
            this.cmsThreads_SortBy.Text = "Sort by";
            // 
            // cmsThreads_SortBy_ThreadURL
            // 
            this.cmsThreads_SortBy_ThreadURL.Name = "cmsThreads_SortBy_ThreadURL";
            this.cmsThreads_SortBy_ThreadURL.Size = new System.Drawing.Size(148, 22);
            this.cmsThreads_SortBy_ThreadURL.Text = "Thread URL";
            this.cmsThreads_SortBy_ThreadURL.Click += new System.EventHandler(this.cmsThreads_SortBy_ThreadURL_Click);
            // 
            // cmsThreads_SortBy_ThreadAdded
            // 
            this.cmsThreads_SortBy_ThreadAdded.Name = "cmsThreads_SortBy_ThreadAdded";
            this.cmsThreads_SortBy_ThreadAdded.Size = new System.Drawing.Size(148, 22);
            this.cmsThreads_SortBy_ThreadAdded.Text = "Thread added";
            this.cmsThreads_SortBy_ThreadAdded.Click += new System.EventHandler(this.cmsThreads_SortBy_ThreadAdded_Click);
            // 
            // cmsThreads_SortBy_LastCheck
            // 
            this.cmsThreads_SortBy_LastCheck.Name = "cmsThreads_SortBy_LastCheck";
            this.cmsThreads_SortBy_LastCheck.Size = new System.Drawing.Size(148, 22);
            this.cmsThreads_SortBy_LastCheck.Text = "Last check";
            this.cmsThreads_SortBy_LastCheck.Click += new System.EventHandler(this.cmsThreads_SortBy_LastCheck_Click);
            // 
            // cmsThreads_SortBy_LastDL
            // 
            this.cmsThreads_SortBy_LastDL.Name = "cmsThreads_SortBy_LastDL";
            this.cmsThreads_SortBy_LastDL.Size = new System.Drawing.Size(148, 22);
            this.cmsThreads_SortBy_LastDL.Text = "Last new file";
            this.cmsThreads_SortBy_LastDL.Click += new System.EventHandler(this.cmsThreads_SortBy_LastDL_Click);
            // 
            // cmsThreads_SortBy_ImageCount
            // 
            this.cmsThreads_SortBy_ImageCount.Name = "cmsThreads_SortBy_ImageCount";
            this.cmsThreads_SortBy_ImageCount.Size = new System.Drawing.Size(148, 22);
            this.cmsThreads_SortBy_ImageCount.Text = "Image count";
            this.cmsThreads_SortBy_ImageCount.Click += new System.EventHandler(this.cmsThreads_SortBy_ImageCount_Click);
            // 
            // cmsThreads_OpenFolder
            // 
            this.cmsThreads_OpenFolder.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsThreads_OpenFolder.Name = "cmsThreads_OpenFolder";
            this.cmsThreads_OpenFolder.Size = new System.Drawing.Size(163, 22);
            this.cmsThreads_OpenFolder.Text = "Open folder";
            this.cmsThreads_OpenFolder.Click += new System.EventHandler(this.cmsThreads_OpenFolder_Click);
            // 
            // cmsThreads_OpenURL
            // 
            this.cmsThreads_OpenURL.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsThreads_OpenURL.Name = "cmsThreads_OpenURL";
            this.cmsThreads_OpenURL.Size = new System.Drawing.Size(163, 22);
            this.cmsThreads_OpenURL.Text = "Open in browser";
            this.cmsThreads_OpenURL.Click += new System.EventHandler(this.cmsThreads_OpenURL_Click);
            // 
            // cmsThreads_ViewImages
            // 
            this.cmsThreads_ViewImages.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsThreads_ViewImages.Name = "cmsThreads_ViewImages";
            this.cmsThreads_ViewImages.Size = new System.Drawing.Size(163, 22);
            this.cmsThreads_ViewImages.Text = "View images";
            this.cmsThreads_ViewImages.Click += new System.EventHandler(this.cmsThreads_ViewImages_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 115);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmdThreads_Save);
            this.panel2.Controls.Add(this.cmdThreads_Load);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmdThreads_Add);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(397, 306);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(370, 57);
            this.panel2.TabIndex = 53;
            this.panel2.Tag = "c2";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(7, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(354, 15);
            this.label6.TabIndex = 35;
            this.label6.Tag = "c4";
            this.label6.Text = "Thread management";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cDownProg);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cSearch);
            this.panel3.Controls.Add(this.cLoadChanFiles);
            this.panel3.Controls.Add(this.cContact);
            this.panel3.Controls.Add(this.cNews);
            this.panel3.Controls.Add(this.cHelp);
            this.panel3.Controls.Add(this.cMarkActive);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(397, 15);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(370, 115);
            this.panel3.TabIndex = 54;
            this.panel3.Tag = "c2";
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
            this.label1.Text = "Control panel";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.ThInf_Folder);
            this.panel4.Controls.Add(this.ThInf_FolderB);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.ThInf_lastCheck);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.ThInf_thrAdded);
            this.panel4.Controls.Add(this.ThInf_picThumb);
            this.panel4.Controls.Add(this.ThInf_ImgCnt);
            this.panel4.Controls.Add(this.ThInf_lastDL);
            this.panel4.ForeColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(397, 179);
            this.panel4.Margin = new System.Windows.Forms.Padding(6);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(4);
            this.panel4.Size = new System.Drawing.Size(370, 115);
            this.panel4.TabIndex = 55;
            this.panel4.Tag = "c2";
            // 
            // ThInf_FolderB
            // 
            this.ThInf_FolderB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ThInf_FolderB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThInf_FolderB.ForeColor = System.Drawing.Color.Silver;
            this.ThInf_FolderB.Location = new System.Drawing.Point(7, 79);
            this.ThInf_FolderB.Name = "ThInf_FolderB";
            this.ThInf_FolderB.Size = new System.Drawing.Size(85, 13);
            this.ThInf_FolderB.TabIndex = 45;
            this.ThInf_FolderB.Tag = "c4";
            this.ThInf_FolderB.Text = "Subfolder";
            this.ThInf_FolderB.Click += new System.EventHandler(this.ThInf_FolderB_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(354, 15);
            this.label3.TabIndex = 35;
            this.label3.Tag = "c4";
            this.label3.Text = "Thread information";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lbSkip);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lbRetry);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbThreads);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbDownloading);
            this.panel1.Controls.Add(this.lbRemaining);
            this.panel1.Controls.Add(this.label10);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(397, 444);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(370, 85);
            this.panel1.TabIndex = 56;
            this.panel1.Tag = "c2";
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(187, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 41;
            this.label14.Tag = "c4";
            this.label14.Text = "Skip count";
            // 
            // lbSkip
            // 
            this.lbSkip.ForeColor = System.Drawing.Color.White;
            this.lbSkip.Location = new System.Drawing.Point(289, 48);
            this.lbSkip.Name = "lbSkip";
            this.lbSkip.Size = new System.Drawing.Size(72, 13);
            this.lbSkip.TabIndex = 40;
            this.lbSkip.Tag = "c5";
            this.lbSkip.Text = "~";
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Silver;
            this.label11.Location = new System.Drawing.Point(187, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 39;
            this.label11.Tag = "c4";
            this.label11.Text = "Retry count";
            // 
            // lbRetry
            // 
            this.lbRetry.ForeColor = System.Drawing.Color.White;
            this.lbRetry.Location = new System.Drawing.Point(289, 35);
            this.lbRetry.Name = "lbRetry";
            this.lbRetry.Size = new System.Drawing.Size(72, 13);
            this.lbRetry.TabIndex = 38;
            this.lbRetry.Tag = "c5";
            this.lbRetry.Text = "~";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(7, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 15);
            this.label5.TabIndex = 35;
            this.label5.Tag = "c4";
            this.label5.Text = "Status";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.cSettings);
            this.panel5.Controls.Add(this.cmdIterate);
            this.panel5.ForeColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(397, 375);
            this.panel5.Margin = new System.Windows.Forms.Padding(6);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(4);
            this.panel5.Size = new System.Drawing.Size(370, 57);
            this.panel5.TabIndex = 57;
            this.panel5.Tag = "c2";
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(7, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(354, 15);
            this.label8.TabIndex = 35;
            this.label8.Tag = "c4";
            this.label8.Text = "wat";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.ForeColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(15, 15);
            this.panel6.Margin = new System.Windows.Forms.Padding(6);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(4);
            this.panel6.Size = new System.Drawing.Size(370, 115);
            this.panel6.TabIndex = 58;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.lstThreads);
            this.panel7.ForeColor = System.Drawing.Color.White;
            this.panel7.Location = new System.Drawing.Point(15, 179);
            this.panel7.Margin = new System.Windows.Forms.Padding(6);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(4);
            this.panel7.Size = new System.Drawing.Size(370, 350);
            this.panel7.TabIndex = 59;
            this.panel7.Tag = "c2";
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
            this.label13.Text = "Threads";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.lbTipNext);
            this.panel8.Controls.Add(this.lbTipPrev);
            this.panel8.Controls.Add(this.lbTip);
            this.panel8.Location = new System.Drawing.Point(15, 142);
            this.panel8.Margin = new System.Windows.Forms.Padding(6);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(4);
            this.panel8.Size = new System.Drawing.Size(752, 23);
            this.panel8.TabIndex = 60;
            this.panel8.Tag = "c2";
            // 
            // lbTipNext
            // 
            this.lbTipNext.ForeColor = System.Drawing.Color.Silver;
            this.lbTipNext.Location = new System.Drawing.Point(718, 4);
            this.lbTipNext.Name = "lbTipNext";
            this.lbTipNext.Size = new System.Drawing.Size(25, 13);
            this.lbTipNext.TabIndex = 62;
            this.lbTipNext.Tag = "c4";
            this.lbTipNext.Text = ">>";
            this.lbTipNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTipNext.Click += new System.EventHandler(this.lbTipNext_Click);
            // 
            // lbTipPrev
            // 
            this.lbTipPrev.ForeColor = System.Drawing.Color.Silver;
            this.lbTipPrev.Location = new System.Drawing.Point(7, 4);
            this.lbTipPrev.Name = "lbTipPrev";
            this.lbTipPrev.Size = new System.Drawing.Size(25, 13);
            this.lbTipPrev.TabIndex = 61;
            this.lbTipPrev.Tag = "c4";
            this.lbTipPrev.Text = "<<";
            this.lbTipPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTipPrev.Click += new System.EventHandler(this.lbTipPrev_Click);
            // 
            // lbTip
            // 
            this.lbTip.ForeColor = System.Drawing.Color.White;
            this.lbTip.Location = new System.Drawing.Point(38, 4);
            this.lbTip.Name = "lbTip";
            this.lbTip.Size = new System.Drawing.Size(674, 13);
            this.lbTip.TabIndex = 35;
            this.lbTip.Tag = "c5";
            this.lbTip.Text = "Tip of the day";
            this.lbTip.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tRetry
            // 
            this.tRetry.Interval = 10;
            this.tRetry.Tick += new System.EventHandler(this.tRetry_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(782, 544);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.LightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chanmongler v";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ThInf_picThumb)).EndInit();
            this.cmsThreads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstThreads;
        private System.Windows.Forms.Button cmdThreads_Add;
        private System.Windows.Forms.Button cContact;
        private System.Windows.Forms.Button cHelp;
        private System.Windows.Forms.Button cNews;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbRemaining;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbDownloading;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbThreads;
        private System.Windows.Forms.Button cmdIterate;
        private System.Windows.Forms.Timer tThreadState;
        private System.Windows.Forms.Timer tDownload;
        private System.Windows.Forms.ToolTip tTip;
        private System.Windows.Forms.NotifyIcon nIco;
        private System.Windows.Forms.Button cMarkActive;
        private System.Windows.Forms.Button cSearch;
        private System.Windows.Forms.Button cLoadChanFiles;
        private System.Windows.Forms.Timer tHotkeys;
        private System.Windows.Forms.Button cmdThreads_Load;
        private System.Windows.Forms.Button cmdThreads_Save;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Timer tAutoIterate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ThInf_lastCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ThInf_lastDL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ThInf_thrAdded;
        private System.Windows.Forms.PictureBox ThInf_picThumb;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label ThInf_ImgCnt;
        private System.Windows.Forms.ContextMenuStrip cmsThreads;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_SortBy;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_SortBy_ThreadURL;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_SortBy_ThreadAdded;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_SortBy_LastCheck;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_SortBy_LastDL;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_SortBy_ImageCount;
        private System.Windows.Forms.Button cSettings;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_OpenFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_OpenURL;
        private System.Windows.Forms.ToolStripMenuItem cmsThreads_ViewImages;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbTip;
        private System.Windows.Forms.Label lbTipNext;
        private System.Windows.Forms.Label lbTipPrev;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbRetry;
        private System.Windows.Forms.Timer tRetry;
        private System.Windows.Forms.Label ThInf_FolderB;
        private System.Windows.Forms.TextBox ThInf_Folder;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbSkip;
        private System.Windows.Forms.Button cDownProg;
    }
}

