using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public partial class HighScoresForm : Form
    {
        private static User Users => Main.currentUser;
        private static List<Score> TopScores => Main.topScores;

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

            Users.scores.Sort();
            Users.scores.Reverse();

            foreach (var score in Users.scores)
            {
                lbUserName.Items.Add(Users.Name);
                lbDate.Items.Add(score.date);
                lbScores.Items.Add(score.points);
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
                
            /*var end = 10;

            if (Main.topScores.Count <= 10)
                end = Main.topScores.Count;*/
            
            for (var i = 0; i < TopScores.Count; ++i)
            {
                lbUserName.Items.Add(TopScores.ElementAt(i).name);
                lbDate.Items.Add(TopScores.ElementAt(i).date);
                lbScores.Items.Add(TopScores.ElementAt(i).points);
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