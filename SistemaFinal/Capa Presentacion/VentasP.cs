using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;
using SistemaFinal.Capa_Presentacion;
using System.Data;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class VentasP : Form
    {
        private bool actualizandoCombos = false;
        public VentasP()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(VentasP_KeyPress);
            TxtBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            TxtBoxTotal.Text = "$0,00";
            this.KeyPreview = true;
            SistemaFinal.Estilos.Tema.AplicarEstiloVentasP(this);
        }
        private List<Articulo> listaActual = new List<Articulo>();

        private List<Articulo> articulos = new List<Articulo>();
        public bool Completo;

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargaInicial();
        }

        private void CargaInicial()
        {
            string vendedores = "";
            VentasL ventaL = new VentasL();
            var vend = ventaL.ObtenerVendedores(vendedores);

            var VendFiltrado = vend
            .Where(m => m.Activo == 1)
            .ToList();
            if (VendFiltrado.Any())
            {
                VendComBox.DisplayMember = "Nombre";
                VendComBox.ValueMember = "CUIL";
                VendComBox.DataSource = VendFiltrado;
            }
            else
            {
                MessageBox.Show($"No se encontraron datos en la tabla {vendedores}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string clientes = "";
            var cli = ventaL.ObtenerClientes(clientes);

            if (cli.Any())
            {
                CliComBox.DisplayMember = "Nombre";
                CliComBox.ValueMember = "CUIL";
                CliComBox.DataSource = cli;
            }
            else
            {
                MessageBox.Show($"No se encontraron datos en la tabla {clientes}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string metodos = "";
            var met = ventaL.ObtenerMetodos(metodos);

            if (met.Any())
            {
                CondPagoComBox.DisplayMember = "Nombre";
                CondPagoComBox.ValueMember = "Nombre";
                CondPagoComBox.DataSource = met;
            }
            else
            {
                MessageBox.Show($"No se encontraron datos en la tabla {metodos}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TxtBoxFact.Text = ventaL.ObtenerProximoNumeroFactura().ToString();
            CondIva.Text = "Consumidor Final";
            PanelArts.Visible = false;
            DGVArts.Visible = false;
            panel1.Focus();

            actualizandoCombos = true;
            try
            {

                int indexNA = CliComBox.FindStringExact("N/A");
                if (indexNA >= 0)
                    CliComBox.SelectedIndex = indexNA;

                string metodoInicial = (CondPagoComBox.SelectedItem?.ToString() ?? CondPagoComBox.Text).Trim();
                CliComBox.Enabled = metodoInicial.Equals("Cuenta Corriente", StringComparison.OrdinalIgnoreCase);
            }
            finally
            {
                actualizandoCombos = false;
            }
        }

        private void VendComBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void MostDgv()
        {
            DGVArts.Visible = true;
            ArticuloL datosL = new ArticuloL();
            articulos = datosL.ListarArticulos();

            var articulosActivos = articulos.Where(articulo => articulo.Activo == 1).ToList();

            DGVArts.DataSource = null;
            DGVArts.DataSource = articulosActivos;

            ConfigurarColumnasDataGridView();


        }
        private void ConfigurarColumnasDataGridView()
        {
            if (DGVArts.Columns["Ganancia"] != null)
                DGVArts.Columns["Ganancia"].Visible = false;
            if (DGVArts.Columns["IVA"] != null)
                DGVArts.Columns["IVA"].Visible = false;
            if (DGVArts.Columns["StockMin"] != null)
                DGVArts.Columns["StockMin"].Visible = false;
            if (DGVArts.Columns["Activo"] != null)
                DGVArts.Columns["Activo"].Visible = false;
            if (DGVArts.Columns.Contains("Proveedor"))
                DGVArts.Columns["Proveedor"].Visible = false;
            if (DGVArts.Columns.Contains("NombreProveedor"))
                DGVArts.Columns["NombreProveedor"].Visible = false;
            if (DGVArts.Columns["Costo"] != null)
                DGVArts.Columns["Costo"].Visible = false;
            if (DGVArts.Columns["Rubro"] != null)
                DGVArts.Columns["Rubro"].Visible = false;


            DGVArts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void panel1_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (PanelArts.Visible == false && e.KeyCode == Keys.F5)
            {
                TxtBoxBusq_Click(e, e);
            }
            else
            {
                PanelArts.Visible = false;
                DGVArts.Visible = false;

            }
            if (PanelArts.Visible == false && e.KeyCode == Keys.Enter)
            {
                AceptBtn.PerformClick();
            }
            if (PanelArts.Visible == false && e.KeyCode == Keys.Oem2)
            {
                PrecBtn.PerformClick();
            }

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F5)
            {
                TxtBoxBusq_Click(this, EventArgs.Empty);
                e.Handled = true;
            }

            base.OnKeyDown(e);


        }


        private void TxtBoxBusq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                PanelArts.Visible = false;
                DGVArts.Visible = false;
            }
        }

        private void TxtBoxBusq_Leave(object sender, EventArgs e)
        {

        }

        private void PanelArts_Leave(object sender, EventArgs e)
        {
            PanelArts.Visible = false;
            DGVArts.Visible = false;
        }

        private void TxtBoxBusq_TextChanged(object sender, EventArgs e)
        {
            string filtro = TxtBoxBusq.Text.Trim();
            var listaFiltrada = articulos
       .Where(articulo => articulo.Activo == 1)
       .Where(articulo => articulo.Nombre.Contains(filtro, StringComparison.OrdinalIgnoreCase))
       .ToList();


            if (listaFiltrada.Count == 0 && !string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = articulos.Where(articulo => articulo.Activo == 1).ToList();
            }


            if (DGVArts.DataSource != listaFiltrada)
            {
                DGVArts.DataSource = listaFiltrada;
                ConfigurarColumnasDataGridView();
            }
        }
        private void ActualizarDataGridView()
        {
            ArticuloL datosL = new ArticuloL();
            listaActual = datosL.ListarArticulos().Where(articulo => articulo.Activo == 1).ToList();


            DGVArts.DataSource = listaActual;
            ConfigurarColumnasDataGridView();
        }

        private void TxtBoxBusq_Click(object sender, EventArgs e)
        {
            TxtBoxBusq.Clear();
            PanelArts.Visible = true;
            DGVArts.Visible = true;
            MostDgv();
            TxtBoxBusq.Focus();
        }

        private void PanelArts_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;

            }
        }
        private void AgregarFilaACarrito(int rowIndex)
        {

            if (rowIndex < 0 || rowIndex >= DGVArts.Rows.Count)
            {
                MessageBox.Show("Índice de fila no válido.");
                return;
            }
            var fila = DGVArts.Rows[rowIndex];
            List<string> valoresFila = new List<string>();
            foreach (DataGridViewCell cell in fila.Cells)
            {
                valoresFila.Add(cell.Value?.ToString() ?? "");
            }

            if (valoresFila.All(valor => string.IsNullOrEmpty(valor)))
            {
                MessageBox.Show("La fila seleccionada está vacía y no se puede agregar.");
                return;
            }


            string nombreArticulo = fila.Cells["Nombre"].Value?.ToString();
            bool articuloExistente = false;

            foreach (DataGridViewRow row in DGVCarrito.Rows)
            {
                if (row.Cells["Nombre"].Value?.ToString() == nombreArticulo)
                {

                    int cantidadActual = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    row.Cells["Cantidad"].Value = cantidadActual + 1;
                    articuloExistente = true;
                    break;
                }
            }

            if (!articuloExistente)
            {
                if (DGVCarrito.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn columna in DGVArts.Columns)
                    {
                        DGVCarrito.Columns.Add((DataGridViewColumn)columna.Clone());
                    }

                    DataGridViewTextBoxColumn columnaCantidad = new DataGridViewTextBoxColumn
                    {
                        Name = "Cantidad",
                        HeaderText = "Cantidad",
                        ValueType = typeof(int),
                    };
                    DGVCarrito.Columns.Add(columnaCantidad);
                }

                int nuevaFilaIndex = DGVCarrito.Rows.Add();
                for (int i = 0; i < valoresFila.Count; i++)
                {
                    DGVCarrito.Rows[nuevaFilaIndex].Cells[i].Value = valoresFila[i];
                }

                DGVCarrito.Rows[nuevaFilaIndex].Cells["Cantidad"].Value = 1;
            }

            CalcularTotalYVerificarStock();
            DGVCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DGVArts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AgregarFilaACarrito(e.RowIndex);
            TxtBoxBusq_Click(sender, e);
        }

        private void DGVArts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && DGVArts.SelectedRows.Count > 0)
            {
                int rowIndex = DGVArts.SelectedRows[0].Index;
                if (rowIndex >= 0 && rowIndex < DGVArts.Rows.Count)
                {
                    AgregarFilaACarrito(rowIndex);
                    TxtBoxBusq_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Índice de fila no válido.");
                }
            }
        }
        private void CalcularTotalYVerificarStock()
        {
            decimal total = 0m;
            bool stockValido = true;

            foreach (DataGridViewRow fila in DGVCarrito.Rows)
            {

                if (fila.Cells["Cantidad"] != null && fila.Cells["Precio"] != null &&
                    int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                    decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                {

                    total += cantidad * precio;


                    if (fila.Cells["Stock"] != null &&
                        int.TryParse(fila.Cells["Stock"].Value?.ToString(), out int stockDisponible))
                    {
                        if (cantidad > stockDisponible)
                        {
                            stockValido = false;
                            fila.DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            fila.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                }
            }

            TxtBoxTotal.Text = total.ToString("C");

            if (!stockValido)
            {
                MessageBox.Show("Algunos artículos tienen cantidad superior al stock disponible.",
                                "Advertencia de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AceptBtn_Click(object sender, EventArgs e)
        {
            GuardarVenta();
            ActualizarDataGridView();
            if (Completo)
            {
                FacturaB factura = new FacturaB(int.Parse(TxtBoxFact.Text));
                this.Close();
                factura.Show();
            }

        }

        private void SalirBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVCarrito_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (DGVCarrito.Columns[e.ColumnIndex].Name == "Precio")
            {
                CalcularTotalYVerificarStock();
            }
        }
        private void ModificarCantidadFilaCarrito()
        {
            if (DGVCarrito.SelectedRows.Count > 0)
            {
                var filaSeleccionada = DGVCarrito.SelectedRows[0];
                var nombreArticulo = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                var cantidadActual = Convert.ToInt32(filaSeleccionada.Cells["Cantidad"].Value);


                string nuevaCantidadStr = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Ingrese la nueva cantidad para el artículo: {nombreArticulo}",
                    "Modificar Cantidad",
                    cantidadActual.ToString());


                if (int.TryParse(nuevaCantidadStr, out int nuevaCantidad) && nuevaCantidad > 0)
                {

                    filaSeleccionada.Cells["Cantidad"].Value = nuevaCantidad;
                    CalcularTotalYVerificarStock();
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad válida (mayor a 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar la cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CambiarPrecioFilaSeleccionada()
        {

            if (DGVCarrito.SelectedRows.Count > 0)
            {
                var filaSeleccionada = DGVCarrito.SelectedRows[0];
                var precioActual = filaSeleccionada.Cells["Precio"].Value?.ToString() ?? "0";
                string nuevoPrecio = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo precio:", "Cambiar Precio", precioActual);
                if (decimal.TryParse(nuevoPrecio, out decimal precioDecimal) && precioDecimal >= 0)
                {
                    filaSeleccionada.Cells["Precio"].Value = precioDecimal;
                    CalcularTotalYVerificarStock();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para cambiar el precio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void PrecBtn_Click(object sender, EventArgs e)
        {
            CambiarPrecioFilaSeleccionada();
        }

        private void DGVCarrito_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DGVCarrito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (DGVCarrito.Columns[e.ColumnIndex].Name == "Precio")
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal nuevoPrecio) || nuevoPrecio < 0)
                {
                    MessageBox.Show("Ingrese un precio válido (mayor o igual a 0).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void CantBtn_Click(object sender, EventArgs e)
        {
            ModificarCantidadFilaCarrito();
        }

        private void RetirarBtn_Click(object sender, EventArgs e)
        {
            if (DGVCarrito.SelectedRows.Count > 0)
            {
                var resultado = MessageBox.Show(
                    "¿Está seguro de que desea retirar este artículo?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    foreach (DataGridViewRow fila in DGVCarrito.SelectedRows)
                    {

                        DGVCarrito.Rows.Remove(fila);
                    }

                    CalcularTotalYVerificarStock();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para retirar del carrito.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AplicarDescuento()
        {

            if (decimal.TryParse(DescTxtBox.Text, out decimal porcentajeDescuento))
            {
                if (porcentajeDescuento >= 0 && porcentajeDescuento <= 100)
                {

                    decimal total = 0m;


                    foreach (DataGridViewRow fila in DGVCarrito.Rows)
                    {
                        if (fila.Cells["Cantidad"] != null && fila.Cells["Precio"] != null &&
                            int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                            decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                        {
                            total += cantidad * precio;
                        }
                    }


                    decimal descuento = (total * porcentajeDescuento) / 100;


                    total -= descuento;


                    TxtBoxTotal.Text = total.ToString("C");
                }

            }

        }
        private void DescTxtBox_TextChanged(object sender, EventArgs e)
        {
            AplicarDescuento();
        }
        private void AplicarRecargo()
        {

            if (decimal.TryParse(RecTxtBox.Text, out decimal porcentajeRecargo))
            {
                if (porcentajeRecargo >= 0 && porcentajeRecargo <= 100)
                {

                    decimal total = 0m;

                    foreach (DataGridViewRow fila in DGVCarrito.Rows)
                    {
                        if (fila.Cells["Cantidad"] != null && fila.Cells["Precio"] != null &&
                            int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                            decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                        {
                            total += cantidad * precio;
                        }
                    }


                    decimal recargo = (total * porcentajeRecargo) / 100;


                    total += recargo;


                    TxtBoxTotal.Text = total.ToString("C");
                }

            }

        }

        private void RecTxtBox_TextChanged(object sender, EventArgs e)
        {
            AplicarRecargo();
        }
        private void GuardarVenta()
        {

            try
            {
                int numFactura = Convert.ToInt32(TxtBoxFact.Text);
                string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                string vendedor = (VendComBox.SelectedItem as Vendedor)?.Nombre;
                string cuilCliente = (CliComBox.SelectedItem as Cliente)?.CUIL;
                string metodoPago = CondPagoComBox.SelectedItem?.ToString();
                decimal totalVenta = decimal.Parse(TxtBoxTotal.Text, System.Globalization.NumberStyles.Currency);

                if (string.IsNullOrEmpty(vendedor) || string.IsNullOrEmpty(cuilCliente) || string.IsNullOrEmpty(metodoPago))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (metodoPago == "Tarjeta")
                {
                    ConfirmTarj confirmar = new ConfirmTarj(numFactura);
                    var resultado = confirmar.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        if (DGVCarrito.Rows.Count > 0)
                        {
                            VentasL ventasL = new VentasL();
                            bool ventaGuardada = ventasL.GuardarVenta(numFactura, fechaHora, vendedor, cuilCliente, metodoPago, totalVenta);

                            if (ventaGuardada)
                            {
                                List<DetalleArticulo> detallesArticulos = new List<DetalleArticulo>();

                                foreach (DataGridViewRow fila in DGVCarrito.Rows)
                                {
                                    if (fila.Cells["Nombre"]?.Value != null && fila.Cells["Cantidad"]?.Value != null && fila.Cells["Precio"]?.Value != null &&
                                        int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                                        decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                                    {
                                        string nombreArticulo = fila.Cells["Nombre"].Value.ToString();
                                        decimal subtotal = cantidad * precio;

                                        detallesArticulos.Add(new DetalleArticulo
                                        {
                                            Nombre = nombreArticulo,
                                            Cantidad = cantidad,
                                            Precio = precio,
                                            Subtotal = subtotal
                                        });
                                    }
                                }

                                if (detallesArticulos.Any())
                                {
                                    ventasL.GuardarDetalleVenta(numFactura, detallesArticulos, metodoPago, totalVenta, cuilCliente, vendedor);
                                    VerificarYNotificarStockBajo();
                                    MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Completo = true;
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron artículos válidos para registrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Completo = false;
                        }
                    }
                    else
                    {

                        MessageBox.Show("Operación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (metodoPago == "Cuenta Corriente")
                {
                    if (DGVCarrito.Rows.Count > 0)
                    {
                        VentasL ventasL = new VentasL();
                        bool ventaGuardada = ventasL.GuardarVenta(numFactura, fechaHora, vendedor, cuilCliente, metodoPago, totalVenta);
                        ClienteL cliente = new ClienteL();
                        cliente.ActualizarCC(cuilCliente, totalVenta);
                        if (ventaGuardada)
                        {
                            List<DetalleArticulo> detallesArticulos = new List<DetalleArticulo>();

                            foreach (DataGridViewRow fila in DGVCarrito.Rows)
                            {
                                if (fila.Cells["Nombre"]?.Value != null && fila.Cells["Cantidad"]?.Value != null && fila.Cells["Precio"]?.Value != null &&
                                    int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                                    decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                                {
                                    string nombreArticulo = fila.Cells["Nombre"].Value.ToString();
                                    decimal subtotal = cantidad * precio;

                                    detallesArticulos.Add(new DetalleArticulo
                                    {
                                        Nombre = nombreArticulo,
                                        Cantidad = cantidad,
                                        Precio = precio,
                                        Subtotal = subtotal
                                    });
                                }
                            }

                            if (detallesArticulos.Any())
                            {
                                ventasL.GuardarDetalleVenta(numFactura, detallesArticulos, metodoPago, totalVenta, cuilCliente, vendedor);
                                VerificarYNotificarStockBajo();
                                MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Completo = true;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron artículos válidos para registrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Completo = false;
                    }
                }
                else
                {
                    if (DGVCarrito.Rows.Count > 0)
                    {
                        VentasL ventasL = new VentasL();
                        bool ventaGuardada = ventasL.GuardarVenta(numFactura, fechaHora, vendedor, cuilCliente, metodoPago, totalVenta);
                        if (ventaGuardada)
                        {
                            List<DetalleArticulo> detallesArticulos = new List<DetalleArticulo>();

                            foreach (DataGridViewRow fila in DGVCarrito.Rows)
                            {
                                if (fila.Cells["Nombre"]?.Value != null && fila.Cells["Cantidad"]?.Value != null && fila.Cells["Precio"]?.Value != null &&
                                    int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                                    decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                                {
                                    string nombreArticulo = fila.Cells["Nombre"].Value.ToString();
                                    decimal subtotal = cantidad * precio;

                                    detallesArticulos.Add(new DetalleArticulo
                                    {
                                        Nombre = nombreArticulo,
                                        Cantidad = cantidad,
                                        Precio = precio,
                                        Subtotal = subtotal
                                    });
                                }
                            }

                            if (detallesArticulos.Any())
                            {
                                ventasL.GuardarDetalleVenta(numFactura, detallesArticulos, metodoPago, totalVenta, cuilCliente, vendedor);
                                VerificarYNotificarStockBajo();
                                MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Completo = true;
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Completo = false;
            }
        }

        private void SenaBtn_Click(object sender, EventArgs e)
        {
            int numFactura = Convert.ToInt32(TxtBoxFact.Text);
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd");
            decimal totalVenta = decimal.Parse(TxtBoxTotal.Text, System.Globalization.NumberStyles.Currency);
            if (DGVCarrito.Rows.Count > 0)
            {
                List<DetalleArticulo> detallesArticulos = new List<DetalleArticulo>();

                foreach (DataGridViewRow fila in DGVCarrito.Rows)
                {
                    if (fila.Cells["Nombre"]?.Value != null && fila.Cells["Cantidad"]?.Value != null && fila.Cells["Precio"]?.Value != null &&
                        int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                        decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                    {
                        string nombreArticulo = fila.Cells["Nombre"].Value.ToString();
                        decimal subtotal = cantidad * precio;

                        detallesArticulos.Add(new DetalleArticulo
                        {
                            Nombre = nombreArticulo,
                            Cantidad = cantidad,
                            Precio = precio,
                            Subtotal = subtotal
                        });
                    }
                }
                FactPresupuesto fact = new FactPresupuesto(numFactura, fechaHora, totalVenta, detallesArticulos);
                fact.Show();
            }
        }
        private void VentasP_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '*')
            {
                ModificarCantidadFilaCarrito();
                e.Handled = true;
            }

            else if (e.KeyChar == '/')
            {
                CambiarPrecioFilaSeleccionada();
                e.Handled = true;
            }
        }
        private void VerificarYNotificarStockBajo()
        {
            try
            {
                NotificacionL notiLogica = new NotificacionL();
                ArticuloL artLogica = new ArticuloL();
                var listaArticulosDb = artLogica.ListarArticulos();

                foreach (DataGridViewRow fila in DGVCarrito.Rows)
                {
                    if (fila.Cells["Nombre"]?.Value != null &&
                        int.TryParse(fila.Cells["Cantidad"]?.Value?.ToString(), out int cantidadVendida))
                    {
                        string nombreArticulo = fila.Cells["Nombre"].Value.ToString();


                        var articuloDb = listaArticulosDb.FirstOrDefault(a => a.Nombre.Equals(nombreArticulo, StringComparison.OrdinalIgnoreCase));

                        if (articuloDb != null)
                        {

                            int stockRestante = articuloDb.Stock - cantidadVendida;

                            if (stockRestante <= articuloDb.StockMin)
                            {
                                notiLogica.RegistrarNotificacion(
                                    tema: "Productos",
                                    titulo: "Stock Mínimo Alcanzado",
                                    descripcion: $"El artículo '{nombreArticulo}' cuenta con {stockRestante} unidades disponibles."
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void DGVArts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CondPagoComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizandoCombos) return;

            actualizandoCombos = true;
            try
            {
                string metodo = (CondPagoComBox.SelectedItem?.ToString() ?? CondPagoComBox.Text).Trim();

                if (metodo.Equals("Cuenta Corriente", StringComparison.OrdinalIgnoreCase))
                {
                    int indicePrimerClienteValido = -1;
                    for (int i = 0; i < CliComBox.Items.Count; i++)
                    {
                        string nombre = (CliComBox.Items[i] as Cliente)?.Nombre?.Trim()
                                        ?? CliComBox.GetItemText(CliComBox.Items[i]).Trim();

                        if (!string.IsNullOrEmpty(nombre) && !nombre.Equals("N/A", StringComparison.OrdinalIgnoreCase))
                        {
                            indicePrimerClienteValido = i;
                            break;
                        }
                    }

                    if (indicePrimerClienteValido >= 0)
                    {
                        CliComBox.Enabled = true;
                        CliComBox.SelectedIndex = indicePrimerClienteValido;
                    }
                    else
                    {
                        int indexEfectivo = CondPagoComBox.FindStringExact("Efectivo");
                        if (indexEfectivo >= 0)
                            CondPagoComBox.SelectedIndex = indexEfectivo;
                        else
                            CondPagoComBox.SelectedItem = "Efectivo";

                        CliComBox.Enabled = false;
                    }
                }
                else
                {
                    CliComBox.Enabled = false;

                    int indexNA = CliComBox.FindStringExact("N/A");
                    if (indexNA >= 0)
                        CliComBox.SelectedIndex = indexNA;
                }
            }
            finally
            {
                actualizandoCombos = false;
            }
        }

        private void CliComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actualizandoCombos) return;

            actualizandoCombos = true;
            try
            {
                string nombreCliente = ((CliComBox.SelectedItem as Cliente)?.Nombre ?? CliComBox.Text).Trim();

                if (nombreCliente.Equals("N/A", StringComparison.OrdinalIgnoreCase))
                {
                    int indexEfectivo = CondPagoComBox.FindStringExact("Efectivo");
                    if (indexEfectivo >= 0)
                        CondPagoComBox.SelectedIndex = indexEfectivo;
                    else
                        CondPagoComBox.SelectedItem = "Efectivo";

                    CliComBox.Enabled = false;
                }
                else if (!string.IsNullOrEmpty(nombreCliente))
                {
                    int indexCC = CondPagoComBox.FindStringExact("Cuenta Corriente");
                    if (indexCC >= 0)
                        CondPagoComBox.SelectedIndex = indexCC;
                    else
                        CondPagoComBox.SelectedItem = "Cuenta Corriente";

                    CliComBox.Enabled = true;
                }
            }
            finally
            {
                actualizandoCombos = false;
            }
        }
    }
}
