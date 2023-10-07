using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace Editor_Multimedia
{
    public partial class Form1 : Form
    {
        private Bitmap original;
        private Bitmap resultante;
        public Form1()
        {
          
            InitializeComponent();
            AbrirForm(new PANTALLA_INICIO_FONDO_());
        }
        private void AbrirForm(object formnuevo)

        {
            if (this.Menu_Central.Controls.Count > 0)


            this.Menu_Central.Controls.RemoveAt(0);

            Form FormHija = formnuevo as Form;
            FormHija.TopLevel = false;
            FormHija.Dock = DockStyle.Fill;
            this.Menu_Central.Controls.Add(FormHija);
            this.Menu_Central.Tag = FormHija;
            FormHija.Show();
        }

                private void Menu_Izquierda_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTN_cerrar_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void BTN_expandir_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            BTN_expandir.Visible = false;
            BTN_restaurar.Visible = true;
          
        }

        private void BTN_INICIO_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            SUBMENU_OPCIONES.Visible = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]    
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Menu_Barra_Titulo_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BTN_restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            BTN_restaurar.Visible = false;
            BTN_expandir.Visible = true;
        }

        private void BTN_contraer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            SUBMENU_OPCIONES.Visible = false;

            AbrirForm(new CAMARA());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = true;
            SUBMENU_OPCIONES.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            OpenFileDialog fo = new OpenFileDialog();
            fo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";

            if (fo.ShowDialog() == DialogResult.OK)
            {
                string archivo = fo.FileName;
                string extension = Path.GetExtension(archivo).ToLower();

                if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                {
                    
                    original = new Bitmap(archivo);
                    Imagen_original.Image = original;

                   FOTOGRAFIA f1 = new FOTOGRAFIA(Imagen_original.Image);
              
                    AbrirForm(f1);

                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un archivo de imagen en formato JPG, JPEG o PNG.", "Formato de archivo inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


                SUBMENU_OPCIONES.Visible = false;
        }

        private void BTN_OPCIONES_Click(object sender, EventArgs e)
        {
            SUBMENU_OPCIONES.Visible = true;
            SUBMENU_FILTROS.Visible = false;
        }

        private void BTN_SUBIR_VIDEO_Click(object sender, EventArgs e)
        {
            SUBMENU_OPCIONES.Visible = false;

        

        }

        private void BTN_EXPORTAR_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            SUBMENU_OPCIONES.Visible = false;
        }

        private void BTN_HISTOGRAMA_Click(object sender, EventArgs e)
        {

            new HISTOGRAMA().Show();
        }

        private void Menu_Central_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Imagen_original_Click(object sender, EventArgs e)
        {

        }
    }
}
