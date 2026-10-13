using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class ConsultarVentas : Form
    {
        public ConsultarVentas()
        {
            InitializeComponent();
        }

        private void ConsultarVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void SalirBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarVentas()
        {
            try
            {
                VentasL logica = new VentasL();
                var ventas = logica.ObtenerVentasActivas();
                MostrarVentasFiltradas(ventas);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarVentasAnuladas()
        {
            try
            {
                VentasL logica = new VentasL();
                var ventas = logica.ObtenerVentasAnuladas();
                MostrarVentasFiltradas(ventas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas, puede que no haya anulaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComprobantesBtn_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void EfectivoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                VentasL logica = new VentasL();
                var ventas = logica.ObtenerVentasEfectivo();
                MostrarVentasFiltradas(ventas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TarjetaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                VentasL logica = new VentasL();
                var ventas = logica.ObtenerVentasTarjeta();
                MostrarVentasFiltradas(ventas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarVentasFiltradas(List<Venta> ventas)
        {
            var ventasFiltradas = ventas
                .Where(v => v.FechaHora >= DateTime.Now.AddDays(-2))
                .Select(v => new
                {
                    v.NumFactura,
                    v.FechaHora,
                    v.Cliente,
                    v.Metodo,
                    v.Total
                })
                .ToList();

            dataGridView1.DataSource = ventasFiltradas;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }
        }

        private void AnularVenta_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int numFactura = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["NumFactura"].Value);
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea anular esta venta?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    VentasL logica = new VentasL();
                    if (logica.AnularVenta(numFactura))
                    {
                        CargarVentas();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una venta para anular.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AnuladosBtn_Click(object sender, EventArgs e)
        {
            CargarVentasAnuladas();
        }

        private void ReactivarBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int numFactura = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["NumFactura"].Value);
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea reactivar esta venta?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    VentasL logica = new VentasL();
                    if (logica.ReactivarVenta(numFactura))
                    {
                        CargarVentasAnuladas();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una venta para reactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void CargarDetalleVenta(int numFactura)
        {

            VentasL logica = new VentasL();
            var detalles = logica.ObtenerDetalle_Venta(numFactura);
            TxtBoxCliente.Text = detalles.Cliente;
            TxtBoxCondPago.Text = detalles.Metodo;
            TxtBoxFact.Text = numFactura.ToString();
            TxtBoxFecha.Text = detalles.FechaHora.ToString();
            TxtBoxTotal.Text = detalles.Total.ToString();
            TxtBoxVendedor.Text = detalles.Vendedor;
            var carrito = logica.ObtenerDetalleVenta(numFactura);
            dataGridView2.DataSource = carrito;

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int numFactura = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["NumFactura"].Value);
                CargarDetalleVenta(numFactura);
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int numFactura = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["NumFactura"].Value);
                CargarDetalleVenta(numFactura);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void ImprimBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxFact.Text))
            {
                MessageBox.Show("Seleccione una venta para imprimir el comprobante.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int numFactura = Convert.ToInt32(TxtBoxFact.Text);

                DateTime fechaHora = DateTime.TryParse(TxtBoxFecha.Text, out DateTime parsedDate) ? parsedDate : DateTime.Now;

                decimal totalVenta = decimal.Parse(TxtBoxTotal.Text.Replace("$", "").Trim(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture);

                List<DetalleArticulo> detallesArticulos = new List<DetalleArticulo>();

                
                foreach (DataGridViewRow fila in dataGridView2.Rows)
                {
                    if (fila.Cells["Nombre"]?.Value != null &&
                        fila.Cells["Cantidad"]?.Value != null &&
                        fila.Cells["Precio"]?.Value != null &&
                        int.TryParse(fila.Cells["Cantidad"].Value?.ToString(), out int cantidad) &&
                        decimal.TryParse(fila.Cells["Precio"].Value?.ToString(), out decimal precio))
                    {
                        string nombreArticulo = fila.Cells["Nombre"].Value.ToString();

                       
                        decimal subtotal = (fila.Cells["Subtotal"]?.Value != null &&
                                            decimal.TryParse(fila.Cells["Subtotal"].Value.ToString(), out decimal sub))
                                            ? sub
                                            : (cantidad * precio);

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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el comprobante: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
