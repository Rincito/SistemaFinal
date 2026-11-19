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
    public partial class Gasto : Form
    {
        public event Action DatosGuardados;
        public Gasto(string fecha)
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
            GastoL gastoL = new GastoL();
            var meta = gastoL.obtenerGastos();
            if (meta.Any())
            {
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = "Nombre";
                comboBox2.DataSource = meta;
            }
            Estilos.Tema.AplicarEstiloPagoVendedores(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtBoxFact.Text, out decimal montoInicial))
            {
                CajaL cajaL = new CajaL();
                string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                string formapago = comboBox1.SelectedValue.ToString();
                string detalle = comboBox2.SelectedValue.ToString();
                cajaL.GuardarGasto(fechaActual, montoInicial, formapago, detalle);
                cajaL.NotifiGasto(montoInicial, formapago, detalle);
                DatosGuardados?.Invoke();
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
    }
}
