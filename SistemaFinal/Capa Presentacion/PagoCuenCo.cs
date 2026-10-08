using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class PagoCuenCo : Form
    {
        
        public event Action FormularioCerrado;
        public event Action ActualizarDataGridViews;
        public string CUIL;
        public PagoCuenCo(Cliente cliente)
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
            TxtBoxCli.Text = cliente.Nombre;
            CUIL = cliente.CUIL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtBoxFact.Text, out decimal pagoCC))
            {
                ClienteL c = new ClienteL();
                CajaL cajaL = new CajaL();
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd");
                string formapago = comboBox1.SelectedValue.ToString();
                decimal cobro = Decimal.Parse(TxtBoxFact.Text);
                c.PagoCC(CUIL, pagoCC);
                cajaL.PagoCC(fechaActual,cobro, formapago);
                ActualizarDataGridViews?.Invoke();
                FormularioCerrado?.Invoke();
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
    }
}
