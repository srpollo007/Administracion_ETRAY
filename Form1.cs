using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_ETRAY
{
    public partial class Form1 : Form
    {
        private Size tamañoOriginal;
        private SoundPlayer reproductorSonido;
        public Form1()
        {
            InitializeComponent();
         

            tamañoOriginal = pictureBoxPDF.Size;
            reproductorSonido = new SoundPlayer("C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Image\\ring.wav");


            // Asocia los eventos MouseEnter y MouseLeave
            pictureBoxPDF.MouseEnter += PictureBox1_MouseEnter;
            pictureBoxPDF.MouseLeave += PictureBox1_MouseLeave;
        }

        private void bebidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Nuevo_Producto formNueva_bebida = new Nuevo_Producto(1);
            formNueva_bebida.ShowDialog();
        }

        private void comidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuevo_Producto fromNueva_comida = new Nuevo_Producto(2);
            fromNueva_comida.ShowDialog();
        }

        private void fotoGrafiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bebidaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cambio_Imagen cambio_imagenB = new Cambio_Imagen(1);
            cambio_imagenB.ShowDialog();
        }

        private void comidaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Cambio_Imagen cambio_imagenC = new Cambio_Imagen(2);
            cambio_imagenC.ShowDialog();
        }

        private void comidaToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editarDatosDeConexiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatosConecxion datosConecxion = new DatosConecxion();
            datosConecxion.ShowDialog();
        }

        private void pictureBoxPDF_Click(object sender, EventArgs e)
        {
            Utilidades.ReproducirSonido();

            string rutaPDF = "C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Resources\\PDF\\PaginaInicio.pdf";

            AbrirArchivoPDF(rutaPDF);

        }
        private void AbrirArchivoPDF(string rutaPDF)
        {
            try
            {
                // Verificar si el archivo existe
                if (!File.Exists(rutaPDF))
                {
                    MessageBox.Show("El archivo PDF no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Iniciar el visor de PDF predeterminado
                Process.Start(rutaPDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            // Aumenta el tamaño cuando el ratón entra en la PictureBox
            pictureBoxPDF.Size = new Size((int)(tamañoOriginal.Width * 1.2), (int)(tamañoOriginal.Height * 1.2));
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el tamaño original cuando el ratón sale de la PictureBox
            pictureBoxPDF.Size = tamañoOriginal;
            
        }

        private void bebidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Cambiar_Precio cambiarPrecio = new Cambiar_Precio(1);
            cambiarPrecio.ShowDialog();

        }

        private void comidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cambiar_Precio cambiarPrecio = new Cambiar_Precio(2);
            cambiarPrecio.ShowDialog();
        }
    }
}
