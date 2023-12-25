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

        private void OK_Click(object sender, EventArgs e)
        {
            int width, height;
            var difficulty = "";

            if (!lblEasy.Enabled)
                difficulty = EasyDifficulty;
            else if (!lblMedium.Enabled)
                difficulty = MediumDifficulty;
            else if (!lblHard.Enabled)
                difficulty = HardDifficulty;

            if (!lbl1680x1050.Enabled)
            {
                width = 1680;
                height = 1050;
            }
            else
            {
                width = 1920;
                height = 1080;
            }

            var newSettings = new Settings(width, height, difficulty);

            if (!CheckChanges(newSettings)) return;

            var dr = MessageBox.Show(@"Do you want to save the changes?", @"Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Main.IsWindowResize = Settings.Height != newSettings.Height;

                Settings = newSettings;
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
         
        private void UpdateFields()
        {
            lbl1680x1050.Enabled = Settings.Width == 1920;
            lbl1920x1080.Enabled = !lbl1680x1050.Enabled;
            lbl1680x1050.Cursor = lbl1680x1050.Enabled ? Cursors.Hand : Cursors.Default;
            lbl1920x1080.Cursor = lbl1920x1080.Enabled ? Cursors.Hand : Cursors.Default;

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

        private void Label1920x1080_Click(object sender, EventArgs e)
        {
            SetResolution(1920, 1080);
        }

        private void Label1680x1050_Click(object sender, EventArgs e)
        {
            SetResolution(1680, 1050);
        }
       
        private void SetResolution(int width, int height)
        {
            lbl1680x1050.Enabled = width == 1920 && height == 1080;
            lbl1920x1080.Enabled = !lbl1680x1050.Enabled;
            lbl1680x1050.Cursor = lbl1680x1050.Enabled ? Cursors.Hand : Cursors.Default;
            lbl1920x1080.Cursor = lbl1920x1080.Enabled ? Cursors.Hand : Cursors.Default;

            CheckOk();
        }

        private void EasyClick(object sender, EventArgs e)
        {
            SetDifficulty(DifficultyLevel.Easy);
        }

        private void Medium_Click(object sender, EventArgs e)
        {
            SetDifficulty(DifficultyLevel.Medium);
        }

        private void Hard_Click(object sender, EventArgs e)
        {
            SetDifficulty(DifficultyLevel.Hard);
        }

        private void CheckOk()
        {
            var resolution = $"{Settings.Width}x{Settings.Height}";
            var difficulty = Settings.Difficulty;

            var selectedResolution = lbl1920x1080.Enabled ? lbl1680x1050.Text : lbl1920x1080.Text;
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

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
