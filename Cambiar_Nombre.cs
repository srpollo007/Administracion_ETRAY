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

namespace Administracion_ETRAY
{
    public partial class Cambiar_Nombre : Form
    {
        public Cambiar_Nombre()
        {
            InitializeComponent();
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

        privare
    }
}
