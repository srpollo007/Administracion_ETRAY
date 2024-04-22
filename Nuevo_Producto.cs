//6
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Administracion_ETRAY
{
    public partial class Nuevo_Producto : Form
    {
        public int opcion = 0;



        public Nuevo_Producto(int opcionEntrada)
        {
            InitializeComponent();
            ProbarConexion();
            txtURL.Click += txtURL_Click;

            pictureBoxPDF.MouseEnter += (sender, e) => Utilidades.PictureBox_MouseEnter(pictureBoxPDF, sender, e);
            pictureBoxPDF.MouseLeave += (sender, e) => Utilidades.PictureBox_MouseLeave(pictureBoxPDF, sender, e);

            this.opcion = opcionEntrada;

        }

        private void Nueva_Bebida_Load(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                lblTipo_Produc.Text = "Tipos Bebidas";
                lblTitulo.Text = "Nueva Bebida";
                // llamada a la función de coger datos de Database de Bebidas
                comboBoxBebida();


            }
            if (opcion == 2)
            {
                lblTipo_Produc.Text = "Tipos Comida";
                lblTitulo.Text = "Nueva Comida";
                comboBoxComida();
                txt_Codigo_ba.Enabled = false;
            }
        }

        private void ProbarConexion()
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

            if (cadenaConexion != null)
            {
                Utilidades.ProbarConexion(cadenaConexion);
            }
        }

        private void txtURL_Click(object sender, EventArgs e)
        {
            Utilidades.SeleccionarYMostrarImagen(txtURL, pictureBox1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Utilidades.SeleccionarYMostrarImagen(txtURL, pictureBox1);
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            //Utilidades.AplicarFormatoEuros(txtPrecio);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilidades.PermitirSoloNumerosYComa(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                string Nombre = txtNom_Produc.Text;
                decimal precio = decimal.Parse(txtPrecio.Text);
                string codigo_Barras = txt_Codigo_ba.Text;
                string rutaImagen = txtURL.Text;
                string TipoBebida = cmbProducto.Text;

                byte[] imagenBytes = Utilidades.ConvertirImagenABinario(rutaImagen);

                InsertarBebida(Nombre, precio, imagenBytes, codigo_Barras, TipoBebida);
            }
            if (opcion == 2)
            {
                string Nombre = txtNom_Produc.Text;
                decimal precio = decimal.Parse(txtPrecio.Text);
                string rutaImagen = txtURL.Text;
                string TipoComida = cmbProducto.Text;
                byte[] imagenBytes = Utilidades.ConvertirImagenABinario(rutaImagen);

                InsertarComida(Nombre, precio, imagenBytes, TipoComida);

            }

            LimpiarCampos();
        }

        private void InsertarBebida(string nombre, decimal precio, byte[] imagen, string codigoBarras, string tipo_bebida)
        {
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    if (conexion.State == ConnectionState.Open)
                    {
                        string consulta = "INSERT INTO Bebidas (nombre_beb, precio_beb, codigodebarras_beb, Imagen, id_tipo_beb) " +
                                         "VALUES (@Nombre, @Precio, @CodigoBarras, @Imagen, " +
                                         "(SELECT idtipo_bebida FROM tipo_bebida WHERE tipo_bebida = @tipo_bebida))";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nombre);
                            comando.Parameters.AddWithValue("@Precio", precio);
                            comando.Parameters.AddWithValue("@CodigoBarras", codigoBarras);
                            comando.Parameters.AddWithValue("@Imagen", imagen);
                            comando.Parameters.AddWithValue("@tipo_bebida", tipo_bebida);

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Bebida insertada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarCampos();
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

        private void comboBoxBebida()
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

                    string consulta = "SELECT tipo_bebida FROM tipo_bebida";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbProducto.Items.Add(reader["tipo_bebida"].ToString());
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

        private void InsertarComida(string nombre, decimal precio, byte[] imagen, string tipo_comida)
        {
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    if (conexion.State == ConnectionState.Open)
                    {
                        string consulta = "INSERT INTO comida (nombre_com, precio_com, imagen_com, id_tipo_com) " +
                                         "VALUES (@Nombre, @Precio, @Imagen, " +
                                         "(SELECT idtipo_comida FROM tipo_comida WHERE tipo_comida = @tipo_comida))";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@Nombre", nombre);
                            comando.Parameters.AddWithValue("@Precio", precio);

                            comando.Parameters.AddWithValue("@Imagen", imagen);
                            comando.Parameters.AddWithValue("@tipo_comida", tipo_comida);

                            comando.ExecuteNonQuery();

                            MessageBox.Show($"Comida {tipo_comida} insertada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LimpiarCampos();
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

        private void LimpiarCampos()
        {
            txtNom_Produc.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txt_Codigo_ba.Text = string.Empty;
            txtURL.Text = string.Empty;
            pictureBox1.Image = null;
            cmbProducto.Text = string.Empty;
        }

        private void comboBoxComida()
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

                    string consulta = "SELECT tipo_comida FROM tipo_comida";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbProducto.Items.Add(reader["tipo_comida"].ToString());
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

        private void pictureBoxPDF_Click(object sender, EventArgs e)
        {
            Utilidades.ReproducirSonido();

            string rutaPDF = "C:\\Users\\Usuario\\Desktop\\Administracion_ETRAY\\Resources\\PDF\\PaginaInicio.pdf";

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

     
    }
}
