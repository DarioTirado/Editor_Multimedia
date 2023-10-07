using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_Multimedia
{
    public partial class FOTOGRAFIA : Form
    {
     

        public FOTOGRAFIA(Image Imagen)
        {

            InitializeComponent();
            Imagen_lienzo.Image = Imagen;
        }

        private void BTN_SUBIR_ARCHIVO_I_Click(object sender, EventArgs e)
        {
          
            
        }
    }
}
