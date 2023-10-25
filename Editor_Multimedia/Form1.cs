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
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;



namespace Editor_Multimedia
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> currentFrame;
        private bool videoLoad = false;
        private double duracion;
        private double frameCount;
        private VideoCapture grabber;
        private Bitmap original;
        private Bitmap resultante;
        private Bitmap resultantevid;

        private bool isPlaying = false;
        public Form1()
        {
          
            InitializeComponent();
            AbrirForm(new PANTALLA_INICIO_FONDO_());
        }

        public PictureBox MiPictureBox { get; set; }

        public void ActualizarPictureBox(Image nuevaImagen)
        {
            Histograma_pic.Image = nuevaImagen;
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
            SUBMENU_FILTROS.Visible = false;
            AbrirForm(new VIDEO());
        }

            private void BTN_EXPORTAR_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            SUBMENU_OPCIONES.Visible = false;

            if (resultante != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    resultante.Save(sfd.FileName);
                    MessageBox.Show("La imagen se guardó exitosamente.", "Guardar imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No se ha aplicado ningún filtro o no se ha cargado una imagen.", "Guardar imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

        private void button9_Click(object sender, EventArgs e)
        {

            AbrirForm(new MANUAL_USUARIO());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                resultante = Inversion(new Bitmap(original));
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                resultante = AplicarFiltroGlitch(new Bitmap(original));
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                resultante = AplicarFiltroSobel(new Bitmap(original));
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                resultante = AplicarFiltroGradienteColores(new Bitmap(original));
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                resultante = AplicaGamma(new Bitmap(original));
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                resultante = QuitarSaturacion(new Bitmap(original));
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                resultante = AplicarFiltroSepia(new Bitmap(original));
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                int Pixel = 30;
                resultante = AplicarFiltroPixeleado(new Bitmap(original) , Pixel);
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            if (original != null)
            {
                double intensidad = 0.05;
                resultante = AplicarFiltroSalPimienta(new Bitmap(original), intensidad);
                FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
                AbrirForm(f2);
                CalculateHistogram();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SUBMENU_FILTROS.Visible = false;
            resultante = AplicarFiltroSaturacion(new Bitmap(original), 1.6);
            FOTOGRAFIA f2 = new FOTOGRAFIA(resultante);
            AbrirForm(f2);
            CalculateHistogram();
        }

        //FILTROS
        private Bitmap Inversion(Bitmap bmp)//NEGATIVO
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    Color color = bmp.GetPixel(i, j);
                    bmp.SetPixel(i, j, Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B));
                }
            }
            return bmp;
        }

        private Bitmap AplicarFiltroGlitch(Bitmap bmp)//GLITCH
        {
            Bitmap resultado = new Bitmap(bmp.Width, bmp.Height);

            Random rand = new Random();
            int desplazamientoMax = 5; // Define el desplazamiento máximo del efecto de glitch

            for (int y = 0; y < bmp.Height; y++)
            {
                int desplazamientoX = rand.Next(-desplazamientoMax, desplazamientoMax + 1);
                int desplazamientoY = rand.Next(-desplazamientoMax, desplazamientoMax + 1);
                int desplazamientoR = rand.Next(-desplazamientoMax, desplazamientoMax + 1);
                int desplazamientoG = rand.Next(-desplazamientoMax, desplazamientoMax + 1);
                int desplazamientoB = rand.Next(-desplazamientoMax, desplazamientoMax + 1);

                for (int x = 0; x < bmp.Width; x++)
                {
                    int newX = (x + desplazamientoX + bmp.Width) % bmp.Width;
                    int newY = (y + desplazamientoY + bmp.Height) % bmp.Height;

                    Color color = bmp.GetPixel(newX, newY);

                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    int newXr = (newX + desplazamientoR + bmp.Width) % bmp.Width;
                    int newGr = (newY + desplazamientoG + bmp.Height) % bmp.Height;
                    int newBr = (newX + desplazamientoB + bmp.Width) % bmp.Width;

                    Color colorR = Color.FromArgb(bmp.GetPixel(newXr, newY).R, g, b);
                    Color colorG = Color.FromArgb(r, bmp.GetPixel(newX, newGr).G, b);
                    Color colorB = Color.FromArgb(r, g, bmp.GetPixel(newBr, newY).B);

                    resultado.SetPixel(x, y, Color.FromArgb(colorR.R, colorG.G, colorB.B));
                }
            }

            return resultado;
        }

        private Bitmap AplicarFiltroSobel(Bitmap bmp)//SOBEL
        {
            Bitmap resultado = new Bitmap(bmp.Width, bmp.Height);

            int[,] filtroX = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] filtroY = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            int ancho = bmp.Width;
            int alto = bmp.Height;

            for (int y = 1; y < alto - 1; y++)
            {
                for (int x = 1; x < ancho - 1; x++)
                {
                    int sumXr = 0, sumXg = 0, sumXb = 0;
                    int sumYr = 0, sumYg = 0, sumYb = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = bmp.GetPixel(x + i, y + j);
                            int r = pixel.R;
                            int g = pixel.G;
                            int b = pixel.B;

                            sumXr += filtroX[i + 1, j + 1] * r;
                            sumXg += filtroX[i + 1, j + 1] * g;
                            sumXb += filtroX[i + 1, j + 1] * b;

                            sumYr += filtroY[i + 1, j + 1] * r;
                            sumYg += filtroY[i + 1, j + 1] * g;
                            sumYb += filtroY[i + 1, j + 1] * b;
                        }
                    }

                    int totalR = Math.Min(Math.Max((int)Math.Sqrt(sumXr * sumXr + sumYr * sumYr), 0), 255);
                    int totalG = Math.Min(Math.Max((int)Math.Sqrt(sumXg * sumXg + sumYg * sumYg), 0), 255);
                    int totalB = Math.Min(Math.Max((int)Math.Sqrt(sumXb * sumXb + sumYb * sumYb), 0), 255);

                    Color colorSobel = Color.FromArgb(totalR, totalG, totalB);
                    resultado.SetPixel(x, y, colorSobel);
                }
            }

            return resultado;
        }

        private Bitmap AplicarFiltroGradienteColores(Bitmap bmp)//GRADIENTE
        {
            Bitmap resultado = new Bitmap(bmp.Width, bmp.Height);

            Color colorInicio = Color.FromArgb(255, 165, 0); // Aumentamos la intensidad del naranja
            Color colorFin = Color.Green; // Cambiamos el color de fin a verde

            for (int y = 0; y < bmp.Height; y++)
            {
                double porcentaje = (double)y / bmp.Height; // Porcentaje de avance en el gradiente

                for (int x = 0; x < bmp.Width; x++)
                {
                    int r = InterpolateColorComponent(colorInicio.R, colorFin.R, porcentaje);
                    int g = InterpolateColorComponent(colorInicio.G, colorFin.G, porcentaje);
                    int b = InterpolateColorComponent(colorInicio.B, colorFin.B, porcentaje);

                    Color colorOriginal = bmp.GetPixel(x, y);

                    int rFinal = (int)(r * porcentaje + colorOriginal.R * (1 - porcentaje));
                    int gFinal = (int)(g * porcentaje + colorOriginal.G * (1 - porcentaje));
                    int bFinal = (int)(b * porcentaje + colorOriginal.B * (1 - porcentaje));

                    resultado.SetPixel(x, y, Color.FromArgb(rFinal, gFinal, bFinal));
                }
            }

            return resultado;
        }

        private int InterpolateColorComponent(int start, int end, double percentage)//COLOR_COMPONENT
        {
            return (int)(start + (end - start) * percentage);
        }

        private Bitmap AplicaGamma(Bitmap bmp)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    Color color = bmp.GetPixel(i, j);
                    bmp.SetPixel(i, j, Color.FromArgb(color.A, 0, color.G, 0));
                }
            }
            return bmp;
        }

        private Bitmap AplicarFiltroSepia(Bitmap bmp)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int nuevoR = (int)(color.R * 0.393 + color.G * 0.769 + color.B * 0.189);
                    int nuevoG = (int)(color.R * 0.349 + color.G * 0.686 + color.B * 0.168);
                    int nuevoB = (int)(color.R * 0.272 + color.G * 0.534 + color.B * 0.131);
                    nuevoR = Math.Min(255, nuevoR);
                    nuevoG = Math.Min(255, nuevoG);
                    nuevoB = Math.Min(255, nuevoB);
                    Color nuevoPixel = Color.FromArgb(nuevoR, nuevoG, nuevoB);
                 
                    bmp.SetPixel(i, j, nuevoPixel);
                }
            }
            return bmp;
        }

        private Bitmap QuitarSaturacion(Bitmap bmp)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    Color color = bmp.GetPixel(i, j);
                    int promedio = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11);
                    Color nuevoPixel = Color.FromArgb(promedio, promedio, promedio);
                    bmp.SetPixel(i, j, nuevoPixel);
                }
            }
            return bmp;
        }

        private Bitmap AplicarFiltroPixeleado(Bitmap bmp, int tamañoPixel)
        {
            Bitmap resultado = new Bitmap(bmp.Width, bmp.Height);

            for (int y = 0; y < bmp.Height; y += tamañoPixel)
            {
                for (int x = 0; x < bmp.Width; x += tamañoPixel)
                {
                    Color promedioColor = CalcularPromedioColor(bmp, x, y, tamañoPixel);
                    RellenarPixeles(resultado, x, y, tamañoPixel, promedioColor);
                }
            }

            return resultado;
        }

        private Color CalcularPromedioColor(Bitmap bmp, int startX, int startY, int tamañoPixel)
        {
            int totalR = 0, totalG = 0, totalB = 0;
            int count = 0;

            for (int y = startY; y < startY + tamañoPixel && y < bmp.Height; y++)
            {
                for (int x = startX; x < startX + tamañoPixel && x < bmp.Width; x++)
                {
                    Color color = bmp.GetPixel(x, y);
                    totalR += color.R;
                    totalG += color.G;
                    totalB += color.B;
                    count++;
                }
            }

            int promedioR = totalR / count;
            int promedioG = totalG / count;
            int promedioB = totalB / count;

            return Color.FromArgb(promedioR, promedioG, promedioB);
        }

        private void RellenarPixeles(Bitmap bmp, int startX, int startY, int tamañoPixel, Color color)
        {
            for (int y = startY; y < startY + tamañoPixel && y < bmp.Height; y++)
            {
                for (int x = startX; x < startX + tamañoPixel && x < bmp.Width; x++)
                {
                    bmp.SetPixel(x, y, color);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)//RESTAURAR
        {
            original = new Bitmap(original);
            Imagen_original.Image = original;

            FOTOGRAFIA f1 = new FOTOGRAFIA(Imagen_original.Image);

            AbrirForm(f1);
        }

        private static Bitmap AplicarFiltroSalPimienta(Bitmap bmp, double intensidad)
        {
            Bitmap resultado = new Bitmap(bmp.Width, bmp.Height);
            Random random = new Random();

            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    if (random.NextDouble() < intensidad)
                    {
                        // Agrega píxeles blancos (sal).
                       resultado.SetPixel(x, y, Color.White);
                    }
                    else if (random.NextDouble() < intensidad)
                    {
                        // Agrega píxeles negros (pimienta).
                        resultado.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        // Copia el píxel de la imagen original.
                        resultado.SetPixel(x, y, bmp.GetPixel(x, y));
                    }
                }
            }

            return resultado;
        }

        //HISTOGRAMA - - - - - - - - - - - - - - - - - - - -
        private void CalculateHistogram()
        {
            Bitmap imgEditada = new Bitmap(resultante);
            int[] redHistogram = new int[256];
            int[] greenHistogram = new int[256];
            int[] blueHistogram = new int[256];

            // Calculate the histogram
            for (int x = 0; x < imgEditada.Width; x++)
            {
                for (int y = 0; y < imgEditada.Height; y++)
                {
                    Color pixelColor = imgEditada.GetPixel(x, y);
                    redHistogram[pixelColor.R]++;
                    greenHistogram[pixelColor.G]++;
                    blueHistogram[pixelColor.B]++;
                }
            }

            // Normalize the histogram values
            int maxCount = Math.Max(Math.Max(redHistogram.Max(), greenHistogram.Max()), blueHistogram.Max());
            double scaleFactor = 400.0 / maxCount; // Increase the scaling factor

            // Create the histogram visualization
            Histograma_pic.Image = new Bitmap(256, 400); // Increase the height of the histogram image
            using (Graphics g = Graphics.FromImage(Histograma_pic.Image))
            {
                g.Clear(Color.White);

                for (int i = 0; i < 256; i++)
                {
                    int redHeight = (int)(redHistogram[i] * scaleFactor);
                    int greenHeight = (int)(greenHistogram[i] * scaleFactor);
                    int blueHeight = (int)(blueHistogram[i] * scaleFactor);

                    g.DrawLine(Pens.Red, i, 399, i, 399 - redHeight);
                    g.DrawLine(Pens.Green, i, 399, i, 399 - greenHeight);
                    g.DrawLine(Pens.Blue, i, 399, i, 399 - blueHeight);
                }

            }

            Histograma_pic.Refresh();
        }

        static Bitmap AplicarFiltroSaturacion(Bitmap imagenOriginal, double factorSaturacion)
        {
            Bitmap imagenSaturada = new Bitmap(imagenOriginal.Width, imagenOriginal.Height);

            for (int x = 0; x < imagenOriginal.Width; x++)
            {
                for (int y = 0; y < imagenOriginal.Height; y++)
                {
                    Color pixel = imagenOriginal.GetPixel(x, y);

                    // Calcula nuevos valores para los componentes de color (RGB) con el factor de saturación
                    int red = (int)Math.Min(255, pixel.R * factorSaturacion);
                    int green = (int)Math.Min(255, pixel.G * factorSaturacion);
                    int blue = (int)Math.Min(255, pixel.B * factorSaturacion);

                    // Crea un nuevo color saturado
                    Color nuevoPixel = Color.FromArgb(red, green, blue);

                    // Asigna el nuevo color al bitmap saturado
                    imagenSaturada.SetPixel(x, y, nuevoPixel);
                }
            }

            return imagenSaturada;
        }

        private void Histograma_pic_Click(object sender, EventArgs e)
        {

        }

        
    }
}
