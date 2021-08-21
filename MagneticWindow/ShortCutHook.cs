
using System;
using System.Windows.Forms;

namespace MagneticWindow
{
    class ShortCutHook
    {
        GlobalKeyboardHook MaximizeWindow = new GlobalKeyboardHook();

        GlobalKeyboardHook LeftSecond = new GlobalKeyboardHook();
        GlobalKeyboardHook RightSecond = new GlobalKeyboardHook();


        GlobalKeyboardHook OneThird = new GlobalKeyboardHook();
        GlobalKeyboardHook TwoThird = new GlobalKeyboardHook();
        GlobalKeyboardHook ThreeThird = new GlobalKeyboardHook();

        GlobalKeyboardHook LeftTwoThird = new GlobalKeyboardHook();
        GlobalKeyboardHook RightTwoThird = new GlobalKeyboardHook();


        GlobalKeyboardHook OneForth = new GlobalKeyboardHook();
        GlobalKeyboardHook TwoForth = new GlobalKeyboardHook();
        GlobalKeyboardHook ThreeForth = new GlobalKeyboardHook();
        GlobalKeyboardHook FourForth = new GlobalKeyboardHook();


        GlobalKeyboardHook LeftThreeForth = new GlobalKeyboardHook();
        GlobalKeyboardHook RightThreeForth = new GlobalKeyboardHook();

        GlobalKeyboardHook MiddleThreeForth = new GlobalKeyboardHook();
        // for grid

        GlobalKeyboardHook TopLeft = new GlobalKeyboardHook();
        GlobalKeyboardHook TopRight = new GlobalKeyboardHook();
        GlobalKeyboardHook BottomLeft = new GlobalKeyboardHook();
        GlobalKeyboardHook BottomRight = new GlobalKeyboardHook();


        public ShortCutHook()
        {
            MaximizeWindow.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindowMaximized);
            MaximizeWindow.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.Enter);
            /// 1 / 2

            LeftSecond.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindowLeftSecond);
            LeftSecond.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.H);

            RightSecond.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindowRightSecond);
            RightSecond.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.L);

            /// 1 / 3

            OneThird.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindowLeftThird);
            OneThird.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.D);

            TwoThird.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindowMiddleThird);
            TwoThird.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.F);

            ThreeThird.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindowRightThird);
            ThreeThird.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.G);


            /// 2 / 3
            LeftTwoThird.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_LEFT_TWO_THIRD);
            LeftTwoThird.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.E);

            RightTwoThird.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_RIGHT_TWO_THIRD);
            RightTwoThird.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.T);


            /// 1 / 4
            OneForth.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_FIRST_ONE_FORTH);
            OneForth.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.D7);

            TwoForth.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_SECOND_ONE_FORTH);
            TwoForth.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.D8);

            ThreeForth.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_THIRD_ONE_FORTH);
            ThreeForth.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.D9);

            FourForth.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_FORTH_ONE_FORTH);
            FourForth.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.D0);

            /// 3 / 4
            /// 
            LeftThreeForth.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_LEFT_THREE_FORTH);
            LeftThreeForth.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.F6);

            RightThreeForth.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_RIGHT_THREE_FORTH);
            RightThreeForth.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.F7);

            //// 2/4 middle
            MiddleThreeForth.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_MIDDLE_TWO_FORTH);
            MiddleThreeForth.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.Space);

            // 4 grid
            TopLeft.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_TOP_LEFT);
            TopLeft.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.U);

            TopRight.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_TOP_RIGHT);
            TopRight.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.I);

            BottomLeft.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_BOTTOM_LEFT);
            BottomLeft.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.J);

            BottomRight.KeyPressed += new EventHandler<KeyPressedEventArgs>(FrontWindowSetter.SetFrontWindow_BOTTOM_RIGHT);
            BottomRight.RegisterHotKey(ModifyKeys.Control | ModifyKeys.Win | ModifyKeys.Alt, Keys.K);

        }

    }
}
