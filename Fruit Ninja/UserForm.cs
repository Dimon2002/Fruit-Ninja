using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public partial class UserForm : Form
    {
        public Timer timer;

        public UserForm()
        {
            InitializeComponent();
            FillUsers();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "")
            {
                MessageBox.Show(@"Please enter a name!");
            }
            else
            {
                if (tbName.Text.Length > 3 && tbName.Text.Length < 11)
                {
                    var user = new User(tbName.Text);

                    if (!Main.users.ContainsKey(tbName.Text.ToUpper()))
                    {
                        Main.users.Add(tbName.Text.ToUpper(), user);
                        FillUsers();
                    }
                    else
                    {
                        MessageBox.Show(@"User already exists!");
                    }
                }
                else
                {
                    MessageBox.Show(@"Username must be between 4 and 10 characters.");
                }
            }

            tbName.Text = "";
            btnSelect.Enabled = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Main.currentUser = lbUsers.SelectedItem as User;
            lblInfo.ForeColor = Color.White;

            timer = new Timer
            {
                Interval = 1000
            };
            
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (lblInfo.ForeColor != Color.White) return;

            lblInfo.ForeColor = Color.Black;
            timer.Stop();
        }

        private void lbUsers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.Red);

            e.DrawBackground();
            e.Graphics.DrawString(lbUsers.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = lbUsers.SelectedIndex != -1;
        }

        private void FillUsers()
        {
            lbUsers.Items.Clear();

            foreach (var user in Main.users.Values)
                lbUsers.Items.Add(user);
        }
    }
}