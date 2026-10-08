using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Capa_Datos
{
    internal class GastoD
    {
        public class Gasto
        {
            public string Nombre { get; set; }
            public int Activo { get; set; }
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        public bool InsertarGasto(string nombreGasto)
        {
            if (GastoExiste(nombreGasto))
            {
                throw new Exception("El gasto ya existe.");
            }
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string query = "INSERT INTO Gastos (Detalles, Activo) VALUES (@Nombre, @Activo)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombreGasto);
                        cmd.Parameters.AddWithValue("@Activo", 1);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("No se insertó el gasto.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el gasto: " + ex.Message);
            }
        }

        public List<Gasto> Gastos()
        {
            List<Gasto> Gasto = new List<Gasto>();
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT Detalles AS Nombre, Activo from Gastos";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Gasto.Add(new Gasto
                            {
                                Nombre = dr["Nombre"].ToString(),
                                Activo = Convert.ToInt32(dr["Activo"]),
                            });
                        }
                    }
                }
            }
            return Gasto;
        }
        public List<string> ObtenerGasto()
        {
            List<string> gastos = new List<string>();

            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT Detalles FROM Gastos WHERE Activo = 1";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gastos.Add(reader["Detalles"].ToString());
                        }
                    }
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show($"Error al obtener los gastos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return gastos;
        }
        private bool GastoExiste(string nombreGasto)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM Gastos WHERE Detalles = @Nombre";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombreGasto);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool BajaGasto(string Gasto, int nuevoActivo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string queryVerificar = "SELECT Activo FROM Gastos WHERE Detalles = @Detalles";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryVerificar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Detalles", Gasto);
                        object result = cmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) != 1)
                        {
                            return false;
                        }
                        string queryActualizar = "UPDATE Gastos SET Activo = @Activo WHERE Detalles = @Detalles";
                        using (SQLiteCommand cmdActualizar = new SQLiteCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@Activo", 0);
                            cmdActualizar.Parameters.AddWithValue("@Detalles", Gasto);

                            int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                            return filasAfectadas > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el gasto: " + ex.Message);
            }
        }

        public bool ReactGasto(string Gasto, int nuevoActivo)
        {
            try
            {
                using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
                {
                    conexion.Open();
                    string queryVerificar = "SELECT Activo FROM Gastos WHERE Detalles = @Detalles";
                    using (SQLiteCommand cmd = new SQLiteCommand(queryVerificar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Detalles", Gasto);
                        object result = cmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) != 0)
                        {
                            return false;
                        }
                        string queryActualizar = "UPDATE Gastos SET Activo = @Activo WHERE Detalles = @Detalles";
                        using (SQLiteCommand cmdActualizar = new SQLiteCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@Activo", 1);
                            cmdActualizar.Parameters.AddWithValue("@Detalles", Gasto);

                            int filasAfectadas = cmdActualizar.ExecuteNonQuery();

                            return filasAfectadas > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el gasto: " + ex.Message);
            }
        }
    }
}
