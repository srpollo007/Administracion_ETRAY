using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Administracion_ETRAY
{

    internal class Utilidades
    {
        private static Size tamañoOriginal;


        static Utilidades()
        {
            // Carga el sonido durante la inicialización de la clase
            CargarSonido();
        }

        private static SoundPlayer reproductorSonido;
        #region FORMATO EUROS
        public static void AplicarFormatoEuros(TextBox textBox)
        {
            if (decimal.TryParse(textBox.Text, out decimal precio))
            {
                string formatoEuros = precio.ToString("C", CultureInfo.GetCultureInfo("es-ES"));
                textBox.Text = formatoEuros;
            }
        }
        public static void PermitirSoloNumerosYComa(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            TextBox textBox = sender as TextBox;

            if ((e.KeyChar == ',') && (textBox.Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion


        public static void SeleccionarYMostrarImagen(TextBox textBox, PictureBox pictureBox)
        {
            // Abre un OpenFileDialog para permitir al usuario seleccionar una imagen
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Muestra la ruta del archivo seleccionado en el TextBox
                textBox.Text = openFileDialog.FileName;

                // Carga la imagen en el PictureBox
                pictureBox.Image = Image.FromFile(textBox.Text);
            }
        }

        public static byte[] ConvertirImagenABinario(string rutaImagen)
        {
            try
            {
                if (!string.IsNullOrEmpty(rutaImagen) && System.IO.File.Exists(rutaImagen))
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(rutaImagen, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        return buffer;
                    }
                }
                else
                {
                    MessageBox.Show("La ruta de la imagen no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al convertir la imagen a binario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        #region ConexionBD

        public static string ObtenerCadenaConexionDesdeXML()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("C:\\Users\\david\\Music\\Administracion_ETRAY\\Datos_ConexionBD.xml");

                XmlNode servidorNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/servidor");
                XmlNode baseDeDatosNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/baseDeDatos");
                XmlNode usuarioNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/usuario");
                XmlNode contrasenaNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/contrasena");

                if (servidorNode != null && baseDeDatosNode != null && usuarioNode != null && contrasenaNode != null)
                {
                    string servidor = servidorNode.InnerText;
                    string baseDeDatos = baseDeDatosNode.InnerText;
                    string usuario = usuarioNode.InnerText;
                    string contrasena = contrasenaNode.InnerText;

                    return $"Server={servidor};Database={baseDeDatos};User ID={usuario};Password={contrasena};";
                }
                else
                {
                    MessageBox.Show("No se encontraron todos los nodos de conexión en el archivo XML.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool ProbarConexion(string cadenaConexion)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    if (conexion.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Conexión exitosa a la base de datos.", "Información de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La conexión a la base de datos no se ha establecido correctamente.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al probar la conexión a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion




        #region BotonAyuda

        private static void CargarSonido()
        {
            try
            {
                // Inicializa el reproductor de sonido con la ruta del archivo de sonido
                reproductorSonido = new SoundPlayer("C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Image\\ring.wav");

                // Carga el sonido en la memoria
                reproductorSonido.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el sonido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ReproducirSonido()
        {
            // Reproduce el sonido
            reproductorSonido.Play();
        }

        public static void PictureBox_MouseEnter(PictureBox pictureBox, object sender, EventArgs e)
        {
            // Guarda el tamaño original del PictureBox
            tamañoOriginal = pictureBox.Size;

            // Aumenta el tamaño cuando el ratón entra en la PictureBox
            pictureBox.Size = new Size((int)(tamañoOriginal.Width * 1.2), (int)(tamañoOriginal.Height * 1.2));
        }

        public static void PictureBox_MouseLeave(PictureBox pictureBox, object sender, EventArgs e)
        {
            // Restaura el tamaño original cuando el ratón sale de la PictureBox
            pictureBox.Size = tamañoOriginal;
        }


   
    
    }


    #endregion



}
    
