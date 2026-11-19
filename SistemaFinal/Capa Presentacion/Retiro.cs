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
    public partial class Retiro : Form
    {
        public event Action DatosGuardados;
        public Retiro(string fecha)
        {
            InitializeComponent();
            Estilos.Tema.AplicarEstiloPagoVendedores(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtBoxFact.Text, out decimal montoInicial))
            {
                CajaL cajaL = new CajaL();
                string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                cajaL.GuardarRetiro(fechaActual, montoInicial);
                cajaL.NotifiRetiro(montoInicial);
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

        private void Retiro_Load(object sender, EventArgs e)
        {

        }
    }
}
