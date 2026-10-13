using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Capa_Logica
{
    internal class ExportarSistemaL
    {
        public static void ExportarTodoAExcel()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

                using (var workbook = new XLWorkbook())
                {
                    using (var conexion = new SQLiteConnection(connectionString))
                    {
                        conexion.Open();

                        string queryTablas = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";

                        List<string> listaTablas = new List<string>();
                        using (var cmdTablas = new SQLiteCommand(queryTablas, conexion))
                        {
                            using (var reader = cmdTablas.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    listaTablas.Add(reader["name"].ToString());
                                }
                            }
                        }

                        foreach (string nombreTabla in listaTablas)
                        {
                            DataTable dt = new DataTable();
                            string queryDatos = $"SELECT * FROM [{nombreTabla}]";

                            using (var adapter = new SQLiteDataAdapter(queryDatos, conexion))
                            {
                                adapter.Fill(dt);
                            }

                            
                            string nombreHojaLimpio = nombreTabla.Length > 31 ? nombreTabla.Substring(0, 31) : nombreTabla;

                            var worksheet = workbook.Worksheets.Add(dt, nombreHojaLimpio);
                            worksheet.Columns().AdjustToContents();
                        }
                    }

                    var saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Archivo de Excel (*.xlsx)|*.xlsx",
                        Title = "Respaldo Completo de la Base de Datos",
                        FileName = $"RespaldoBaseDatos_Completo_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("¡Las 18 tablas de la base de datos se han exportado con éxito en pestañas separadas!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ImportarArticulosDesdeExcel()
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    openFileDialog.Title = "Seleccionar Excel de Artículos para Importar";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook(openFileDialog.FileName))
                        {
                            var worksheet = workbook.Worksheets.FirstOrDefault(w => w.Name == "Artículos") ?? workbook.Worksheet(1);

                            var rows = worksheet.RowsUsed().Skip(1); // Omitir cabecera
                            int contadorExitosos = 0;
                            int contadorOmitidos = 0;

                            var articuloL = new ArticuloL();

                            foreach (var row in rows)
                            {
                                try
                                {
                                    // Lectura segura de textos
                                    string codigo = row.Cell(1).Value.ToString().Trim();
                                    string nombre = row.Cell(2).Value.ToString().Trim();
                                    string marca = row.Cell(3).Value.ToString().Trim();
                                    string rubro = row.Cell(4).Value.ToString().Trim();

                                    // Lectura segura de números usando Double.TryParse o formato de texto
                                    decimal precio = ParsearDecimal(row.Cell(5).Value.ToString());
                                    int stock = ParsearEntero(row.Cell(6).Value.ToString());
                                    decimal costo = ParsearDecimal(row.Cell(7).Value.ToString());
                                    int stockMin = ParsearEntero(row.Cell(8).Value.ToString());
                                    decimal ganancia = ParsearDecimal(row.Cell(9).Value.ToString());
                                    decimal iva = ParsearDecimal(row.Cell(10).Value.ToString());

                                    if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre))
                                        continue;

                                    bool guardado = articuloL.GuardarProducto(codigo, nombre, stock, costo, precio, stockMin, iva, ganancia, marca, rubro);

                                    if (guardado) contadorExitosos++;
                                    else contadorOmitidos++;
                                }
                                catch
                                {

                                    contadorOmitidos++;
                                }
                            }

                            MessageBox.Show($"Importación finalizada.\n\n• Productos importados con éxito: {contadorExitosos}\n• Filas omitidas/duplicadas: {contadorOmitidos}",
                                "Resultado de Importación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo de Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static decimal ParsearDecimal(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return 0;
            // Normaliza puntos y comas para que acepte ambos formatos numéricos
            valor = valor.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                         .Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            decimal.TryParse(valor, out decimal resultado);
            return resultado;
        }

        private static int ParsearEntero(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor)) return 0;
            int.TryParse(valor, out int resultado);
            return resultado;
        }
    }
}

