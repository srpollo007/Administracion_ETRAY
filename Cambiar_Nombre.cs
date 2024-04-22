using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Administracion_ETRAY
{
    public partial class Cambiar_Nombre : Form
    {
        public int opcion = 0;

        public Cambiar_Nombre(int opcionEntrada)
        {
            InitializeComponent();
            this.opcion = opcionEntrada;
        }


        private void LLENARDATAVIEWGRIDBebida()
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

                    string consulta = "SELECT idcomida, nombre_com FROM comida";

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

        private void Cambiar_Nombre_Load(object sender, EventArgs e)
        {
            if(opcion == 1)
            {
                LLENARDATAVIEWGRIDBebida();
                txtNombre.Enabled = false;
                textBox1.Visible = false;
            }
            if(opcion == 2)
            {
                LLENARDATAVIEWGRIDComida();
                txtNombre.Enabled = false;
                textBox1.Visible = false;
            }
        }    
        private void button1_Click(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                try
                {
                    string nuevoNombre = txtNuevoNombre.Text;

                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE bebidas SET nombre_beb =@NuevoNombre WHERE idbebidas = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                            comando.Parameters.AddWithValue("@ID", textBox1.Text);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Se actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (opcion == 2)
            {
                try
                {
                    string nuevoNombre = txtNuevoNombre.Text;


                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE comida SET nombre_com =@NuevoNombre WHERE idcomida = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@NuevoNombre", nuevoNombre);
                            comando.Parameters.AddWithValue("@ID", textBox1.Text);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Se actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (opcion == 1)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string nombre = dataGridView1.Rows[e.RowIndex].Cells["nombre_beb"].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells["idbebidas"].Value.ToString();
                    txtNombre.Text = nombre;
                    
                    textBox1.Text = id;
                }

            }
            if (opcion == 2)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    string nombre = dataGridView1.Rows[e.RowIndex].Cells["nombre_com"].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells["idcomida"].Value.ToString();

                    txtNombre.Text = nombre;
                    textBox1.Text = id;
                }
            }

        }
    
    
    
    
    
    
    
    }

}
