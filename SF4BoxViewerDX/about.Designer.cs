namespace SF4BoxViewerDX
{
    partial class about
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bVisit = new System.Windows.Forms.Button();
            this.bDonate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SF4 Box Viewer";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::SF4BoxViewerDX.Properties.Resources.avatar96x96_siden_mørk_flytta_koppen;
            this.pictureBox1.Location = new System.Drawing.Point(12, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bVisit
            // 
            this.bVisit.Location = new System.Drawing.Point(98, 74);
            this.bVisit.Name = "bVisit";
            this.bVisit.Size = new System.Drawing.Size(74, 37);
            this.bVisit.TabIndex = 5;
            this.bVisit.Text = "Visit";
            this.bVisit.UseVisualStyleBackColor = true;
            this.bVisit.Click += new System.EventHandler(this.bVisit_Click);
            // 
            // bDonate
            // 
            this.bDonate.Location = new System.Drawing.Point(98, 117);
            this.bDonate.Name = "bDonate";
            this.bDonate.Size = new System.Drawing.Size(74, 37);
            this.bDonate.TabIndex = 4;
            this.bDonate.Text = "Donate";
            this.bDonate.UseVisualStyleBackColor = true;
            this.bDonate.Click += new System.EventHandler(this.bDonate_Click);
            // 
            // about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 166);
            this.Controls.Add(this.bVisit);
            this.Controls.Add(this.bDonate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "about";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "about";
            this.Load += new System.EventHandler(this.about_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bVisit;
        private System.Windows.Forms.Button bDonate;
    }
}