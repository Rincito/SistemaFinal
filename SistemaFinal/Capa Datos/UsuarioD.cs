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
                    string query = "UPDATE Usuarios SET Activo = @activo WHERE ID = @idUsuario";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@activo", activo);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }

        public bool ModificarUsuario(int idUsuario, string email, int rol, string nuevaContraHash = null)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();

                // Consulta dinámica: si viene una contraseña nueva la cambia, si no, solo cambia Email y Rol
                string query = string.IsNullOrEmpty(nuevaContraHash)
                    ? "UPDATE Usuarios SET Email = @email, Rol = @rol WHERE ID = @id"
                    : "UPDATE Usuarios SET Email = @email, Rol = @rol, ContraHash = @hash WHERE ID = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@rol", rol);
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    if (!string.IsNullOrEmpty(nuevaContraHash))
                    {
                        cmd.Parameters.AddWithValue("@hash", nuevaContraHash);
                    }

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
    }
