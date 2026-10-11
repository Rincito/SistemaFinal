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
    public partial class VentasXVend : Form
    {
        public VentasXVend()
        {
            InitializeComponent();
        }
        public string FechaInicio { get; private set; }
        public string FechaFin { get; private set; }
        public string VendedorSeleccionado { get; private set; }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void VentasXVend_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            VentasL ventaL = new VentasL();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            FechaInicio = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            FechaFin = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            VendedorSeleccionado = comboBox2.Text.Trim();
            if (DateTime.Parse(FechaInicio) > DateTime.Parse(FechaFin))
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
