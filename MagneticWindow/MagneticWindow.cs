using System;
using System.Windows.Forms;

namespace MagneticWindow
{
    public partial class MagneticWindow : Form
    {
        static string version = "0.4.0";

        // not useful
        static FormWindowState prevWindowState = FormWindowState.Normal;
        public MagneticWindow()
        {
            DateTime NowDate = DateTime.Now;
            DateTime ExpiredDate = new DateTime(2023, 8, 31, 0, 0, 0);
            if (ExpiredDate.Subtract(NowDate).TotalDays < 0)
            {
                this.Close();
            }
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
            string message = 
                "MagneticWindow Version "
                + version + "\n"
                + "Copyright © 2021 Zhang Song. All right reserved.";

            
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
