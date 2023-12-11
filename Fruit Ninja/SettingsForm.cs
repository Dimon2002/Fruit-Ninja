using System;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public partial class SettingsForm : Form
    {
        public static Settings settings;

        public SettingsForm()
        {
            InitializeComponent();
            UpdateFields();
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            int width, height;

            var difficulty = "";

            if (lblEasy.Enabled == false)
                difficulty = "EASY";
            else if (lblMedium.Enabled == false)
                difficulty = "MEDIUM";
            else if (lblHard.Enabled == false)
                difficulty = "HARD";
            if (lbl800x600.Enabled == false)
            {
                width = 800;
                height = 600;
            }
            else
            {
                width = 1024;
                height = 768;
            }
            
            var newSettings = new Settings(width, height, difficulty);

            if (!CheckChanges(newSettings)) return;

            var dr = MessageBox.Show(@"Do you want to save the changes?", @"Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           
            if (dr == DialogResult.Yes)
            {
                Main.resize = settings.Height != newSettings.Height;

                settings = newSettings;
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateFields()
        {
            if (settings.Width == 800 && settings.Height == 600)
            {
                lbl800x600.Enabled = false;
                lbl1024x768.Enabled = true;
                lbl800x600.Cursor = Cursors.Default;
                lbl1024x768.Cursor = Cursors.Hand;
            }
            else
            {
                lbl1024x768.Enabled = false;
                lbl800x600.Enabled = true;
                lbl800x600.Cursor = Cursors.Hand;
                lbl1024x768.Cursor = Cursors.Default;
            }

            switch (settings.Difficulty)
            {
                case "EASY":
                    lblEasy.Enabled = false;
                    lblMedium.Enabled = true;
                    lblHard.Enabled = true;
                    lblEasy.Cursor = Cursors.Default;
                    lblMedium.Cursor = Cursors.Hand;
                    lblHard.Cursor = Cursors.Hand;
                    break;
                case "MEDIUM":
                    lblEasy.Enabled = true;
                    lblMedium.Enabled = false;
                    lblHard.Enabled = true;
                    lblEasy.Cursor = Cursors.Hand;
                    lblMedium.Cursor = Cursors.Default;
                    lblHard.Cursor = Cursors.Hand;
                    break;
                case "HARD":
                    lblEasy.Enabled = true;
                    lblMedium.Enabled = true;
                    lblHard.Enabled = false;
                    lblEasy.Cursor = Cursors.Hand;
                    lblMedium.Cursor = Cursors.Hand;
                    lblHard.Cursor = Cursors.Default;
                    break;
            }
        }

        public bool CheckChanges(Settings newSettings)
        {
            return settings.CompareTo(newSettings) == 1;
        }

        private void lbl1024x768_Click(object sender, EventArgs e)
        {
            if (lbl1024x768.Enabled == true)
            {
                lbl1024x768.Enabled = false;
                lbl800x600.Enabled = true;
                lbl800x600.Cursor = Cursors.Hand;
                lbl1024x768.Cursor = Cursors.Default;
            }

            CheckOk();
        }

        private void lbl800x600_Click(object sender, EventArgs e)
        {
            if (lbl800x600.Enabled == true)
            {
                lbl800x600.Enabled = false;
                lbl1024x768.Enabled = true;
                lbl800x600.Cursor = Cursors.Default;
                lbl1024x768.Cursor = Cursors.Hand;
            }

            CheckOk();
        }

        private void lblEasy_Click(object sender, EventArgs e)
        {
            if (lblEasy.Enabled == true)
            {
                lblEasy.Enabled = false;
                lblMedium.Enabled = true;
                lblHard.Enabled = true;
                lblEasy.Cursor = Cursors.Default;
                lblMedium.Cursor = Cursors.Hand;
                lblHard.Cursor = Cursors.Hand;
            }

            CheckOk();
        }

        private void lblMedium_Click(object sender, EventArgs e)
        {
            if (lblMedium.Enabled == true)
            {
                lblEasy.Enabled = true;
                lblMedium.Enabled = false;
                lblHard.Enabled = true;
                lblEasy.Cursor = Cursors.Hand;
                lblMedium.Cursor = Cursors.Default;
                lblHard.Cursor = Cursors.Hand;
            }

            CheckOk();
        }

        private void lblHard_Click(object sender, EventArgs e)
        {
            if (lblHard.Enabled == true)
            {
                lblEasy.Enabled = true;
                lblMedium.Enabled = true;
                lblHard.Enabled = false;
                lblEasy.Cursor = Cursors.Hand;
                lblMedium.Cursor = Cursors.Hand;
                lblHard.Cursor = Cursors.Default;
            }

            CheckOk();
        }

        private void CheckOk()
        {
            var resolution = $"{settings.Width}x{settings.Height}";

            var difficulty = settings.Difficulty;

            var selectedResolution = lbl1024x768.Enabled 
                                            ? lbl800x600.Text 
                                            : lbl1024x768.Text;

            string selectedDifficulty;

            if (lblEasy.Enabled)
            {
                selectedDifficulty = lblMedium.Enabled 
                                     ? lblHard.Text.ToUpper() 
                                     : lblMedium.Text.ToUpper();
            }
            else
            {
                selectedDifficulty = lblEasy.Text.ToUpper();
            }

            if (selectedResolution.Equals(resolution) && selectedDifficulty.Equals(difficulty))
            {
                lblOK.Enabled = false;
            }
            else
            {
                lblOK.Enabled = true;
            }
        }
    }
}
