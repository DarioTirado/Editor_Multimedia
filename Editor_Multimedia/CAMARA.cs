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

namespace Editor_Multimedia
{
    public partial class CAMARA : Form
    {
        private bool camara = true;
        private bool hayDispositivos;
        private FilterInfoCollection misDispositivos;
        private VideoCaptureDevice Micamara;

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

        private void capturavideo(object sender, NewFrameEventArgs eventArgs )
        {
          
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = imagen;
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
