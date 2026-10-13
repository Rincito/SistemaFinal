using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Capa_Datos
{
    public class Notificacion
    {
        public int ID { get; set; }
        public string Tema { get; set; }       
        public string Titulo { get; set; }
        public DateTime FechayHora { get; set; }
        public string Descripcion { get; set; }
        public int Leido { get; set; }        
    }
    internal class NotificacionD
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        
        public bool RegistrarNotificacion(string tema, string titulo, string descripcion)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Notificaciones (Tema, Titulo, FechayHora, Descripcion, Leido) 
                                VALUES (@Tema, @Titulo, @FechayHora, @Descripcion, 0)";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Tema", tema);
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    cmd.Parameters.AddWithValue("@FechayHora", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Notificacion> ObtenerNotificaciones(string categoria = "Todas")
        {
            List<Notificacion> lista = new List<Notificacion>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Tema, Titulo, FechayHora, Descripcion, Leido FROM Notificaciones ";

                if (categoria != "Todas")
                {
                    query += "WHERE Tema = @Categoria ";
                }

                query += "ORDER BY FechayHora DESC LIMIT 50";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    if (categoria != "Todas")
                        cmd.Parameters.AddWithValue("@Categoria", categoria);

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Notificacion
                            {
                                Tema = dr["Tema"].ToString(),
                                Titulo = dr["Titulo"].ToString(),
                                FechayHora = Convert.ToDateTime(dr["FechayHora"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Leido = Convert.ToInt32(dr["Leido"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        
        public int ObtenerCantidadNoLeidas()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Notificaciones WHERE Leido = 0";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

      
        public void MarcarTodasComoLeidas()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Notificaciones SET Leido = 1 WHERE Leido = 0";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

