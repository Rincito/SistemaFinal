using SistemaFinal.Capa_Logica;
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
        public string Email { get; set; }
        public int Activo { get; set; }
    }
    internal class VendedorD
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public List<Vendedor> ObtenerVendedores()
        {
            List<Vendedor> lista = new List<Vendedor>();
            string query = "SELECT CUIL, Nombre, Apellido, Telefono, Domicilio, Email, Activo FROM Vendedores";

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
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
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
            UsuarioL usuarioL = new UsuarioL();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string queryVendedor = @"INSERT INTO Vendedores (CUIL, Nombre, Apellido, Telefono, Domicilio, Email, Activo) 
                                                 VALUES (@CUIL, @Nombre, @Apellido, @Telefono, @Domicilio, @Email, @Activo)";

                        using (SQLiteCommand cmdV = new SQLiteCommand(queryVendedor, conn, transaction))
                        {
                            cmdV.Parameters.AddWithValue("@CUIL", vendedor.CUIL);
                            cmdV.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
                            cmdV.Parameters.AddWithValue("@Apellido", vendedor.Apellido);
                            cmdV.Parameters.AddWithValue("@Telefono", vendedor.Telefono);
                            cmdV.Parameters.AddWithValue("@Domicilio", vendedor.Domicilio);
                            cmdV.Parameters.AddWithValue("@Email", vendedor.Email);
                            cmdV.Parameters.AddWithValue("@Activo", vendedor.Activo);
                            cmdV.ExecuteNonQuery();
                        }

                        string queryUsuario = @"INSERT INTO Usuarios (Email, ContraHash, Rol, Activo) 
                                                VALUES (@Email, @ContraHash, 0, 1)";

                        using (SQLiteCommand cmdU = new SQLiteCommand(queryUsuario, conn, transaction))
                        {
                            cmdU.Parameters.AddWithValue("@Email", vendedor.Email);
                            cmdU.Parameters.AddWithValue("@ContraHash",usuarioL.GenerarHashSHA256("1"));
                            cmdU.ExecuteNonQuery();
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
        public bool BajarVendedor(string cuil, int activo)
        {
            string query = "UPDATE Vendedores SET Activo = @Activo WHERE CUIL = @CUIL";
            string queryUsuario = "UPDATE Usuarios SET Activo = @Activo WHERE Email = (SELECT Email FROM Vendedores WHERE CUIL = @CUIL)";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand cmdV = new SQLiteCommand(query, conn, transaction))
                        {
                            cmdV.Parameters.AddWithValue("@Activo", activo);
                            cmdV.Parameters.AddWithValue("@CUIL", cuil);
                            cmdV.ExecuteNonQuery();
                        }

                        using (SQLiteCommand cmdU = new SQLiteCommand(queryUsuario, conn, transaction))
                        {
                            cmdU.Parameters.AddWithValue("@Activo", activo);
                            cmdU.Parameters.AddWithValue("@CUIL", cuil);
                            cmdU.ExecuteNonQuery();
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
        public bool ReactVendedor(string cuil, int activo)
        {
            string query = "UPDATE Vendedores SET Activo = @Activo WHERE CUIL = @CUIL";
            string queryUsuario = "UPDATE Usuarios SET Activo = @Activo WHERE Email = (SELECT Email FROM Vendedores WHERE CUIL = @CUIL)";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand cmdV = new SQLiteCommand(query, conn, transaction))
                        {
                            cmdV.Parameters.AddWithValue("@Activo", activo);
                            cmdV.Parameters.AddWithValue("@CUIL", cuil);
                            cmdV.ExecuteNonQuery();
                        }

                        using (SQLiteCommand cmdU = new SQLiteCommand(queryUsuario, conn, transaction))
                        {
                            cmdU.Parameters.AddWithValue("@Activo", activo);
                            cmdU.Parameters.AddWithValue("@CUIL", cuil);
                            cmdU.ExecuteNonQuery();
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
        public bool ActualizarVendedor(string cuil, string nombre, string apellido, string telefono, string domicilio, string email)
        {
            string query = @"UPDATE Vendedores SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Domicilio = @Domicilio, Email = @Email WHERE CUIL = @CUIL";
            string queryUsuario = @"UPDATE Usuarios SET Email = @Email WHERE Email = (SELECT Email FROM Vendedores WHERE CUIL = @CUIL)";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                       
                        string queryUsuarioSeguro = @"UPDATE Usuarios SET Email = @NuevoEmail WHERE Email = (SELECT Email FROM Vendedores WHERE CUIL = @CUIL)";

                        using (SQLiteCommand cmdU = new SQLiteCommand(queryUsuarioSeguro, conn, transaction))
                        {
                            cmdU.Parameters.AddWithValue("@NuevoEmail", email);
                            cmdU.Parameters.AddWithValue("@CUIL", cuil);
                            cmdU.ExecuteNonQuery();
                        }

                        using (SQLiteCommand cmdV = new SQLiteCommand(query, conn, transaction))
                        {
                            cmdV.Parameters.AddWithValue("@Nombre", nombre);
                            cmdV.Parameters.AddWithValue("@Apellido", apellido);
                            cmdV.Parameters.AddWithValue("@Telefono", telefono);
                            cmdV.Parameters.AddWithValue("@Domicilio", domicilio);
                            cmdV.Parameters.AddWithValue("@Email", email);
                            cmdV.Parameters.AddWithValue("@CUIL", cuil);
                            cmdV.ExecuteNonQuery();
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
