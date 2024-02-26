using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Administracion_ETRAY
{
    public partial class DatosConecxion : Form
    {
        private string rutaArchivoXml = "C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Datos_ConexionBD.xml";
        private Size tamañoOriginal;

        public DatosConecxion()
        {
            InitializeComponent();
            txtContrasena.PasswordChar = '*';
            CargarDatosActualesSinUsuarioContraseña();
            tamañoOriginal = pictureBoxPDF.Size;
           
            pictureBoxPDF.MouseEnter += (sender, e) => Utilidades.PictureBox_MouseEnter(pictureBoxPDF, sender, e);
            pictureBoxPDF.MouseLeave += (sender, e) => Utilidades.PictureBox_MouseLeave(pictureBoxPDF, sender, e);


        }

        private void CargarDatosActuales()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaArchivoXml);

                XmlNode servidorNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/servidor");
                XmlNode baseDeDatosNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/baseDeDatos");
                XmlNode usuarioNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/usuario");
                XmlNode contrasenaNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/contrasena");

                if (servidorNode != null)
                    txtServidor.Text = servidorNode.InnerText;

                if (baseDeDatosNode != null)
                    txtBaseDatos.Text = baseDeDatosNode.InnerText;

                if (usuarioNode != null)
                    txtUsuario.Text = usuarioNode.InnerText;

                if (contrasenaNode != null)
                    txtContrasena.Text = contrasenaNode.InnerText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos actuales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaArchivoXml);

                XmlNode servidorNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/servidor");
                XmlNode baseDeDatosNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/baseDeDatos");
                XmlNode usuarioNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/usuario");
                XmlNode contrasenaNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/contrasena");

                if (servidorNode != null)
                    servidorNode.InnerText = txtServidor.Text;

                if (baseDeDatosNode != null)
                    baseDeDatosNode.InnerText = txtBaseDatos.Text;

                if (usuarioNode != null)
                    usuarioNode.InnerText = txtUsuario.Text;

                if (contrasenaNode != null)
                    contrasenaNode.InnerText = txtContrasena.Text;

                doc.Save(rutaArchivoXml);

                MessageBox.Show("Datos de conexión guardados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
        private void CargarDatosActualesSinUsuarioContraseña()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(rutaArchivoXml);

                XmlNode servidorNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/servidor");
                XmlNode baseDeDatosNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/baseDeDatos");
                XmlNode usuarioNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/usuario");
                XmlNode contrasenaNode = doc.DocumentElement.SelectSingleNode("/configuracion/conexion/contrasena");

                if (servidorNode != null)
                    txtServidor.Text = servidorNode.InnerText;

                if (baseDeDatosNode != null)
                    txtBaseDatos.Text = baseDeDatosNode.InnerText;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos actuales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxOjo_Click(object sender, EventArgs e)
        {
            string ojoCerrado = "C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Image\\OjoCerrado.png";
            string ojoabierto = "C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Image\\OjoAbierto.png";
            // Verifica si el PasswordChar actual es '*'
            if (txtContrasena.PasswordChar == '*')
            {
                // Cambia a modo de texto visible
                txtContrasena.PasswordChar = '\0';
                pictureBoxOjo.Image = Image.FromFile(ojoabierto);
            }
            else
            {
                // Cambia a modo de contraseña oculta
                txtContrasena.PasswordChar = '*';
                pictureBoxOjo.Image = Image.FromFile(ojoCerrado);
            }

        }




        #region PDF
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
        private void pictureBoxPDF_Click(object sender, EventArgs e)
        {
            string rutaPDF = "C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Resources\\PDF\\PaginaInicio.pdf";

            AbrirArchivoPDF(rutaPDF);
        }

      



        #endregion


    }
}


