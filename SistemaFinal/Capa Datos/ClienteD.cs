using System.Configuration;
using System.Data.SQLite;

namespace SistemaFinal.Capa_Datos
{
    public class Cliente
    {
        public string CUIL { get; set; }
        public string CUILViejo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public decimal CuenCo { get; set; }
    }
    internal class ClienteD
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public bool Guardar(Cliente cliente)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {

                    command.CommandText = @"
                    INSERT INTO Clientes (CUIL, Nombre, Apellido, Telefono, Domicilio, Email, CuenCo)
                    VALUES (@CUIL, @Nombre, @Apellido, @Telefono, @Domicilio, @Email, @CuenCo)";
                    command.Parameters.AddWithValue("@CUIL", cliente.CUIL);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Apellido", cliente.Apellido ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Domicilio", cliente.Domicilio ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", cliente.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CuenCo", 0);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar cliente: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Clientes WHERE Nombre IS NOT NULL";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new Cliente
                        {
                            CUIL = reader["CUIL"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Domicilio = reader["Domicilio"].ToString(),
                            Email = reader["Email"].ToString(),
                            CuenCo = Convert.ToDecimal(reader["CuenCo"])
                        };

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }

        public int ObtenerTotalClientes()
        {
            int total = 0;
            string query = "SELECT COUNT(*) FROM Clientes"; 

            
            using (var conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                using (var comando = new SQLiteCommand(query, conexion))
                {
                    total = Convert.ToInt32(comando.ExecuteScalar());
                }
            }
            return total;
        }

        public List<Cliente> ListarClientesPaginados(int paginaActual, int registrosPorPagina)
        {
            var lista = new List<Cliente>();
            int offset = (paginaActual - 1) * registrosPorPagina;

            // Consulta con paginación para SQLite
            string query = "SELECT * FROM Clientes LIMIT @registros OFFSET @offset";

            using (var conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                using (var comando = new SQLiteCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@registros", registrosPorPagina);
                    comando.Parameters.AddWithValue("@offset", offset);

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                // Mapea las propiedades de tu objeto Cliente según las columnas de tu BD
                                // Ejemplo:
                                // Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                CuenCo = Convert.ToDecimal(reader["CuenCo"])
                                // ... demas propiedades
                            };
                            lista.Add(cliente);
                        }
                    }
                }
            }
            return lista;
        }

        public bool ActualizarCliente(Cliente cliente, string cuil)
        {
            try
            {
                using (var conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    var comando = new SQLiteCommand("UPDATE Clientes SET CUIL = @CUIL, Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Domicilio = @Domicilio, Email = @Email WHERE CUIL = @CUILViejo", conexion);
                    comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    comando.Parameters.AddWithValue("@Email", cliente.Email);
                    comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                    comando.Parameters.AddWithValue("@CUIL", cliente.CUIL);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Domicilio", cliente.Domicilio);
                    comando.Parameters.AddWithValue("@CUILViejo", cuil);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        public void ActualizarCC(string cuil, decimal total)
        {
            using (var conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                var comando = new SQLiteCommand("UPDATE Clientes SET CuenCo = CuenCo + @Total WHERE CUIL = @CUIL", conexion);
                comando.Parameters.AddWithValue("@Total", total);
                comando.Parameters.AddWithValue("@CUIL", cuil);
                comando.ExecuteNonQuery();

            }
        }
        public void PagoCC(string cuil, decimal total)
        {
            using (var conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                var comando = new SQLiteCommand("UPDATE Clientes SET CuenCo = CuenCo - @Total WHERE CUIL = @CUIL", conexion);
                comando.Parameters.AddWithValue("@Total", total);
                comando.Parameters.AddWithValue("@CUIL", cuil);
                comando.ExecuteNonQuery();

            }
        }
    }
}
