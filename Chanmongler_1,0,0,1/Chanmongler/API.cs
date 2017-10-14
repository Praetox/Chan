using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Chanmongler
{
    #region MP3 player class
    public class MP3
    {
        private string Pcommand; private bool isOpen;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(
            string strCommand,          // The command to execute
            StringBuilder strReturn,    // The returned string (if any)
            int iReturnLength,          // The bitcount of the returned string
            IntPtr hwndCallback);       // Callback value of spec. handle
        public MP3()
        {
        }

        public void Close()
        {
            Pcommand = "close Praetox";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }

        public void Open(string sFileName)
        {
            Pcommand = "open \"" + sFileName + "\" type mpegvideo alias Praetox";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = true;
        }

        public void Play(bool loop)
        {
            if (isOpen)
            {
                Pcommand = "play Praetox";
                if (loop) Pcommand += " REPEAT";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
            }
        }
    }
    #endregion
    #region Set position of any form
    public class FormPos
    {
        //FormPos.SetWindowPos((int)this.Handle, -1, 0, 0, 0, 0,
        //FormPos.SWP_NOMOVE + FormPos.SWP_NOSIZE + FormPos.SWP_SHOWWINDOW);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(
           IntPtr hWnd,            // Window handle
           int hWndInsertAfter,    // Placement-order handle
           int X,                  // Horizontal position
           int Y,                  // Vertical position
           int cx,                 // Width
           int cy,                 // Height
           uint uFlags);           // Window positioning flags
        public const int HWND_BOTTOM = 0x1;
        public const uint SWP_NOSIZE = 0x1;
        public const uint SWP_NOMOVE = 0x2;
        public const uint SWP_SHOWWINDOW = 0x40;
        public const uint SWP_HIDEWINDOW = 0x80;
    }
    #endregion
    #region Read keyboard without focus
    public class GKHook
    {
        //if (GetAsyncKeyState(Keys.F12)==-32767) ...
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(
            System.Windows.Forms.Keys vKey);    // The keycode to poll for
    }
    #endregion
}
