using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ScreenBody : Form
    {
        private Point startPoint;
        private Point endPoint;
        private bool isCapture;
        public Rectangle RectRegion { get; private set; }
        Bitmap b;
        public ScreenBody()
        {
            //SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            InitializeComponent();
        }

        private void ScreenBody_Load(object sender, EventArgs e)
        {
            Left = 0;
            Top = 0;
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Point pt = this.PointToScreen(new Point(0, 0));
            b = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(pt, new Point(), new Size(this.Width, this.Height));
            }
            this.BackgroundImage = b;
        }

        private void ScreenBody_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            isCapture = true;
            endPoint = e.Location;
            Console.WriteLine($"down x={e.X}, y={e.Y}");
        }

        private void ScreenBody_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Up x={e.X}, y={e.Y}");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private int count = 0;
        private void ScreenBody_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            RectRegion = new Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
            g.DrawRectangle(Pens.Black, RectRegion);
        }

        private void ScreenBody_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isCapture)
            {
                Console.WriteLine($"Mouse x={e.X}, y={e.Y}");
                endPoint = e.Location;
                this.Refresh();
            }
        }
    }
}
