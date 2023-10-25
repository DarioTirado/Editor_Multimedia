using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using Emgu.CV;
using Emgu.CV.Structure;


namespace Editor_Multimedia
{
    public partial class CAMARA : Form
    {
        private bool camara = true;
        private bool hayDispositivos;
        private FilterInfoCollection misDispositivos;
        private VideoCaptureDevice Micamara;

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("HOLAUWU.xml");

        public CAMARA()
        {
            InitializeComponent();
          
        }

        private void CAMARA_Load(object sender, EventArgs e)
        {
            CargarDispositivos();
        }


        private void rjComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Se Selecciono un disposiutivo :)");
        }

        public void CargarDispositivos()
        {
            misDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if(misDispositivos.Count > 0)
            {
                hayDispositivos = true;
                for(int i=0; i < misDispositivos.Count; i++)
                {

                    rjComboBox2.Items.Add(misDispositivos[i].Name.ToString());

                    rjComboBox2.Text = misDispositivos[0].ToString();
                }
            }
            else
            {
                hayDispositivos = false;
            }

        }

      public void CerrarCamara()
        {

            if(Micamara != null && Micamara.IsRunning)
            {
              
                Micamara.SignalToStop();
                Micamara.WaitForStop();
                Micamara = null;
                MessageBox.Show("Video Cerrado");
            }
            if (Micamara == null)
            {
                MessageBox.Show("Ningun Dipositivo Seleccionado");
                camara = false;
            }
            if (Micamara != null)
            {
                camara = true;
            }

        }

        private void BTN_INICIAR_VIDEO_Click(object sender, EventArgs e)
        {
            CerrarCamara();
            if (camara == true)
            {
                int i = rjComboBox2.SelectedIndex;
                string valor = misDispositivos[i].MonikerString;
                Micamara = new VideoCaptureDevice(valor);
                Micamara.NewFrame += new NewFrameEventHandler(capturavideo);
                MessageBox.Show("Camara disponible");
                Micamara.Start();
            }
            else
            {
                MessageBox.Show("Camara no disponible");
                camara = false;
            }
        }

        private List<Tuple<Rectangle, int>> personasDetectadas = new List<Tuple<Rectangle, int>>();


        private void capturavideo(object sender, NewFrameEventArgs eventArgs )
        {
          
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
         

            using (Image<Bgr, byte> currentFrame = BitmapExtension.ToImage<Bgr, byte>(frame))
            using (Image<Gray, byte> gray = currentFrame.Convert<Gray, byte>())
            {
                Rectangle[] facesDetected = cascadeClassifier.DetectMultiScale(gray, 1.1, 3, new Size(20, 20));

                personasDetectadas.Clear();

                int numeroPersona = 1;
                foreach (Rectangle rectangulo in facesDetected)
                {
                    personasDetectadas.Add(new Tuple<Rectangle, int>(rectangulo, numeroPersona));
                    numeroPersona++;
                }

                foreach (var persona in personasDetectadas)
                {
                    Rectangle rectangulo = persona.Item1;
                    int numPersona = persona.Item2;

                    using (Graphics graphics = Graphics.FromImage(frame))
                    using (Pen lapiz = new Pen(Color.Yellow, 1))
                    {
                        graphics.DrawRectangle(lapiz, rectangulo);
                        graphics.DrawString(numPersona.ToString(), new Font("Arial", 12), Brushes.Blue, rectangulo.Location);
                    }
                }

                pictureBox1.Image = frame;
            }




         
        }

        private void CAMARA_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarCamara();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CerrarCamara();
        }
    }
}
