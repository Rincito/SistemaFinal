using SistemaFinal.Capa_Datos;

namespace SistemaFinal.Capa_Logica
{
    internal class ProveedorL
    {
        private ProveedorD ProveedorD = new ProveedorD();
        public bool GuardarDatos(string nombre, string telefono, string email)
        {
            return ProveedorD.InsertarDatos(nombre, telefono, email);
        }
        public List<Proveedor> ListarProveedores()
        {
            return ProveedorD.ObtenerProveedores();
        }
        public bool BajaProveedor(string Nombre, int nuevoActivo)
        {
            return ProveedorD.BajaProveedor(Nombre, nuevoActivo);
        }
        public bool ReactProv(string nombre, int nuevoActivo)
        {
            return ProveedorD.ReactProv(nombre, nuevoActivo);
        }
        public bool ActProv(string nombre, string telefono, string email, int ID)
        {
            return ProveedorD.ActProv(nombre, telefono, email, ID);
        }
        public List<Proveedor> ListarProveedoresConDeuda()
        {
            return ProveedorD.ObtenerProveedores();
        }
        public bool ActualizarDeuda(Proveedor proveedor)
        {
            if (proveedor.Deuda < 0)
            {
                MessageBox.Show("La deuda no puede ser negativa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return ProveedorD.ActualizarDeuda(proveedor);
        }

    }
}
