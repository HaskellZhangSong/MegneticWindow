using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MagneticWindow
{
    struct PositionArg
    {
        public PositionArg(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public enum Layout
    {
        FIRST_ONE_SECOND,
        SECOND_ONE_SECOND,

        FIRST_ONE_THIRD,
        SECOND_ONE_THIRD,
        THIRD_ONE_THIRD,
        LEFT_TWO_THIRD,
        RIGHT_TWO_THIRD,

        FIRST_ONE_FORTH,
        SECOND_ONE_FORTH,
        THIRD_ONE_FORTH,
        FORTH_ONE_FORTH,
        LEFT_THREE_FORTH,
        RIGHT_THREE_FORTH,
        MIDDLE_TWO_FORTH,

        TOP_LEFT,
        TOP_RIGHT,
        BOTTOM_LEFT,
        BOTTOM_RIGHT,

        CENTER
    }
    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }

    class FrontWindowSetter
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [DllImport("dwmapi.dll")]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out Rect pvAttribute, int cbAttribute);

        [Serializable]

        internal enum WindowStates : int
        {
            Hide = 0,
            Normal = 1,
            Minimized = 2,
            Maximized = 3,
        }
        internal struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public WindowStates showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        private static WindowStates GetFrontWindowState(IntPtr hWnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hWnd, ref placement);
            return placement.showCmd;
        }
        [Flags]
        private enum DwmWindowAttribute : uint
        {
            DWMWA_NCRENDERING_ENABLED = 1,
            DWMWA_NCRENDERING_POLICY,
            DWMWA_TRANSITIONS_FORCEDISABLED,
            DWMWA_ALLOW_NCPAINT,
            DWMWA_CAPTION_BUTTON_BOUNDS,
            DWMWA_NONCLIENT_RTL_LAYOUT,
            DWMWA_FORCE_ICONIC_REPRESENTATION,
            DWMWA_FLIP3D_POLICY,
            DWMWA_EXTENDED_FRAME_BOUNDS,
            DWMWA_HAS_ICONIC_BITMAP,
            DWMWA_DISALLOW_PEEK,
            DWMWA_EXCLUDED_FROM_PEEK,
            DWMWA_CLOAK,
            DWMWA_CLOAKED,
            DWMWA_FREEZE_REPRESENTATION,
            DWMWA_LAST
        }

        public static Rect GetWindowRectangle(IntPtr hWnd)
        {
            Rect rect;

            int size = Marshal.SizeOf(typeof(Rect));
            DwmGetWindowAttribute(hWnd, (int)DwmWindowAttribute.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, size);

            return rect;
        }

        private const int SW_NORMAL = 1;

        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;

        const short SWP_NOMOVE = 0x2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0x4;
        const int SWP_SHOWWINDOW = 0x0040;

        private static PositionArg pa = new PositionArg(0, 0, 0, 0);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]


        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static PositionArg GetWindowPositionArg(IntPtr window, Screen screen, Layout layout)
        {
            Rectangle wa = screen.WorkingArea;
            PositionArg posArg = new PositionArg();
            switch (layout)
            {
                case Layout.FIRST_ONE_SECOND:
                    posArg = new PositionArg(wa.X + wa.Width * 0 / 2, wa.Y, wa.Width / 2, wa.Height);
                    break;
                case Layout.SECOND_ONE_SECOND:
                    posArg = new PositionArg(wa.X + wa.Width * 1 / 2, wa.Y, wa.Width / 2, wa.Height);
                    break;

                case Layout.FIRST_ONE_THIRD:
                    posArg = new PositionArg(wa.X + wa.Width * 0 / 3, wa.Y, wa.Width / 3, wa.Height);
                    break;
                case Layout.SECOND_ONE_THIRD:
                    posArg = new PositionArg(wa.X + wa.Width * 1 / 3, wa.Y, wa.Width / 3, wa.Height);
                    break;
                case Layout.THIRD_ONE_THIRD:
                    posArg = new PositionArg(wa.X + wa.Width * 2 / 3, wa.Y, wa.Width / 3, wa.Height);
                    break;

                case Layout.LEFT_TWO_THIRD:
                    posArg = new PositionArg(wa.X, wa.Y, wa.Width * 2 / 3, wa.Height);
                    break;
                case Layout.RIGHT_TWO_THIRD:
                    posArg = new PositionArg(wa.X + wa.Width / 3, wa.Y, wa.Width * 2 / 3, wa.Height);
                    break;

                case Layout.FIRST_ONE_FORTH:
                    posArg = new PositionArg(wa.X + wa.Width * 0 / 4, wa.Y, wa.Width / 4, wa.Height);
                    break;
                case Layout.SECOND_ONE_FORTH:
                    posArg = new PositionArg(wa.X + wa.Width * 1 / 4, wa.Y, wa.Width / 4, wa.Height);
                    break;
                case Layout.THIRD_ONE_FORTH:
                    posArg = new PositionArg(wa.X + wa.Width * 2 / 4, wa.Y, wa.Width / 4, wa.Height);
                    break;
                case Layout.FORTH_ONE_FORTH:
                    posArg = new PositionArg(wa.X + wa.Width * 3 / 4, wa.Y, wa.Width / 4, wa.Height);
                    break;

                case Layout.LEFT_THREE_FORTH:
                    posArg = new PositionArg(wa.X, wa.Y, wa.Width * 3 / 4, wa.Height);
                    break;
                case Layout.RIGHT_THREE_FORTH:
                    posArg = new PositionArg(wa.X + wa.Width / 4, wa.Y, wa.Width * 3 / 4, wa.Height);
                    break;

                case Layout.MIDDLE_TWO_FORTH:
                    posArg = new PositionArg(wa.X + wa.Width / 4, wa.Y, wa.Width * 2 / 4, wa.Height);
                    break;

                case Layout.TOP_LEFT:
                    posArg = new PositionArg(wa.X, wa.Y, wa.Width / 2, wa.Height / 2);
                    break;
                case Layout.TOP_RIGHT:
                    posArg = new PositionArg(wa.X + wa.Width / 2, wa.Y, wa.Width / 2, wa.Height / 2);
                    break;
                case Layout.BOTTOM_LEFT:
                    posArg = new PositionArg(wa.X, wa.Y + wa.Height / 2, wa.Width / 2, wa.Height / 2);
                    break;
                case Layout.BOTTOM_RIGHT:
                    posArg = new PositionArg(wa.X + wa.Width / 2, wa.Y + wa.Height / 2, wa.Width / 2, wa.Height / 2);
                    break;
                case Layout.CENTER:
                    posArg = new PositionArg(wa.X + wa.Width / 8, wa.Y + wa.Height / 8, wa.Width * 3 / 4, wa.Height * 3 / 4);
                    break;

            }

            Rect inner = FrontWindowSetter.GetWindowRectangle(window);
            Rect outer = new Rect();
            FrontWindowSetter.GetWindowRect(window, ref outer);
            int leftAdornmentSize = outer.Left - inner.Left;
            int rightAdornmentSize = 2 * (outer.Right - inner.Right);
            int bottomAdornmentSize = outer.Bottom - inner.Bottom;

            posArg.x += leftAdornmentSize;
            posArg.width += rightAdornmentSize;
            posArg.height += bottomAdornmentSize;
            return posArg;
        }

        private static Screen GetNextScreen(Screen s)
        {
            int currentScreenIndex = 0;
            Screen[] allScreen = Screen.AllScreens;
            for(int i = 0; i < allScreen.Length; i++)
            {
                if(s.Equals(allScreen[i]))
                {
                    currentScreenIndex = i;
                }
            }

            return allScreen[(currentScreenIndex + 1) % allScreen.Length];
        }

        private static Screen GetPreviousScreen(Screen s)
        {
            int currentScreenIndex = 0;
            Screen[] allScreen = Screen.AllScreens;
            for (int i = 0; i < allScreen.Length; i++)
            {
                if (s.Equals(allScreen[i]))
                {
                    currentScreenIndex = i;
                }
            }

            return allScreen[(currentScreenIndex - 1) % allScreen.Length];
        }
        /// <summary>
        /// Move window to next screen if had
        /// </summary>
        /// <param name="sender"></param>
        /// <param name=""></param>
        public static void MoveToNextScreen(object sender, KeyPressedEventArgs e)
        {
            int screenSize = Screen.AllScreens.Length;
            // save a system call, can just use modulus operation
            if (screenSize == 0 || screenSize == 1)
            {
                return;
            } else
            {
                IntPtr window = GetForegroundWindow();
                Screen locatedScreen = Screen.FromHandle(window);
                Screen nextScreen = GetNextScreen(locatedScreen);
                MoveWindow(
                    window, 
                    nextScreen.WorkingArea.Right, 
                    nextScreen.WorkingArea.Top, 
                    nextScreen.WorkingArea.Width, 
                    nextScreen.WorkingArea.Height, 
                    false);
            }
        }

        public static void MoveToPreviousScreen(object sender, KeyPressedEventArgs e)
        {
            int screenSize = Screen.AllScreens.Length;
            // save a system call, can just use modulus operation
            if (screenSize == 0 || screenSize == 1)
            {
                return;
            }
            else
            {
                IntPtr window = GetForegroundWindow();
                Screen locatedScreen = Screen.FromHandle(window);
                Screen nextScreen = GetPreviousScreen(locatedScreen);
                MoveWindow(
                    window,
                    nextScreen.WorkingArea.Right,
                    nextScreen.WorkingArea.Top,
                    nextScreen.WorkingArea.Width,
                    nextScreen.WorkingArea.Height,
                    false);
            }
        }

        /// <summary>
        /// Toggle front window between maximized and normal state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ToggleWindowNormalAndMaximium(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            WindowStates ws = GetFrontWindowState(window);
            if (ws == WindowStates.Normal)
            {
                ShowWindow(window, SW_MAXIMIZE);
            } else if (ws == WindowStates.Maximized) 
            {
                ShowWindow(window, SW_NORMAL);
            }
            
        }
        /// <summary>
        /// Set front window to minimzed state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void MinimizeWindow(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            WindowStates ws = GetFrontWindowState(window);
            ShowWindow(window, SW_MINIMIZE);
        }

        ////////// 1/2
        public static void SetFrontWindowLeftSecond(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.FIRST_ONE_SECOND);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }
        public static void SetFrontWindowRightSecond(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.SECOND_ONE_SECOND);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }

        ////////// 1/3
        public static void SetFrontWindowLeftThird(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.FIRST_ONE_THIRD);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }

        public static void SetFrontWindowMiddleThird(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.SECOND_ONE_THIRD);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }
        public static void SetFrontWindowRightThird(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.THIRD_ONE_THIRD);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }

        ////////// 2/3
        public static void SetFrontWindow_LEFT_TWO_THIRD(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.LEFT_TWO_THIRD);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }
        public static void SetFrontWindow_RIGHT_TWO_THIRD(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.RIGHT_TWO_THIRD);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }



        ////////// 1/4
        public static void SetFrontWindow_FIRST_ONE_FORTH(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.FIRST_ONE_FORTH);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }


        public static void SetFrontWindow_SECOND_ONE_FORTH(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.SECOND_ONE_FORTH);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }


        public static void SetFrontWindow_THIRD_ONE_FORTH(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.THIRD_ONE_FORTH);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }


        public static void SetFrontWindow_FORTH_ONE_FORTH(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.FORTH_ONE_FORTH);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }


        ////////// 3/4
        public static void SetFrontWindow_LEFT_THREE_FORTH(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.LEFT_THREE_FORTH);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }


        public static void SetFrontWindow_RIGHT_THREE_FORTH(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.RIGHT_THREE_FORTH);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }

        /// middle 2/4
        public static void SetFrontWindow_MIDDLE_TWO_FORTH(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.MIDDLE_TWO_FORTH);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }

        ///////// 4 grid
        public static void SetFrontWindow_TOP_LEFT(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.TOP_LEFT);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }


        public static void SetFrontWindow_TOP_RIGHT(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.TOP_RIGHT);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }

        public static void SetFrontWindow_BOTTOM_LEFT(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.BOTTOM_LEFT);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }


        public static void SetFrontWindow_BOTTOM_RIGHT(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.BOTTOM_RIGHT);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }

        public static void SetFrontWindow_CENTER(object sender, KeyPressedEventArgs e)
        {
            IntPtr window = GetForegroundWindow();
            ShowWindow(window, SW_NORMAL);
            Screen locatedScreen = Screen.FromHandle(window);
            PositionArg pa = GetWindowPositionArg(window, locatedScreen, Layout.CENTER);
            MoveWindow(window, pa.x, pa.y, pa.width, pa.height, true);
        }
    }
}
