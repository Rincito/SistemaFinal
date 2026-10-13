using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Capa_Datos
{
    internal class UsuarioD
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        public class UsuarioDTO
        {
            public int ID { get; set; }
            public string Email { get; set; }
            public string ContraHash { get; set; }
            public int Rol { get; set; }
            public int Activo { get; set; }
        }

         public List<UsuarioDTO> ObtenerUsuarios()
            {
              List<UsuarioDTO> lista = new List<UsuarioDTO>();

              using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                 conexion.Open();
                 string query = "SELECT ID, Email, ContraHash, Rol, Activo FROM Usuarios";

                 using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new UsuarioDTO
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Email = reader["Email"].ToString(),
                                ContraHash = reader["ContraHash"].ToString(),
                                Rol = Convert.ToInt32(reader["Rol"]),
                                Activo = Convert.ToInt32(reader["Activo"])
                            });
                        }
                    }
                }
                return lista;
            }

            public bool InsertarUsuario(string email, string contraHash, int rol)
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Usuarios (Email, ContraHash, Rol, Activo) VALUES (@email, @contraHash, @rol, 1)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contraHash", contraHash);
                        cmd.Parameters.AddWithValue("@rol", rol);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }

            public bool ActualizarEstadoUsuario(int idUsuario, int activo)
            {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                using (SQLiteTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        string queryUsuario = "UPDATE Usuarios SET Activo = @activo WHERE ID = @idUsuario";
                        using (SQLiteCommand cmdU = new SQLiteCommand(queryUsuario, conexion, transaction))
                        {
                            cmdU.Parameters.AddWithValue("@activo", activo);
                            cmdU.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdU.ExecuteNonQuery();
                        }

                        string queryVendedor = @"UPDATE Vendedores SET Activo = @activo WHERE Email = (SELECT Email FROM Usuarios WHERE ID = @idUsuario)";
                        using (SQLiteCommand cmdV = new SQLiteCommand(queryVendedor, conexion, transaction))
                        {
                            cmdV.Parameters.AddWithValue("@activo", activo);
                            cmdV.Parameters.AddWithValue("@idUsuario", idUsuario);
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

        public bool ModificarUsuario(int idUsuario, string email, int rol, string nuevaContraHash = null)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                using (SQLiteTransaction transaction = conexion.BeginTransaction())
                {
                    try
                    {
                        string emailViejo = "";
                        string querySelect = "SELECT Email FROM Usuarios WHERE ID = @id";
                        using (SQLiteCommand cmdS = new SQLiteCommand(querySelect, conexion, transaction))
                        {
                            cmdS.Parameters.AddWithValue("@id", idUsuario);
                            emailViejo = cmdS.ExecuteScalar()?.ToString();
                        }

                        string queryUsuario = string.IsNullOrEmpty(nuevaContraHash)
                            ? "UPDATE Usuarios SET Email = @email, Rol = @rol WHERE ID = @id"
                            : "UPDATE Usuarios SET Email = @email, Rol = @rol, ContraHash = @hash WHERE ID = @id";

                        using (SQLiteCommand cmdU = new SQLiteCommand(queryUsuario, conexion, transaction))
                        {
                            cmdU.Parameters.AddWithValue("@email", email);
                            cmdU.Parameters.AddWithValue("@rol", rol);
                            cmdU.Parameters.AddWithValue("@id", idUsuario);

                            if (!string.IsNullOrEmpty(nuevaContraHash))
                            {
                                cmdU.Parameters.AddWithValue("@hash", nuevaContraHash);
                            }

                            cmdU.ExecuteNonQuery();
                        }

                        if (!string.IsNullOrEmpty(emailViejo))
                        {
                            string queryVendedor = "UPDATE Vendedores SET Email = @emailNuevo WHERE Email = @emailViejo";
                            using (SQLiteCommand cmdV = new SQLiteCommand(queryVendedor, conexion, transaction))
                            {
                                cmdV.Parameters.AddWithValue("@emailNuevo", email);
                                cmdV.Parameters.AddWithValue("@emailViejo", emailViejo);
                                cmdV.ExecuteNonQuery();
                            }
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
