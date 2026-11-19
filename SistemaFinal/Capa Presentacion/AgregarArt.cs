using SistemaFinal.Capa_Logica;
using SistemaFinal.Estilos;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class AgregarArt : Form
    {
        public AgregarArt()
        {
            InitializeComponent();
            Tema.AplicarEstructura(this, esFormHijo: false);
            CostTxtBox.TextChanged += CostTxtBox_TextChanged;
            IVATxtBox.TextChanged += IVATxtBox_TextChanged;
            PrecTxtBox.TextChanged += PrecTxtBox_TextChanged;
            GananciaTxtBox.TextChanged += GananciaTxtBox_TextChanged;
            IVATxtBox.Text = "21";
            GananciaTxtBox.Text = "100";

        }
        public event Action FormularioCerrado;
        public event Action ActualizarDataGridViews;
        private void CargarComboBoxRubros()
        {
            try
            {
                ArticuloL articuloL = new ArticuloL();
                List<string> listaRubros = articuloL.ObtenerListaRubros();

                RubroComBox.DataSource = null;
                RubroComBox.DataSource = listaRubros;
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

                MarcCombBox.DataSource = null;
                MarcCombBox.DataSource = listaMarcas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las marcas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            ActualizarDataGridViews?.Invoke();
            FormularioCerrado?.Invoke();
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AgregarArt_Load(object sender, EventArgs e)
        {
            CargarComboBoxRubros();
            CargarComboBoxMarcas();
        }

        private void ProvComBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {

                string codigo = CodTxtBox.Text.Trim();
                string nombre = NomTxtBox.Text.Trim();
                int stock = 0;
                decimal costo = 0, precio = 0, ganancia = 0;
                int stockCritico = 0;
                decimal iva = 0;
                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("El código no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CodTxtBox.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(nombre))
                {
                    MessageBox.Show("El nombre no puede estar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NomTxtBox.Focus();
                    return;
                }

                if (!int.TryParse(StockTxtBox.Text.Trim(), out stock) || stock < 0)
                {
                    MessageBox.Show("Ingrese un valor válido para el stock.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    StockTxtBox.Focus();
                    return;
                }
                if (!decimal.TryParse(CostTxtBox.Text.Trim(), out costo) || costo < 0)
                {
                    MessageBox.Show("Ingrese un valor válido para el costo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CostTxtBox.Focus();
                    return;
                }
                if (!decimal.TryParse(PrecTxtBox.Text.Trim(), out precio) || precio < 0)
                {
                    MessageBox.Show("Ingrese un valor válido para el precio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PrecTxtBox.Focus();
                    return;
                }
                if (!int.TryParse(StockCritTxtBox.Text.Trim(), out stockCritico) || stockCritico < 0)
                {
                    MessageBox.Show("Ingrese un valor válido para el stock crítico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    StockCritTxtBox.Focus();
                    return;
                }
                if (!decimal.TryParse(IVATxtBox.Text.Trim(), out iva) || iva < 0 || iva > 100)
                {
                    MessageBox.Show("Ingrese un valor válido para el IVA (0-100).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    IVATxtBox.Focus();
                    return;
                }
                if (!decimal.TryParse(GananciaTxtBox.Text.Trim(), out ganancia) || ganancia < 0)
                {
                    MessageBox.Show("Ingrese un valor válido para la ganancia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GananciaTxtBox.Focus();
                    return;
                }


                string marca = MarcCombBox.SelectedItem?.ToString() ?? "";
                string rubro = RubroComBox.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(rubro))
                {
                    MessageBox.Show("Debe seleccionar una opción válida para Marca, Rubro y Proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ArticuloL productoL = new ArticuloL();
                bool resultado = productoL.GuardarProducto(codigo, nombre, stock, costo, precio, stockCritico, iva, ganancia, marca, rubro);
                if (resultado)
                {
                    MessageBox.Show("El artículo se agregó correctamente.");
                    CodTxtBox.Text = "";
                    NomTxtBox.Text = "";
                    PrecTxtBox.Text = "";
                    IVATxtBox.Text = "21";
                    StockTxtBox.Text = "";
                    CostTxtBox.Text = "";
                    GananciaTxtBox.Text = "";
                    StockCritTxtBox.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el artículo.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al capturar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GananciaTxtBox_TextChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();

        }

        private void IVATxtBox_TextChanged(object sender, EventArgs e)
        {
            ActualizarPrecio();
            ActualizarGanancia();
        }

        private void PrecTxtBox_TextChanged(object sender, EventArgs e)
        {
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
             decimal.TryParse(GananciaTxtBox.Text, out decimal ganancia))
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
                GananciaTxtBox.TextChanged -= GananciaTxtBox_TextChanged;
                GananciaTxtBox.Text = ganancia.ToString("F2");
                GananciaTxtBox.TextChanged += GananciaTxtBox_TextChanged;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


