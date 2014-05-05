namespace SF4BoxViewerDX
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.labelP1 = new System.Windows.Forms.Label();
            this.labelP2 = new System.Windows.Forms.Label();
            this.labelBasic = new System.Windows.Forms.Label();
            this.labelHit = new System.Windows.Forms.Label();
            this.labelGrab = new System.Windows.Forms.Label();
            this.labelProjectile = new System.Windows.Forms.Label();
            this.cbP1Basic = new System.Windows.Forms.CheckBox();
            this.cbP1Hit = new System.Windows.Forms.CheckBox();
            this.cbP1Grab = new System.Windows.Forms.CheckBox();
            this.cbP1Projectile = new System.Windows.Forms.CheckBox();
            this.cbP2Projectile = new System.Windows.Forms.CheckBox();
            this.cbP2Grab = new System.Windows.Forms.CheckBox();
            this.cbP2Hit = new System.Windows.Forms.CheckBox();
            this.cbP2Basic = new System.Windows.Forms.CheckBox();
            this.lbBoxes = new System.Windows.Forms.ListBox();
            this.lbAddedBoxes = new System.Windows.Forms.ListBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.cbVsync = new System.Windows.Forms.CheckBox();
            this.cbSteam = new System.Windows.Forms.CheckBox();
            this.labelProx = new System.Windows.Forms.Label();
            this.cbP2Prox = new System.Windows.Forms.CheckBox();
            this.cbP1Prox = new System.Windows.Forms.CheckBox();
            this.bAbout = new System.Windows.Forms.Button();
            this.labelShowInfo = new System.Windows.Forms.Label();
            this.cbShowInfo = new System.Windows.Forms.CheckBox();
            this.bPause = new System.Windows.Forms.Button();
            this.bNextFrame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelP1
            // 
            this.labelP1.AutoSize = true;
            this.labelP1.Location = new System.Drawing.Point(134, 9);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(20, 13);
            this.labelP1.TabIndex = 0;
            this.labelP1.Text = "P1";
            // 
            // labelP2
            // 
            this.labelP2.AutoSize = true;
            this.labelP2.Location = new System.Drawing.Point(174, 9);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(20, 13);
            this.labelP2.TabIndex = 1;
            this.labelP2.Text = "P2";
            // 
            // labelBasic
            // 
            this.labelBasic.AutoSize = true;
            this.labelBasic.Location = new System.Drawing.Point(12, 25);
            this.labelBasic.Name = "labelBasic";
            this.labelBasic.Size = new System.Drawing.Size(33, 13);
            this.labelBasic.TabIndex = 2;
            this.labelBasic.Text = "Basic";
            // 
            // labelHit
            // 
            this.labelHit.AutoSize = true;
            this.labelHit.Location = new System.Drawing.Point(12, 38);
            this.labelHit.Name = "labelHit";
            this.labelHit.Size = new System.Drawing.Size(38, 13);
            this.labelHit.TabIndex = 4;
            this.labelHit.Text = "Attack";
            // 
            // labelGrab
            // 
            this.labelGrab.AutoSize = true;
            this.labelGrab.Location = new System.Drawing.Point(12, 51);
            this.labelGrab.Name = "labelGrab";
            this.labelGrab.Size = new System.Drawing.Size(37, 13);
            this.labelGrab.TabIndex = 5;
            this.labelGrab.Text = "Throw";
            // 
            // labelProjectile
            // 
            this.labelProjectile.AutoSize = true;
            this.labelProjectile.Location = new System.Drawing.Point(12, 64);
            this.labelProjectile.Name = "labelProjectile";
            this.labelProjectile.Size = new System.Drawing.Size(55, 13);
            this.labelProjectile.TabIndex = 6;
            this.labelProjectile.Text = "Projectiles";
            // 
            // cbP1Basic
            // 
            this.cbP1Basic.AutoSize = true;
            this.cbP1Basic.Location = new System.Drawing.Point(137, 25);
            this.cbP1Basic.Name = "cbP1Basic";
            this.cbP1Basic.Size = new System.Drawing.Size(15, 14);
            this.cbP1Basic.TabIndex = 7;
            this.cbP1Basic.UseVisualStyleBackColor = true;
            this.cbP1Basic.CheckedChanged += new System.EventHandler(this.cbP1Basic_CheckedChanged);
            // 
            // cbP1Hit
            // 
            this.cbP1Hit.AutoSize = true;
            this.cbP1Hit.Location = new System.Drawing.Point(137, 38);
            this.cbP1Hit.Name = "cbP1Hit";
            this.cbP1Hit.Size = new System.Drawing.Size(15, 14);
            this.cbP1Hit.TabIndex = 9;
            this.cbP1Hit.UseVisualStyleBackColor = true;
            this.cbP1Hit.CheckedChanged += new System.EventHandler(this.cbP1Hit_CheckedChanged);
            // 
            // cbP1Grab
            // 
            this.cbP1Grab.AutoSize = true;
            this.cbP1Grab.Location = new System.Drawing.Point(137, 51);
            this.cbP1Grab.Name = "cbP1Grab";
            this.cbP1Grab.Size = new System.Drawing.Size(15, 14);
            this.cbP1Grab.TabIndex = 10;
            this.cbP1Grab.UseVisualStyleBackColor = true;
            this.cbP1Grab.CheckedChanged += new System.EventHandler(this.cbP1Grab_CheckedChanged);
            // 
            // cbP1Projectile
            // 
            this.cbP1Projectile.AutoSize = true;
            this.cbP1Projectile.Location = new System.Drawing.Point(137, 64);
            this.cbP1Projectile.Name = "cbP1Projectile";
            this.cbP1Projectile.Size = new System.Drawing.Size(15, 14);
            this.cbP1Projectile.TabIndex = 11;
            this.cbP1Projectile.UseVisualStyleBackColor = true;
            this.cbP1Projectile.CheckedChanged += new System.EventHandler(this.cbP1Projectile_CheckedChanged);
            // 
            // cbP2Projectile
            // 
            this.cbP2Projectile.AutoSize = true;
            this.cbP2Projectile.Location = new System.Drawing.Point(177, 64);
            this.cbP2Projectile.Name = "cbP2Projectile";
            this.cbP2Projectile.Size = new System.Drawing.Size(15, 14);
            this.cbP2Projectile.TabIndex = 16;
            this.cbP2Projectile.UseVisualStyleBackColor = true;
            this.cbP2Projectile.CheckedChanged += new System.EventHandler(this.cbP2Projectile_CheckedChanged);
            // 
            // cbP2Grab
            // 
            this.cbP2Grab.AutoSize = true;
            this.cbP2Grab.Location = new System.Drawing.Point(177, 51);
            this.cbP2Grab.Name = "cbP2Grab";
            this.cbP2Grab.Size = new System.Drawing.Size(15, 14);
            this.cbP2Grab.TabIndex = 15;
            this.cbP2Grab.UseVisualStyleBackColor = true;
            this.cbP2Grab.CheckedChanged += new System.EventHandler(this.cbP2Grab_CheckedChanged);
            // 
            // cbP2Hit
            // 
            this.cbP2Hit.AutoSize = true;
            this.cbP2Hit.Location = new System.Drawing.Point(177, 38);
            this.cbP2Hit.Name = "cbP2Hit";
            this.cbP2Hit.Size = new System.Drawing.Size(15, 14);
            this.cbP2Hit.TabIndex = 14;
            this.cbP2Hit.UseVisualStyleBackColor = true;
            this.cbP2Hit.CheckedChanged += new System.EventHandler(this.cbP2Hit_CheckedChanged);
            // 
            // cbP2Basic
            // 
            this.cbP2Basic.AutoSize = true;
            this.cbP2Basic.Location = new System.Drawing.Point(177, 25);
            this.cbP2Basic.Name = "cbP2Basic";
            this.cbP2Basic.Size = new System.Drawing.Size(15, 14);
            this.cbP2Basic.TabIndex = 12;
            this.cbP2Basic.UseVisualStyleBackColor = true;
            this.cbP2Basic.CheckedChanged += new System.EventHandler(this.cbP2Basic_CheckedChanged);
            // 
            // lbBoxes
            // 
            this.lbBoxes.FormattingEnabled = true;
            this.lbBoxes.Location = new System.Drawing.Point(15, 119);
            this.lbBoxes.Name = "lbBoxes";
            this.lbBoxes.Size = new System.Drawing.Size(57, 134);
            this.lbBoxes.TabIndex = 17;
            // 
            // lbAddedBoxes
            // 
            this.lbAddedBoxes.FormattingEnabled = true;
            this.lbAddedBoxes.Location = new System.Drawing.Point(135, 119);
            this.lbAddedBoxes.Name = "lbAddedBoxes";
            this.lbAddedBoxes.Size = new System.Drawing.Size(57, 134);
            this.lbAddedBoxes.TabIndex = 18;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(78, 158);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(51, 23);
            this.bAdd.TabIndex = 19;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bRemove
            // 
            this.bRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRemove.Location = new System.Drawing.Point(78, 187);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(51, 23);
            this.bRemove.TabIndex = 20;
            this.bRemove.Text = "Remove";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // cbVsync
            // 
            this.cbVsync.AutoSize = true;
            this.cbVsync.Location = new System.Drawing.Point(17, 259);
            this.cbVsync.Name = "cbVsync";
            this.cbVsync.Size = new System.Drawing.Size(55, 17);
            this.cbVsync.TabIndex = 21;
            this.cbVsync.Text = "Vsync";
            this.cbVsync.UseVisualStyleBackColor = true;
            this.cbVsync.CheckedChanged += new System.EventHandler(this.cbVsync_CheckedChanged);
            // 
            // cbSteam
            // 
            this.cbSteam.AutoSize = true;
            this.cbSteam.Location = new System.Drawing.Point(100, 259);
            this.cbSteam.Name = "cbSteam";
            this.cbSteam.Size = new System.Drawing.Size(94, 17);
            this.cbSteam.TabIndex = 22;
            this.cbSteam.Text = "Steam Version";
            this.cbSteam.UseVisualStyleBackColor = true;
            this.cbSteam.CheckedChanged += new System.EventHandler(this.cbSteam_CheckedChanged);
            // 
            // labelProx
            // 
            this.labelProx.AutoSize = true;
            this.labelProx.Location = new System.Drawing.Point(12, 77);
            this.labelProx.Name = "labelProx";
            this.labelProx.Size = new System.Drawing.Size(48, 13);
            this.labelProx.TabIndex = 23;
            this.labelProx.Text = "Proximity";
            // 
            // cbP2Prox
            // 
            this.cbP2Prox.AutoSize = true;
            this.cbP2Prox.Location = new System.Drawing.Point(177, 77);
            this.cbP2Prox.Name = "cbP2Prox";
            this.cbP2Prox.Size = new System.Drawing.Size(15, 14);
            this.cbP2Prox.TabIndex = 25;
            this.cbP2Prox.UseVisualStyleBackColor = true;
            this.cbP2Prox.CheckedChanged += new System.EventHandler(this.cbP2Prox_CheckedChanged);
            // 
            // cbP1Prox
            // 
            this.cbP1Prox.AutoSize = true;
            this.cbP1Prox.Location = new System.Drawing.Point(137, 77);
            this.cbP1Prox.Name = "cbP1Prox";
            this.cbP1Prox.Size = new System.Drawing.Size(15, 14);
            this.cbP1Prox.TabIndex = 24;
            this.cbP1Prox.UseVisualStyleBackColor = true;
            this.cbP1Prox.CheckedChanged += new System.EventHandler(this.cbP1Prox_CheckedChanged);
            // 
            // bAbout
            // 
            this.bAbout.Location = new System.Drawing.Point(64, 314);
            this.bAbout.Name = "bAbout";
            this.bAbout.Size = new System.Drawing.Size(75, 23);
            this.bAbout.TabIndex = 26;
            this.bAbout.Text = "About";
            this.bAbout.UseVisualStyleBackColor = true;
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // labelShowInfo
            // 
            this.labelShowInfo.AutoSize = true;
            this.labelShowInfo.Location = new System.Drawing.Point(12, 90);
            this.labelShowInfo.Name = "labelShowInfo";
            this.labelShowInfo.Size = new System.Drawing.Size(89, 13);
            this.labelShowInfo.TabIndex = 27;
            this.labelShowInfo.Text = "Show Information";
            // 
            // cbShowInfo
            // 
            this.cbShowInfo.AutoSize = true;
            this.cbShowInfo.Location = new System.Drawing.Point(157, 90);
            this.cbShowInfo.Name = "cbShowInfo";
            this.cbShowInfo.Size = new System.Drawing.Size(15, 14);
            this.cbShowInfo.TabIndex = 28;
            this.cbShowInfo.UseVisualStyleBackColor = true;
            this.cbShowInfo.CheckedChanged += new System.EventHandler(this.cbShowInfo_CheckedChanged);
            // 
            // bPause
            // 
            this.bPause.Location = new System.Drawing.Point(15, 282);
            this.bPause.Name = "bPause";
            this.bPause.Size = new System.Drawing.Size(75, 23);
            this.bPause.TabIndex = 29;
            this.bPause.Text = "Pause";
            this.bPause.UseVisualStyleBackColor = true;
            this.bPause.Click += new System.EventHandler(this.bPause_Click);
            // 
            // bNextFrame
            // 
            this.bNextFrame.Location = new System.Drawing.Point(117, 282);
            this.bNextFrame.Name = "bNextFrame";
            this.bNextFrame.Size = new System.Drawing.Size(75, 23);
            this.bNextFrame.TabIndex = 30;
            this.bNextFrame.Text = "Next Frame";
            this.bNextFrame.UseVisualStyleBackColor = true;
            this.bNextFrame.Click += new System.EventHandler(this.bNextFrame_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 345);
            this.Controls.Add(this.bNextFrame);
            this.Controls.Add(this.bPause);
            this.Controls.Add(this.cbShowInfo);
            this.Controls.Add(this.labelShowInfo);
            this.Controls.Add(this.bAbout);
            this.Controls.Add(this.cbP2Prox);
            this.Controls.Add(this.cbP1Prox);
            this.Controls.Add(this.labelProx);
            this.Controls.Add(this.cbSteam);
            this.Controls.Add(this.cbVsync);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.lbAddedBoxes);
            this.Controls.Add(this.lbBoxes);
            this.Controls.Add(this.cbP2Projectile);
            this.Controls.Add(this.cbP2Grab);
            this.Controls.Add(this.cbP2Hit);
            this.Controls.Add(this.cbP2Basic);
            this.Controls.Add(this.cbP1Projectile);
            this.Controls.Add(this.cbP1Grab);
            this.Controls.Add(this.cbP1Hit);
            this.Controls.Add(this.cbP1Basic);
            this.Controls.Add(this.labelProjectile);
            this.Controls.Add(this.labelGrab);
            this.Controls.Add(this.labelHit);
            this.Controls.Add(this.labelBasic);
            this.Controls.Add(this.labelP2);
            this.Controls.Add(this.labelP1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.Text = "SF4 Box Viewer v0.12";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Label labelP2;
        private System.Windows.Forms.Label labelBasic;
        private System.Windows.Forms.Label labelHit;
        private System.Windows.Forms.Label labelGrab;
        private System.Windows.Forms.Label labelProjectile;
        private System.Windows.Forms.CheckBox cbP1Basic;
        private System.Windows.Forms.CheckBox cbP1Hit;
        private System.Windows.Forms.CheckBox cbP1Grab;
        private System.Windows.Forms.CheckBox cbP1Projectile;
        private System.Windows.Forms.CheckBox cbP2Projectile;
        private System.Windows.Forms.CheckBox cbP2Grab;
        private System.Windows.Forms.CheckBox cbP2Hit;
        private System.Windows.Forms.CheckBox cbP2Basic;
        private System.Windows.Forms.ListBox lbBoxes;
        private System.Windows.Forms.ListBox lbAddedBoxes;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.CheckBox cbVsync;
        private System.Windows.Forms.CheckBox cbSteam;
        private System.Windows.Forms.Label labelProx;
        private System.Windows.Forms.CheckBox cbP2Prox;
        private System.Windows.Forms.CheckBox cbP1Prox;
        private System.Windows.Forms.Button bAbout;
        private System.Windows.Forms.Label labelShowInfo;
        private System.Windows.Forms.CheckBox cbShowInfo;
        private System.Windows.Forms.Button bPause;
        private System.Windows.Forms.Button bNextFrame;
    }
}