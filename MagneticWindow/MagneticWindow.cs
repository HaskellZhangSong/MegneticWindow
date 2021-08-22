﻿using System;
using System.Windows.Forms;

namespace MagneticWindow
{
    public partial class MagneticWindow : Form
    {
        static FormWindowState prevWindowState = FormWindowState.Normal;
        public MagneticWindow()
        {
            this.Visible = false;
            ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            InitializeComponent();
            prevWindowState = WindowState;
            
            new ShortCutHook();
        }
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = prevWindowState;
            }
            else if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                prevWindowState = WindowState;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void NotifyIconExit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void NotifyIconAbout_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string caption = "MagneticWindow";
            string message = "Copyright © 2021 Zhang Song. All right reserved.";
            
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void MagneticWindow_Load(object sender, EventArgs e)
        {
            this.Hide();
            Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }
    }

}
