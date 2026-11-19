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
    public partial class CajaInicio : Form
    {
        public CajaInicio(string fecha)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtBoxFact.Text, out decimal montoInicial))
            {
                CajaL cajaL = new CajaL();
                string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                cajaL.GuardarMontoInicial(fechaActual, montoInicial);
                MessageBox.Show($"Caja inicial configurada con ${montoInicial}.");
                this.Close();
            }
            else
            {
                MessageBox.Show("El monto ingresado no es válido. Intente nuevamente.");
            }
        }
    }
}
