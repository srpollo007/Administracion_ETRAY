using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Administracion_ETRAY
{
    public partial class Cambiar_Precio : Form
    {
        private int idSeleccionado;
        int opcion;

        public Cambiar_Precio(int opcionEntrada)
        {
            InitializeComponent();
           
            pictureBoxPDF.MouseEnter += (sender, e) => Utilidades.PictureBox_MouseEnter(pictureBoxPDF, sender, e);
            pictureBoxPDF.MouseLeave += (sender, e) => Utilidades.PictureBox_MouseLeave(pictureBoxPDF, sender, e);
            dataGridView1.CellClick += dataGridView1_CellClick;
         

            this.opcion = opcionEntrada;
            
        }

        private void Cambiar_Precio_Load_1(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                label2.Text = "Nombre Bebida";
                label1.Text = "Cambiar Precio Bebida";
                // llamada a la función de coger datos de Database de Bebidas
                LLENARDATAVIEWGRIDBebida();


            }
            if (opcion == 2)
            {
                label2.Text = "Nombre Comida";
                label1.Text = "Cambiar Precio Comida";
                LLENARDATAVIEWGRIDComida();
            }
        }
     
        private void pictureBoxPDF_Click(object sender, EventArgs e)
        {
            string rutaPDF = "..\\service-bell-ring-14610.mp3";
            AbrirArchivoPDF(rutaPDF);
        }

        private void AbrirArchivoPDF(string rutaPDF)
        {
            try
            {
                if (!File.Exists(rutaPDF))
                {
                    MessageBox.Show("El archivo PDF no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Process.Start(rutaPDF);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LLENARDATAVIEWGRIDBebida()
        {
          
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "SELECT idbebidas, nombre_beb, precio_beb FROM bebidas";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);

                            
                            dataGridView1.DataSource = tabla;
                            dataGridView1.Columns["idbebidas"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LLENARDATAVIEWGRIDComida()
        {

            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "SELECT idcomida, nombre_com, precio_com FROM comida";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);


                            dataGridView1.DataSource = tabla;
                            dataGridView1.Columns["idcomida"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
                if(opcion == 1)
            {
                try
                {
                    decimal nuevoPrecio = decimal.Parse(txtNewPrecio.Text);

                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE bebidas SET precio_beb =@NuevoPrecio WHERE idbebidas = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@NuevoPrecio", nuevoPrecio);
                            comando.Parameters.AddWithValue("@ID", textBox1.Text);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Precio actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LLENARDATAVIEWGRIDBebida();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el precio en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           if(opcion == 2)
           {
                try
                {
                    decimal nuevoPrecio = decimal.Parse(txtNewPrecio.Text);

                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE comida SET precio_com =@NuevoPrecio WHERE idcomida = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@NuevoPrecio", nuevoPrecio);
                            comando.Parameters.AddWithValue("@ID", textBox1.Text);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Precio actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LLENARDATAVIEWGRIDComida();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el precio en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(opcion == 1)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string nombre = dataGridView1.Rows[e.RowIndex].Cells["nombre_beb"].Value.ToString();
                    string precio = dataGridView1.Rows[e.RowIndex].Cells["precio_beb"].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells["idbebidas"].Value.ToString();

                    txtNombre.Text = nombre;
                    txtPrecio.Text = precio;
                    textBox1.Text = id;
                }

            }
            if (opcion == 2)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string nombre = dataGridView1.Rows[e.RowIndex].Cells["nombre_com"].Value.ToString();
                    string precio = dataGridView1.Rows[e.RowIndex].Cells["precio_com"].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells["idcomida"].Value.ToString();

                    txtNombre.Text = nombre;
                    txtPrecio.Text = precio;
                    textBox1.Text = id;
                }
            }
          
        }

      
    }
}
