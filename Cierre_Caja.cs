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
    public partial class Cierre_Caja : Form
    {
        public Cierre_Caja()
        {
            InitializeComponent();
        }

        private void btnCierre_Click(object sender, EventArgs e)
        {
            try
            {
                if (HayMesasAbiertas())
                {
                    MessageBox.Show("Hay mesas sin cerrar. Por favor, cierre todas las mesas antes de finalizar el día.", "Mesas abiertas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal totalDiario = CalcularTotalDiario();
                    int mesasAtendidas = ContarMesasAtendidas();
                    decimal mediaTotal = mesasAtendidas > 0 ? totalDiario / mesasAtendidas : 0;
                    decimal mediaTicketsDiarios = CalcularMediaMesasAtendidasDiarias();  // Nueva función para calcular la media de tickets diarios


                    txtTotal.Text = totalDiario.ToString("C2");
                    txtMesasAtendidas.Text = mesasAtendidas.ToString();
                    txtMediaTotal.Text = CalcularMediaTotalDiaria().ToString("C2");
                    txtMediaAtendidas.Text = mediaTicketsDiarios.ToString(); // Mostrar la media de tickets diarios

                    MessageBox.Show("Cierre diario completado con éxito.", "Cierre completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el cierre diario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool HayMesasAbiertas()
        {
            return EjecutarConsultaScalar("SELECT COUNT(*) FROM ticket WHERE pagado = 0 AND fecha_hora >= CURDATE()") > 0;
        }

        private decimal CalcularTotalDiario()
        {
            object resultado = EjecutarConsultaScalar("SELECT SUM(total) FROM ticket WHERE pagado = 1 AND fecha_hora >= CURDATE()");
            return resultado != DBNull.Value && resultado != null ? Convert.ToDecimal(resultado) : 0;
        }

        private decimal CalcularMediaTotalDiaria()
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                // Consulta que calcula el promedio de los totales diarios
                string consulta = @"
                SELECT AVG(daily_total) AS average_daily_total
                FROM (
                    SELECT DATE(fecha_hora) AS day, SUM(total) AS daily_total
                    FROM ticket
                    WHERE pagado = 1
                    GROUP BY DATE(fecha_hora)
                ) AS daily_totals";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    object resultado = comando.ExecuteScalar();
                    return resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;
                }
            }
        }


        private int ContarMesasAtendidas()
        {
            return EjecutarConsultaScalar("SELECT COUNT(*) FROM ticket WHERE pagado = 1 AND fecha_hora >= CURDATE()");
        }

        private int EjecutarConsultaScalar(string consulta)
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }

        private decimal CalcularMediaMesasAtendidasDiarias()
        {
            string cadenaConexion = Utilidades.ObtenerCadenaConexionDesdeXML();
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                string consulta = @"
                    SELECT AVG(daily_tickets) AS average_daily_tickets
                    FROM (
                        SELECT DATE(fecha_hora) AS day, COUNT(*) AS daily_tickets
                        FROM ticket
                        WHERE pagado = 1
                        GROUP BY DATE(fecha_hora)
                    ) AS daily_ticket_counts";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    object resultado = comando.ExecuteScalar();
                    // Convierte el resultado a decimal y redondea a 0 decimales si deseas eliminar la parte fraccionaria
                    decimal average = resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;
                    return Math.Round(average, 0); // Redondea al entero más cercano
                }
            }
        }


    }
}
