﻿namespace Chanmongler
{
    partial class frmNews
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNews));
            this.txtNews = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNews
            // 
            this.txtNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(64)))));
            this.txtNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNews.ForeColor = System.Drawing.Color.Azure;
            this.txtNews.Location = new System.Drawing.Point(12, 12);
            this.txtNews.Multiline = true;
            this.txtNews.Name = "txtNews";
            this.txtNews.Size = new System.Drawing.Size(758, 495);
            this.txtNews.TabIndex = 2;
            this.txtNews.Text = resources.GetString("txtNews.Text");
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(782, 519);
            this.Controls.Add(this.txtNews);
            this.Name = "frmNews";
            this.Text = "News";
            this.Load += new System.EventHandler(this.frmNews_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNews;
    }
}