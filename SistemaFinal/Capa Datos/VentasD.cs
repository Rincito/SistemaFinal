using Newtonsoft.Json;
using System.Configuration;
using System.Data.SQLite;

namespace SistemaFinal.Capa_Datos
{
    public class Venta
    {
        public int NumFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public string Vendedor { get; set; }
        public string Cliente { get; set; }
        public string Metodo { get; set; }
        public decimal Total { get; set; }
        public int Anulada { get; set; }
    }
    public class DetalleArticulo
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
    }
    public class VentaDetalle
    {
        public int NumFactura { get; set; }
        public string DetalleArticulos { get; set; }
        public string Metodo { get; set; }
        public decimal Total { get; set; }
        public string NombreVendedor { get; set; }
    }

    internal class VentasD
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public List<Vendedor> ObtenerVendedor(string tabla)
        {
            List<Vendedor> vendedores = new List<Vendedor>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT CUIL, Nombre, Activo FROM Vendedores";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendedores.Add(new Vendedor
                            {
                                CUIL = reader["CUIL"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Activo = Convert.ToInt32(reader["Activo"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return vendedores;
        }
        public List<Cliente> ObtenerCliente(string tabla)
        {
            List<Cliente> vendedores = new List<Cliente>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT CUIL, Nombre FROM Clientes";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendedores.Add(new Cliente
                            {
                                CUIL = reader["CUIL"].ToString(),
                                Nombre = reader["Nombre"].ToString()
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las personas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return vendedores;
        }
        public List<string> ObtenerMetodo(string tabla)
        {
            List<string> metodos = new List<string>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT Metodo FROM Metodos";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            metodos.Add(reader["Metodo"].ToString());
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener los metodos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return metodos;
        }
        public int ObtenerProximoNumeroFactura()
        {
            int numeroFactura = 1;
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT MAX(NumFact) FROM Ventas";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        var resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value && resultado != null)
                        {
                            numeroFactura = Convert.ToInt32(resultado) + 1;
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener el próximo número de factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return numeroFactura;
        }
        public bool GuardarVenta(int numFactura, DateTime fechaHora, string vendedor, string cliente, string metodo, decimal total)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Ventas (NumFact, FechaHora, Vendedor, Cliente, Metodo, Total, Anulada) VALUES (@NumFact, @FechaHora, @Vendedor, @Cliente, @Metodo, @Total, @Anulada)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumFact", numFactura);
                    cmd.Parameters.AddWithValue("@FechaHora", fechaHora);
                    cmd.Parameters.AddWithValue("@Vendedor", vendedor);
                    cmd.Parameters.AddWithValue("@Cliente", cliente);
                    cmd.Parameters.AddWithValue("@Metodo", metodo);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@Anulada", 1);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
        public int ObtenerProximoNumeroDetalleVenta()
        {
            int numeroDetalleVenta = 1;
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT MAX(ID) FROM Detalles_Venta";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        var resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value && resultado != null)
                        {
                            numeroDetalleVenta = Convert.ToInt32(resultado) + 1;
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener el próximo número de detalle de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return numeroDetalleVenta;
        }
        public int ObtenerProximoNumeroDetalleCompra()
        {
            int numeroDetalleVenta = 1;
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT MAX(IDCompra) FROM Detalles_Compra";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        var resultado = cmd.ExecuteScalar();
                        if (resultado != DBNull.Value && resultado != null)
                        {
                            numeroDetalleVenta = Convert.ToInt32(resultado) + 1;
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener el próximo número de detalle de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return numeroDetalleVenta;
        }


        public void GuardarDetalleVenta(int numFactura, List<DetalleArticulo> detallesArticulos, string metodo, decimal total, string cuilCliente, string cuilVendedor)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string detalleArticulosJson = System.Text.Json.JsonSerializer.Serialize(detallesArticulos);

                string query = "INSERT INTO Detalles_Venta (NumFact, DetalleArticulos, Metodo, Total, CuilCli, NomVen, Anulada) " +
                               "VALUES (@NumFact, @DetalleArticulos, @Metodo, @Total, @CuilCli, @CuilVen, @Anulada)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumFact", numFactura);
                    cmd.Parameters.AddWithValue("@DetalleArticulos", detalleArticulosJson);
                    cmd.Parameters.AddWithValue("@Metodo", metodo);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@CuilCli", cuilCliente);
                    cmd.Parameters.AddWithValue("@CuilVen", cuilVendedor);
                    cmd.Parameters.AddWithValue("@Anulada", 1);

                    cmd.ExecuteNonQuery();
                }
                ActualizarStockArticulosVenta(detallesArticulos);
            }
        }
        public void ActualizarStockArticulosVenta(List<DetalleArticulo> detallesArticulos)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                foreach (var detalle in detallesArticulos)
                {
                    string queryObtenerStock = "SELECT Stock FROM Articulos WHERE Nombre = @Nombre";
                    int stockActual = 0;
                    using (SQLiteCommand cmdObtenerStock = new SQLiteCommand(queryObtenerStock, conn))
                    {
                        cmdObtenerStock.Parameters.AddWithValue("@Nombre", detalle.Nombre);
                        var result = cmdObtenerStock.ExecuteScalar();
                        if (result != null)
                        {
                            stockActual = Convert.ToInt32(result);
                        }
                    }
                    int nuevoStock = stockActual - detalle.Cantidad;
                    string queryActualizarStock = "UPDATE Articulos SET Stock = @NuevoStock WHERE Nombre = @Nombre";
                    using (SQLiteCommand cmdActualizarStock = new SQLiteCommand(queryActualizarStock, conn))
                    {
                        cmdActualizarStock.Parameters.AddWithValue("@NuevoStock", nuevoStock);
                        cmdActualizarStock.Parameters.AddWithValue("@Nombre", detalle.Nombre);
                        cmdActualizarStock.ExecuteNonQuery();
                    }
                }
            }
        }

        public void GuardarDetalleCompra(int numFactura, List<DetalleArticulo> detallesArticulos, string metodo, decimal total, DateTime fechahora, int idProveedor, int activa)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string detalleArticulosJson = System.Text.Json.JsonSerializer.Serialize(detallesArticulos);
                string query = "INSERT INTO Detalles_Compra (NumFact, DetalleArticulos, Metodo, Total, FechaHora, IDProveedor, Anulada) " + "VALUES (@NumFact, @DetalleArticulos, @Metodo, @Total, @FechaHora, @IDProveedor, @Anulada)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NumFact", numFactura);
                    cmd.Parameters.AddWithValue("@DetalleArticulos", detalleArticulosJson);
                    cmd.Parameters.AddWithValue("@Metodo", metodo);
                    cmd.Parameters.AddWithValue("@Total", total);
                    cmd.Parameters.AddWithValue("@FechaHora", fechahora);
                    cmd.Parameters.AddWithValue("@IDProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@Anulada", activa); cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DetalleArticulo> ObtenerDetalleVenta(int numFactura)
        {
            List<DetalleArticulo> detalles = new List<DetalleArticulo>();
            string query = "SELECT DetalleArticulos FROM Detalles_Venta WHERE NumFact = @numFactura";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@numFactura", numFactura);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Se asume que 'DetalleArticulos' tiene la información en formato JSON o delimitado
                    string detalleArticulos = reader["DetalleArticulos"].ToString();

                    // Parsear los detalles del artículo
                    var articulos = ParsearDetalleArticulos(detalleArticulos); // Método auxiliar para deserializar

                    detalles.AddRange(articulos);
                }
            }
            return detalles;
        }

        private List<DetalleArticulo> ParsearDetalleArticulos(string detalleArticulos)
        {
            List<DetalleArticulo> articulos = new List<DetalleArticulo>();

            // Suponiendo que `detalleArticulos` está en formato JSON:
            try
            {
                articulos = JsonConvert.DeserializeObject<List<DetalleArticulo>>(detalleArticulos);
            }
            catch (Exception ex)
            {
                // Manejar excepciones, por ejemplo, si no está en el formato esperado
                Console.WriteLine("Error al deserializar DetalleArticulos: " + ex.Message);
            }

            return articulos;
        }


        public Venta ObtenerVenta(int numFactura)
        {
            Venta venta = null;
            string query = "SELECT * FROM Ventas WHERE NumFact = @numFactura";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@numFactura", numFactura);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    venta = new Venta
                    {
                        NumFactura = Convert.ToInt32(reader["NumFact"]),
                        FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                        Vendedor = reader["Vendedor"].ToString(),
                        Cliente = reader["Cliente"].ToString(),
                        Metodo = reader["Metodo"].ToString(),
                        Total = Convert.ToDecimal(reader["Total"]),
                        Anulada = Convert.ToInt32(reader["Anulada"])
                    };
                }
            }
            return venta;

        }

        public bool ActualizarStockCompra(string nombreArticulo, int cantidad)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Articulos SET Stock = Stock + @Cantidad WHERE Nombre = @Nombre";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@Nombre", nombreArticulo);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine($"Error al actualizar el stock: {ex.Message}");
                    return false;
                }
            }
        }

        public List<Proveedor> ObtenerProveedor(string tabla)
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT ID, Nombre FROM Proveedores WHERE Activo = 1";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            proveedores.Add(new Proveedor
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Nombre = reader["Nombre"].ToString()
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener los proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return proveedores;
        }

        public bool ActualizarDeuda(int idproveedor, decimal total)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Proveedores SET Deuda = Deuda + @total WHERE ID = @idproveedor";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@idproveedor", idproveedor);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine($"Error al actualizar la deuda: {ex.Message}");
                    return false;
                }
            }
        }

        public List<DetalleArticulo> ObtenerDetalleCompra(int numFactura)
        {
            List<DetalleArticulo> detalles = new List<DetalleArticulo>();
            string query = "SELECT DetalleArticulos FROM Detalles_Compra WHERE NumFact = @numFactura";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@numFactura", numFactura);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Se asume que 'DetalleArticulos' tiene la información en formato JSON o delimitado
                    string detalleArticulos = reader["DetalleArticulos"].ToString();

                    // Parsear los detalles del artículo
                    var articulos = ParsearDetalleArticulos(detalleArticulos); // Método auxiliar para deserializar

                    detalles.AddRange(articulos);
                }
            }
            return detalles;
        }
        public List<Venta> ObtenerVentasActivas()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    v.NumFact, 
                    v.FechaHora, 
                    c.Nombre AS Cliente,
                    v.Metodo,
                    v.Total
                FROM 
                    Ventas v
                INNER JOIN 
                    Clientes c ON v.Cliente = c.CUIL
                WHERE 
                    v.Anulada = 1";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                Cliente = reader["Cliente"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las ventas activas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ventas;
        }
        public List<Venta> ObtenerVentasEfectivo()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    v.NumFact, 
                    v.FechaHora, 
                    c.Nombre AS Cliente,
                    v.Metodo,
                    v.Total
                FROM 
                    Ventas v
                INNER JOIN 
                    Clientes c ON v.Cliente = c.CUIL
                WHERE 
                    v.Anulada = 1 AND v.Metodo = 'Efectivo'";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                Cliente = reader["Cliente"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las ventas en efectivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ventas;
        }
        public List<Venta> ObtenerVentasTarjeta()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    v.NumFact, 
                    v.FechaHora, 
                    c.Nombre AS Cliente,
                    v.Metodo,
                    v.Total
                FROM 
                    Ventas v
                INNER JOIN 
                    Clientes c ON v.Cliente = c.CUIL
                WHERE 
                    v.Anulada = 1 AND v.Metodo = 'Tarjeta'";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                Cliente = reader["Cliente"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las ventas con tarjeta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ventas;
        }
        public bool AnularVenta(int numFactura)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string verificarQuery = "SELECT Anulada FROM Ventas WHERE NumFact = @NumFact";
                    using (SQLiteCommand verificarCmd = new SQLiteCommand(verificarQuery, conn))
                    {
                        verificarCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        object resultado = verificarCmd.ExecuteScalar();
                        if (resultado == null)
                        {
                            MessageBox.Show("La venta no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        int estadoAnulada = Convert.ToInt32(resultado);
                        if (estadoAnulada == 0)
                        {
                            MessageBox.Show("Esta venta ya está anulada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    string anularQuery = "UPDATE Ventas SET Anulada = 0 WHERE NumFact = @NumFact";
                    using (SQLiteCommand anularCmd = new SQLiteCommand(anularQuery, conn))
                    {
                        anularCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        int filasAfectadas = anularCmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("La venta se anuló correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo anular la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al anular la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public List<Venta> ObtenerVentasAnuladas()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    v.NumFact, 
                    v.FechaHora, 
                    c.Nombre AS Cliente,
                    v.Metodo,
                    v.Total
                FROM 
                    Ventas v
                INNER JOIN 
                    Clientes c ON v.Cliente = c.CUIL
                WHERE 
                    v.Anulada = 0";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                Cliente = reader["Cliente"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las ventas anuladas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ventas;
        }
        public bool ReactivarVenta(int numFactura)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Verificar si la venta está anulada
                    string verificarQuery = "SELECT Anulada FROM Ventas WHERE NumFact = @NumFact";
                    using (SQLiteCommand verificarCmd = new SQLiteCommand(verificarQuery, conn))
                    {
                        verificarCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        object resultado = verificarCmd.ExecuteScalar();
                        if (resultado == null)
                        {
                            MessageBox.Show("La venta no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        int estadoAnulada = Convert.ToInt32(resultado);
                        if (estadoAnulada == 1)
                        {
                            MessageBox.Show("Esta venta ya está activa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    // Reactivar la venta si está anulada
                    string reactivarQuery = "UPDATE Ventas SET Anulada = 1 WHERE NumFact = @NumFact";
                    using (SQLiteCommand reactivarCmd = new SQLiteCommand(reactivarQuery, conn))
                    {
                        reactivarCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        int filasAfectadas = reactivarCmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("La venta se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al reactivar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public Venta ObtenerDetalle_Venta(int numFactura)
        {
            Venta ventas = new Venta();
            string query = @"SELECT
                dv.Metodo, 
                dv.Total, 
                c.Nombre AS Cliente,
                dv.NomVen,
                v.FechaHora 
                FROM Detalles_Venta dv
                INNER JOIN Clientes c ON dv.CuilCli = c.CUIL
                INNER JOIN Ventas v ON dv.NumFact = v.NumFact
                WHERE dv.NumFact = @numFactura";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@numFactura", numFactura);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ventas.FechaHora = Convert.ToDateTime(reader["FechaHora"]);
                    ventas.Cliente = reader["Cliente"].ToString();
                    ventas.Vendedor = reader["NomVen"].ToString();
                    ventas.Metodo = reader["Metodo"].ToString();
                    ventas.Total = Convert.ToDecimal(reader["Total"]);

                }
            }
            return ventas;
        }
        public List<string> ObtenerTarjeta()
        {
            List<string> metodos = new List<string>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT Nombre FROM Tarjetas WHERE Estado = 1";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            metodos.Add(reader["Nombre"].ToString());
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las tarjetas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return metodos;
        }
        public List<Venta> ObtenerComprasActivas()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {

                conexion.Open();

                string query = @"
                SELECT 
                    dv.NumFact, 
                    dv.FechaHora, 
                    p.Nombre AS ProveedorNombre,
                    dv.Metodo,
                    dv.Total
                FROM 
                    Detalles_Compra dv
                INNER JOIN 
                    Proveedores p ON dv.IDProveedor = p.ID
                WHERE 
                    dv.Anulada = 1";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ventas.Add(new Venta
                        {
                            NumFactura = Convert.ToInt32(reader["NumFact"]),
                            FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                            Cliente = reader["ProveedorNombre"].ToString(),
                            Metodo = reader["Metodo"].ToString(),
                            Total = Convert.ToDecimal(reader["Total"])
                        });
                    }
                }


                return ventas;
            }
        }
        public List<Venta> ObtenerComprasAnuladas()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    dc.NumFact, 
                    dc.FechaHora, 
                    p.Nombre AS ProveedorNombre,
                    dc.Metodo,
                    dc.Total
                FROM 
                    Detalles_Compra dc
                INNER JOIN 
                   Proveedores p ON dc.IDProveedor = p.ID
                WHERE 
                    dc.Anulada = 0";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                Cliente = reader["ProveedorNombre"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las compras anuladas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ventas;
        }
        public List<Venta> ObtenerComprasEfectivo()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    v.NumFact, 
                    v.FechaHora, 
                    c.Nombre AS ProveedorNombre,
                    v.Metodo,
                    v.Total
                FROM 
                    Detalles_Compra v
                INNER JOIN 
                    Proveedores c ON v.IDProveedor = c.ID
                WHERE 
                    v.Anulada = 1 AND v.Metodo = 'Efectivo'";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                Cliente = reader["ProveedorNombre"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las compras en efectivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ventas;
        }
        public List<Venta> ObtenerComprasTarjeta()
        {
            List<Venta> ventas = new List<Venta>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    string query = @"
                SELECT 
                    v.NumFact, 
                    v.FechaHora, 
                    c.Nombre AS ProveedorNombre,
                    v.Metodo,
                    v.Total
                FROM 
                    Detalles_Compra v
                INNER JOIN 
                    Proveedores c ON v.IDProveedor = c.ID
                WHERE 
                    v.Anulada = 1 AND v.Metodo = 'Tarjeta'";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new Venta
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                FechaHora = Convert.ToDateTime(reader["FechaHora"]),
                                Cliente = reader["ProveedorNombre"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"])
                            });
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener las compras con tarjeta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ventas;
        }
        public bool AnularCompra(int numFactura)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string verificarQuery = "SELECT Anulada FROM Detalles_Compra WHERE NumFact = @NumFact";
                    using (SQLiteCommand verificarCmd = new SQLiteCommand(verificarQuery, conn))
                    {
                        verificarCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        object resultado = verificarCmd.ExecuteScalar();
                        if (resultado == null)
                        {
                            MessageBox.Show("La compra no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        int estadoAnulada = Convert.ToInt32(resultado);
                        if (estadoAnulada == 0)
                        {
                            MessageBox.Show("Esta compra ya está anulada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    string anularQuery = "UPDATE Detalles_Compra SET Anulada = 0 WHERE NumFact = @NumFact";
                    using (SQLiteCommand anularCmd = new SQLiteCommand(anularQuery, conn))
                    {
                        anularCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        int filasAfectadas = anularCmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("La compra se anuló correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo anular la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al anular la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public bool ReactivarCompra(int numFactura)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string verificarQuery = "SELECT Anulada FROM Detalles_Compra WHERE NumFact = @NumFact";
                    using (SQLiteCommand verificarCmd = new SQLiteCommand(verificarQuery, conn))
                    {
                        verificarCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        object resultado = verificarCmd.ExecuteScalar();
                        if (resultado == null)
                        {
                            MessageBox.Show("La compra no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        int estadoAnulada = Convert.ToInt32(resultado);
                        if (estadoAnulada == 1)
                        {
                            MessageBox.Show("Esta compra ya está activa.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    // Reactivar la venta si está anulada
                    string reactivarQuery = "UPDATE Detalles_Compra SET Anulada = 1 WHERE NumFact = @NumFact";
                    using (SQLiteCommand reactivarCmd = new SQLiteCommand(reactivarQuery, conn))
                    {
                        reactivarCmd.Parameters.AddWithValue("@NumFact", numFactura);

                        int filasAfectadas = reactivarCmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("La compra se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar la compra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al reactivar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        public Venta ObtenerDetalle_Compra(int numFactura)
        {
            Venta ventas = new Venta();
            string query = @"SELECT
                dv.Metodo, 
                dv.Total, 
                c.Nombre AS Proveedor,
                dv.FechaHora 
                FROM Detalles_Compra dv
                INNER JOIN Proveedores c ON dv.IDProveedor = c.ID
                WHERE dv.NumFact = @numFactura";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@numFactura", numFactura);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    ventas.FechaHora = Convert.ToDateTime(reader["FechaHora"]);
                    ventas.Cliente = reader["Proveedor"].ToString();
                    ventas.Metodo = reader["Metodo"].ToString();
                    ventas.Total = Convert.ToDecimal(reader["Total"]);

                }
            }
            return ventas;
        }
        public Dictionary<string, List<VentaDetalle>> CargarResumen(string fechaInicio, string fechaFin)
        {
            Dictionary<string, List<VentaDetalle>> resumenPorFecha = new Dictionary<string, List<VentaDetalle>>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                string query = @"
        SELECT 
            DATE(v.FechaHora) AS Fecha, 
            dv.NumFact,
            dv.DetalleArticulos,
            dv.Metodo,
            dv.Total,
            dv.NomVen
        FROM 
            Detalles_Venta dv
        INNER JOIN 
            Ventas v ON dv.NumFact = v.NumFact
        WHERE 
            v.Anulada = 1
            AND DATE(v.FechaHora) >= DATE(@FechaInicio)
            AND DATE(v.FechaHora) <= DATE(@FechaFin)
        ORDER BY Fecha";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fecha = reader["Fecha"].ToString();

                            VentaDetalle detalle = new VentaDetalle
                            {
                                NumFactura = Convert.ToInt32(reader["NumFact"]),
                                DetalleArticulos = reader["DetalleArticulos"].ToString(),
                                Metodo = reader["Metodo"].ToString(),
                                Total = Convert.ToDecimal(reader["Total"]),
                                NombreVendedor = reader["NomVen"].ToString()
                            };

                            // Agrupar por fecha
                            if (!resumenPorFecha.ContainsKey(fecha))
                            {
                                resumenPorFecha[fecha] = new List<VentaDetalle>();
                            }
                            resumenPorFecha[fecha].Add(detalle);
                        }
                    }
                }
            }

            return resumenPorFecha;
        }

    }
}