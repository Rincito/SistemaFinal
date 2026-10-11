using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;
using System.Data;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class ArticulosP : Form
    {


        public event Action ActualizarDataGridViews;
        public event Action FormularioCerrado;
        private Dictionary<string, bool> ordenAscendente = new Dictionary<string, bool>();
        private List<Articulo> listaOriginal = new List<Articulo>();
        private bool buscarInactivos = false;

        private int paginaActual = 1;
        private int registrosPorPagina = 50;
        private int totalPaginas = 1;



        public ArticulosP()
        {
            InitializeComponent();
            this.KeyPreview = true;
            BusquedaTxtBox.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Show();
            CargarDatosPaginados();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AgregarArt formulario = new AgregarArt();
            dataGridView1.Visible = false;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel2.Controls.Add(formulario);
            formulario.FormularioCerrado += MostDgv;
            formulario.ActualizarDataGridViews += ActualizarDataGridView;
            formulario.Show();
        }
        private void ModArtBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                var articuloSeleccionado = filaSeleccionada.DataBoundItem as Articulo;

                if (articuloSeleccionado != null)
                {
                    if (articuloSeleccionado.Activo != 1)
                    {
                        MessageBox.Show("El artículo seleccionado no está activo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ModificarArt formulario = new ModificarArt(articuloSeleccionado);
                    formulario.ActualizarDataGridViews += ActualizarDataGridView;
                    formulario.FormularioCerrado += MostDgv;
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarDataGridView()
        {
            paginaActual = 1;
            CargarDatosPaginados();
        }
        private void BuscarArtBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    string codigo = filaSeleccionada.Cells["Codigo"].Value.ToString();
                    string nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    ArticuloL articuloL = new ArticuloL();
                    if (activo == 0)
                    {
                        bool exito = articuloL.DarDeAltaArticulo(codigo);

                        if (exito)
                        {
                            MessageBox.Show("El artículo se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listaOriginal = articuloL.ListarArticulos();
                            if (buscarInactivos)
                            {
                                var articulosInactivos = listaOriginal.Where(articulo => articulo.Activo != 1).ToList();
                                dataGridView1.DataSource = articulosInactivos;
                            }
                            else
                            {
                                var articulosActivos = listaOriginal.Where(articulo => articulo.Activo == 1).ToList();
                                dataGridView1.DataSource = articulosActivos;
                            }
                            ConfigurarColumnasDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar el artículo. Verifique la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("El artículo ya está activo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila para reactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal" + ex.Message, "Error");
            }
        }
        private void ConfigurarColumnasDataGridView()
        {
            if (dataGridView1.Columns["Ganancia"] != null)
                dataGridView1.Columns["Ganancia"].Visible = false;
            if (dataGridView1.Columns["Codigo"] != null)
                dataGridView1.Columns["Codigo"].Visible = false;
            if (dataGridView1.Columns["IVA"] != null)
                dataGridView1.Columns["IVA"].Visible = false;
            if (dataGridView1.Columns["StockMin"] != null)
                dataGridView1.Columns["StockMin"].Visible = false;
            if (dataGridView1.Columns["Activo"] != null)
                dataGridView1.Columns["Activo"].Visible = false;
            if (dataGridView1.Columns.Contains("Proveedor"))
                dataGridView1.Columns["Proveedor"].Visible = false;
            if (dataGridView1.Columns.Contains("NombreProveedor"))
                dataGridView1.Columns["NombreProveedor"].HeaderText = "Proveedor";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void BusquedaTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BusquedaTxtBox.Visible = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                BusquedaTxtBox.Visible = false;

            }
        }

        private void BuscarArtBtn_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void panel2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ReactArtBtn.PerformClick();
            }
        }

        private void DadosBaja_Click(object sender, EventArgs e)
        {
            buscarInactivos = true;
            paginaActual = 1;
            CargarDatosPaginados();
        }

        private void BusquedaTxtBox_Leave(object sender, EventArgs e)
        {
            BusquedaTxtBox.Visible = false;
        }

        private void ArticulosP_Load(object sender, EventArgs e)
        {

        }
        private void MostDgv()
        {
            dataGridView1.Visible = true;
            buscarInactivos = false;
            CargarDatosPaginados();

        }
        private void MostDgvInactivos()
        {
            dataGridView1.Visible = true;
            buscarInactivos = true;
            CargarDatosPaginados();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F5)
            {
                BuscarArtBtn_Click_1(e, e);
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var fila = dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (fila != null)
            {

                var tipoFila = fila.GetType();
                var valorActivo = tipoFila.GetProperty("Activo")?.GetValue(fila)?.ToString();

                if (!string.IsNullOrEmpty(valorActivo))
                {

                    if (valorActivo == "1")
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(204, 255, 255);
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 182);
                    }
                }
            }
        }

        private void StockActual_Click(object sender, EventArgs e)
        {
            buscarInactivos = false;
            paginaActual = 1;
            CargarDatosPaginados();
        }

        private void BajaArtBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    string codigo = filaSeleccionada.Cells["Codigo"].Value.ToString();
                    string nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    ArticuloL articuloL = new ArticuloL();
                    if (activo == 1)
                    {
                        DialogResult confirmacion = MessageBox.Show($"¿Está seguro de que desea dar de baja el artículo '{nombre}' (Código: {codigo})?",
                                                                     "Confirmar baja",
                                                                     MessageBoxButtons.YesNo,
                                                                     MessageBoxIcon.Warning);

                        if (confirmacion == DialogResult.Yes)
                        {
                            bool exito = articuloL.DarDeBajaArticulo(codigo);

                            if (exito)
                            {
                                MessageBox.Show("El artículo se dio de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                var articuloModificado = listaOriginal.FirstOrDefault(a => a.Codigo == codigo);
                                if (articuloModificado != null)
                                {
                                    articuloModificado.Activo = 0;
                                }
                                BusquedaTxtBox.Text = string.Empty;
                                buscarInactivos = false;
                                MostDgv();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo dar de baja el artículo. Verifique la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El artículo ya está dado de baja.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila para dar de baja.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal" + ex.Message, "Error");
            }
        }

        private void BuscarArtBtn_Click_1(object sender, EventArgs e)
        {
            BusquedaTxtBox.Text = "";
            BusquedaTxtBox.Visible = !BusquedaTxtBox.Visible;
            BusquedaTxtBox.Focus();
        }

        private void BuscarArtBtn_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                MostDgv();

            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (!ordenAscendente.ContainsKey(columnName))
            {
                ordenAscendente[columnName] = true;
            }

            if (dataGridView1.DataSource is List<Articulo> articulos && articulos.Count > 0)
            {
                bool ascending = ordenAscendente[columnName];
                articulos = ascending
                    ? articulos.OrderBy(a => a.GetType().GetProperty(columnName)?.GetValue(a)).ToList()
                    : articulos.OrderByDescending(a => a.GetType().GetProperty(columnName)?.GetValue(a)).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = articulos;
                ordenAscendente[columnName] = !ascending;
                ConfigurarColumnasDataGridView();
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                var articuloSeleccionado = filaSeleccionada.DataBoundItem as Articulo;

                if (articuloSeleccionado != null)
                {
                    if (articuloSeleccionado.Activo != 1)
                    {
                        MessageBox.Show("El artículo seleccionado no está activo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ModificarArt formulario = new ModificarArt(articuloSeleccionado);
                    formulario.ActualizarDataGridViews += ActualizarDataGridView;
                    formulario.FormularioCerrado += MostDgv;
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarDatosPaginados()
        {
            ArticuloL articuloL = new ArticuloL();

            // 1. Contar total para saber cuántas páginas hay
            int totalRegistros = articuloL.ObtenerTotalArticulos();
            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
            if (totalPaginas == 0) totalPaginas = 1;

            if (paginaActual > totalPaginas) paginaActual = totalPaginas;
            if (paginaActual < 1) paginaActual = 1;

            // 2. Traer solo los 50 de esta página
            listaOriginal = articuloL.ListarArticulosPaginados(paginaActual, registrosPorPagina);

            AplicarFiltroVisual();
            ActualizarControlesPaginacionUI();
        }

        private void AplicarFiltroVisual()
        {
            var listaBase = buscarInactivos
                ? listaOriginal.Where(a => a.Activo != 1).ToList()
                : listaOriginal.Where(a => a.Activo == 1).ToList();

            string filtro = BusquedaTxtBox.Text.Trim();
            if (!string.IsNullOrEmpty(filtro))
            {
                listaBase = listaBase.Where(a => a.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaBase;
            ConfigurarColumnasDataGridView();
        }

        private void ActualizarControlesPaginacionUI()
        {
            if (paginacionLbl != null)
            {
                paginacionLbl.Text = $"Página {paginaActual} de {totalPaginas}";
            }

            if (anteriorBtn != null) anteriorBtn.Enabled = (paginaActual > 1);
            if (siguienteBtn != null) siguienteBtn.Enabled = (paginaActual < totalPaginas);
        }

        private void ArticulosP_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BusquedaTxtBox_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroVisual();
        }

        private void siguienteBtn_Click(object sender, EventArgs e)
        {
            if (paginaActual < totalPaginas)
            {
                paginaActual++;
                CargarDatosPaginados();
            }
        }

        private void anteriorBtn_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarDatosPaginados();
            }
        }

        private void panelPaginacion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paginacionLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
