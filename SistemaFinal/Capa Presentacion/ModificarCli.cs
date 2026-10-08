using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class ModificarCli : Form
    {
        private bool datosModificados;
        private bool cerrarPorPerderFoco = true;
        Cliente cli = new Cliente();

        public event Action FormularioCerrado;
        public event Action ActualizarDataGridViews;

        public ModificarCli(Cliente cliente)
        {
            InitializeComponent();
            datosModificados = false;
            this.ShowInTaskbar = false;
            this.Deactivate += ModificarArt_Deactivate;
            CargarDatosCliente(cliente);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarDatosCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                CUILTxtBox.Text = cliente.CUIL.ToString();
                cli.CUILViejo = cliente.CUIL;
                NomTxtBox.Text = cliente.Nombre;
                ApeTxtBox.Text = cliente.Apellido;
                TelTxtBox.Text = cliente.Telefono;
                EmailTxtBox.Text = cliente.Email;
                DomTxtBox.Text = cliente.Domicilio;


            }
        }
        private void ModificarArt_Load(object sender, EventArgs e)
        {

        }
        private void GuardarDatos()
        {
            ClienteL cliente = new ClienteL();
            cli.CUIL = CUILTxtBox.Text;
            cli.Nombre = NomTxtBox.Text;
            cli.Apellido = ApeTxtBox.Text;
            cli.Telefono = TelTxtBox.Text;
            cli.Domicilio = DomTxtBox.Text;
            cli.Email = EmailTxtBox.Text;
            bool exito = cliente.ActualizarCliente(cli, cli.CUILViejo);

            if (exito)
            {
                MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarDataGridViews?.Invoke();
                FormularioCerrado?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ModificarArt_Deactivate(object sender, EventArgs e)
        {
            if (cerrarPorPerderFoco)
            {
                if (this.Owner != null && !this.Owner.Focused)
                {
                    if (datosModificados)
                    {
                        var result = MessageBox.Show(
                            "Tienes cambios sin guardar. ¿Deseas guardarlos antes de cerrar?",
                            "Confirmación",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            GuardarDatos();
                            ActualizarDataGridViews?.Invoke();
                            FormularioCerrado?.Invoke();
                            this.Close();
                        }
                        else if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
    }
}
