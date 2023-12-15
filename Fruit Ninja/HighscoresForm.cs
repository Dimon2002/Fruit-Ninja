using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public partial class HighScoresForm : Form
    {
        private static User Users => Main.CurrentUser;
        private static List<Score> TopScores => Main.TopScores;

        public HighScoresForm()
        {
            InitializeComponent();

            lblCurrUser.Enabled = false;
            lblAllUsers.Enabled = true;

            ResetFields();

            AcquireScores();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CurrentUser_Click(object sender, EventArgs e)
        {
            lblCurrUser.Enabled = false;
            lblAllUsers.Enabled = true;

            ResetFields();

            AcquireScores();
        }

        private void AcquireScores()
        {
            if (Users == null) { return; }

            Users.Scores.Sort();
            Users.Scores.Reverse();

            foreach (var score in Users.Scores)
            {
                lbUserName.Items.Add(Users.Name);
                lbDate.Items.Add(score.Date);
                lbScores.Items.Add(score.Points);
            }
        }

        private void AllUsers_Click(object sender, EventArgs e)
        {
            lblCurrUser.Enabled = true;
            lblAllUsers.Enabled = false;

            ResetFields();

            if (TopScores.Count == 0) return;

            TopScores.Sort();
            TopScores.Reverse();
            
            for (var i = 0; i < TopScores.Count; ++i)
            {
                lbUserName.Items.Add(TopScores.ElementAt(i).Name);
                lbDate.Items.Add(TopScores.ElementAt(i).Date);
                lbScores.Items.Add(TopScores.ElementAt(i).Points);
            }
        }

        private void ResetFields()
        {
            lbUserName.Items.Clear();
            lbScores.Items.Clear();
            lbDate.Items.Clear();
        }
    }
}