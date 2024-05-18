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

                        string consulta = "SELECT idbebidas, nombre_beb FROM bebidas";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Crear un objeto Producto con el ID y el nombre y agregarlo a la lista desplegable
                                    Producto producto = new Producto(Convert.ToInt32(reader["idbebidas"]), reader["nombre_beb"].ToString());
                                    cmbProducto.Items.Add(producto);
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
                                    // Crear un objeto Producto con el nombre y agregarlo a la lista desplegable
                                    Producto producto = new Producto(0, reader["nombre_com"].ToString());
                                    cmbProducto.Items.Add(producto);
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
                comboBoxProductos();

            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {    
                string Producto = cmbProducto.Text;  
                string rutaImagen = txtruta.Text;
                byte[] imagenBytes = Utilidades.ConvertirImagenABinario(rutaImagen);

                ActualizarFoto(imagenBytes, Producto);            

        }

        private void ActualizarFoto(byte[] imagen, string Producto)
        {
            if(opcion == 1)
            {
                try
                {
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        if (conexion.State == ConnectionState.Open)
                        {
                            string consulta = "UPDATE bebidas SET Imagen = @Imagen WHERE nombre_beb = @Nombre";

                            using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                            {
                                comando.Parameters.AddWithValue("@Nombre", Producto);
                                
                                comando.Parameters.AddWithValue("@Imagen", imagen);
                              

                                comando.ExecuteNonQuery();

                                MessageBox.Show("Actuaalizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                               
                            }
                        }
                        else
                        {
                            MessageBox.Show("La conexión a la base de datos no se ha establecido correctamente.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Control de errores específico para MySQL
                    switch (ex.Number)
                    {
                        case 1062: // Duplicado de clave única
                            MessageBox.Show("Error: La bebida con este nombre ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show($"Error MySQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general al insertar la bebida en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        if (conexion.State == ConnectionState.Open)
                        {
                            string consulta = "UPDATE comida SET Imagen = @Imagen WHERE nombre_com = @Nombre";

                            using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                            {
                                comando.Parameters.AddWithValue("@Nombre", Producto);

                                comando.Parameters.AddWithValue("@Imagen", imagen);


                                comando.ExecuteNonQuery();

                                MessageBox.Show("Actuaalizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            }
                        }
                        else
                        {
                            MessageBox.Show("La conexión a la base de datos no se ha establecido correctamente.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Control de errores específico para MySQL
                    switch (ex.Number)
                    {
                        case 1062: // Duplicado de clave única
                            MessageBox.Show("Error: La fotografia ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show($"Error MySQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error general al insertar la bebida en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
          
                Utilidades.SeleccionarYMostrarImagen(txtruta, pictureBox2);
           
        }

        private void pictureBoxPDF_Click(object sender, EventArgs e)
        {

        }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Producto(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

}

