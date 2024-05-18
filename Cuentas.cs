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
    public partial class Cuentas : Form
    {
        public Cuentas()
        {
            InitializeComponent();
            this.DataMesa.SelectionChanged += new System.EventHandler(this.DataMesa_SelectionChanged);
            this.DataMesa.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(this.DataMesa_DataBindingComplete);

            CargarMesasNoCerradas();
            ConfigurarEstilosDataGridView();


        }

        private void ConfigurarEstilosDataGridView()
        {
            // Configuraciones de estilo para DataMesa
           
            DataMesa.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            DataMesa.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataMesa.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Aumentar la fuente de las cabeceras
            DataMesa.DefaultCellStyle.Font = new Font("Segoe UI", 12); // Aumentar la fuente del cuerpo
            DataMesa.RowTemplate.Height = 40; // Aumentar la altura de las filas
            DataMesa.EnableHeadersVisualStyles = false;
            DataMesa.DefaultCellStyle.SelectionBackColor = Color.Orange;
            DataMesa.DefaultCellStyle.SelectionForeColor = Color.White;
            DataMesa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataMesa.AutoResizeColumns(); // Ajustar automáticamente el tamaño de las columnas según su contenido

            // Configuraciones de estilo para DataCuenta
            DataCuenta.RowHeadersVisible = false;
            DataCuenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataCuenta.MultiSelect = false; 
            DataCuenta.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            DataCuenta.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataCuenta.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Aumentar la fuente de las cabeceras
            DataCuenta.DefaultCellStyle.Font = new Font("Segoe UI", 12); // Aumentar la fuente del cuerpo
            DataCuenta.RowTemplate.Height = 40; // Aumentar la altura de las filas
            DataCuenta.EnableHeadersVisualStyles = false;
            DataCuenta.DefaultCellStyle.SelectionBackColor = Color.Orange;
            DataCuenta.DefaultCellStyle.SelectionForeColor = Color.White;
            DataCuenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataCuenta.AutoResizeColumns(); // Ajustar automáticamente el tamaño de las columnas según su contenido
        }

        private void DataMesa_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Selecciona automáticamente la primera fila después de que los datos se carguen
            if (DataMesa.Rows.Count > 0)
            {
                DataMesa.Rows[0].Selected = true;
                int idMesa = Convert.ToInt32(DataMesa.Rows[0].Cells["idMesa"].Value);
                CargarDetallesTicketsNoPagados(idMesa);
            }
        }

        private void CargarDetallesTicketsNoPagados(int idMesa)
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                string query = @"
            SELECT 
                td.idticket_detalle AS IdTicketDetalle,
                t.idticket AS IdTicket,
                COALESCE(b.nombre_beb, c.nombre_com) AS NombreProducto,
                td.cantidad AS Cantidad,
                td.precio_unitario AS PrecioUnitario,
                (td.precio_unitario * td.cantidad) AS TotalProducto
            FROM etray.ticket t  
            INNER JOIN etray.ticket_detalle td ON t.idticket = td.idticket
            LEFT JOIN etray.bebidas b ON td.idproducto = b.idbebidas AND td.es_bebida = 1
            LEFT JOIN etray.comida c ON td.idproducto = c.idcomida AND td.es_bebida = 0
            WHERE t.pagado = 0 AND t.idmesa = @IdMesa;";

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdMesa", idMesa);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        decimal totalCuenta = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            if (int.TryParse(row["Cantidad"].ToString(), out int cantidad))
                            {
                                totalCuenta += cantidad * Convert.ToDecimal(row["PrecioUnitario"]);
                            }
                        }

                        DataRow totalRow = dt.NewRow();
                        totalRow["NombreProducto"] = "Total";
                        totalRow["Cantidad"] = DBNull.Value;
                        totalRow["PrecioUnitario"] = DBNull.Value;
                        totalRow["TotalProducto"] = totalCuenta;
                        dt.Rows.Add(totalRow);

                        DataCuenta.DataSource = dt;
                        DataCuenta.Columns["IdTicket"].Visible = false;
                        DataCuenta.Columns["IdTicketDetalle"].Visible = false;
                        DataCuenta.Columns["NombreProducto"].ReadOnly = true;
                        DataCuenta.Columns["PrecioUnitario"].ReadOnly = true;
                        DataCuenta.Columns["TotalProducto"].ReadOnly = true;
                    }
                }
            }
        }
        private void GuardarCambiosEnLaBaseDeDatos()
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                foreach (DataGridViewRow row in DataCuenta.Rows)
                {
                    if (!row.IsNewRow && row.Cells["NombreProducto"].Value.ToString() != "Total")
                    {
                        using (MySqlCommand comando = new MySqlCommand("UPDATE ticket_detalle SET cantidad = @Cantidad WHERE idticket_detalle = @IdTicketDetalle", conexion))
                        {
                            comando.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(row.Cells["Cantidad"].Value));
                            comando.Parameters.AddWithValue("@IdTicketDetalle", Convert.ToInt32(row.Cells["IdTicketDetalle"].Value));
                            comando.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        private void CargarMesasNoCerradas()
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                if (conexion.State == ConnectionState.Open)
                {
                    string query = @"SELECT m.idmesa, m.numero_mesa
                             FROM mesa m
                             JOIN ticket t ON m.idmesa = t.idmesa
                             WHERE t.pagado = 0";  // Asumiendo que 'pagado' es un campo en 'ticket'

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            DataMesa.DataSource = dt;
                            DataMesa.Columns["numero_mesa"].HeaderText = "Mesas";
                            DataMesa.Columns["idmesa"].Visible = false; // Oculta la columna idmesa pero mantiene los datos accesibles

                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo conectar a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RecargarDataCuenta()
        {
            if (DataMesa.SelectedRows.Count > 0)
            {
                int idMesa = Convert.ToInt32(DataMesa.SelectedRows[0].Cells["idMesa"].Value);
                CargarDetallesTicketsNoPagados(idMesa);
            }
            else
            {
                MessageBox.Show("Seleccione una mesa para cargar los detalles de los tickets no pagados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void MarcarComoPagado(int idTicket)
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "UPDATE etray.ticket SET pagado = 1 WHERE idticket = @IdTicket";

                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@IdTicket", idTicket);
                        int result = comando.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("El ticket ha sido marcado como pagado.", "Pago registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el ticket para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al marcar el ticket como pagado: " + ex.Message, "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ActualizarTotalTicket(int idTicket)
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            decimal totalTicket = 0;

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                // Primero, calcular el nuevo total del ticket
                string consultaTotal = @"
                SELECT SUM(precio_unitario * cantidad) AS Total
                FROM ticket_detalle
                WHERE idticket = @IdTicket";

                using (MySqlCommand comandoTotal = new MySqlCommand(consultaTotal, conexion))
                {
                    comandoTotal.Parameters.AddWithValue("@IdTicket", idTicket);
                    object resultado = comandoTotal.ExecuteScalar();
                    if (resultado != DBNull.Value)
                    {
                        totalTicket = Convert.ToDecimal(resultado);
                    }
                }

                // Luego, actualizar el total en la tabla ticket
                string consultaActualizar = "UPDATE ticket SET total = @Total WHERE idticket = @IdTicket";
                using (MySqlCommand comandoActualizar = new MySqlCommand(consultaActualizar, conexion))
                {
                    comandoActualizar.Parameters.AddWithValue("@Total", totalTicket);
                    comandoActualizar.Parameters.AddWithValue("@IdTicket", idTicket);
                    comandoActualizar.ExecuteNonQuery();
                }
            }

            // Opcionalmente, mostrar una confirmación o actualizar la UI
            MessageBox.Show($"El total del ticket {idTicket} ha sido actualizado a {totalTicket:C}.", "Total Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        #region Botones Menu


        private void btnMesas_Click(object sender, EventArgs e)
        {
            CargarMesasNoCerradas();
        }
        private void DataMesa_SelectionChanged(object sender, EventArgs e)
        {
            if (DataMesa.SelectedRows.Count > 0) // Asegúrate de que hay una fila seleccionada
            {
                int idMesa = Convert.ToInt32(DataMesa.SelectedRows[0].Cells["idMesa"].Value); // Asume que el nombre de la columna en DataMesa que contiene el id de la mesa es 'idMesa'
               

                CargarDetallesTicketsNoPagados(idMesa);
               
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarCambiosEnLaBaseDeDatos();
                if (DataCuenta.SelectedRows.Count > 0 && DataCuenta.SelectedRows[0].Cells["IdTicket"].Value != DBNull.Value)
                {
                    int idTicket = Convert.ToInt32(DataCuenta.SelectedRows[0].Cells["IdTicket"].Value);
                    ActualizarTotalTicket(idTicket);
                }
                RecargarDataCuenta();
                MessageBox.Show("Cambios guardados exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (DataCuenta.SelectedRows.Count > 0 && DataCuenta.SelectedRows[0].Cells["IdTicket"].Value != DBNull.Value)
            {
                int idTicket = Convert.ToInt32(DataCuenta.SelectedRows[0].Cells["IdTicket"].Value);
                MarcarComoPagado(idTicket);

                // Recargar las mesas y detalles para reflejar los cambios
                CargarMesasNoCerradas();
                if (DataMesa.Rows.Count > 0)
                {
                    DataMesa.Rows[0].Selected = true;
                }
                else
                {
                    DataCuenta.DataSource = null; // Limpiar detalles si no hay más mesas con pagos pendientes
                }
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para proceder con el pago.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion




    }
}
