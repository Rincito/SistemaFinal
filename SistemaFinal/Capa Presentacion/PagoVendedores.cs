using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFinal.Capa_Logica;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class PagoVendedores : Form
    {
        public event Action DatosGuardados;
        public PagoVendedores()
        {
            InitializeComponent();
            VentasL ventaL = new VentasL();
            string metodos = "";
            var met = ventaL.ObtenerMetodos(metodos);
            var metFiltrado = met
            .Where(m => !m.Trim().Equals("Cuenta Corriente", StringComparison.OrdinalIgnoreCase))
             .ToList();
            if (metFiltrado.Any())
            {
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Nombre";
                comboBox1.DataSource = metFiltrado;
            }
            else
            {
                MessageBox.Show($"No se encontraron datos en la tabla {metodos}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string vendedores = "";
            var vend = ventaL.ObtenerVendedores(vendedores);

            var VendFiltrado = vend
            .Where(m => m.Activo == 1 && !m.Nombre.Trim().Equals("N/A", StringComparison.OrdinalIgnoreCase))
            .ToList();
            if (VendFiltrado.Any())
            {
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Nombre";
                comboBox2.DataSource = VendFiltrado;
            }
            else
            {
                MessageBox.Show($"No se encontraron datos en la tabla {vendedores}.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtBoxFact.Text, out decimal montoInicial))
            {
                CajaL cajaL = new CajaL();
                string formapago = comboBox1.SelectedValue.ToString();
                string detalle = comboBox2.SelectedValue.ToString();
                cajaL.GuardarPago(montoInicial, formapago, detalle);
                cajaL.NotifiPagoVend(montoInicial, formapago, detalle);
                DatosGuardados?.Invoke();
                MessageBox.Show("Pago realizado correctamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("El monto ingresado no es válido. Intente nuevamente.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PagoVendedores_Load(object sender, EventArgs e)
        {

        }
    }
}
