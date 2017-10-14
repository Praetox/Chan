namespace Chanmongler
{
    partial class frmMainBG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainBG));
            this.tGUI = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tGUI
            // 
            this.tGUI.Enabled = true;
            this.tGUI.Interval = 1;
            this.tGUI.Tick += new System.EventHandler(this.tGUI_Tick);
            // 
            // frmMainBG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainBG";
            this.Text = "Chanmongler | v";
            this.Load += new System.EventHandler(this.frmMainBG_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMainBG_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMainBG_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMainBG_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tGUI;
    }
}