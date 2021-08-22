
namespace MagneticWindow
{
    partial class MagneticWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagneticWindow));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyIconAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NotifyIconExit = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconMenu;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "NotifyIcon";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // NotifyIconMenu
            // 
            this.NotifyIconMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.NotifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotifyIconAbout,
            this.toolStripSeparator1,
            this.NotifyIconExit});
            this.NotifyIconMenu.Name = "NotifyIconMenu";
            this.NotifyIconMenu.Size = new System.Drawing.Size(135, 70);
            // 
            // NotifyIconAbout
            // 
            this.NotifyIconAbout.Name = "NotifyIconAbout";
            this.NotifyIconAbout.Size = new System.Drawing.Size(134, 30);
            this.NotifyIconAbout.Text = "About";
            this.NotifyIconAbout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyIconAbout_MouseDoubleClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // NotifyIconExit
            // 
            this.NotifyIconExit.Name = "NotifyIconExit";
            this.NotifyIconExit.Size = new System.Drawing.Size(134, 30);
            this.NotifyIconExit.Text = "Exit";
            this.NotifyIconExit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyIconExit_MouseDoubleClick);
            // 
            // MagneticWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 0);
            this.Name = "MagneticWindow";
            this.Text = "MagneticWindow";
            this.Load += new System.EventHandler(this.MagneticWindow_Load);
            this.NotifyIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem NotifyIconExit;
        private System.Windows.Forms.ToolStripMenuItem NotifyIconAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

