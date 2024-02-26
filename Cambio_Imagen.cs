using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Administracion_ETRAY
{
    public partial class Cambio_Imagen : Form
    {
        public int opcion = 0;

        public Cambio_Imagen(int opcionesEntrada)
        {
            InitializeComponent();
            this.opcion = opcionesEntrada;

        }

        private void comboBoxProductos()
        {
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDown;
            cmbProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;

            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = (opcion == 1) ? "SELECT Nombre FROM bebidas" : "SELECT Nombre FROM comidas";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbProducto.Items.Add(reader["Nombre"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar la ComboBox de Tipo Producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cambio_Imagen_Load(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                lblSeleccione.Text = "Seleccione Bebida";
                comboBoxProductos();
            }
            if (opcion == 2)
            {
                // llamada a la función de coger datos de Database de Comidas
                lblSeleccione.Text = "Seleccione Comida";

            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {

               string bebida = cmbProducto.Text;


            }
            if (opcion == 2)
            {
                string comida = cmbProducto.Text;


                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex != -1)
            {

                try
                {
                    string nombreProducto = cmbProducto.SelectedItem.ToString();
                    string columnaImagen = (opcion == 1) ? "Imagen" : "Imagen"; // Asegúrate de poner el nombre correcto de la columna

                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = $"SELECT {columnaImagen} FROM {(opcion == 1 ? "bebidas" : "comidas")} WHERE Nombre = @Nombre";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nombreProducto);

                            object result = comando.ExecuteScalar();
                            if (result != null)
                            {
                                byte[] imagenBytes = (byte[])result;

                                // Muestra la imagen en el PictureBox
                                using (MemoryStream ms = new MemoryStream(imagenBytes))
                                {
                                    pictureBox1.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                // Si no hay imagen en la base de datos, puedes mostrar una imagen predeterminada o dejar el PictureBox en blanco.
                                pictureBox1.Image = null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la imagen del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Intenta cargar la imagen seleccionada en el PictureBox
                    pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
        }
    }
}

