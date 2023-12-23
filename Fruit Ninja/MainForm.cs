using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace Fruit_Ninja
{
    public partial class Main : Form
    {
        private Game _game;

        private bool _isSlicing;

        private int _ticks;
        private int _r;
        
        private readonly string _saveFile = Environment.CurrentDirectory + "\\save.txt";
        private readonly List<Point> _slicePoints = new List<Point>();

        public static bool IsWindowResize;

        public static User CurrentUser = new User()
        {
            Name = "Guest"
        };

        public static Dictionary<string, User> Users = new Dictionary<string, User>()
        {
            { "Guest", CurrentUser }
        };

        public static List<Score> TopScores = new List<Score>();

        public Main()
        {
            InitializeComponent();

            SettingsForm.Settings = new Settings(800, 600, "EASY");

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            panelGame, new object[] { true });
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile();
        }

        private void PanelGame_Paint(object sender, PaintEventArgs e)
        {
            _game.Draw(e);
            lblTime.Text = $@"00:{_game.Time:00}";
        }
         
        private void TopScores_Click(object sender, EventArgs e)
        {
            new HighScoresForm().Show();
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

        private void Settings_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();

            if (settings.ShowDialog() != DialogResult.OK) return;
            
            if (!IsWindowResize) return;

            if (Width == 800)
            {
                Width = 1024;
                Height = 768;
                IsWindowResize = false;
                CenterFormToScreen();
            } 
            else
            {
                Width = 800;
                Height = 600;
                IsWindowResize = true;
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
        
        private void PanelGame_Click(object sender, EventArgs e)
        {
            _isSlicing = true;
            _slicePoints.Clear();
        }

        private void PanelGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isSlicing) return;

            if (_slicePoints.Count >= 50)
            {
                _slicePoints.Clear();
                return;
            }

            _slicePoints.Add(PointToClient(Cursor.Position));

            Task.Factory.StartNew(() => _game.DrawCurve(_slicePoints,  _r));

            if (!_game.IsGameActive(_slicePoints))
            {
                StopGame();
            }
        }

        private void PanelGame_MouseUp(object sender, MouseEventArgs e)
        {
            _isSlicing = false;

            _r = new Random().Next();

            _slicePoints.Clear();
            panelGame.Invalidate(true);
        }

        private void UnPause_Click(object sender, EventArgs e)
        {
            pbQuit.Visible = false;
            pbUnpause.Visible = false;

            pbPause.Visible = true;

            gameTimer.Start();
            timeTimer.Start();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            pbUnpause.Visible = true;
            pbQuit.Visible = true;

            pbPause.Visible = false;

            gameTimer.Stop();
            timeTimer.Stop();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = _game.CurrentScore.Points.ToString();

            if (lblScore.Right > Width)
                lblScore.Left = Width - lblScore.Width - 20;

            var speed = 0;

            switch (SettingsForm.Settings.Difficulty)
            {
                case "EASY": speed = 40; break;
                case "MEDIUM": speed = 30; break;
                case "HARD": speed = 20; break;
            }

            if (_ticks++ % speed == 0)
                _game.Elements.Add(new Element());

            _game.Move();

            Invalidate(true);
        }

        private void ViewTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = $@"00:{--_game.Time:00}";

            if (_game.Time == 0)
                StopGame();
        }

        public void NewGame()
        {
            pbUnpause.Visible = true;
            panelGame.Visible = true;

            pbPause.Visible = false;
            tableLayoutPanel1.Visible = false;

            lblScore.Text = @"0";

            _game = new Game(this);

            if (ActiveForm != null)
                ActiveForm.BackgroundImage = _game.Background;

            SetGameTimeInterval();

            Invalidate(true);
        }

        private void SetGameTimeInterval()
        {
            switch (SettingsForm.Settings.Difficulty)
            {
                case "EASY": gameTimer.Interval = 50; break;
                case "MEDIUM": gameTimer.Interval = 30; break;
                case "HARD": gameTimer.Interval = 20; break;
            }
        }

        public void StopGame()
        {
            var currentScore = new Score(int.Parse(lblScore.Text), DateTime.Now, CurrentUser.Name);

            gameTimer.Stop();
            timeTimer.Stop();

            TopScores.Add(currentScore);
            CurrentUser.AddScore(currentScore);

            const string title = "Time Up :(";
            var text = $"No more time {CurrentUser.Name}. You have scored {_game.CurrentScore.Points} points! Play again?";

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
            lblUser.Text = CurrentUser.ToString();

            Invalidate(true);

            if (sender is UserForm userForm)
            {
                userForm.ChildFormClosed -= UserForm_ChildFormClosed;
            }
        }

        public void SaveToFile()
        {
            var bf = new BinaryFormatter();
            var fs = new FileStream(_saveFile, FileMode.Create, FileAccess.Write);

            bf.Serialize(fs, Users.Values.ToArray());
            fs.Close();

        } // try catch

        public void LoadFromFile()
        {
            var bf = new BinaryFormatter();
            var fs = new FileStream(_saveFile, FileMode.Open, FileAccess.Read);
            var userList = (User[])bf.Deserialize(fs);

            fs.Close();

            Users = userList.ToDictionary((x) => x.Name, (x) => x);

            foreach (var s in Users.Values.SelectMany(user => user.Scores))
                TopScores?.Add(s);

            var u = new User() { Name = "Guest" };

            if (!Users.ContainsKey("Guest"))
            {
                Users.Add("Guest", u);
            }
            else
            {
                foreach (var us in Users.Values.Where(us => us.Name.Equals("Guest")))
                {
                    u = us;
                    break;
                }
            }

            CurrentUser = u;

        } // try catch
    }
}