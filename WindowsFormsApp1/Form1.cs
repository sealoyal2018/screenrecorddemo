using System;
using System.Drawing;
using System.Windows.Forms;
using acvideo = Accord.Video;
using System.IO;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public acvideo::ScreenCaptureStream stream;
        acvideo::FFMPEG.VideoFileWriter writer;
        private Rectangle regionRect;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Stream_NewFrame(object sender, acvideo.NewFrameEventArgs eventArgs)
        {
            writer.WriteVideoFrame(eventArgs.Frame);
            writer.Flush();
            using (var ms = new MemoryStream())
            {
                eventArgs.Frame.Save(ms, ImageFormat.Bmp);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stream = new acvideo::ScreenCaptureStream(regionRect);
            writer = new acvideo::FFMPEG.VideoFileWriter();
            writer.Open("./temp.avi", regionRect.Width, regionRect.Height, 30, acvideo.FFMPEG.VideoCodec.MSMPEG4v3);
            stream.FrameInterval = 40;
            stream.NewFrame += Stream_NewFrame;
            stream.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stream.Stop();
            writer.Flush();
            writer.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var s = new ScreenBody();
            this.Hide();
            if (s.ShowDialog(this) == DialogResult.OK)
            {
                regionRect = s.RectRegion;
            }
            if (regionRect.Width % 2 != 0)
                regionRect.Width += 1;

            if (regionRect.Height % 2 != 0)
                regionRect.Height += 1;

            this.Show();

        }



        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            writer.Dispose();

        }
    }
}
