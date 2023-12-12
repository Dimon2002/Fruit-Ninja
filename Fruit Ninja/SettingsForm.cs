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
            var newSettings = GetSelectedSettings();

            if (!CheckChanges(newSettings)) return;

            var result = MessageBox.Show("Do you want to save the changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
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
            UpdateResolutionFields();
            UpdateDifficultyFields();
        }

        private void UpdateResolutionFields()
        {
            lbl800x600.Enabled = settings.Width != 800 || settings.Height != 600;
            lbl1024x768.Enabled = !lbl800x600.Enabled;

            lbl800x600.Cursor = lbl800x600.Enabled ? Cursors.Hand : Cursors.Default;
            lbl1024x768.Cursor = lbl1024x768.Enabled ? Cursors.Hand : Cursors.Default;
        }

        private void UpdateDifficultyFields()
        {
            lblEasy.Enabled = settings.Difficulty != "EASY";
            lblMedium.Enabled = settings.Difficulty != "MEDIUM";
            lblHard.Enabled = settings.Difficulty != "HARD";

            lblEasy.Cursor = lblEasy.Enabled ? Cursors.Hand : Cursors.Default;
            lblMedium.Cursor = lblMedium.Enabled ? Cursors.Hand : Cursors.Default;
            lblHard.Cursor = lblHard.Enabled ? Cursors.Hand : Cursors.Default;
        }

        private Settings GetSelectedSettings()
        {
            int width = lbl800x600.Enabled ? 800 : 1024;
            int height = lbl800x600.Enabled ? 600 : 768;

            string difficulty = lblEasy.Enabled ? "EASY" : lblMedium.Enabled ? "MEDIUM" : "HARD";

            return new Settings(width, height, difficulty);
        }

        private bool CheckChanges(Settings newSettings)
        {
            return settings.CompareTo(newSettings) == 1;
        }

        private void UpdateOkButtonState()
        {
            var resolution = $"{settings.Width}x{settings.Height}";
            var difficulty = settings.Difficulty;

            var selectedResolution = lbl800x600.Enabled ? lbl800x600.Text : lbl1024x768.Text;
            var selectedDifficulty = lblEasy.Enabled ? lblEasy.Text.ToUpper() : lblMedium.Text.ToUpper();

            lblOK.Enabled = !(selectedResolution.Equals(resolution) && selectedDifficulty.Equals(difficulty));
        }

        private void UpdateResolutionLabel(object sender, EventArgs e)
        {
            var label = (Label)sender;

            if (label.Enabled)
            {
                lbl800x600.Enabled = !lbl800x600.Enabled;
                lbl1024x768.Enabled = !lbl800x600.Enabled;

                UpdateOkButtonState();
            }
        }

        private void UpdateDifficultyLabel(object sender, EventArgs e)
        {
            var label = (Label)sender;

            if (label.Enabled)
            {
                lblEasy.Enabled = label == lblEasy ? false : true;
                lblMedium.Enabled = label == lblMedium ? false : true;
                lblHard.Enabled = label == lblHard ? false : true;

                UpdateOkButtonState();
            }
        }
    }
}