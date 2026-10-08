using SistemaFinal.Capa_Datos;

namespace SistemaFinal.Capa_Logica
{
    internal class VendedorL
    {
        public List<Vendedor> ListarVendedores()
        {
            VendedorD datos = new VendedorD();
            return datos.ObtenerVendedores();
        }
        public bool GuardarVendedor(Vendedor vendedor)
        {
            VendedorD datos = new VendedorD();
            return datos.InsertarVendedor(vendedor);
        }
        public bool BajaVendedor(string cuil, int activo)
        {
            VendedorD datos = new VendedorD();
            return datos.BajarVendedor(cuil, activo);
        }
        public bool ReactivarVendedor(string cuil, int activo)
        {
            VendedorD datos = new VendedorD();
            return datos.ReactVendedor(cuil, activo);
        }
        public bool ActualizarVendedor(string cuil, string nombre, string apellido, string telefono, string domicilio)
        {
            VendedorD datos = new VendedorD();
            return datos.ActualizarVendedor(cuil, nombre, apellido, telefono, domicilio);
        }
    }
}
