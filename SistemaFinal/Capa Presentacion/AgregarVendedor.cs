using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;
using System.Data;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class AgregarVendedor : Form
    {
        private bool datosModificados;
        private bool cerrarPorPerderFoco = true;
        private Dictionary<string, bool> ordenAscendente = new Dictionary<string, bool>();
        public AgregarVendedor(Form padre)
        {
            this.Owner = padre;
            InitializeComponent();
            datosModificados = false;
            this.ShowInTaskbar = false;
            NomVenTxtBox.TextChanged += NomProvTxtBox_TextChanged;
            TelTxtBox.TextChanged += TelTxtBox_TextChanged;
            DomTxtBox.TextChanged += EmailTxtBox_TextChanged;
            CUILTxtBox.TextChanged += CUILTxtBox_TextChanged;
            ApeTxtBox.TextChanged += ApeTxtBox_TextChanged;
            MostDgv();
        }

        private void AgregarVendedor_Load(object sender, EventArgs e)
        {
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }
        private void MostDgv()
        {
            VendedorL datosL = new VendedorL();
            var listaVendedores = datosL.ListarVendedores().Where(v => v.CUIL != "1").ToList();
            dataGridView1.DataSource = listaVendedores;
            if (dataGridView1.Columns["Activo"] != null)
            {
                dataGridView1.Columns["Activo"].Visible = false;
            }
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


        private void GuardarDatos()
        {
            try
            {
                cerrarPorPerderFoco = false;
                string cuil = CUILTxtBox.Text.Trim();
                string nombre = NomVenTxtBox.Text.Trim();
                string apellido = ApeTxtBox.Text.Trim();
                string telefono = TelTxtBox.Text.Trim();
                string domicilio = DomTxtBox.Text.Trim();
                string email = emailTxtBox.Text.Trim();


                if (string.IsNullOrEmpty(cuil))
                {
                    MessageBox.Show("El CUIL no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CUILTxtBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NomVenTxtBox.Focus();
                    return;
                }


                VendedorL datosL = new VendedorL();

                if (datosL.GuardarVendedor(new Vendedor
                {
                    CUIL = cuil,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono,
                    Domicilio = domicilio,
                    Email = email,
                    Activo = 1
                }))
                {
                    MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CUILTxtBox.Text = "";
                    NomVenTxtBox.Text = "";
                    ApeTxtBox.Text = "";
                    TelTxtBox.Text = "";
                    DomTxtBox.Text = "";
                    emailTxtBox.Text = "";
                    datosModificados = false;
                    CUILTxtBox.Focus();
                    cerrarPorPerderFoco = true;
                    MostDgv();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NomProvTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }

        private void TelTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }

        private void EmailTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }


        private void AgregarProveedor_Deactivate(object sender, EventArgs e)
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

        private void CancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CUILTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }

        private void ApeTxtBox_TextChanged(object sender, EventArgs e)
        {
            datosModificados = true;
        }

        private void AgVenBtn_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (!ordenAscendente.ContainsKey(columnName))
            {
                ordenAscendente[columnName] = true;
            }
            if (dataGridView1.DataSource is List<Vendedor> vendedores && vendedores.Count > 0)
            {
                dataGridView1.DataSource = null;

                bool ascending = ordenAscendente[columnName];
                var vendedoresOrdenados = ascending
                    ? vendedores.OrderBy(v => v.GetType().GetProperty(columnName)?.GetValue(v)).ToList()
                    : vendedores.OrderByDescending(v => v.GetType().GetProperty(columnName)?.GetValue(v)).ToList();

                dataGridView1.DataSource = vendedoresOrdenados;
                ordenAscendente[columnName] = !ascending;
                dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
                if (dataGridView1.Columns["Activo"] != null)
                {
                    dataGridView1.Columns["Activo"].Visible = false;
                }

            }
        }

        private void BajaVenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string cuil = Convert.ToString(filaSeleccionada.Cells["CUIL"].Value);
                    string nombre = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);
                    string apellido = Convert.ToString(filaSeleccionada.Cells["Apellido"].Value);
                    VendedorL vendedorL = new VendedorL();
                    if (activo == 1)
                    {
                        bool exito = vendedorL.BajaVendedor(cuil, 0);

                        if (exito)
                        {
                            MostDgv();
                            MessageBox.Show($"El vendedor {nombre} {apellido} se desactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo desactivar el vendedor. Puede que ya esté desactivado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"El vendedor {nombre} {apellido} ya está dado de baja.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un vendedor de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReactVenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cerrarPorPerderFoco = false;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    int activo = Convert.ToInt32(filaSeleccionada.Cells["Activo"].Value);
                    string cuil = Convert.ToString(filaSeleccionada.Cells["CUIL"].Value);
                    string nombre = Convert.ToString(filaSeleccionada.Cells["Nombre"].Value);
                    string apellido = Convert.ToString(filaSeleccionada.Cells["Apellido"].Value);
                    VendedorL vendedorL = new VendedorL();
                    if (activo == 0)
                    {
                        bool exito = vendedorL.ReactivarVendedor(cuil, 1);
                        if (exito)
                        {
                            MostDgv();
                            MessageBox.Show($"El vendedor {nombre} {apellido} se reactivó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cerrarPorPerderFoco = true;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo reactivar el vendedor. Puede que ya esté activo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"El vendedor {nombre} {apellido} ya está activo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un vendedor de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo ha salido mal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModVenBtn_Click(object sender, EventArgs e)
        {
            cerrarPorPerderFoco = false;
            string nombre = NomVenTxtBox.Text.Trim();
            string apellido = ApeTxtBox.Text.Trim();
            string telefono = TelTxtBox.Text.Trim();
            string domicilio = DomTxtBox.Text.Trim();
            string email = emailTxtBox.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NomVenTxtBox.Focus();
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un vendedor para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];
            string cuil = Convert.ToString(selectedRow.Cells["CUIL"].Value);

            if (string.IsNullOrEmpty(cuil))
            {
                MessageBox.Show("El CUIL del vendedor seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VendedorL datosL = new VendedorL();
            if (datosL.ActualizarVendedor(cuil, nombre, apellido, telefono, domicilio, email))
            {
                MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CUILTxtBox.Text = "";
                NomVenTxtBox.Text = "";
                ApeTxtBox.Text = "";
                TelTxtBox.Text = "";
                DomTxtBox.Text = "";
                CUILTxtBox.Text = "";
                emailTxtBox.Text = "";
                datosModificados = false;
                cerrarPorPerderFoco = true;
                MostDgv();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                NomVenTxtBox.Text = row.Cells["Nombre"].Value.ToString();
                ApeTxtBox.Text = row.Cells["Apellido"].Value.ToString();
                TelTxtBox.Text = row.Cells["Telefono"].Value.ToString();
                DomTxtBox.Text = row.Cells["Domicilio"].Value.ToString();
                CUILTxtBox.Text = row.Cells["CUIL"].Value.ToString();
                emailTxtBox.Text = row.Cells["Email"].Value.ToString();
            }
        }
    }
}
