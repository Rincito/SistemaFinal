using SistemaFinal.Capa_Logica;
using System.Data;
using static SistemaFinal.Capa_Datos.MarcaD;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class AgregarTarjeta: Form
    {
        private bool datosModificados;
        private bool cerrarPorPerderFoco = true;
        private Dictionary<string, bool> ordenAscendente = new Dictionary<string, bool>();
        public AgregarTarjeta(Form padre)
        {
            InitializeComponent();
            this.Owner = padre;
            datosModificados = false;
            this.ShowInTaskbar = false;
            this.Deactivate += AgregarTarjeta_Deactivate;
            NomTarjTxtBox.TextChanged += NomTarjTxtBox_TextChanged;
            MostDgv();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarTarjeta_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
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

        private void AgTarjBtn_Click(object sender, EventArgs e)
        {
            cerrarPorPerderFoco = false;
            if (!string.IsNullOrWhiteSpace(NomTarjTxtBox.Text))
            {
                GuardarDatos();
            }
            else
            {
                MessageBox.Show("Rellenar el campo de 'NOMBRE DE LA TARJETA'");
                NomTarjTxtBox.Focus();
            }

            cerrarPorPerderFoco = true;

        }

        private void AgregarTarjeta_Deactivate(object sender, EventArgs e)
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
            TarjetaL tarjetaL = new TarjetaL();
            dataGridView1.DataSource = tarjetaL.ListarTarjetas();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void NomTarjTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }
        private void GuardarDatos()
        {
            try
            {
                string nombreTarjeta = NomTarjTxtBox.Text.Trim();
                TarjetaL tarjetaL = new TarjetaL();

                if (string.IsNullOrEmpty(nombreTarjeta))
                {
                    MessageBox.Show("El nombre de la tarjeta no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tarjetaL.GuardarTarjeta(nombreTarjeta))
                {
                    MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NomTarjTxtBox.Text = "";
                    datosModificados = false;
                    MostDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BajaTarjBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string tarjeta = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);

                    TarjetaL tarjetaL = new TarjetaL();

                    if (activo == 1)
                    {

                        bool exito = tarjetaL.BajaTarjeta(tarjeta, 0);

                        if (exito)
                        {
                            cerrarPorPerderFoco = false;
                            MostDgv();
                            MessageBox.Show("La tarjeta se desactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NomTarjTxtBox.Focus();
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo desactivar la tarjeta. Puede que ya esté desactivada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La tarjeta ya está dada de baja.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NomTarjTxtBox.Focus();
                        cerrarPorPerderFoco = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReactTarjBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string tarjeta = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);

                    TarjetaL tarjetaL = new TarjetaL();

                    if (activo == 0)
                    {
                        bool exito = tarjetaL.ReactTarjeta(tarjeta);

                        if (exito)
                        {
                            cerrarPorPerderFoco = false;
                            MostDgv();
                            MessageBox.Show("La tarjeta se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            NomTarjTxtBox.Focus();
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar la tarjeta. Puede que ya esté activa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La tarjeta ya está activa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NomTarjTxtBox.Focus();
                        cerrarPorPerderFoco = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
