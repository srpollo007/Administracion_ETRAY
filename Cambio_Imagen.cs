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

            if (opcion == 1)
            {
                try
                {
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "SELECT nombre_beb FROM bebidas";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cmbProducto.Items.Add(reader["nombre_beb"].ToString());
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
            if (opcion == 2)
            {
                try
                {
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "SELECT nombre_com FROM comida";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    cmbProducto.Items.Add(reader["nombre_com"].ToString());
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
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un producto antes de intentar cambiar la imagen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Por favor, seleccione una imagen primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


          
            //byte[] imagenBytes = Utilidades.ConvertirImagenABinario();

           // if (imagenBytes == null) return;  // Si hay un error en la conversión, termina la ejecución

            string nombreProducto = cmbProducto.Text;
            string tabla = opcion == 1 ? "bebidas" : "comidas";
            string columnaNombre = opcion == 1 ? "nombre_beb" : "nombre_com";
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = $"UPDATE {tabla} SET Imagen = @Imagen WHERE {columnaNombre} = @Nombre";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        //comando.Parameters.AddWithValue("@Imagen", imagenBytes);
                        comando.Parameters.AddWithValue("@Nombre", nombreProducto);

                        int resultado = comando.ExecuteNonQuery();
                        if (resultado > 0)
                        {
                            MessageBox.Show("La imagen ha sido actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la imagen en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreProducto = cmbProducto.SelectedItem.ToString();
            string tabla = opcion == 1 ? "bebidas" : "comida";
            string columnaNombre = opcion == 1 ? "nombre_beb" : "nombre_com";
            string columnaImagen = "Imagen"; // Asumiendo que el nombre de la columna de imagen es el mismo para ambas tablas
            string consulta = $"SELECT {columnaImagen} FROM {tabla} WHERE {columnaNombre} = @Nombre";
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", nombreProducto);

                        object result = comando.ExecuteScalar();
                        if (result != null)
                        {
                            byte[] imagenBytes = (byte[])result;
                            using (MemoryStream ms = new MemoryStream(imagenBytes))
                            {
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pictureBox1.Image = null; // O mostrar una imagen predeterminada
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la imagen del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

