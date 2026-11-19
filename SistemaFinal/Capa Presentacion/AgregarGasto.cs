using SistemaFinal.Capa_Logica;
using SistemaFinal.Estilos;
using System.Data;
using static SistemaFinal.Capa_Datos.RubroD;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class AgregarGasto : Form
    {
        private bool datosModificados;
        private bool cerrarPorPerderFoco = true;
        private Dictionary<string, bool> ordenAscendente = new Dictionary<string, bool>();
        public AgregarGasto(Form padre)
        {
            this.Owner = padre;
            InitializeComponent();
            Tema.AplicarEstructura(this, esFormHijo: false);
            datosModificados = false;
            this.ShowInTaskbar = false;
            this.Deactivate += FormSecundario_Deactivate;
            NomRubTxtBox.TextChanged += NomRubTxtBox_TextChanged;
            MostDgv();
        }

        private void AgregarRubro_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
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
            GastoL rubroL = new GastoL();
            dataGridView1.DataSource = rubroL.ListarGastos();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NomRubTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }

        private void GuardarDatos()
        {
            try
            {
                string nombreRubro = NomRubTxtBox.Text.Trim();
                GastoL rubroL = new GastoL();
                if (string.IsNullOrEmpty(nombreRubro))
                {
                    MessageBox.Show("El nombre del gasto no puede estar vacío.");
                    return;
                }
                if (rubroL.GuardarGasto(nombreRubro))
                {
                    MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NomRubTxtBox.Text = "";
                    datosModificados = false;
                    MostDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void AgRubBtn_Click(object sender, EventArgs e)
        {
            cerrarPorPerderFoco = false;

            if (!string.IsNullOrWhiteSpace(NomRubTxtBox.Text))
            {
                GuardarDatos();
            }
            else
            {
                MessageBox.Show("Rellenar el campo de 'NOMBRE DEL GASTO'");
                NomRubTxtBox.Focus();
            }

            cerrarPorPerderFoco = true;


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

        private void BajaRubroBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string rubro = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);
                    GastoL rubroL = new GastoL();
                    if (activo == 1)
                    {

                        bool exito = rubroL.BajaGasto(rubro, 0);

                        if (exito)
                        {
                            cerrarPorPerderFoco = false;
                            filaSeleccionada.Cells["Activo"].Value = 0;
                            MostDgv();
                            MessageBox.Show("El gasto se desactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NomRubTxtBox.Focus();
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo desactivar el gasto. Puede que ya esté desactivado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El gasto ya está dado de baja");
                        NomRubTxtBox.Focus();
                        cerrarPorPerderFoco = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal" + ex.Message, "Error");
            }
        }

        private void ReactRubBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string rubro = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);
                    GastoL rubroL = new GastoL();
                    if (activo == 0)
                    {

                        bool exito = rubroL.ReactGasto(rubro, 0);

                        if (exito)
                        {
                            cerrarPorPerderFoco = false;
                            MostDgv();
                            MessageBox.Show("El gasto se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NomRubTxtBox.Focus();
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar el gasto. Puede que ya esté activado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (activo == 1)
                    {
                        MessageBox.Show("El gasto ya está activo");
                        NomRubTxtBox.Focus();
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
            if (dataGridView1.DataSource is List<Gasto> gastos && gastos.Count > 0)
            {

                bool ascending = ordenAscendente[columnName];
                gastos = ascending
                    ? gastos.OrderBy(r => r.GetType().GetProperty(columnName)?.GetValue(r)).ToList()
                    : gastos.OrderByDescending(r => r.GetType().GetProperty(columnName)?.GetValue(r)).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = gastos;
                ordenAscendente[columnName] = !ascending;
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
