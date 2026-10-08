using SistemaFinal.Capa_Logica;
using System.Data;
using static SistemaFinal.Capa_Datos.MarcaD;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class AgregarMarca : Form
    {
        private bool datosModificados;
        private bool cerrarPorPerderFoco = true;
        private Dictionary<string, bool> ordenAscendente = new Dictionary<string, bool>();
        public AgregarMarca(Form padre)
        {
            this.Owner = padre;
            InitializeComponent();
            datosModificados = false;
            this.ShowInTaskbar = false;
            this.Deactivate += FormSecundario_Deactivate;
            NomMarcaTxtBox.TextChanged += NomMarcaTxtBox_TextChanged;
            MostDgv();
        }

        private void AgregarMarca_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        private void AgMarBtn_Click(object sender, EventArgs e)
        {
            cerrarPorPerderFoco = false;

            if (!string.IsNullOrWhiteSpace(NomMarcaTxtBox.Text))
            {
                GuardarDatos();
            }
            else
            {
                MessageBox.Show("Rellenar el campo de 'NOMBRE DE LA MARCA'");
                NomMarcaTxtBox.Focus();
            }

            cerrarPorPerderFoco = true;
        }
        private void FormSecundario_Deactivate(object sender, EventArgs e)
        {
            if (cerrarPorPerderFoco)
            {
                if (this.Owner != null && !this.Owner.Focused)
                {
                    if (datosModificados)
                    {
                        var result = MessageBox.Show(
                            "Tienes cambios sin guardar. ¿Deseas guardarlos antes de cerrar?",
                            "Confirmación",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            GuardarDatos();
                            this.Close();
                        }
                        else if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }
        private void MostDgv()
        {
            MarcaL marcaL = new MarcaL();
            dataGridView1.DataSource = marcaL.ListarMarcas();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GuardarDatos()
        {
            try
            {
                string nombreMarca = NomMarcaTxtBox.Text.Trim();
                MarcaL marcaL = new MarcaL();
                if (string.IsNullOrEmpty(nombreMarca))
                {
                    MessageBox.Show("El nombre de la marca no puede estar vacío.");
                    return;
                }
                if (marcaL.GuardarMarca(nombreMarca))
                {
                    MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NomMarcaTxtBox.Text = "";
                    datosModificados = false;
                    MostDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void NomMarcaTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }

        private void BajaMarcaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string marca = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);
                    MarcaL MarcaL = new MarcaL();
                    if (activo == 1)
                    {

                        bool exito = MarcaL.BajaMarca(marca, 0);

                        if (exito)
                        {
                            cerrarPorPerderFoco = false;
                            MostDgv();
                            MessageBox.Show("La marca se desactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NomMarcaTxtBox.Focus();
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo desactivar la marca. Puede que ya esté desactivada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La marca ya está dada de baja");
                        NomMarcaTxtBox.Focus();
                        cerrarPorPerderFoco = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal" + ex.Message, "Error");
            }
        }

        private void ReactMarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string marca = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);
                    MarcaL marcaL = new MarcaL();
                    if (activo == 0)
                    {

                        bool exito = marcaL.ReactMarca(marca, 0);

                        if (exito)
                        {
                            cerrarPorPerderFoco = false;
                            MostDgv();
                            MessageBox.Show("La marca se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NomMarcaTxtBox.Focus();
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar la marca. Puede que ya esté activada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La marca ya está activa");
                        NomMarcaTxtBox.Focus();
                        cerrarPorPerderFoco = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal" + ex.Message, "Error");
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (!ordenAscendente.ContainsKey(columnName))
            {
                ordenAscendente[columnName] = true;
            }
            if (dataGridView1.DataSource is List<Marca> marcas && marcas.Count > 0)
            {

                bool ascending = ordenAscendente[columnName];
                marcas = ascending
                    ? marcas.OrderBy(r => r.GetType().GetProperty(columnName)?.GetValue(r)).ToList()
                    : marcas.OrderByDescending(r => r.GetType().GetProperty(columnName)?.GetValue(r)).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = marcas;
                ordenAscendente[columnName] = !ascending;
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
            }
        }
    }
}

