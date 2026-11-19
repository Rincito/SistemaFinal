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
    public partial class SeleccionFechas : Form
    {
        public string FechaInicio { get; private set; }
        public string FechaFin { get; private set; }
        public SeleccionFechas()
        {
            InitializeComponent();
            Estilos.Tema.AplicarEstiloVentasXVend(this);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            FechaInicio = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            FechaFin = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (DateTime.Parse(FechaInicio) > DateTime.Parse(FechaFin))
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close();
        }
    }
}
