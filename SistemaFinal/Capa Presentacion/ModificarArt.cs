using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class ModificarArt : Form
    {
        private bool datosModificados;
        private bool cerrarPorPerderFoco = true;

        public ModificarArt(Articulo articulo)
        {
            InitializeComponent();
            datosModificados = false;
            this.ShowInTaskbar = false;
            this.Deactivate += ModificarArt_Deactivate;
            CargarComboBoxMarcas();
            CargarComboBoxProveedores();
            CargarComboBoxRubros();
            CargarDatosArticulo(articulo);
        }
        public event Action FormularioCerrado;
        public event Action ActualizarDataGridViews;

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarComboBoxRubros()
        {
            try
            {
                ArticuloL articuloL = new ArticuloL();
                List<string> listaRubros = articuloL.ObtenerListaRubros();

                RubComBox.DataSource = null;
                RubComBox.DataSource = listaRubros;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los rubros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboBoxMarcas()
        {
            try
            {
                ArticuloL articuloL = new ArticuloL();
                List<string> listaMarcas = articuloL.ObtenerListaMarcas();

                MarcComBox.DataSource = null;
                MarcComBox.DataSource = listaMarcas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las marcas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboBoxProveedores()
        {
            try
            {
                ArticuloL articuloL = new ArticuloL();
                List<string> listaProveedores = articuloL.ObtenerListaProvs();

                ProvComBox.DataSource = null;
                ProvComBox.DataSource = listaProveedores;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarDatosArticulo(Articulo articulo)
        {
            if (articulo != null)
            {


                CodTxtBox.Text = articulo.Codigo;
                NomTxtBox.Text = articulo.Nombre;
                PrecTxtBox.Text = articulo.Precio.ToString("F2");
                StockTxtBox.Text = articulo.Stock.ToString();
                CostTxtBox.Text = articulo.Costo.ToString("F2");
                StockCritTxtBox.Text = articulo.StockMin.ToString();
                GanTxtBox.Text = articulo.Ganancia.ToString("F2");
                IVATxtBox.Text = articulo.IVA.ToString("F2");
                if (ProvComBox.DataSource != null)
                {
                    ProvComBox.SelectedItem = articulo.NombreProveedor;
                    MarcComBox.SelectedItem = articulo.Marca;
                    RubComBox.SelectedItem = articulo.Rubro;
                }


            }
        }
        private void ModificarArt_Load(object sender, EventArgs e)
        {

        }

        private void PrecTxtBox_TextChanged(object sender, EventArgs e)
        {
            ActualizarGanancia();
        }
        private void GuardarDatos()
        {
            Articulo art = new Articulo();
            art.Codigo = CodTxtBox.Text;
            art.Nombre = NomTxtBox.Text;
            art.Precio = decimal.Parse(PrecTxtBox.Text);
            art.Stock = int.Parse(StockTxtBox.Text);
            art.Costo = decimal.Parse(CostTxtBox.Text);
            art.StockMin = int.Parse(StockCritTxtBox.Text);
            art.Ganancia = decimal.Parse(GanTxtBox.Text);
            art.IVA = decimal.Parse(IVATxtBox.Text);
            if (!string.IsNullOrWhiteSpace(MarcComBox.Text))
            {
                art.Marca = MarcComBox.Text;
            }
            else
            {
                MessageBox.Show("Selecciona una marca válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(RubComBox.Text))
            {
                art.Rubro = RubComBox.Text;
            }
            else
            {
                MessageBox.Show("Selecciona un rubro válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ProvComBox.SelectedIndex == -1 || ProvComBox.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un proveedor válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ArticuloD articulo = new ArticuloD();
            string proveedorNombre = ProvComBox.SelectedItem.ToString();
            int proveedorID = articulo.ObtenerIDProveedorPorNombre(proveedorNombre);

            if (proveedorID == -1)
            {
                MessageBox.Show("Proveedor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            art.Proveedor = proveedorID;


            var articuloL = new ArticuloL();
            bool exito = articuloL.ActualizarArticulo(art, art.Codigo);

            if (exito)
            {
                MessageBox.Show("Artículo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarDataGridViews?.Invoke();
                FormularioCerrado?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ModificarArt_Deactivate(object sender, EventArgs e)
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
                            ActualizarDataGridViews?.Invoke();
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

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }

        private void ProvComBox_DisplayMemberChanged(object sender, EventArgs e)
        {

        }

        private void ProvComBox_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void GanTxtBox_TextChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void IVATxtBox_TextChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
            ActualizarGanancia();
        }

        private void CostTxtBox_TextChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
            ActualizarGanancia();

        }
        private void ActualizarPrecio()
        {
            if (decimal.TryParse(CostTxtBox.Text, out decimal costo) &&
             decimal.TryParse(IVATxtBox.Text, out decimal iva) &&
             decimal.TryParse(GanTxtBox.Text, out decimal ganancia))
            {

                decimal precio = costo + (costo * (iva / 100)) + (costo * (ganancia / 100));


                PrecTxtBox.TextChanged -= PrecTxtBox_TextChanged;


                PrecTxtBox.Text = precio.ToString("F2");


                PrecTxtBox.TextChanged += PrecTxtBox_TextChanged;
            }
            else
            {

                PrecTxtBox.TextChanged -= PrecTxtBox_TextChanged;
                PrecTxtBox.Text = "";
                PrecTxtBox.TextChanged += PrecTxtBox_TextChanged;
            }
        }
        private void ActualizarGanancia()
        {
            if (decimal.TryParse(CostTxtBox.Text, out decimal costo) &&
                decimal.TryParse(IVATxtBox.Text, out decimal iva) &&
                decimal.TryParse(PrecTxtBox.Text, out decimal precio))
            {

                decimal ganancia = ((precio - (costo + (costo * (iva / 100)))) / costo) * 100;
                GanTxtBox.TextChanged -= GanTxtBox_TextChanged;
                GanTxtBox.Text = ganancia.ToString("F2");
                GanTxtBox.TextChanged += GanTxtBox_TextChanged;
            }
        }

        private void AuMinTxtBox_Leave(object sender, EventArgs e)
        {
            try
            {
                int sumres = Convert.ToInt32(AuMinTxtBox.Text);

                int stockactual = Convert.ToInt32(StockTxtBox.Text);
                stockactual = stockactual + sumres;
                StockTxtBox.Text = stockactual.ToString();

            }
            catch
            {
                MessageBox.Show("Coloque un valor válido en el campo (si no desea sumar ni restar al stock coloque 0)");
                AuMinTxtBox.Focus();
            }


        }
    }
}
