using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Administracion_ETRAY
{
    public partial class Tablets : Form
    {
        public Tablets()
        {
            InitializeComponent();
            LLENARDATAVIEWGRIDTablets();
        }


        private void LLENARDATAVIEWGRIDTablets()
        {

            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "SELECT idtablets, mac FROM tablets";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);


                            DataTablets.DataSource = tabla;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtMac.Text =string.Empty;
        
        }
        private void InsertarTablets(string MAC)
        {
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    if (conexion.State == ConnectionState.Open)
                    {
                        string consulta = "INSERT INTO tablets (mac) VALUES (@MAC) ";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            comando.Parameters.AddWithValue("@MAC", MAC);
                           ;

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Tablet insertada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LLENARDATAVIEWGRIDTablets();
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
                        MessageBox.Show("Error: Tablets con esta MAC ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Mac = txtMac.Text;

            InsertarTablets(Mac);
        }



    }
}
