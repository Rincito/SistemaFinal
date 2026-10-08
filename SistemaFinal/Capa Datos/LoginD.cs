using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Capa_Datos
{
    internal class LoginD
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public List<UsuarioDTO> ObtenerUsuariosPorRol(int rol)
        {
            List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT ID, Email, ContraHash, Rol, Activo FROM Usuarios WHERE Rol = @rol AND Activo = 1";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@rol", rol);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UsuarioDTO usuario = new UsuarioDTO
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Email = reader["Email"].ToString(),
                                ContraHash = reader["ContraHash"].ToString(),
                                Rol = Convert.ToInt32(reader["Rol"]),
                                Activo = Convert.ToInt32(reader["Activo"])
                            };
                            listaUsuarios.Add(usuario);
                        }
                    }
                }
            }
            return listaUsuarios; // Retorna null si no existe esa combinación de usuario y rol
        }


        public UsuarioDTO ObtenerUsuarioPorEmail(string email)
        {
            UsuarioDTO usuario = null;

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT ID, Email, ContraHash, Rol, Activo FROM Usuarios WHERE Email = @email";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new UsuarioDTO
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Email = reader["Email"].ToString(),
                                ContraHash = reader["ContraHash"].ToString(),
                                Rol = Convert.ToInt32(reader["Rol"]),
                                Activo = Convert.ToInt32(reader["Activo"])
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        // Método nuevo en LoginD para guardar la nueva contraseña
        public bool ActualizarContraseña(int idUsuario, string nuevaContraHash)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "UPDATE Usuarios SET ContraHash = @hash WHERE ID = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@hash", nuevaContraHash);
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Objeto de transferencia de datos (DTO)
        public class UsuarioDTO
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string ContraHash { get; set; }
            public int Rol { get; set; }
            public int Activo { get; set; }
        }
    }
}

