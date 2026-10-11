using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace SistemaFinal.Capa_Datos
{
    public class Articulo
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Rubro { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public decimal Costo { get; set; }
        public int StockMin { get; set; }
        public decimal Ganancia { get; set; }
        public decimal IVA { get; set; }
        public int Activo { get; set; }
    }
    internal class ArticuloD : IDisposable
    {
        private readonly string connectionString;
        private SQLiteConnection conexion;
        private bool disposed = false;

        public ArticuloD()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            conexion = new SQLiteConnection(connectionString);
        }

        private void AbrirConexion()
        {
            try
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexión: " + ex.Message);
            }
        }

        private void CerrarConexion()
        {
            try
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }

        public List<string> ObtenerRubros()
        {
            List<string> listaRubros = new List<string>();

            try
            {
                AbrirConexion();
                string query = "SELECT Rubro FROM Rubro WHERE Activo = 1";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                using (SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        listaRubros.Add(dr["Rubro"].ToString());
                    }
                }
                return listaRubros;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los rubros: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public List<string> ObtenerMarcas()
        {
            List<string> listaMarcas = new List<string>();

            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string query = "SELECT Marca FROM Marca WHERE Activo = 1";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        using (SQLiteDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                listaMarcas.Add(dr["Marca"].ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las marcas: " + ex.Message);
            }

            return listaMarcas;
        }
        public bool GuardarProducto(string codigo, string nombre, int stock, decimal costo,
            decimal precio, int stockCritico, decimal iva, decimal ganancia,
            string marca, string rubro)
        {
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre))
                throw new ArgumentException("Código y nombre son requeridos");

            try
            {
                AbrirConexion();
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        const string query = @"INSERT INTO Articulos 
                            (Codigo, Nombre, Marca, Rubro, Precio, Stock, Costo, StockMin, Ganancia, IVA, Activo)
                            VALUES 
                            (@Codigo, @Nombre, @Marca, @Rubro, @Precio, @Stock, 
                             @Costo, @StockMin, @Ganancia, @IVA, @Activo)";

                        using (var cmd = new SQLiteCommand(query, conexion, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Codigo", codigo);
                            cmd.Parameters.AddWithValue("@Nombre", nombre);
                            cmd.Parameters.AddWithValue("@Stock", stock);
                            cmd.Parameters.AddWithValue("@Costo", costo);
                            cmd.Parameters.AddWithValue("@Precio", precio);
                            cmd.Parameters.AddWithValue("@StockMin", stockCritico);
                            cmd.Parameters.AddWithValue("@IVA", iva);
                            cmd.Parameters.AddWithValue("@Ganancia", ganancia);
                            cmd.Parameters.AddWithValue("@Marca", marca);
                            cmd.Parameters.AddWithValue("@Rubro", rubro);
                            cmd.Parameters.AddWithValue("@Activo", 1);

                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas <= 0)
                                throw new Exception("No se pudo insertar el producto.");

                            transaction.Commit();
                            return true;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            finally
            {
                CerrarConexion();
            }
        }
        public bool ExisteArticulo(string codigo, string nombre)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();

                    string query = @"SELECT COUNT(*) 
                             FROM Articulos 
                             WHERE Codigo = @Codigo OR Nombre = @Nombre";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia del artículo: " + ex.Message);
            }
        }
        public List<Articulo> ListarArticulos()
        {
            var articulos = new List<Articulo>();

            try
            {
                AbrirConexion();
                const string query = @"SELECT Codigo, Nombre, Marca, Rubro, Precio, 
                    Stock, Costo, StockMin, Ganancia, IVA, Activo 
                    FROM Articulos";

                using (var cmd = new SQLiteCommand(query, conexion))
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                 
                        articulos.Add(new Articulo
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Marca = dr["Marca"].ToString(),
                            Rubro = dr["Rubro"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"] ?? 0),
                            Stock = Convert.ToInt32(dr["Stock"] ?? 0),
                            Costo = Convert.ToDecimal(dr["Costo"] ?? 0),
                            StockMin = Convert.ToInt32(dr["StockMin"] ?? 0),
                            Ganancia = Convert.ToDecimal(dr["Ganancia"] ?? 0),
                            IVA = Convert.ToDecimal(dr["IVA"] ?? 0),
                            Activo = Convert.ToInt32(dr["Activo"])

                        });
                    }
                }
                return articulos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

        }

        public int ObtenerTotalArticulos()
        {
            try
            {
                AbrirConexion();
                const string query = "SELECT COUNT(*) FROM Articulos";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al contar los artículos: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<Articulo> ListarArticulosPaginados(int paginaActual, int registrosPorPagina)
        {
            var articulos = new List<Articulo>();
            int offset = (paginaActual - 1) * registrosPorPagina;

            try
            {
                AbrirConexion();
                const string query = @"SELECT Codigo, Nombre, Marca, Rubro, Precio, 
                                      Stock, Costo, StockMin, Ganancia, IVA, Activo 
                                      FROM Articulos 
                                      LIMIT @Limit OFFSET @Offset";

                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Limit", registrosPorPagina);
                    cmd.Parameters.AddWithValue("@Offset", offset);

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            articulos.Add(new Articulo
                            {
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Marca = dr["Marca"].ToString(),
                                Rubro = dr["Rubro"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"] ?? 0),
                                Stock = Convert.ToInt32(dr["Stock"] ?? 0),
                                Costo = Convert.ToDecimal(dr["Costo"] ?? 0),
                                StockMin = Convert.ToInt32(dr["StockMin"] ?? 0),
                                Ganancia = Convert.ToDecimal(dr["Ganancia"] ?? 0),
                                IVA = Convert.ToDecimal(dr["IVA"] ?? 0),
                                Activo = Convert.ToInt32(dr["Activo"])
                            });
                        }
                    }
                }
                return articulos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos paginados: " + ex.Message);
            }
            finally
            {
                CerrarConexion();
            }
        }
        public bool DarDeBajaArticulo(string codigo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string query = "UPDATE Articulos SET Activo = 0 WHERE Codigo = @Codigo";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el artículo en la base de datos: " + ex.Message);
            }
        }
        public bool DarDeAltaArticulo(string codigo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string query = "UPDATE Articulos SET Activo = 1 WHERE Codigo = @Codigo";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", codigo);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el artículo en la base de datos: " + ex.Message);
            }
        }
        public bool ActualizarArticulo(Articulo articulo, string codviejo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();

                    string query = @"UPDATE Articulos 
                             SET Nombre = @Nombre, Marca = @Marca, Rubro = @Rubro, 
                                 Precio = @Precio, Stock = @Stock, Costo = @Costo, 
                                 StockMin = @StockMin, Ganancia = @Ganancia, 
                                 IVA = @IVA WHERE Codigo = @AntCodigo";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                        cmd.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                        cmd.Parameters.AddWithValue("@Marca", articulo.Marca);
                        cmd.Parameters.AddWithValue("@Rubro", articulo.Rubro);
                        cmd.Parameters.AddWithValue("@Precio", articulo.Precio);
                        cmd.Parameters.AddWithValue("@Stock", articulo.Stock);
                        cmd.Parameters.AddWithValue("@Costo", articulo.Costo);
                        cmd.Parameters.AddWithValue("@StockMin", articulo.StockMin);
                        cmd.Parameters.AddWithValue("@Ganancia", articulo.Ganancia);
                        cmd.Parameters.AddWithValue("@IVA", articulo.IVA);
                        cmd.Parameters.AddWithValue("@AntCodigo", codviejo);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el artículo: " + ex.Message);
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (conexion != null)
                    {
                        CerrarConexion();
                        conexion.Dispose();
                        conexion = null;
                    }
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
