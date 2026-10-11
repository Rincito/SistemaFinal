using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;
using System.Data;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class ClientesP : Form
    {

        public event Action ActualizarDataGridViews;
        public event Action FormularioCerrado;
        private Dictionary<string, bool> ordenAscendente = new Dictionary<string, bool>();
        private List<Cliente> listaOriginal = new List<Cliente>();

        private int paginaActual = 1;
        private int registrosPorPagina = 50;
        private int totalPaginas = 1;

        public ClientesP()
        {
            InitializeComponent();
            this.KeyPreview = true;
            BusquedaTxtBox.Visible = false;
            dataGridView1.Visible = true;
            dataGridView1.Show();
            CargarDatosPaginados();
        }
        private void MostDgv()
        {
            dataGridView1.Visible = true;
            paginaActual = 1;
            CargarDatosPaginados();

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F5)
            {
                BuscCliBtn_Click(e, e);
            }
        }
        private void ConfigurarColumnasDataGridView()
        {
            dataGridView1.Columns["CuenCo"].HeaderText = "Deuda";
            if (dataGridView1.Columns["CUILViejo"] != null)
                dataGridView1.Columns["CUILViejo"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ActualizarDataGridView()
        {
            paginaActual = 1;
            CargarDatosPaginados();
        }
        private void AgCliBtn_Click(object sender, EventArgs e)
        {
            AgregarCli formulario = new AgregarCli();
            dataGridView1.Visible = false;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panel2.Controls.Add(formulario);
            formulario.ActualizarDataGridViews += ActualizarDataGridView;
            formulario.FormularioCerrado += MostDgv;
            formulario.Show();
        }
        private void CargarDatosPaginados()
        {
            ClienteL clienteL = new ClienteL();

            // 1. Obtener total de registros para calcular las páginas
            int totalRegistros = clienteL.ObtenerTotalClientes(); // O tu método equivalente en ClienteL
            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
            if (totalPaginas == 0) totalPaginas = 1;

            if (paginaActual > totalPaginas) paginaActual = totalPaginas;
            if (paginaActual < 1) paginaActual = 1;

            listaOriginal = clienteL.ListarClientesPaginados(paginaActual, registrosPorPagina);

            AplicarFiltroVisual();
            ActualizarControlesPaginacionUI();
        }

        private void AplicarFiltroVisual()
        {
            var listaBase = listaOriginal
                .Where(cliente => !string.IsNullOrEmpty(cliente.Nombre))
                .ToList();

            string filtro = BusquedaTxtBox.Text.Trim();
            if (!string.IsNullOrEmpty(filtro))
            {
                listaBase = listaBase.Where(cliente => cliente.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaBase;
            ConfigurarColumnasDataGridView();
        }

        private void ActualizarControlesPaginacionUI()
        {
            // Asumiendo que tenés la etiqueta y los botones con los mismos nombres
            if (paginacionLbl != null)
            {
                paginacionLbl.Text = $"Página {paginaActual} de {totalPaginas}";
            }

            if (anteriorBtn != null) anteriorBtn.Enabled = (paginaActual > 1);
            if (siguienteBtn != null) siguienteBtn.Enabled = (paginaActual < totalPaginas);
        }

        private void ModCliBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                var clienteSeleccionado = filaSeleccionada.DataBoundItem as Cliente;

                if (clienteSeleccionado != null)
                {
                    if (clienteSeleccionado.Nombre == null)
                    {
                        MessageBox.Show("El cliente seleccionado no tiene un nombre definido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ModificarCli formulario = new ModificarCli(clienteSeleccionado);
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

        private void CliActBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                var clienteSeleccionado = filaSeleccionada.DataBoundItem as Cliente;

                if (clienteSeleccionado != null)
                {
                    if (clienteSeleccionado.Nombre == null)
                    {
                        MessageBox.Show("El cliente seleccionado no tiene un nombre definido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    PagoCuenCo formulario = new PagoCuenCo(clienteSeleccionado);
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

        private void BusquedaTxtBox_TextChanged(object sender, EventArgs e)
        {
            string filtro = BusquedaTxtBox.Text.Trim();
            var clientesFiltrados = listaOriginal
     .Where(cliente => cliente.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase))
     .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientesFiltrados;
            ConfigurarColumnasDataGridView();
        }

        private void BuscCliBtn_Click(object sender, EventArgs e)
        {
            BusquedaTxtBox.Text = "";
            BusquedaTxtBox.Visible = !BusquedaTxtBox.Visible;
            BusquedaTxtBox.Focus();
        }

        private void BuscCliBtn_KeyDown(object sender, KeyEventArgs e)
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

            if (dataGridView1.DataSource is List<Cliente> clientes && clientes.Count > 0)
            {
                bool ascending = ordenAscendente[columnName];
                clientes = ascending
                    ? clientes.OrderBy(a => a.GetType().GetProperty(columnName)?.GetValue(a)).ToList()
                    : clientes.OrderByDescending(a => a.GetType().GetProperty(columnName)?.GetValue(a)).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = clientes;
                ordenAscendente[columnName] = !ascending;
                ConfigurarColumnasDataGridView();
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void panel2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                BuscCliBtn.PerformClick();
            }
        }

        private void BusquedaTxtBox_Leave(object sender, EventArgs e)
        {
            BusquedaTxtBox.Visible = false;
        }

        private void ClientesP_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                var clienteSeleccionado = filaSeleccionada.DataBoundItem as Cliente;

                if (clienteSeleccionado != null)
                {
                    ModificarCli formulario = new ModificarCli(clienteSeleccionado);
                    formulario.FormularioCerrado += MostDgv;
                    formulario.ActualizarDataGridViews += ActualizarDataGridView;
                    formulario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
    }
}
