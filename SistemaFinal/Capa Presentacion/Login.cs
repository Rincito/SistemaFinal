using SistemaFinal.Capa_Datos;
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
using static SistemaFinal.Capa_Datos.LoginD;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class Login : Form
    {
        private LoginL logica = new LoginL();
        public Login()
        {
            InitializeComponent();
            Estilos.Tema.AplicarEstiloLogin(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            ComboBoxRol.Items.Clear();
            ComboBoxRol.Items.Add("Administrador");
            ComboBoxRol.Items.Add("Vendedor");
            if (ComboBoxRol.Items.Count > 0)
            {
                ComboBoxRol.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string contra = ContraTxtBox.Text;
            string rolTexto = ComboBoxRol.SelectedItem.ToString(); ;
            if (logica.ValidarIngreso(contra, rolTexto, out string error, out int rolNumero, out UsuarioDTO usuario))
            {
                SesionActual.Email = usuario.Email;
                SesionActual.Rol = rolNumero;
                VendedorL vendedorL = new VendedorL();
                var vendedorAsociado = vendedorL.ListarVendedores().FirstOrDefault(v => v.Email.Equals(usuario.Email, StringComparison.OrdinalIgnoreCase));

                if (vendedorAsociado != null)
                {
                    SesionActual.NombreCompleto = $"{vendedorAsociado.Nombre} {vendedorAsociado.Apellido}";
                }
                else
                {
                    SesionActual.NombreCompleto = "Administrador Principal";
                }

                if (rolNumero == 1)
                {
                    Inicio formAdmin = new Inicio(this, rolNumero);
                    formAdmin.Show();
                }
                else if (rolNumero == 0)
                {
                    Inicio formVend = new Inicio(this, rolNumero);
                    formVend.Show();
                }
                ContraTxtBox.Clear();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show(error, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ContraTxtBox.PasswordChar == '*')
            {
                ContraTxtBox.PasswordChar = '\0';
                pictureBox1.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                ContraTxtBox.PasswordChar = '*';
                pictureBox1.BackgroundImage = Properties.Resources.view;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Recuperacion formrecu = new Recuperacion();
            formrecu.Show();
        }
    }
}
