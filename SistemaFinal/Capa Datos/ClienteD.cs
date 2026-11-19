using SistemaFinal.Capa_Logica;
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

                                CUIL = reader["CUIL"] != DBNull.Value ? reader["CUIL"].ToString() : string.Empty,
                                Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                                Apellido = reader["Apellido"] != DBNull.Value ? reader["Apellido"].ToString() : string.Empty,
                                Telefono = reader["Telefono"] != DBNull.Value ? reader["Telefono"].ToString() : string.Empty,
                                Domicilio = reader["Domicilio"] != DBNull.Value ? reader["Domicilio"].ToString() : string.Empty,
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty,
                                CuenCo = reader["CuenCo"] != DBNull.Value ? Convert.ToDecimal(reader["CuenCo"]) : 0m

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

        public bool AplicarInteresAGlobal(decimal porcentaje)
        {
            using (var conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                using (var transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        // 1. Aplicar el aumento del porcentaje a las cuentas corrientes (ej: 1.05 para un 5%)
                        string queryUpdate = "UPDATE Clientes SET CuenCo = CuenCo * @Porcentaje WHERE CuenCo > 0 AND CUIL <> '1'";
                        using (var cmdU = new SQLiteCommand(queryUpdate, conexion, transaction))
                        {
                            cmdU.Parameters.AddWithValue("@Porcentaje", porcentaje);
                            cmdU.ExecuteNonQuery();
                        }

                        // 2. Registrar la notificación indicando quién realizó la acción
                        string operador = SesionActual.NombreCompleto ?? "Administrador";
                        string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                        string queryNoti = "INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion) VALUES (@Tema, @Titulo, @Fecha, @Desc)";
                        using (var cmdN = new SQLiteCommand(queryNoti, conexion, transaction))
                        {
                            cmdN.Parameters.AddWithValue("@Tema", "Clientes");
                            cmdN.Parameters.AddWithValue("@Titulo", "Recargo en Cuentas Corrientes");
                            cmdN.Parameters.AddWithValue("@Fecha", fecha);
                            cmdN.Parameters.AddWithValue("@Desc", $"El usuario {operador} aplicó un recargo porcentual del {((porcentaje - 1) * 100)}% a todas las cuentas corrientes activas.");
                            cmdN.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
