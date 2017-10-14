using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Chanmongler
{
    public partial class frmMainBG : Form
    {
        public frmMainBG()
        {
            InitializeComponent();
        }

        private const Int32 LWA_COLORKEY = 0x1;
        private const Int32 LWA_ALPHA = 0x2;
        private const Int32 WS_EX_LAYERED = 0x00080000;

        public struct BlendF
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        public const byte AC_SRC_OVER = 0x0;
        public const byte AC_SRC_ALPHA = 0x1;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BlendF pblend, Int32 dwFlags);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        public static Point myLocationOffset = new Point(0, 0);
        public static FormWindowState getWindowState = FormWindowState.Normal;
        public static FormWindowState setWindowState = FormWindowState.Normal;
        public static IntPtr myHandle = (IntPtr)0;
        public static bool intGUI = false;

        private void frmMainBG_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            myHandle = this.Handle;
            this.Text += Application.ProductVersion;
            this.Show(); new frmMain().Show();
            Application.DoEvents(); SyncForms();

            byte[] buf = new byte[4096];
            Stream input = System.Reflection.Assembly.GetExecutingAssembly().
                   GetManifestResourceStream("Chanmongler.Chanmongler.png");
            Stream output = new FileStream("Chanmongler.png", FileMode.Create);
            int byteCount = input.Read(buf, 0, buf.Length);
            while (byteCount > 0)
            {
                output.Write(buf, 0, byteCount);
                byteCount = input.Read(buf, 0, buf.Length);
            }
            input.Dispose(); output.Dispose();
            Bitmap img = Image.FromFile("Chanmongler.png") as Bitmap;
            SetBitmap(img, 255); img.Dispose();
            System.IO.File.Delete("Chanmongler.png");
        }

        private void SetBitmap(Bitmap img, byte opacity)
        {
            if (img.PixelFormat != PixelFormat.Format32bppArgb)
                throw new Exception("Wrong bitmap format!");

            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;

            try
            {
                hBitmap = img.GetHbitmap(Color.FromArgb(0));
                oldBitmap = SelectObject(memDc, hBitmap);

                Size size = new Size(img.Width, img.Height);
                Point pointSource = new Point(0, 0);
                Point topPos = new Point(Left, Top);
                BlendF blend = new BlendF();
                blend.BlendOp = AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = opacity;
                blend.AlphaFormat = AC_SRC_ALPHA;

                UpdateLayeredWindow(this.Handle, screenDc, ref topPos, ref size,
                    memDc, ref pointSource, 0, ref blend, LWA_ALPHA);
            }
            finally
            {
                ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    SelectObject(memDc, oldBitmap);
                    DeleteObject(hBitmap);
                }
                DeleteDC(memDc);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_LAYERED; // This form has to have the WS_EX_LAYERED extended style
                return cp;
            }
        }

        private void frmMainBG_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                myLocationOffset = new Point(e.X, e.Y);
            SyncForms();
        }

        private void frmMainBG_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Location = new Point(
                this.Left - myLocationOffset.X + e.X,
                this.Top - myLocationOffset.Y + e.Y);
            SyncForms();
        }

        private void tGUI_Tick(object sender, EventArgs e)
        {
            if (intGUI) return; intGUI = true;
            IntPtr FWnd = GetForegroundWindow();
            if (FWnd == myHandle)
            {
                SyncForms();
            }
            if (FWnd != myHandle && FWnd != frmMain.myHandle)
            {
                frmMain.isVisible = false;
            }
            else
            {
                frmMain.isVisible = true;
            }
            if (setWindowState != FormWindowState.Normal)
            {
                getWindowState = setWindowState;
                this.WindowState = setWindowState;
                setWindowState = FormWindowState.Normal;
                if (getWindowState == FormWindowState.Minimized) frmMain.isVisible = false;
                if (getWindowState == FormWindowState.Normal) frmMain.isVisible = true;
            }
            if (getWindowState != this.WindowState)
            {
                getWindowState = this.WindowState;
                if (getWindowState == FormWindowState.Minimized) frmMain.isVisible = false;
                if (getWindowState == FormWindowState.Normal) frmMain.isVisible = true;
            }
            intGUI = false;
        }

        private void SyncForms()
        {
            FormPos.SetWindowPos(frmMain.myHandle, 0,
                this.Left, this.Top, 0, 0, FormPos.SWP_NOSIZE);
        }

        private void frmMainBG_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Kill();
        }
    }
}
