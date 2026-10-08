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
                

                dataGridView1.DataSource = ventas.Select(v => new
                {
                    v.NumFactura,
                    v.FechaHora,
                    v.Cliente,
                    v.Metodo,
                    v.Total
                }).ToList();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];

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
                dataGridView1.DataSource = ventas.Select(v => new
                {
                    v.NumFactura,
                    v.FechaHora,
                    v.Cliente,
                    v.Metodo,
                    v.Total
                }).ToList();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
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
                dataGridView1.DataSource = ventas.Select(v => new
                {
                    v.NumFactura,
                    v.FechaHora,
                    v.Cliente,
                    v.Metodo,
                    v.Total
                }).ToList();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
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
                dataGridView1.DataSource = ventas.Select(v => new
                {
                    v.NumFactura,
                    v.FechaHora,
                    v.Cliente,
                    v.Metodo,
                    v.Total
                }).ToList();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
