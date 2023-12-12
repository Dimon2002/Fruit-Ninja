namespace Fruit_Ninja
{
    partial class HighScoresForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighScoresForm));
            this.lblCurrUser = new System.Windows.Forms.Label();
            this.lblAllUsers = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.ListBox();
            this.lbUserName = new System.Windows.Forms.ListBox();
            this.lbScores = new System.Windows.Forms.ListBox();
            this.lbDate = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pbBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrUser
            // 
            this.lblCurrUser.AutoSize = true;
            this.lblCurrUser.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCurrUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrUser.ForeColor = System.Drawing.Color.White;
            this.lblCurrUser.Location = new System.Drawing.Point(13, 13);
            this.lblCurrUser.Name = "lblCurrUser";
            this.lblCurrUser.Size = new System.Drawing.Size(128, 24);
            this.lblCurrUser.TabIndex = 0;
            this.lblCurrUser.Text = "Current User";
            this.lblCurrUser.Click += new System.EventHandler(this.CurrentUser_Click);
            // 
            // lblAllUsers
            // 
            this.lblAllUsers.AutoSize = true;
            this.lblAllUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblAllUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAllUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllUsers.ForeColor = System.Drawing.Color.White;
            this.lblAllUsers.Location = new System.Drawing.Point(296, 13);
            this.lblAllUsers.Name = "lblAllUsers";
            this.lblAllUsers.Size = new System.Drawing.Size(93, 24);
            this.lblAllUsers.TabIndex = 1;
            this.lblAllUsers.Text = "All Users";
            this.lblAllUsers.Click += new System.EventHandler(this.AllUsers_Click);
            // 
            // lbNumber
            // 
            this.lbNumber.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumber.ForeColor = System.Drawing.Color.Black;
            this.lbNumber.FormattingEnabled = true;
            this.lbNumber.ItemHeight = 24;
            this.lbNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.lbNumber.Location = new System.Drawing.Point(17, 101);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbNumber.Size = new System.Drawing.Size(40, 244);
            this.lbNumber.TabIndex = 2;
            // 
            // lbUserName
            // 
            this.lbUserName.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.Black;
            this.lbUserName.FormattingEnabled = true;
            this.lbUserName.ItemHeight = 24;
            this.lbUserName.Location = new System.Drawing.Point(64, 101);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbUserName.Size = new System.Drawing.Size(207, 244);
            this.lbUserName.TabIndex = 3;
            // 
            // lbScores
            // 
            this.lbScores.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScores.ForeColor = System.Drawing.Color.Black;
            this.lbScores.FormattingEnabled = true;
            this.lbScores.ItemHeight = 24;
            this.lbScores.Location = new System.Drawing.Point(275, 101);
            this.lbScores.Name = "lbScores";
            this.lbScores.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbScores.Size = new System.Drawing.Size(124, 244);
            this.lbScores.TabIndex = 4;
            // 
            // lbDate
            // 
            this.lbDate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.ForeColor = System.Drawing.Color.Black;
            this.lbDate.FormattingEnabled = true;
            this.lbDate.ItemHeight = 24;
            this.lbDate.Location = new System.Drawing.Point(406, 101);
            this.lbDate.Name = "lbDate";
            this.lbDate.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbDate.Size = new System.Drawing.Size(250, 244);
            this.lbDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(256, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "|";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "#   ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(64, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Username           ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(275, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Score      ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(406, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "Date                             ";
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Transparent;
            this.pbBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBack.Image = global::Fruit_Ninja.Properties.Resources.back;
            this.pbBack.Location = new System.Drawing.Point(600, 13);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(56, 53);
            this.pbBack.TabIndex = 11;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.Back_Click);
            // 
            // HighScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fruit_Ninja.Properties.Resources.background3;
            this.ClientSize = new System.Drawing.Size(668, 358);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbScores);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.lblAllUsers);
            this.Controls.Add(this.lblCurrUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HighScoresForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hall of Fame";
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrUser;
        private System.Windows.Forms.Label lblAllUsers;
        private System.Windows.Forms.ListBox lbNumber;
        private System.Windows.Forms.ListBox lbUserName;
        private System.Windows.Forms.ListBox lbScores;
        private System.Windows.Forms.ListBox lbDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbBack;
    }
}