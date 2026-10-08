using System.Configuration;
using System.Data.SQLite;

namespace SistemaFinal.Capa_Datos
{
    public class Vendedor
    {
        public string CUIL { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Domicilio { get; set; }
        public int Activo { get; set; }
    }
    internal class VendedorD
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public List<Vendedor> ObtenerVendedores()
        {
            List<Vendedor> lista = new List<Vendedor>();
            string query = "SELECT CUIL, Nombre, Apellido, Telefono, Domicilio, Activo FROM Vendedores";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            lista.Add(new Vendedor
                            {
                                CUIL = reader["CUIL"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Telefono = reader["Telefono"].ToString(),
                                Domicilio = reader["Domicilio"].ToString(),
                                Activo = Convert.ToInt32(reader["Activo"])
                            });
                        }
                    }
                }
            }
            return lista;
        }
        public bool InsertarVendedor(Vendedor vendedor)
        {
            string query = "INSERT INTO Vendedores (CUIL, Nombre, Apellido, Telefono, Domicilio, Activo) " +
                           "VALUES (@CUIL, @Nombre, @Apellido, @Telefono, @Domicilio, @Activo)";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CUIL", vendedor.CUIL);
                    cmd.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", vendedor.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", vendedor.Telefono);
                    cmd.Parameters.AddWithValue("@Domicilio", vendedor.Domicilio);
                    cmd.Parameters.AddWithValue("@Activo", vendedor.Activo);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool BajarVendedor(string cuil, int activo)
        {
            string query = "UPDATE Vendedores SET Activo = @Activo WHERE CUIL = @CUIL";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Activo", activo);
                    cmd.Parameters.AddWithValue("@CUIL", cuil);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ReactVendedor(string cuil, int activo)
        {
            string query = "UPDATE Vendedores SET Activo = @Activo WHERE CUIL = @CUIL";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Activo", activo);
                    cmd.Parameters.AddWithValue("@CUIL", cuil);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool ActualizarVendedor(string cuil, string nombre, string apellido, string telefono, string domicilio)
        {
            string query = @"UPDATE Vendedores 
                     SET Nombre = @Nombre, 
                         Apellido = @Apellido, 
                         Telefono = @Telefono, 
                         Domicilio = @Domicilio 
                     WHERE CUIL = @CUIL";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellido", apellido);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);
                    cmd.Parameters.AddWithValue("@Domicilio", domicilio);
                    cmd.Parameters.AddWithValue("@CUIL", cuil);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
