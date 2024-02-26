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

        public Cambiar_Precio()
        {
            InitializeComponent();
            LLENARDATAVIEWGRID();
            pictureBoxPDF.MouseEnter += (sender, e) => Utilidades.PictureBox_MouseEnter(pictureBoxPDF, sender, e);
            pictureBoxPDF.MouseLeave += (sender, e) => Utilidades.PictureBox_MouseLeave(pictureBoxPDF, sender, e);
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void pictureBoxPDF_Click(object sender, EventArgs e)
        {
            string rutaPDF = "C:\\Users\\asix\\Desktop\\Administracion_ETRAY\\Image\\service-bell-ring-14610.mp3";
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

        private void LLENARDATAVIEWGRID()
        {
            try
            {
                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "SELECT ID, Nombre, Precio FROM bar.bebidas";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            tabla.Load(reader);

                            // Configura la columna de ID como no visible
                            dataGridView1.DataSource = tabla;
                            dataGridView1.Columns["ID"].Visible = false;
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
            try
            {
                decimal nuevoPrecio = decimal.Parse(txtNewPrecio.Text);

                string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();

                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "UPDATE bar.bebidas SET Precio =@NuevoPrecio WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@NuevoPrecio", nuevoPrecio);
                        comando.Parameters.AddWithValue("@ID", textBox1.Text);

                        int filasActualizadas = comando.ExecuteNonQuery();

                        if (filasActualizadas > 0)
                        {
                            MessageBox.Show("Precio actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LLENARDATAVIEWGRID();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string nombre = dataGridView1.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string precio = dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                txtNombre.Text = nombre;
                txtPrecio.Text = precio;
                textBox1.Text = id;
            }
        }
    }
}
