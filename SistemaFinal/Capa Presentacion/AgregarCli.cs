using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Logica;

namespace SistemaFinal.Capa_Presentacion
{
    public partial class AgregarCli : Form
    {
        public AgregarCli()
        {
            InitializeComponent();
            Estilos.Tema.AplicarEstiloModalCliente(this);
        }

        public event Action FormularioCerrado;
        public event Action ActualizarDataGridViews;
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            FormularioCerrado?.Invoke();
            ActualizarDataGridViews?.Invoke();
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AgregarArt_Load(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                CUIL = CUILTxtBox.Text,
                Nombre = NomTxtBox.Text,
                Apellido = ApeTxtBox.Text,
                Telefono = TelTxtBox.Text,
                Domicilio = DomTxtBox.Text,
                Email = EmailTxtBox.Text
            };
            ClienteL clienteL = new ClienteL();
            bool exito = clienteL.GuardarCliente(cliente);

            if (exito)
            {
                MessageBox.Show("Cliente guardado exitosamente.");
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar el cliente.");
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}


