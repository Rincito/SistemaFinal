using System.Configuration;
using System.Data.SQLite;

namespace SistemaFinal.Capa_Datos
{
    internal class MarcaD
    {
        public class Marca
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public bool InsertarMarca(string nombreMarca)
        {
            if (MarcaExiste(nombreMarca))
            {
                throw new Exception("La marca ya existe.");
            }
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Marca (Marca, Activo) VALUES (@Nombre, @Activo)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombreMarca);
                        cmd.Parameters.AddWithValue("@Activo", 1);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("No se insertó la marca.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la marca: " + ex.Message);
            }
        }

        public List<Marca> Marcas()
        {
            List<Marca> oMarca = new List<Marca>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT Marca AS Marca, Activo from Marca";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oMarca.Add(new Marca
                            {
                                Nombre = dr["Marca"].ToString(),
                                Activo = Convert.ToInt32(dr["Activo"]),
                            });
                        }
                    }
                }
            }
            return oMarca;
        }
        private bool MarcaExiste(string nombreMarca)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM Marca WHERE Marca = @Nombre";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombreMarca);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool BajaMarca(string Marca, int nuevoActivo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string queryVerificar = "SELECT Activo FROM Marca WHERE Marca = @Marca";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryVerificar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Marca", Marca);
                        object result = cmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) != 1)
                        {
                            return false;
                        }
                        string queryActualizar = "UPDATE Marca SET Activo = @Activo WHERE Marca = @Marca";
                        using (SQLiteCommand cmdActualizar = new SQLiteCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@Activo", 0);
                            cmdActualizar.Parameters.AddWithValue("@Marca", Marca);

                            int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                            return filasAfectadas > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la marca: " + ex.Message);
            }
        }

        public bool ReactMarca(string Marca, int nuevoActivo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string queryVerificar = "SELECT Activo FROM Marca WHERE Marca = @Marca";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryVerificar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Marca", Marca);
                        object result = cmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) != 0)
                        {
                            return false;
                        }
                        string queryActualizar = "UPDATE Marca SET Activo = @Activo WHERE Marca = @Marca";
                        using (SQLiteCommand cmdActualizar = new SQLiteCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@Activo", 1);
                            cmdActualizar.Parameters.AddWithValue("@Marca", Marca);

                            int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                            return filasAfectadas > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la marca: " + ex.Message);
            }
        }
    }
}
