using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;

namespace Fruit_Ninja
{
    public partial class Main : Form
    {
        private CustomToolTip _tip;

        public static Dictionary<string, User> users = new Dictionary<string, User>()
        {
            { "Guest", new User() {Name = "Guest"} }
        };

        public static User currentUser = new User() { Name = "Guest" };
        public static List<Score> topScores = new List<Score>();

        public static bool resize = false;

        public Game game;
        public bool canClick = false;
        public int ticks = 0;
        public string saveFile = Environment.CurrentDirectory + "\\save.txt";

        public Main()
        {
            InitializeComponent();

            SettingsForm.settings = new Settings(800, 600, "EASY");

            // LoadFromFile();

            //DoubleBuffered = true;

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panelGame, new object[] { true });
        }

        // TODO: Users upload score from file stats
        private void Main_Load(object sender, EventArgs e)
        {
            // LoadFromFile();
        }

        // TODO: Users score save to file stats
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SaveToFile();
        }

        private void PanelGame_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e);
            lblTime.Text = $@"00:{game.time:00}";
        }

        // TODO: Users Stats
        private void Highscores_Click(object sender, EventArgs e)
        {
            new HighScoresForm().Show();
            // x.ShowDialog();
        }
         
        private void User_Click(object sender, EventArgs e)
        {
            new UserForm().Show();
            // user.ShowDialog();

            lblUser.Text = currentUser.ToString();
        }
        
        private void Play_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                @"Are you sure you want to quit? Your progress won't be saved.", 
                @"Are you a loser?", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Stop);

            if (dr == DialogResult.No) return;

            tableLayoutPanel1.Visible = true;
            panelGame.Visible = false;

            if (ActiveForm != null)
                ActiveForm.BackgroundImage = Properties.Resources._2013_08_28_105146;
        }

        private void pbSettings_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();

            if (settings.ShowDialog() != DialogResult.OK) return;

            if (!resize) return;

            if (ActiveForm.Width == 800)
            {
                ActiveForm.Width += 224;
                ActiveForm.Height += 168;
                resize = false;
                ReallyCenterToScreen();
            }
            else
            {
                ActiveForm.Width -= 224;
                ActiveForm.Height -= 168;
                resize = true;
                ReallyCenterToScreen();
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(@"Are you sure you want to exit the game?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
                ActiveForm?.Close();
        }

        private void panelGame_Click(object sender, EventArgs e)
        {
            if (game.CheckClick(PointToClient(Cursor.Position)))
                StopGame();
        }

        private void pbPlay_MouseHover(object sender, EventArgs e)
        {
            _tip = new CustomToolTip(new Size(121, 48));
            _tip.SetToolTip(pbPlay, "PLAY");
        }

        private void pbSettings_MouseHover(object sender, EventArgs e)
        {
            _tip = new CustomToolTip(new Size(220, 48));
            _tip.SetToolTip(pbSettings, "SETTINGS");
        }

        private void pbHighscores_MouseHover(object sender, EventArgs e)
        {
            _tip = new CustomToolTip(new Size(312, 48));
            _tip.SetToolTip(pbHighscores, "HALL OF FAME");
        }

        private void pbUser_MouseHover(object sender, EventArgs e)
        {
            _tip = new CustomToolTip(new Size(121, 48));
            _tip.SetToolTip(pbUser, "USER");
        }

        private void pbExit_MouseHover(object sender, EventArgs e)
        {
            _tip = new CustomToolTip(new Size(121, 48));
            _tip.SetToolTip(pbExit, "EXIT");
        }

        private void lblUser_TextChanged(object sender, EventArgs e)
        {
            if (lblUser.Text.Length > 9)
                lblUser.Font = new Font(lblUser.Font.FontFamily, 8);
            else if (lblUser.Text.Length > 6)
                lblUser.Font = new Font(lblUser.Font.FontFamily, 10);
            else
                lblUser.Font = new Font(lblUser.Font.FontFamily, 12);
        }

        private void pbUnpause_Click(object sender, EventArgs e)
        {
            canClick = true;
            pbUnpause.Visible = false;
            pbPause.Visible = true;
            pbQuit.Visible = false;

            gameTimer.Start();
            timeTimer.Start();
        }

        private void pbPause_Click(object sender, EventArgs e)
        {
            canClick = false;
            pbUnpause.Visible = true;
            pbPause.Visible = false;
            pbQuit.Visible = true;

            gameTimer.Stop();
            timeTimer.Stop();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = game.currentScore.points.ToString();

            if (lblScore.Right > Width)
                lblScore.Left = Width - lblScore.Width - 20;

            var speed = 0;

            switch (SettingsForm.settings.Difficulty)
            {
                case "EASY":
                    {
                        speed = 40;
                        break;
                    }
                case "MEDIUM":
                    {
                        speed = 30;
                        break;
                    }
                case "HARD":
                    {
                        speed = 20;
                        break;
                    }
            }

            if (ticks++ % speed == 0)
                game.elements.Add(new Element());

            game.MoveElements();
            Invalidate(true);
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $@"00:{--game.time:00}";

            if (game.time == 0)
                StopGame();
        }

        public void NewGame()
        {
            pbUnpause.Visible = true;
            pbPause.Visible = false;
            tableLayoutPanel1.Visible = false;
            panelGame.Visible = true;

            lblScore.Text = @"0";

            game = new Game();

            if (ActiveForm != null) ActiveForm.BackgroundImage = game.background;

            NewMethod();

            Invalidate(true);
        }

        private void NewMethod()
        {
            switch (SettingsForm.settings.Difficulty)
            {
                case "EASY":
                    {
                        gameTimer.Interval = 50;
                        break;
                    }
                case "MEDIUM":
                    {
                        gameTimer.Interval = 30;
                        break;
                    }
                case "HARD":
                    {
                        gameTimer.Interval = 20;
                        break;
                    }
            }
        }

        public void StopGame()
        {
            var currentScore = new Score(int.Parse(lblScore.Text), DateTime.Now, lblUser.Text);

            topScores.Add(currentScore);
            currentUser.AddScore(currentScore);

            gameTimer.Stop();
            timeTimer.Stop();

            string text;
            string title;

            if (game.time != 0)
            {
                text =
                    $"Thank you for playing {currentUser.Name}. You have scored {game.currentScore.points} points! Play again?";
                title = "Game Over :(";
            }
            else
            {
                text =
                    $"No more time {currentUser.Name}. You have scored {game.currentScore.points} points! Play again?";
                title = "Time Up :(";
            }

            var dr = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                NewGame();
            }
            else
            {
                tableLayoutPanel1.Visible = true;
                panelGame.Visible = false;
                if (ActiveForm != null) ActiveForm.BackgroundImage = Properties.Resources._2013_08_28_105146;
            }
        }

        protected void ReallyCenterToScreen()
        {
            var screen = Screen.FromControl(this);

            var workingArea = screen.WorkingArea;

            Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - Height) / 2)
            };
        }

        public void SaveToFile()
        {
            var bf = new BinaryFormatter();
            var fs = new FileStream(saveFile, FileMode.Create, FileAccess.Write);

            bf.Serialize(fs, users.Values.ToArray());
            fs.Close();

        } // try catch

        public void LoadFromFile()
        {
            var bf = new BinaryFormatter();
            var fs = new FileStream(saveFile, FileMode.Open, FileAccess.Read);
            var userList = (User[])bf.Deserialize(fs);

            fs.Close();

            users = userList.ToDictionary((x) => x.Name, (x) => x);

            foreach (var s in users.Values.SelectMany(user => user.scores))
                topScores?.Add(s);

            var u = new User() { Name = "Guest" };

            if (!users.ContainsKey("Guest"))
            {
                users.Add("Guest", u);
            }
            else
            {
                foreach (var us in users.Values.Where(us => us.Name.Equals("Guest")))
                {
                    u = us;
                    break;
                }
            }

            currentUser = u;

        } // try catch
    }
}