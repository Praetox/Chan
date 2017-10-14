namespace Chanmongler
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.txTerm = new System.Windows.Forms.TextBox();
            this.cbBoard = new System.Windows.Forms.ComboBox();
            this.cbChan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdDoSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lbBoards = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbFound = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbThreads = new System.Windows.Forms.Label();
            this.cmdViewResults = new System.Windows.Forms.Button();
            this.TTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txTerm
            // 
            this.txTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.txTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txTerm.ForeColor = System.Drawing.Color.Azure;
            this.txTerm.Location = new System.Drawing.Point(64, 79);
            this.txTerm.Name = "txTerm";
            this.txTerm.Size = new System.Drawing.Size(397, 20);
            this.txTerm.TabIndex = 35;
            this.txTerm.Tag = "c1";
            this.TTip.SetToolTip(this.txTerm, "PROTIP: Separate multiple search terms with a semicolon-space. Example:\r\nPedobear" +
                    "; Grinman; Windows Optimizer; Mods = Fags");
            // 
            // cbBoard
            // 
            this.cbBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cbBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBoard.ForeColor = System.Drawing.Color.Azure;
            this.cbBoard.FormattingEnabled = true;
            this.cbBoard.Location = new System.Drawing.Point(64, 52);
            this.cbBoard.Name = "cbBoard";
            this.cbBoard.Size = new System.Drawing.Size(397, 21);
            this.cbBoard.TabIndex = 34;
            this.cbBoard.Tag = "c1";
            // 
            // cbChan
            // 
            this.cbChan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cbChan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbChan.ForeColor = System.Drawing.Color.Azure;
            this.cbChan.FormattingEnabled = true;
            this.cbChan.Location = new System.Drawing.Point(64, 25);
            this.cbChan.Name = "cbChan";
            this.cbChan.Size = new System.Drawing.Size(397, 21);
            this.cbChan.TabIndex = 33;
            this.cbChan.Tag = "c1";
            this.cbChan.SelectedIndexChanged += new System.EventHandler(this.cbChan_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 32;
            this.label2.Tag = "c4";
            this.label2.Text = "Find";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(7, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 31;
            this.label1.Tag = "c4";
            this.label1.Text = "Board";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(7, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 30;
            this.label7.Tag = "c4";
            this.label7.Text = "Chan";
            // 
            // cmdDoSearch
            // 
            this.cmdDoSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdDoSearch.ForeColor = System.Drawing.Color.Azure;
            this.cmdDoSearch.Location = new System.Drawing.Point(15, 132);
            this.cmdDoSearch.Name = "cmdDoSearch";
            this.cmdDoSearch.Size = new System.Drawing.Size(470, 32);
            this.cmdDoSearch.TabIndex = 36;
            this.cmdDoSearch.Tag = "c3";
            this.cmdDoSearch.Text = "E x e c u t e    s e a r c h";
            this.cmdDoSearch.UseVisualStyleBackColor = false;
            this.cmdDoSearch.Click += new System.EventHandler(this.cmdDoSearch_Click);
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(7, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 39;
            this.label8.Tag = "c4";
            this.label8.Text = "Boards checked";
            // 
            // lbBoards
            // 
            this.lbBoards.ForeColor = System.Drawing.Color.White;
            this.lbBoards.Location = new System.Drawing.Point(109, 35);
            this.lbBoards.Name = "lbBoards";
            this.lbBoards.Size = new System.Drawing.Size(72, 13);
            this.lbBoards.TabIndex = 38;
            this.lbBoards.Tag = "c5";
            this.lbBoards.Text = "0 / 1";
            // 
            // lbStatus
            // 
            this.lbStatus.ForeColor = System.Drawing.Color.White;
            this.lbStatus.Location = new System.Drawing.Point(7, 22);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(454, 13);
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
            this.label12.Text = "Found instances";
            // 
            // lbFound
            // 
            this.lbFound.ForeColor = System.Drawing.Color.White;
            this.lbFound.Location = new System.Drawing.Point(109, 61);
            this.lbFound.Name = "lbFound";
            this.lbFound.Size = new System.Drawing.Size(72, 13);
            this.lbFound.TabIndex = 32;
            this.lbFound.Tag = "c5";
            this.lbFound.Text = "0";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(7, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 29;
            this.label5.Tag = "c4";
            this.label5.Text = "Threads checked";
            // 
            // lbThreads
            // 
            this.lbThreads.ForeColor = System.Drawing.Color.White;
            this.lbThreads.Location = new System.Drawing.Point(109, 48);
            this.lbThreads.Name = "lbThreads";
            this.lbThreads.Size = new System.Drawing.Size(72, 13);
            this.lbThreads.TabIndex = 28;
            this.lbThreads.Tag = "c5";
            this.lbThreads.Text = "0 / 0";
            // 
            // cmdViewResults
            // 
            this.cmdViewResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmdViewResults.ForeColor = System.Drawing.Color.Azure;
            this.cmdViewResults.Location = new System.Drawing.Point(15, 268);
            this.cmdViewResults.Name = "cmdViewResults";
            this.cmdViewResults.Size = new System.Drawing.Size(470, 32);
            this.cmdViewResults.TabIndex = 41;
            this.cmdViewResults.Tag = "c3";
            this.cmdViewResults.Text = "V i e w    r e s u l t s    i n    d e f a u l t    b r o w s e r";
            this.cmdViewResults.UseVisualStyleBackColor = false;
            this.cmdViewResults.Click += new System.EventHandler(this.cmdViewResults_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txTerm);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.cbBoard);
            this.panel3.Controls.Add(this.cbChan);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(15, 15);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4);
            this.panel3.Size = new System.Drawing.Size(470, 108);
            this.panel3.TabIndex = 55;
            this.panel3.Tag = "c2";
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Silver;
            this.label9.Location = new System.Drawing.Point(7, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(454, 15);
            this.label9.TabIndex = 35;
            this.label9.Tag = "c4";
            this.label9.Text = "Search options";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbBoards);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.lbThreads);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbFound);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(15, 173);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(470, 86);
            this.panel1.TabIndex = 56;
            this.panel1.Tag = "c2";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 15);
            this.label3.TabIndex = 35;
            this.label3.Tag = "c4";
            this.label3.Text = "Status";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(500, 312);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cmdViewResults);
            this.Controls.Add(this.cmdDoSearch);
            this.ForeColor = System.Drawing.Color.LightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chanmongler - Search Engine";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txTerm;
        private System.Windows.Forms.ComboBox cbBoard;
        private System.Windows.Forms.ComboBox cbChan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdDoSearch;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbFound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbThreads;
        private System.Windows.Forms.Button cmdViewResults;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbBoards;
        private System.Windows.Forms.ToolTip TTip;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}