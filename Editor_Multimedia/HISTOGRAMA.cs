using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Editor_Multimedia
{
    public partial class HISTOGRAMA : Form
    {
        public HISTOGRAMA()
        {
            InitializeComponent();
        }

        private void HISTOGRAMA_Load(object sender, EventArgs e)
        {
            //informacion
            string[] series = { "R", "G", "B" };
            int[] puntos = { 10, 50, 70 };

            //cambiar colores
            chart1.Palette = ChartColorPalette.Pastel;

            chart1.Titles.Add("Histograma RGB");

            for(int i=0; i< series.Length; i++)
            {//titulos
                Series serie = chart1.Series.Add(series[i]);

                //cantidades
                serie.Label = puntos[i].ToString();
                serie.Points.Add(puntos[i]);



            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
