﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fruit_Ninja
{
    public partial class UserForm : Form
    {
        public event EventHandler ChildFormClosed;
        
        public System.Windows.Forms.Timer Timer = new System.Windows.Forms.Timer
        {
            Interval = 1000
        };

        private static Dictionary<string, User> Users => Main.Users;

        private static User CurrentUser
        {
            set => Main.CurrentUser = value;
        }

        public UserForm()
        {
            InitializeComponent();
            FillUsers();
        }

        private void UserForm_Closing(object sender, FormClosingEventArgs e)
        {
            OnChildFormClosed();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            OnChildFormClosed();
            Close();
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            var username = tbName.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show(@"Please enter a name!");
                return;
            }

            if (username.Length >= 20)
            {
                MessageBox.Show(@"The username is too long. Must be less 20");
                return;
            }

            if (Users.ContainsKey(username))
            {
                MessageBox.Show(@"User already exists!");
                return;
            }

            Users.Add(username, new User() { Name = username });
            FillUsers();

            tbName.Text = string.Empty;
            btnSelect.Enabled = false;
        }

        private void ChoiceUser_Click(object sender, EventArgs e)
        {
            CurrentUser = lbUsers.SelectedItem as User;

            lblInfo.ForeColor = Color.White;

            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblInfo.ForeColor = Color.Black;
            Timer.Tick -= Timer_Tick;
            Timer.Stop();
        }

        private void Users_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.DimGray);
            }

            e.DrawBackground();

            e.Graphics.DrawString(
                lbUsers.Items[e.Index].ToString(),
                e.Font,
                Brushes.White,
                e.Bounds,
                StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }

        private void Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = lbUsers.SelectedIndex != -1;
        }

        private void FillUsers()
        {
            lbUsers.Items.Clear();

            foreach (var user in Users.Values)
                lbUsers.Items.Add(user);
        }

        protected virtual void OnChildFormClosed()
        {
            ChildFormClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}