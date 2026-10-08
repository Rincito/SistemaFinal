using SistemaFinal.Capa_Datos;

namespace SistemaFinal.Capa_Logica
{
    internal class ClienteL
    {
        ClienteD ClienteD = new ClienteD();
        public bool GuardarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.CUIL) || string.IsNullOrEmpty(cliente.Nombre))
            {
                MessageBox.Show("CUIL y Nombre son requeridos.");
                return false;
            }
            return ClienteD.Guardar(cliente);
        }

        public List<Cliente> ListarClientes()
        {

            return ClienteD.ListarClientes();

        }
        public bool ActualizarCliente(Cliente cliente, string cuil)
        {
            return ClienteD.ActualizarCliente(cliente, cuil);
        }
        public void ActualizarCC(string cuilCli, decimal total)
        {
            ClienteD.ActualizarCC(cuilCli, total);
        }
        public void PagoCC(string cuilCli, decimal total)
        {
            ClienteD.PagoCC(cuilCli, total);
        }
    }
}
