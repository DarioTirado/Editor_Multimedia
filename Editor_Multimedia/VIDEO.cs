using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;




namespace Editor_Multimedia
{
    public partial class VIDEO : Form
    {
        private bool isPaused = false;
        private long lastFramePos = 0;
        private bool isPlaying = false;
        private Image<Bgr, byte> currentFrame;
        private bool videoLoad = false;
        private double duracion;
        private double frameCount;
        private VideoCapture grabber;
        private Bitmap bmpVideo;
        private Bitmap original;
        public VIDEO()
        {
            InitializeComponent();
        }

        private void BTN_SUBIR_ARCHIVO_I_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Files (.mp4)|*.mp4";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                grabber = new VideoCapture(ofd.FileName);
                grabber.QueryFrame();

                Mat m = new Mat();
                grabber.Read(m);

                duracion = grabber.GetCaptureProperty(CapProp.FrameCount);
                frameCount = grabber.GetCaptureProperty(CapProp.PosFrames);
                videoLoad = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (videoLoad)
            {
                if (isPaused)
                {
                    isPlaying = true;
                    isPaused = false;
                    Application.Idle += reproducirVideo;
                }
                else
                {
                    isPlaying = true;
                    lastFramePos = (long)grabber.GetCaptureProperty(CapProp.PosFrames);
                    Application.Idle += reproducirVideo;
                }
            }
            else
            {
                MessageBox.Show("No se cargó el video", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void reproducirVideo(object sender, EventArgs e)
        {
            if (isPlaying && frameCount < duracion - 1)
            {
                Mat m = new Mat();
                 grabber.Read(m);

                Image<Bgr, byte> currentFrame = new Image<Bgr, byte>(m.Width, m.Height);
                m.CopyTo(currentFrame);
                currentFrame = currentFrame.Resize(videoOri.Width, videoOri.Height, Inter.Cubic);

                frameCount = grabber.GetCaptureProperty(CapProp.PosFrames);

                videoOri.Image = currentFrame.ToBitmap();

                lastFramePos = (long)frameCount; // Actualizar la posición del cuadro cuando se reproduzca

                // Actualizar la posición del TrackBar
                int trackBarValue = (int)(frameCount * macTrackBar1.Maximum / duracion);
                macTrackBar1.Value = trackBarValue;
            }
            else if (!isPlaying)
            {
                frameCount = 0;
                grabber.SetCaptureProperty(CapProp.PosFrames, lastFramePos);
                Application.Idle -= reproducirVideo;
            }
        }

    }
}
