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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            tableLayoutPanel1 = new TableLayoutPanel();
            pbHighscores = new PictureBox();
            pbUser = new PictureBox();
            pbExit = new PictureBox();
            lblUser = new Label();
            pbPlay = new PictureBox();
            pbSettings = new PictureBox();
            panelGame = new Panel();
            lblTime = new Label();
            lblScore = new Label();
            pbQuit = new PictureBox();
            pbUnpause = new PictureBox();
            pbPause = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            timeTimer = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbHighscores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbExit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPlay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbSettings).BeginInit();
            panelGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbQuit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbUnpause).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPause).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.89543F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.89543F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.89543F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.36598F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.94772F));
            tableLayoutPanel1.Controls.Add(pbHighscores, 0, 0);
            tableLayoutPanel1.Controls.Add(pbUser, 4, 0);
            tableLayoutPanel1.Controls.Add(pbExit, 4, 4);
            tableLayoutPanel1.Controls.Add(lblUser, 3, 0);
            tableLayoutPanel1.Controls.Add(pbPlay, 1, 4);
            tableLayoutPanel1.Controls.Add(pbSettings, 2, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tableLayoutPanel1.Size = new Size(1924, 1061);
            tableLayoutPanel1.TabIndex = 10;
            // 
            // pbHighscores
            // 
            pbHighscores.BackColor = Color.Transparent;
            pbHighscores.Cursor = Cursors.Hand;
            pbHighscores.Image = Properties.Resources.trophy;
            pbHighscores.Location = new Point(4, 3);
            pbHighscores.Margin = new Padding(4, 3, 4, 3);
            pbHighscores.Name = "pbHighscores";
            pbHighscores.Size = new Size(119, 118);
            pbHighscores.TabIndex = 4;
            pbHighscores.TabStop = false;
            pbHighscores.Click += TopScores_Click;
            // 
            // pbUser
            // 
            pbUser.Anchor = AnchorStyles.Top;
            pbUser.BackColor = Color.Transparent;
            pbUser.Cursor = Cursors.Hand;
            pbUser.Image = Properties.Resources.user;
            pbUser.Location = new Point(1768, 3);
            pbUser.Margin = new Padding(4, 3, 4, 3);
            pbUser.Name = "pbUser";
            pbUser.Padding = new Padding(0, 15, 0, 0);
            pbUser.Size = new Size(78, 90);
            pbUser.TabIndex = 7;
            pbUser.TabStop = false;
            pbUser.Click += User_Click;
            // 
            // pbExit
            // 
            pbExit.Anchor = AnchorStyles.Bottom;
            pbExit.BackColor = Color.Transparent;
            pbExit.Cursor = Cursors.Hand;
            pbExit.Image = Properties.Resources.exit2;
            pbExit.Location = new Point(1769, 969);
            pbExit.Margin = new Padding(4, 3, 4, 3);
            pbExit.Name = "pbExit";
            pbExit.Size = new Size(76, 89);
            pbExit.TabIndex = 8;
            pbExit.TabStop = false;
            pbExit.Click += Exit_Click;
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(1627, 46);
            lblUser.Margin = new Padding(0, 46, 0, 0);
            lblUser.Name = "lblUser";
            lblUser.RightToLeft = RightToLeft.No;
            lblUser.Size = new Size(64, 24);
            lblUser.TabIndex = 0;
            lblUser.Text = "Guest";
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            lblUser.UseMnemonic = false;
            // 
            // pbPlay
            // 
            pbPlay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbPlay.BackColor = Color.Transparent;
            pbPlay.Cursor = Cursors.Hand;
            pbPlay.Image = Properties.Resources.play2;
            pbPlay.Location = new Point(770, 851);
            pbPlay.Margin = new Padding(4, 3, 23, 3);
            pbPlay.Name = "pbPlay";
            pbPlay.Size = new Size(125, 122);
            pbPlay.TabIndex = 5;
            pbPlay.TabStop = false;
            pbPlay.Click += Play_Click;
            // 
            // pbSettings
            // 
            pbSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbSettings.BackColor = Color.Transparent;
            pbSettings.Cursor = Cursors.Hand;
            pbSettings.Image = Properties.Resources.settings;
            pbSettings.Location = new Point(1159, 851);
            pbSettings.Margin = new Padding(4, 3, 93, 3);
            pbSettings.Name = "pbSettings";
            pbSettings.Size = new Size(125, 121);
            pbSettings.TabIndex = 6;
            pbSettings.TabStop = false;
            pbSettings.Click += Settings_Click;
            // 
            // panelGame
            // 
            panelGame.BackColor = Color.Transparent;
            panelGame.BackgroundImageLayout = ImageLayout.Stretch;
            panelGame.Controls.Add(lblTime);
            panelGame.Controls.Add(lblScore);
            panelGame.Controls.Add(pbQuit);
            panelGame.Controls.Add(pbUnpause);
            panelGame.Controls.Add(pbPause);
            panelGame.Cursor = Cursors.Cross;
            panelGame.Dock = DockStyle.Fill;
            panelGame.Location = new Point(0, 0);
            panelGame.Margin = new Padding(4, 3, 4, 3);
            panelGame.Name = "panelGame";
            panelGame.Size = new Size(1924, 1061);
            panelGame.TabIndex = 12;
            panelGame.Visible = false;
            panelGame.Paint += PanelGame_Paint;
            panelGame.MouseDown += PanelGame_Click;
            panelGame.MouseMove += PanelGame_MouseMove;
            panelGame.MouseUp += PanelGame_MouseUp;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTime.ForeColor = Color.White;
            lblTime.Location = new Point(1710, 10);
            lblTime.Margin = new Padding(4, 0, 4, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(150, 55);
            lblTime.TabIndex = 6;
            lblTime.Text = "01:00";
            // 
            // lblScore
            // 
            lblScore.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(1845, 986);
            lblScore.Margin = new Padding(4, 0, 4, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(52, 55);
            lblScore.TabIndex = 4;
            lblScore.Text = "0";
            // 
            // pbQuit
            // 
            pbQuit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pbQuit.BackColor = Color.Transparent;
            pbQuit.Cursor = Cursors.Hand;
            pbQuit.Image = Properties.Resources.back;
            pbQuit.Location = new Point(14, 986);
            pbQuit.Margin = new Padding(4, 3, 4, 3);
            pbQuit.Name = "pbQuit";
            pbQuit.Size = new Size(68, 61);
            pbQuit.TabIndex = 3;
            pbQuit.TabStop = false;
            pbQuit.Click += Quit_Click;
            // 
            // pbUnpause
            // 
            pbUnpause.Anchor = AnchorStyles.None;
            pbUnpause.BackColor = Color.Transparent;
            pbUnpause.Cursor = Cursors.Hand;
            pbUnpause.Image = Properties.Resources.unpaused;
            pbUnpause.Location = new Point(831, 381);
            pbUnpause.Margin = new Padding(4, 3, 4, 3);
            pbUnpause.Name = "pbUnpause";
            pbUnpause.Size = new Size(272, 275);
            pbUnpause.TabIndex = 2;
            pbUnpause.TabStop = false;
            pbUnpause.Click += UnPause_Click;
            // 
            // pbPause
            // 
            pbPause.BackColor = Color.Transparent;
            pbPause.Cursor = Cursors.Hand;
            pbPause.Image = Properties.Resources.pause;
            pbPause.Location = new Point(0, 3);
            pbPause.Margin = new Padding(4, 3, 4, 3);
            pbPause.Name = "pbPause";
            pbPause.Size = new Size(41, 38);
            pbPause.TabIndex = 1;
            pbPause.TabStop = false;
            pbPause.Visible = false;
            pbPause.Click += Pause_Click;
            // 
            // gameTimer
            // 
            gameTimer.Tick += GameTimer_Tick;
            // 
            // timeTimer
            // 
            timeTimer.Interval = 1000;
            timeTimer.Tick += ViewTimer_Tick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._2013_08_28_105146;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1924, 1061);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panelGame);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fruit Ninja";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbHighscores).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbExit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPlay).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbSettings).EndInit();
            panelGame.ResumeLayout(false);
            panelGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbQuit).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbUnpause).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPause).EndInit();
            ResumeLayout(false);
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

