using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagneticWindow
{
    public partial class MagneticWindow : Form
    {
        static FormWindowState prevWindowState = FormWindowState.Normal;
        public MagneticWindow()
        {
            InitializeComponent();
            prevWindowState = WindowState;
            ShowInTaskbar = false;
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
    }

}
