using SistemaFinal.Capa_Logica;
using SistemaFinal.Capa_Presentacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemaFinal.Capa_Datos
{
    internal class CajaD
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public bool CajaInicialExistente(string fecha)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM InicioCaja WHERE Fecha = @Fecha";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public void GuardarMontoInicial(string fecha, decimal montoInicial)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO InicioCaja (Fecha, Monto) VALUES (@Fecha, @MontoInicial)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@MontoInicial", montoInicial);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string MontoInicio(string fecha)
        {
            string monto = "0";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Monto FROM InicioCaja WHERE Fecha = @Fecha";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    var result = cmd.ExecuteScalar();

                    if(result != null && result != DBNull.Value)
{
                        monto = result.ToString();
                    }
                    return monto;
                }
            }
        }
        public string VentasEfect(string fechaActual)
        {

            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Total) 
                FROM Ventas 
                WHERE Metodo = 'Efectivo' 
                AND Anulada = 1 
                AND DATE(FechaHora) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }


            return totalEfectivo.ToString("F2");
        }
        public string OtrosEfect(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Ingreso) 
                FROM Ingresos 
                WHERE Metodo = 'Efectivo'
                AND Metodo_CC = 'Otros'
                AND DATE(Fecha) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }
        public string CCEfect(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Ingreso) 
                FROM Ingresos 
                WHERE Metodo = 'Cuenta Corriente'
                AND Metodo_CC = 'Efectivo'
                AND DATE(Fecha) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }
        public string VentasTarj(string fechaActual)
        {

            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Total) 
                FROM Ventas 
                WHERE Metodo = 'Tarjeta' 
                AND Anulada = 1 
                AND DATE(FechaHora) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }


            return totalEfectivo.ToString("F2");
        }
        public string OtrosTarj(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Ingreso) 
                FROM Ingresos 
                WHERE Metodo = 'Tarjeta'
                AND Metodo_CC = 'Otros'
                AND DATE(Fecha) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }
        public string EgresoOtrosTarj(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Egreso) 
                FROM Egresos 
                WHERE Metodo = 'Tarjeta'
                AND DATE(Fecha) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }
        public string CCTarj(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Ingreso) 
                FROM Ingresos 
                WHERE Metodo = 'Cuenta Corriente' 
                AND Metodo_CC = 'Tarjeta'
                AND DATE(Fecha) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }
        public string PagosVendEfect(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Egreso) 
                FROM Egresos 
                WHERE Metodo = 'Efectivo'
                AND Detalle = 'Pago Vendedor'
                AND DATE(Fecha) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }
        public string RetiroOtrosEfect(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Egreso) 
                FROM Egresos 
                WHERE Metodo = 'Efectivo' 
                AND DATE(Fecha) = DATE(@Fecha)
                AND Detalle NOT IN('Pago Vendedor', 'Pago Proveedor')";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }
        public string PagosVendTarj(string fechaActual)
        {
            decimal totalEfectivo = 0;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT SUM(Egreso) 
                FROM Egresos 
                WHERE Metodo = 'Tarjeta'
                AND Detalle = 'Pago Vendedor'
                AND DATE(Fecha) = DATE(@Fecha)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);

                    var result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalEfectivo = Convert.ToDecimal(result);
                    }
                }
            }
            return totalEfectivo.ToString("F2");
        }

        public void GuardarIngreso(string fecha, decimal ingreso, string formapago)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Ingresos (Fecha, Ingreso, Metodo, Metodo_CC) VALUES (@Fecha, @Ingreso, @Metodo, @Metodo_CC)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Ingreso", ingreso);
                    cmd.Parameters.AddWithValue("@Metodo", formapago);
                    cmd.Parameters.AddWithValue("@Metodo_CC", "Otros");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void PagoCC(string fecha, decimal ingreso, string formapago)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Ingresos (Fecha, Ingreso, Metodo, Metodo_CC) VALUES (@Fecha, @Ingreso, @Metodo, @Metodo_CC)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Ingreso", ingreso);
                    cmd.Parameters.AddWithValue("@Metodo_CC", formapago);
                    cmd.Parameters.AddWithValue("@Metodo", "Cuenta Corriente");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void GuardarGasto(string fecha, decimal ingreso, string formapago, string detalle)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Egresos (Fecha, Egreso, Metodo, Detalle) VALUES (@Fecha, @Ingreso, @Metodo, @Detalle)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Ingreso", ingreso);
                    cmd.Parameters.AddWithValue("@Metodo", formapago);
                    cmd.Parameters.AddWithValue("@Detalle", detalle);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void GuardarRetiro(string fecha, decimal ingreso)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Egresos (Fecha, Egreso, Metodo, Detalle) VALUES (@Fecha, @Egreso, @Metodo, @Detalles)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Egreso", ingreso);
                    cmd.Parameters.AddWithValue("@Metodo", "Efectivo");
                    cmd.Parameters.AddWithValue("@Detalles", "Retiro");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void CierreCaja(string fecha, decimal totalEfect, decimal totalTarj, decimal totalDia, decimal cierre, decimal inicio)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Si ya existe registro para esa fecha (por ejemplo, tras una reapertura), lo actualizamos; si no, lo insertamos.
                string checkQuery = "SELECT COUNT(*) FROM Caja_Diaria WHERE Fecha = @Fecha";
                int existe;
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Fecha", fecha);
                    existe = Convert.ToInt32(checkCmd.ExecuteScalar());
                }

                string query = existe > 0
                    ? @"UPDATE Caja_Diaria
                SET Efectivo = @Efectivo,
                    Tarjeta = @Tarjeta,
                    Total = @Dia,
                    Cierre = @Cierre,
                    CajaInicio = @Inicio,
                    Estado = 'Cerrada'
                WHERE Fecha = @Fecha"
                    : @"INSERT INTO Caja_Diaria (Fecha, Efectivo, Tarjeta, Total, Cierre, CajaInicio, Estado)
                VALUES (@Fecha, @Efectivo, @Tarjeta, @Dia, @Cierre, @Inicio, 'Cerrada')";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Efectivo", totalEfect);
                    cmd.Parameters.AddWithValue("@Tarjeta", totalTarj);
                    cmd.Parameters.AddWithValue("@Dia", totalDia);
                    cmd.Parameters.AddWithValue("@Cierre", cierre);
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void GuardarVentaTarjeta(int NumFact, string tarjeta)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO VentasTarjeta (NumFact, Tarjeta) VALUES (@Fact, @Tarjeta)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fact", NumFact);
                    cmd.Parameters.AddWithValue("@Tarjeta", tarjeta);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ModMontoInicio(string montoNuevo)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE InicioCaja SET Monto = @Monto ";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Monto", decimal.Parse(montoNuevo));
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void NotifiCaja(string CajaInicio, string CajaNueva)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                string query = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                   
                    cmd.Parameters.AddWithValue("@Tema", "Caja");
                    cmd.Parameters.AddWithValue("@Titulo", "Caja Modificada");
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Desc", $"El usuario {SesionActual.NombreCompleto} ha modificado la caja inicial. El monto era: ${CajaInicio}. Y cambió a: ${CajaNueva}");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ReabrirCaja(string fecha, string motivo = "Emergencia / salida de empleado")
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Caja_Diaria SET Estado = 'Abierta' WHERE Fecha = @Fecha";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.ExecuteNonQuery();
                }
            }

            NotifiReaperturaCaja(fecha, motivo);
        }
        public void NotifiReaperturaCaja(string fecha, string motivo)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    cmd.Parameters.AddWithValue("@Tema", "Caja");
                    cmd.Parameters.AddWithValue("@Titulo", "Reapertura de Caja");
                    cmd.Parameters.AddWithValue("@Fecha", fechaActual);
                    cmd.Parameters.AddWithValue("@Desc", $"El usuario {SesionActual.NombreCompleto} reabrió la caja de la fecha {fecha}. Motivo: {motivo}.");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CajaCerrada(string fecha)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Estado FROM Caja_Diaria WHERE Fecha = @Fecha ORDER BY ID DESC LIMIT 1";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    var result = cmd.ExecuteScalar();
                    return result != null && result.ToString().Equals("Cerrada", StringComparison.OrdinalIgnoreCase);
                }
            }
        }
        public void NotifiCierreCaja(decimal totalEfect, decimal totalTarj, decimal totalDia, decimal Cierre, decimal Inicio)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    cmd.Parameters.AddWithValue("@Tema", "Caja");
                    cmd.Parameters.AddWithValue("@Titulo", "Cierre de Caja");
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Desc", $"El usuario {SesionActual.NombreCompleto} realizó el cierre de caja. Monto inicial: {Inicio}. Tarjeta: ${totalTarj}, Efectivo: ${totalEfect}, Total día: ${totalDia}. Efectivo al cierre: ${Cierre}.");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public void NotifiRetiro(decimal monto)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    cmd.Parameters.AddWithValue("@Tema", "Caja");
                    cmd.Parameters.AddWithValue("@Titulo", "Retiro de caja");
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Desc", $"El usuario {SesionActual.NombreCompleto} hizo un retiro de: ${monto}.");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void NotifiGasto(decimal monto, string formapago, string detalle)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); 
                    cmd.Parameters.AddWithValue("@Tema", "Gasto");
                    cmd.Parameters.AddWithValue("@Titulo", "Gasto en caja");
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Desc", $"El usuario {SesionActual.NombreCompleto} hizo un gasto de: ${monto} en la caja, se realizó con {formapago} y fue para {detalle}.");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void NotifiIngreso(decimal monto, string formapago)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    cmd.Parameters.AddWithValue("@Tema", "Caja");
                    cmd.Parameters.AddWithValue("@Titulo", "Ingreso en caja");
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Desc", $"El usuario {SesionActual.NombreCompleto} hizo un ingreso de: ${monto} en la caja, se realizó con {formapago}.");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void NotifiPagoVend(decimal pago, string formapago, string vendedor)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    cmd.Parameters.AddWithValue("@Tema", "Pagos");
                    cmd.Parameters.AddWithValue("@Titulo", "Pago a vendedor");
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Desc", $"El usuario {SesionActual.NombreCompleto} le ha pagado ${pago} a {vendedor}. El pago se realizó con {formapago}");
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void GuardarPago(decimal pago, string formapago, string vendedor)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Egresos (Fecha, Egreso, Metodo, Detalle) VALUES (@Fecha, @Egreso, @Metodo, @Detalle)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Egreso", pago);
                    cmd.Parameters.AddWithValue("@Metodo", formapago);
                    cmd.Parameters.AddWithValue("@Detalle", "Pago Vendedor");
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
