using System.Configuration;
using System.Data.SQLite;

namespace SistemaFinal.Capa_Datos
{
    internal class RubroD
    {
        public class Rubro
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public bool InsertarRubro(string nombreRubro)
        {
            if (RubroExiste(nombreRubro))
            {
                throw new Exception("El rubro ya existe.");
            }
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Rubro (Rubro, Activo) VALUES (@Nombre, @Activo)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombreRubro);
                        cmd.Parameters.AddWithValue("@Activo", 1);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("No se insertó el rubro.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el rubro: " + ex.Message);
            }
        }

        public List<Rubro> Rubros()
        {
            List<Rubro> oRubro = new List<Rubro>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT Rubro AS Nombre, Activo from Rubro";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oRubro.Add(new Rubro
                            {
                                Nombre = dr["Nombre"].ToString(),
                                Activo = Convert.ToInt32(dr["Activo"]),
                            });
                        }
                    }
                }
            }
            return oRubro;
        }
        private bool RubroExiste(string nombreRubro)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM Rubro WHERE Rubro = @Nombre";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombreRubro);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool BajaRubro(string Rubro, int nuevoActivo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string queryVerificar = "SELECT Activo FROM Rubro WHERE Rubro = @Rubro";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryVerificar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Rubro", Rubro);
                        object result = cmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) != 1)
                        {
                            return false;
                        }
                        string queryActualizar = "UPDATE Rubro SET Activo = @Activo WHERE Rubro = @Rubro";
                        using (SQLiteCommand cmdActualizar = new SQLiteCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@Activo", 0);
                            cmdActualizar.Parameters.AddWithValue("@Rubro", Rubro);

                            int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                            return filasAfectadas > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el rubro: " + ex.Message);
            }
        }

        public bool ReactRubro(string Rubro, int nuevoActivo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string queryVerificar = "SELECT Activo FROM Rubro WHERE Rubro = @Rubro";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryVerificar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Rubro", Rubro);
                        object result = cmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) != 0)
                        {
                            return false;
                        }
                        string queryActualizar = "UPDATE Rubro SET Activo = @Activo WHERE Rubro = @Rubro";
                        using (SQLiteCommand cmdActualizar = new SQLiteCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@Activo", 1);
                            cmdActualizar.Parameters.AddWithValue("@Rubro", Rubro);

                            int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                            return filasAfectadas > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el rubro: " + ex.Message);
            }
        }
    }
}
