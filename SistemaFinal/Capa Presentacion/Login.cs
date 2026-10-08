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
                MessageBox.Show("¡Ingreso correcto!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Redirección según el rol
                if (rolNumero == 1)
                {
                    Inicio formAdmin = new Inicio(this);
                    formAdmin.Show();
                }
                else if (rolNumero == 0)
                {
                    //FormVendedor formVendedor = new FormVendedor();
                    //formVendedor.Show();
                }
                ContraTxtBox.Clear();
                this.Hide(); // Oculta la pantalla de Login
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
                // Revelamos la contraseña (carácter nulo)
                ContraTxtBox.PasswordChar = '\0';

                // Cambiamos al icono del ojo abierto
                pictureBox1.BackgroundImage = Properties.Resources.hide;
            }
            else
            {
                // Volvemos a ocultar la contraseña con asterisco
                ContraTxtBox.PasswordChar = '*';

                // Cambiamos al icono del ojo cerrado
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
