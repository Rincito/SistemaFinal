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
    public partial class Recuperacion : Form
    {
        private LoginL logica = new LoginL();
        public Recuperacion()
        {
            InitializeComponent();
            Estilos.Tema.AplicarEstiloRecuperacion(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = MailTxtBox.Text.Trim();

            button1.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            var resultado = await logica.ProcesarRecuperacion(email);
            // Llamamos al método que agregamos en LoginL
            if (resultado.Exito)
            {
                MessageBox.Show(resultado.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
