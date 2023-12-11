using System;
using System.Linq;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public partial class HighscoresForm : Form
    {
        public HighscoresForm()
        {
            InitializeComponent();

            lblCurrUser.Enabled = false;
            lblAllUsers.Enabled = true;
            
            ResetFields();

            AcquireScores();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCurrUser_Click(object sender, EventArgs e)
        {
            lblCurrUser.Enabled = false;
            lblAllUsers.Enabled = true;

            ResetFields();

            AcquireScores();
        }

        private void AcquireScores ()
        {
            if (Main.currentUser.scores.Count == 0)
            {
                return;
            }

            Main.currentUser.scores.Sort();
            Main.currentUser.scores.Reverse();

            foreach (var score in Main.currentUser.scores)
            {
                lbUserName.Items.Add(Main.currentUser.name);
                lbDate.Items.Add(score.date);
                lbScores.Items.Add(score.points);
            }
        }

        private void lblAllUsers_Click(object sender, EventArgs e)
        {
            lblCurrUser.Enabled = true;
            lblAllUsers.Enabled = false;
            ResetFields();

            if (Main.topScores.Count == 0) return;

            Main.topScores.Sort();
            Main.topScores.Reverse();

            var end = 10;

            if (Main.topScores.Count <= 10)
                end = Main.topScores.Count;
            
            for (var i = 0; i < end; ++i)
            {
                lbUserName.Items.Add(Main.topScores.ElementAt(i).name);
                lbDate.Items.Add(Main.topScores.ElementAt(i).date);
                lbScores.Items.Add(Main.topScores.ElementAt(i).points);
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
