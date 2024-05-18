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
    public partial class Mesas : Form
    {
        public Mesas()
        {
            InitializeComponent();
            LLENARDATAVIEWGRIDTablets();
            LLENARDATAVIEWGRIDMesa();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int Mesa = Convert.ToInt16(TxtMesa.Text);
            int Tablet = Convert.ToInt16(txtTablet.Text);
            ActualizarMesaTablet(Tablet, Mesa);



        }

        private void LLENARDATAVIEWGRIDTablets()
        {
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // Ajusta la consulta para hacer un JOIN con la tabla `mesa` y obtener el número de mesa
                    string consulta = @"
                        SELECT 
                            t.idtablets AS Tablet, 
                            COALESCE(m.numero_mesa, 'Sin Mesa') AS Mesa 
                        FROM tablets t
                        LEFT JOIN mesa m ON t.idmesa = m.idmesa
                        ORDER BY t.idtablets";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);

                            DataTablets.DataSource = tabla; // Asume que DataTablets es tu DataGridView
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LLENARDATAVIEWGRIDMesa()
        {
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = @"
                        SELECT m.numero_mesa AS MESA, IFNULL(t.idtablets, 'Sin Mesa') AS Tablet
                        FROM mesa m
                        LEFT JOIN tablets t ON m.idmesa = t.idmesa 
                        ORDER BY m.numero_mesa ";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);
                            DataMesa.DataSource = tabla;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ActualizarMesaTablet(int idTablets, int numeroMesa)
        {
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    if (conexion.State == ConnectionState.Open)
                    {
                        // Actualización en la tabla tablets utilizando una subconsulta para obtener el idmesa
                        string consultaActualizacion = @"
                            UPDATE tablets 
                            SET idmesa = (SELECT idmesa FROM mesa WHERE numero_mesa = @NumeroMesa)
                            WHERE idtablets = @IdTablets;";

                        using (MySqlCommand comandoActualizar = new MySqlCommand(consultaActualizacion, conexion))
                        {
                            comandoActualizar.Parameters.AddWithValue("@NumeroMesa", numeroMesa);
                            comandoActualizar.Parameters.AddWithValue("@IdTablets", idTablets);
                            int filasAfectadas = comandoActualizar.ExecuteNonQuery();
                            if (filasAfectadas > 0)
                            {
                                LLENARDATAVIEWGRIDMesa();
                                LLENARDATAVIEWGRIDTablets();

                                MessageBox.Show("Tablet actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la tablet especificada para actualizar o el número de mesa no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                MessageBox.Show($"Error MySQL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general al actualizar la tablet en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
