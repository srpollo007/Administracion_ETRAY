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
  
    public partial class OcultarProducto : Form
    {
        int opcion;
        private int idSeleccionado;

        public OcultarProducto(int opcionEntrada)
        {
            InitializeComponent();
            this.opcion = opcionEntrada;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            int ID = int.Parse(txtID.Text);
            CambiarDisponible(ID);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            CambiarNoDisponible(ID);
        }

        private void OcultarProducto_Load(object sender, EventArgs e)
        {
            if (opcion == 1)
            {
                lblNombreProducto.Text = "Bebida";

                CargarDataviewgrid();


            }
            if (opcion == 2)
            {
                lblNombreProducto.Text = "Comida";
                CargarDataviewgrid();
            }
        }

        private void CargarDataviewgrid()
        {
            LLENARDATAVIEWGRIDstock();
            LLENARDATAVIEWGRIDSin();
        }

        private void LLENARDATAVIEWGRIDstock()
        {
            if (opcion == 1)
            {
                try
                {
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "SELECT idbebidas, nombre_beb AS Nombre FROM bebidas WHERE stock = 1";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                DataTable tabla = new DataTable();
                                tabla.Load(reader);


                                DataCon.DataSource = tabla;
                                DataCon.Columns["idbebidas"].Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        string consulta = "SELECT idcomida, nombre_com AS Nombre FROM comida WHERE stock = 1";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                DataTable tabla = new DataTable();
                                tabla.Load(reader);


                                DataCon.DataSource = tabla;
                                DataCon.Columns["idcomida"].Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }


        private void LLENARDATAVIEWGRIDSin()
        {
            if (opcion == 1)
            {
                try
                {
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "SELECT idbebidas, nombre_beb AS Nombre FROM bebidas WHERE stock = 0";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                DataTable tabla = new DataTable();
                                tabla.Load(reader);


                                DataSin.DataSource = tabla;
                                DataSin.Columns["idbebidas"].Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        string consulta = "SELECT idcomida, nombre_com AS Nombre FROM comida WHERE stock = 0";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            using (MySqlDataReader reader = comando.ExecuteReader())
                            {
                                DataTable tabla = new DataTable();
                                tabla.Load(reader);


                                DataSin.DataSource = tabla;
                                DataSin.Columns["idcomida"].Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al llenar la DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

           
        }

        private void CambiarDisponible(int ID)
        {
            if (opcion == 1)
            {
                try
                {
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE bebidas SET stock = 1 WHERE idbebidas = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                           
                            comando.Parameters.AddWithValue("@ID", ID);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Producto actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarDataviewgrid();
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
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE comida SET stock = 1 WHERE idcomida = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {

                            comando.Parameters.AddWithValue("@ID", ID);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Producto actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarDataviewgrid();
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

        private void CambiarNoDisponible(int ID)
        {
            if (opcion == 1)
            {
                try
                {
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE bebidas SET stock = 0 WHERE idbebidas = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {

                            comando.Parameters.AddWithValue("@ID", ID);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Producto actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarDataviewgrid();
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
                    string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                    using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                    {
                        conexion.Open();

                        string consulta = "UPDATE comida SET stock = 1 WHERE idcomida = @ID";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {

                            comando.Parameters.AddWithValue("@ID", ID);

                            int filasActualizadas = comando.ExecuteNonQuery();

                            if (filasActualizadas > 0)
                            {
                                MessageBox.Show("Producto actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarDataviewgrid();
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
           
        
    }
}
