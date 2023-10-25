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
        private Bitmap resultante;
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
        private int dato;
        //filtros
        private bool negativo;
        private bool glitch;
        private bool sobel;
        private bool gradiente;
        private bool gamma;
        private bool desaturacion;
        private bool sepia;
        private bool mosaico;
        private bool salpimienta;
        private bool saturacion;
        Form1 inst = new Form1();
        public VIDEO()
        {
            InitializeComponent();
            Lista_Filtros.Items.Add("Negativo");
            Lista_Filtros.Items.Add("Glitch");
            Lista_Filtros.Items.Add("Sobel");
            Lista_Filtros.Items.Add("Gradiente");
            Lista_Filtros.Items.Add("Gamma");
            Lista_Filtros.Items.Add("Desaturacion");
            Lista_Filtros.Items.Add("Sepia");
            Lista_Filtros.Items.Add("Mosaico");
            Lista_Filtros.Items.Add("Sal_Pimienta");
            Lista_Filtros.Items.Add("Saturacion");
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

              

                if (negativo == true)
                {
                    resultante = AplicarFiltroNegativo(currentFrame.ToBitmap());
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                   
                }
                if (glitch == true)
                {
                    resultante = AplicarFiltroGlitch(currentFrame.ToBitmap());
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (sobel == true)
                {
                    resultante = AplicarFiltroSobel(currentFrame.ToBitmap());
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (gradiente == true)
                {
                    resultante = AplicarFiltroGradiente(currentFrame.ToBitmap());
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (gamma == true)
                {
                    resultante = AplicarFiltroGamma(currentFrame.ToBitmap());
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (desaturacion == true)
                {
                    resultante = AplicarFiltroDesaturacion(currentFrame.ToBitmap());
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (sepia == true)
                {
                    resultante = AlicarFiltroSepia(currentFrame.ToBitmap());
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (mosaico == true)
                {
                    resultante = AlpicarFiltroMosaico(currentFrame.ToBitmap(), 10);
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (salpimienta == true)
                {
                    resultante = AplicarFiltroSalpimienta(currentFrame.ToBitmap(), 0.05);
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }
                if (saturacion == true)
                {
                    resultante = AplicarFiltroSaturacion(currentFrame.ToBitmap(), 1.6);
                    Imagen_lienzo.Image = resultante;
                    CalculateHistogram();
                }


            }
            else if (!isPlaying)
            {
                frameCount = 0;
                grabber.SetCaptureProperty(CapProp.PosFrames, lastFramePos);
                Application.Idle -= reproducirVideo;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (videoLoad)
            {
                frameCount = 0;
                grabber.SetCaptureProperty(CapProp.PosFrames, 0);
            }
            else
            {
                MessageBox.Show("No se cargó el video", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (videoLoad)
            {
                isPlaying = false;
                isPaused = true;
                grabber.SetCaptureProperty(CapProp.PosFrames, lastFramePos);
            }
            else
            {
                MessageBox.Show("No se cargó el video", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lista_Filtros_OnSelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void BTN_APLICAR_FILTRO_Click(object sender, EventArgs e)
        {
            dato = Lista_Filtros.SelectedIndex;
            if (dato ==0)
            {
                negativo = true;
                glitch = false;
                sobel = false;
                gradiente = false;
                gamma = false;
                desaturacion = false;
                sepia = false;
                mosaico = false;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 1)
            {
                negativo = false;
                glitch = true;
                sobel = false;
                gradiente = false;
                gamma = false;
                desaturacion = false;
                sepia = false;
                mosaico = false;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 2)
            {
                negativo = false;
                glitch = false;
                sobel = true;
                gradiente = false;
                gamma = false;
                desaturacion = false;
                sepia = false;
                mosaico = false;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 3)
            {
                negativo = false;
                glitch = false;
                sobel = false;
                gradiente = true;
                gamma = false;
                desaturacion = false;
                sepia = false;
                mosaico = false;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 4)
            {
                negativo = false;
                glitch = false;
                sobel = false;
                gradiente = false;
                gamma = true;
                desaturacion = false;
                sepia = false;
                mosaico = false;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 5)
            {
                negativo = false;
                glitch = false;
                sobel = false;
                gradiente = false;
                gamma = false;
                desaturacion = true;
                sepia = false;
                mosaico = false;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 6)
            {
                negativo = false;
                glitch = false;
                sobel = false;
                gradiente = false;
                gamma = false;
                desaturacion = false;
                sepia = true;
                mosaico = false;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 7)
            {
                negativo = false;
                glitch = false;
                sobel = false;
                gradiente = false;
                gamma = false;
                desaturacion = false;
                sepia = false;
                mosaico = true;
                salpimienta = false;
                saturacion = false;
            }
            if (dato == 8)
            {
                negativo = false;
                glitch = false;
                sobel = false;
                gradiente = false;
                gamma = false;
                desaturacion = false;
                sepia = false;
                mosaico = false;
                salpimienta = true;
                saturacion = false;
            }
            if (dato == 9)
            {
                negativo = false;
                glitch = false;
                sobel = false;
                gradiente = false;
                gamma = false;
                desaturacion = false;
                sepia = false;
                mosaico = false;
                salpimienta = false;
                saturacion = true;
            }

        }

        private void CalculateHistogram()
        {
            Bitmap imgEditada = new Bitmap(Imagen_lienzo.Image);
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
            histog.Image= new Bitmap(256, 400); // Increase the height of the histogram image
            using (Graphics g = Graphics.FromImage(histog.Image))
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

            histog.Refresh();
        }

        private Bitmap AplicarFiltroNegativo(Bitmap bmp)
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

        private Bitmap AplicarFiltroGlitch(Bitmap bmp)
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

        private Bitmap AplicarFiltroSobel(Bitmap bmp)
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

        private Bitmap AplicarFiltroGradiente(Bitmap bmp)
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

        private Bitmap AplicarFiltroGamma(Bitmap bmp)
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

        private Bitmap AplicarFiltroDesaturacion(Bitmap bmp)
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

        private Bitmap AlicarFiltroSepia(Bitmap bmp)
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

        private Bitmap AlpicarFiltroMosaico(Bitmap bmp ,int tamañoPixel)
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

        private Bitmap AplicarFiltroSalpimienta(Bitmap bmp, double intensidad)
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

        private Bitmap AplicarFiltroSaturacion(Bitmap imagenOriginal, double factorSaturacion)
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

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
