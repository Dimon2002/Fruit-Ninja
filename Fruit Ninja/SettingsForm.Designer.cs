namespace Fruit_Ninja
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblSize = new System.Windows.Forms.Label();
            this.lbl1680x1050 = new System.Windows.Forms.Label();
            this.lbl1920x1080 = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblEasy = new System.Windows.Forms.Label();
            this.lblMedium = new System.Windows.Forms.Label();
            this.lblHard = new System.Windows.Forms.Label();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.Font = new System.Drawing.Font("Engravers MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.White;
            this.lblSize.Location = new System.Drawing.Point(12, 24);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(242, 28);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Window Size";
            // 
            // lbl1680x1050
            // 
            this.lbl1680x1050.AutoSize = true;
            this.lbl1680x1050.BackColor = System.Drawing.Color.Transparent;
            this.lbl1680x1050.Enabled = false;
            this.lbl1680x1050.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1680x1050.ForeColor = System.Drawing.Color.White;
            this.lbl1680x1050.Location = new System.Drawing.Point(1, 74);
            this.lbl1680x1050.Name = "lbl1680x1050";
            this.lbl1680x1050.Size = new System.Drawing.Size(134, 22);
            this.lbl1680x1050.TabIndex = 1;
            this.lbl1680x1050.Text = "1680x1050";
            this.lbl1680x1050.Click += new System.EventHandler(this.Label1680x1050_Click);
            // 
            // lbl1920x1080
            // 
            this.lbl1920x1080.AutoSize = true;
            this.lbl1920x1080.BackColor = System.Drawing.Color.Transparent;
            this.lbl1920x1080.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1920x1080.ForeColor = System.Drawing.Color.White;
            this.lbl1920x1080.Location = new System.Drawing.Point(132, 74);
            this.lbl1920x1080.Name = "lbl1920x1080";
            this.lbl1920x1080.Size = new System.Drawing.Size(134, 22);
            this.lbl1920x1080.TabIndex = 2;
            this.lbl1920x1080.Text = "1920x1080";
            this.lbl1920x1080.Click += new System.EventHandler(this.Label1920x1080_Click);
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.BackColor = System.Drawing.Color.Transparent;
            this.lblDifficulty.Font = new System.Drawing.Font("Engravers MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficulty.ForeColor = System.Drawing.Color.White;
            this.lblDifficulty.Location = new System.Drawing.Point(32, 120);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(221, 28);
            this.lblDifficulty.TabIndex = 3;
            this.lblDifficulty.Text = "Difficulty";
            // 
            // lblEasy
            // 
            this.lblEasy.AutoSize = true;
            this.lblEasy.BackColor = System.Drawing.Color.Transparent;
            this.lblEasy.Enabled = false;
            this.lblEasy.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEasy.ForeColor = System.Drawing.Color.White;
            this.lblEasy.Location = new System.Drawing.Point(93, 161);
            this.lblEasy.Name = "lblEasy";
            this.lblEasy.Size = new System.Drawing.Size(81, 22);
            this.lblEasy.TabIndex = 4;
            this.lblEasy.Text = "Easy";
            this.lblEasy.Click += new System.EventHandler(this.EasyClick);
            // 
            // lblMedium
            // 
            this.lblMedium.AutoSize = true;
            this.lblMedium.BackColor = System.Drawing.Color.Transparent;
            this.lblMedium.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedium.ForeColor = System.Drawing.Color.White;
            this.lblMedium.Location = new System.Drawing.Point(74, 198);
            this.lblMedium.Name = "lblMedium";
            this.lblMedium.Size = new System.Drawing.Size(122, 22);
            this.lblMedium.TabIndex = 5;
            this.lblMedium.Text = "Medium";
            this.lblMedium.Click += new System.EventHandler(this.Medium_Click);
            // 
            // lblHard
            // 
            this.lblHard.AutoSize = true;
            this.lblHard.BackColor = System.Drawing.Color.Transparent;
            this.lblHard.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHard.ForeColor = System.Drawing.Color.White;
            this.lblHard.Location = new System.Drawing.Point(93, 236);
            this.lblHard.Name = "lblHard";
            this.lblHard.Size = new System.Drawing.Size(88, 22);
            this.lblHard.TabIndex = 6;
            this.lblHard.Text = "Hard";
            this.lblHard.Click += new System.EventHandler(this.Hard_Click);
            // 
            // lblOK
            // 
            this.lblOK.AutoSize = true;
            this.lblOK.BackColor = System.Drawing.Color.Transparent;
            this.lblOK.Enabled = false;
            this.lblOK.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOK.ForeColor = System.Drawing.Color.White;
            this.lblOK.Location = new System.Drawing.Point(13, 286);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(49, 22);
            this.lblOK.TabIndex = 7;
            this.lblOK.Text = "OK";
            this.lblOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("Engravers MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(178, 286);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(76, 22);
            this.lblExit.TabIndex = 8;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fruit_Ninja.Properties.Resources._2013_08_28_105146;
            this.ClientSize = new System.Drawing.Size(270, 321);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.lblHard);
            this.Controls.Add(this.lblMedium);
            this.Controls.Add(this.lblEasy);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lbl1920x1080);
            this.Controls.Add(this.lbl1680x1050);
            this.Controls.Add(this.lblSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lbl1680x1050;
        private System.Windows.Forms.Label lbl1920x1080;
        private System.Windows.Forms.Label lblHard;
        private System.Windows.Forms.Label lblMedium;
        private System.Windows.Forms.Label lblEasy;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblExit;
    }
}