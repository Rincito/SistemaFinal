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
    public partial class ConfirmTarj : Form
    {
        public int numFact;
        public ConfirmTarj(int NumFact)
        {
            InitializeComponent();
            numFact = NumFact;
            VentasL ventaL = new VentasL();
            var met = ventaL.ObtenerTarjetas();
            if (met.Any())
            {
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = "Nombre";
                comboBox1.DataSource = met;
            }
            else
            {
                MessageBox.Show($"No se encontraron datos de tarjetas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                CajaL cajaL = new CajaL();
                string tarjeta = comboBox1.SelectedValue.ToString();
                cajaL.GuardarVentaTarjeta(numFact, tarjeta);
                this.DialogResult = DialogResult.OK;
                this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
