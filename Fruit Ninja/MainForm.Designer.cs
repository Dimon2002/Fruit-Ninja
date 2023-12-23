using System.Windows.Forms;

namespace Fruit_Ninja
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbHighscores = new System.Windows.Forms.PictureBox();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbSettings = new System.Windows.Forms.PictureBox();
            this.pbPlay = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.panelGame = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pbQuit = new System.Windows.Forms.PictureBox();
            this.pbUnpause = new System.Windows.Forms.PictureBox();
            this.pbPause = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.timeTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighscores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).BeginInit();
            this.panelGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnpause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.89543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.89543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.89543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.36598F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.94772F));
            this.tableLayoutPanel1.Controls.Add(this.pbHighscores, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbUser, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbExit, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.pbSettings, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.pbPlay, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblUser, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // Highscores
            // 
            this.pbHighscores.BackColor = System.Drawing.Color.Transparent;
            this.pbHighscores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHighscores.Image = global::Fruit_Ninja.Properties.Resources.trophy;
            this.pbHighscores.Location = new System.Drawing.Point(3, 3);
            this.pbHighscores.Name = "pbHighscores";
            this.pbHighscores.Size = new System.Drawing.Size(102, 102);
            this.pbHighscores.TabIndex = 4;
            this.pbHighscores.TabStop = false;
            this.pbHighscores.Click += new System.EventHandler(this.TopScores_Click);
            // 
            // pbUser
            // 
            this.pbUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbUser.BackColor = System.Drawing.Color.Transparent;
            this.pbUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUser.Image = global::Fruit_Ninja.Properties.Resources.user;
            this.pbUser.Location = new System.Drawing.Point(703, 3);
            this.pbUser.Name = "pbUser";
            this.pbUser.Padding = new System.Windows.Forms.Padding(0, 13, 0, 0);
            this.pbUser.Size = new System.Drawing.Size(67, 78);
            this.pbUser.TabIndex = 7;
            this.pbUser.TabStop = false;
            this.pbUser.Click += new System.EventHandler(this.User_Click);
            // 
            // pbExit
            // 
            this.pbExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Image = global::Fruit_Ninja.Properties.Resources.exit2;
            this.pbExit.Location = new System.Drawing.Point(704, 481);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(65, 77);
            this.pbExit.TabIndex = 8;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // pbSettings
            // 
            this.pbSettings.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbSettings.BackColor = System.Drawing.Color.Transparent;
            this.pbSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSettings.Image = global::Fruit_Ninja.Properties.Resources.settings;
            this.pbSettings.Location = new System.Drawing.Point(451, 339);
            this.pbSettings.Name = "pbSettings";
            this.pbSettings.Size = new System.Drawing.Size(107, 105);
            this.pbSettings.TabIndex = 6;
            this.pbSettings.TabStop = false;
            this.pbSettings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // pbPlay
            // 
            this.pbPlay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbPlay.BackColor = System.Drawing.Color.Transparent;
            this.pbPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlay.Image = global::Fruit_Ninja.Properties.Resources.play2;
            this.pbPlay.Location = new System.Drawing.Point(264, 339);
            this.pbPlay.Name = "pbPlay";
            this.pbPlay.Size = new System.Drawing.Size(107, 106);
            this.pbPlay.TabIndex = 5;
            this.pbPlay.TabStop = false;
            this.pbPlay.Click += new System.EventHandler(this.Play_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(628, 0);
            this.lblUser.Margin = new System.Windows.Forms.Padding(3, 0, 3, 25);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 87);
            this.lblUser.TabIndex = 9;
            this.lblUser.Text = "Guest";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Transparent;
            this.panelGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelGame.Controls.Add(this.lblTime);
            this.panelGame.Controls.Add(this.lblScore);
            this.panelGame.Controls.Add(this.pbQuit);
            this.panelGame.Controls.Add(this.pbUnpause);
            this.panelGame.Controls.Add(this.pbPause);
            this.panelGame.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(784, 561);
            this.panelGame.TabIndex = 12;
            this.panelGame.Visible = false;
            //this.panelGame.Click += new System.EventHandler(this.PanelGame_Click);
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelGame_Paint);
            this.panelGame.MouseMove += new MouseEventHandler(this.PanelGame_MouseMove);
            this.panelGame.MouseUp += new MouseEventHandler(this.PanelGame_MouseUp);
            this.panelGame.MouseDown += new MouseEventHandler(this.PanelGame_Click);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(600, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(150, 55);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "01:00";
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(716, 496);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(52, 55);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "0";
            // 
            // pbQuit
            // 
            this.pbQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbQuit.BackColor = System.Drawing.Color.Transparent;
            this.pbQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbQuit.Image = global::Fruit_Ninja.Properties.Resources.back;
            this.pbQuit.Location = new System.Drawing.Point(12, 496);
            this.pbQuit.Name = "pbQuit";
            this.pbQuit.Size = new System.Drawing.Size(58, 53);
            this.pbQuit.TabIndex = 3;
            this.pbQuit.TabStop = false;
            this.pbQuit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // pbUnpause
            // 
            this.pbUnpause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbUnpause.BackColor = System.Drawing.Color.Transparent;
            this.pbUnpause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUnpause.Image = global::Fruit_Ninja.Properties.Resources.unpaused;
            this.pbUnpause.Location = new System.Drawing.Point(279, 151);
            this.pbUnpause.Name = "pbUnpause";
            this.pbUnpause.Size = new System.Drawing.Size(233, 238);
            this.pbUnpause.TabIndex = 2;
            this.pbUnpause.TabStop = false;
            this.pbUnpause.Click += new System.EventHandler(this.UnPause_Click);
            // 
            // pbPause
            // 
            this.pbPause.BackColor = System.Drawing.Color.Transparent;
            this.pbPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPause.Image = global::Fruit_Ninja.Properties.Resources.pause;
            this.pbPause.Location = new System.Drawing.Point(0, 3);
            this.pbPause.Name = "pbPause";
            this.pbPause.Size = new System.Drawing.Size(35, 33);
            this.pbPause.TabIndex = 1;
            this.pbPause.TabStop = false;
            this.pbPause.Visible = false;
            this.pbPause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // timeTimer
            // 
            this.timeTimer.Interval = 1000;
            this.timeTimer.Tick += new System.EventHandler(this.ViewTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Fruit_Ninja.Properties.Resources._2013_08_28_105146;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fruit Ninja";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighscores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlay)).EndInit();
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnpause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPause)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox pbPlay;
        private System.Windows.Forms.PictureBox pbSettings;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.PictureBox pbHighscores;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbPause;
        public System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.PictureBox pbUnpause;
        private System.Windows.Forms.PictureBox pbQuit;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timeTimer;
    }
}

