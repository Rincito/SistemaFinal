using System.Configuration;
using System.Data.SQLite;

namespace SistemaFinal.Capa_Datos
{
    internal class TarjetaD
    {
        public class Tarjeta
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public bool GuardarTarjeta(string nombreTarjeta)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Tarjetas (Nombre, Estado) VALUES (@Nombre, @Activo)";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreTarjeta);
                        command.Parameters.AddWithValue("@Activo", 1);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la tarjeta: " + ex.Message);
                return false;
            }
        }
        public bool ExisteTarjeta(string nombreTarjeta)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Tarjetas WHERE Nombre = @Nombre";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreTarjeta);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la existencia de la tarjeta: " + ex.Message);
                return false;
            }
        }
        public bool BajaTarjeta(string nombreTarjeta, int estado)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tarjetas SET Estado = @Activo WHERE Nombre = @Nombre";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Activo", estado);
                        command.Parameters.AddWithValue("@Nombre", nombreTarjeta);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al desactivar la tarjeta: " + ex.Message);
                return false;
            }
        }
        public bool ReactTarjeta(string nombreTarjeta)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Tarjetas SET Estado = 1 WHERE Nombre = @Nombre AND Estado = 0";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreTarjeta);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reactivar la tarjeta: " + ex.Message);
                return false;
            }
        }
        public List<Tarjeta> ListarTarjetas()
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Nombre, Estado FROM Tarjetas";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Tarjeta tarjeta = new Tarjeta
                                {
                                    Nombre = reader.GetString(0),
                                    Activo = reader.GetInt32(1)
                                };
                                tarjetas.Add(tarjeta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar las tarjetas: " + ex.Message);
                return null;
            }
            return tarjetas;
        }
    }
}
