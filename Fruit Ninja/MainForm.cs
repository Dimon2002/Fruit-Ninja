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

        private List<Point> _slicePoints = new List<Point>();
        private Point _endSlicePoint;
        private bool _isSlicing;

        public Main()
        {
            InitializeComponent();

            SettingsForm.settings = new Settings(800, 600, "EASY");

            // LoadFromFile();

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
            // new HighScoresForm().Show();
        }

        private void User_Click(object sender, EventArgs e)
        {
            var userForm = new UserForm();
            userForm.ChildFormClosed += UserForm_ChildFormClosed;
            userForm.Show();
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
                CenterFormToScreen();
            }
            else
            {
                ActiveForm.Width -= 224;
                ActiveForm.Height -= 168;
                resize = true;
                CenterFormToScreen();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show(
                @"Are you sure you want to exit the game?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (dr == DialogResult.Yes)
                ActiveForm?.Close();
        }

        // TODO: Animation slice figure
        private void PanelGame_Click(object sender, EventArgs e)
        {
            _isSlicing = true;
            _slicePoints.Clear();
        }

        private void PanelGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isSlicing) return;

            _endSlicePoint = PointToClient(Cursor.Position);
            _slicePoints.Add(_endSlicePoint);
            game.DrawCurve(_slicePoints);
        }

        private void PanelGame_MouseUp(object sender, MouseEventArgs e)
        {
            _isSlicing = false;

            if (game.CheckSlice(_slicePoints))
            {
                StopGame();
            }

            _slicePoints.Clear();
            panelGame.Invalidate(true);
        }

        private void UnPause_Click(object sender, EventArgs e)
        {
            pbQuit.Visible = false;
            pbUnpause.Visible = false;

            pbPause.Visible = true;
            canClick = true;

            gameTimer.Start();
            timeTimer.Start();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            pbUnpause.Visible = true;
            pbQuit.Visible = true;

            canClick = false;
            pbPause.Visible = false;

            gameTimer.Stop();
            timeTimer.Stop();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = game.currentScore.points.ToString();

            if (lblScore.Right > Width)
                lblScore.Left = Width - lblScore.Width - 20;

            var speed = 0;

            switch (SettingsForm.settings.Difficulty)
            {
                case "EASY": speed = 40; break;
                case "MEDIUM": speed = 30; break;
                case "HARD": speed = 20; break;
            }

            if (ticks++ % speed == 0)
                game.elements.Add(new Element());

            game.Move();

            Invalidate(true);
        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $@"00:{--game.time:00}";

            if (game.time == 0)
                StopGame();
        }

        public void NewGame()
        {
            pbUnpause.Visible = true;
            panelGame.Visible = true;

            pbPause.Visible = false;
            tableLayoutPanel1.Visible = false;

            lblScore.Text = @"0";

            game = new Game(this);

            if (ActiveForm != null)
                ActiveForm.BackgroundImage = game.background;

            SetGameTimeInterval();

            Invalidate(true);
        }

        private void SetGameTimeInterval()
        {
            switch (SettingsForm.settings.Difficulty)
            {
                case "EASY": gameTimer.Interval = 50; break;
                case "MEDIUM": gameTimer.Interval = 30; break;
                case "HARD": gameTimer.Interval = 20; break;
            }
        }

        public void StopGame()
        {
            var currentScore = new Score(int.Parse(lblScore.Text), DateTime.Now, currentUser.Name);

            gameTimer.Stop();
            timeTimer.Stop();

            topScores.Add(currentScore);
            currentUser.AddScore(currentScore);

            const string title = "Time Up :(";
            var text = $"No more time {currentUser.Name}. You have scored {game.currentScore.points} points! Play again?";

            var dr = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                NewGame();
            }
            else
            {
                tableLayoutPanel1.Visible = true;
                panelGame.Visible = false;

                if (ActiveForm != null) 
                    ActiveForm.BackgroundImage = Properties.Resources._2013_08_28_105146;
            }
        }

        protected void CenterFormToScreen()
        {
            var screen = Screen.FromControl(this);

            var workingArea = screen.WorkingArea;

            Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - Height) / 2)
            };
        }

        private void UserForm_ChildFormClosed(object sender, EventArgs e)
        {
            lblUser.Text = currentUser.ToString();

            Invalidate(true);

            if (sender is UserForm userForm)
            {
                userForm.ChildFormClosed -= UserForm_ChildFormClosed;
            }
        }

        // TODO: Save scores to file
        public void SaveToFile()
        {
            var bf = new BinaryFormatter();
            var fs = new FileStream(saveFile, FileMode.Create, FileAccess.Write);

            bf.Serialize(fs, users.Values.ToArray());
            fs.Close();

        } // try catch

        // TODO: Load scores from file
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