using System;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public partial class SettingsForm : Form
    {
        private const string EasyDifficulty = "EASY";
        private const string MediumDifficulty = "MEDIUM";
        private const string HardDifficulty = "HARD";

        private enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard
        }

        public static Settings Settings;

        public SettingsForm()
        {
            InitializeComponent();
            UpdateFields();
        }

        private void lblOK_Click(object sender, EventArgs e)
        {
            int width, height;
            var difficulty = "";

            if (!lblEasy.Enabled)
                difficulty = EasyDifficulty;
            else if (!lblMedium.Enabled)
                difficulty = MediumDifficulty;
            else if (!lblHard.Enabled)
                difficulty = HardDifficulty;

            if (!lbl800x600.Enabled)
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
                Main.resize = Settings.Height != newSettings.Height;

                Settings = newSettings;
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
            lbl800x600.Enabled = Settings.Width == 1024;
            lbl1024x768.Enabled = !lbl800x600.Enabled;
            lbl800x600.Cursor = lbl800x600.Enabled ? Cursors.Hand : Cursors.Default;
            lbl1024x768.Cursor = lbl1024x768.Enabled ? Cursors.Hand : Cursors.Default;

            SetDifficultyLabel(lblEasy, DifficultyLevel.Easy);
            SetDifficultyLabel(lblMedium, DifficultyLevel.Medium);
            SetDifficultyLabel(lblHard, DifficultyLevel.Hard);

            SetSelectedDifficulty();
        }

        private void SetSelectedDifficulty()
        {
            switch (Settings.Difficulty)
            {
                case EasyDifficulty:
                    SetDifficulty(DifficultyLevel.Easy);
                    break;
                case MediumDifficulty:
                    SetDifficulty(DifficultyLevel.Medium);
                    break;
                case HardDifficulty:
                    SetDifficulty(DifficultyLevel.Hard);
                    break;
            }
        }

        private void SetDifficultyLabel(Label label, DifficultyLevel level)
        {
            label.Enabled = Settings.Difficulty != level.ToString();
            label.Cursor = label.Enabled ? Cursors.Hand : Cursors.Default;
        }

        public bool CheckChanges(Settings newSettings)
        {
            return Settings.CompareTo(newSettings) > 0;
        }

        private void SetDifficulty(DifficultyLevel level)
        {
            lblEasy.Enabled = level != DifficultyLevel.Easy;
            lblMedium.Enabled = level != DifficultyLevel.Medium;
            lblHard.Enabled = level != DifficultyLevel.Hard;

            lblEasy.Cursor = lblEasy.Enabled ? Cursors.Hand : Cursors.Default;
            lblMedium.Cursor = lblMedium.Enabled ? Cursors.Hand : Cursors.Default;
            lblHard.Cursor = lblHard.Enabled ? Cursors.Hand : Cursors.Default;

            CheckOk();
        }

        private void lbl1024x768_Click(object sender, EventArgs e)
        {
            SetResolution(1024, 768);
        }

        private void lbl800x600_Click(object sender, EventArgs e)
        {
            SetResolution(800, 600);
        }

        private void SetResolution(int width, int height)
        {
            lbl800x600.Enabled = width == 1024 && height == 768;
            lbl1024x768.Enabled = !lbl800x600.Enabled;
            lbl800x600.Cursor = lbl800x600.Enabled ? Cursors.Hand : Cursors.Default;
            lbl1024x768.Cursor = lbl1024x768.Enabled ? Cursors.Hand : Cursors.Default;

            CheckOk();
        }

        private void lblEasy_Click(object sender, EventArgs e)
        {
            SetDifficulty(DifficultyLevel.Easy);
        }

        private void lblMedium_Click(object sender, EventArgs e)
        {
            SetDifficulty(DifficultyLevel.Medium);
        }

        private void lblHard_Click(object sender, EventArgs e)
        {
            SetDifficulty(DifficultyLevel.Hard);
        }

        private void CheckOk()
        {
            var resolution = $"{Settings.Width}x{Settings.Height}";
            var difficulty = Settings.Difficulty;

            var selectedResolution = lbl1024x768.Enabled ? lbl800x600.Text : lbl1024x768.Text;
            string selectedDifficulty;

            if (lblEasy.Enabled)
            {
                selectedDifficulty = lblMedium.Enabled ? lblHard.Text.ToUpper() : lblMedium.Text.ToUpper();
            }
            else
            {
                selectedDifficulty = lblEasy.Text.ToUpper();
            }

            lblOK.Enabled = !selectedResolution.Equals(resolution) || !selectedDifficulty.Equals(difficulty);
        }
    }
}
