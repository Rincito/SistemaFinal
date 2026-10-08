using Punto_de_venta___Prácticas_profesionales.Presentación;
using SistemaFinal.Capa_Datos;


namespace SistemaFinal.Capa_Logica
{
    internal class VentasL
    {
        VentasD ventaD = new VentasD();
        public List<Vendedor> ObtenerVendedores(string tabla)
        {
            VentasD clienteD = new VentasD();
            return clienteD.ObtenerVendedor(tabla);
        }
        public List<Cliente> ObtenerClientes(string tabla)
        {
            VentasD clienteD = new VentasD();
            return clienteD.ObtenerCliente(tabla);
        }
        public List<string> ObtenerMetodos(string tabla)
        {
            VentasD clienteD = new VentasD();
            return clienteD.ObtenerMetodo(tabla);
        }
        public int ObtenerProximoNumeroFactura()
        {
            return ventaD.ObtenerProximoNumeroFactura();
        }
        public bool GuardarVenta(int numFactura, DateTime fechaHora, string vendedor, string cliente, string metodo, decimal total)
        {
            return ventaD.GuardarVenta(numFactura, fechaHora, vendedor, cliente, metodo, total);
        }
        public void GuardarDetalleVenta(int numFactura, List<DetalleArticulo> detallesArticulos, string metodo, decimal total, string cuilCliente, string cuilVendedor)
        {
            ventaD.GuardarDetalleVenta(numFactura, detallesArticulos, metodo, total, cuilCliente, cuilVendedor);
        }
        public List<DetalleArticulo> ObtenerDetalleVenta(int numFactura)
        {
            return ventaD.ObtenerDetalleVenta(numFactura);
        }
        public Venta ObtenerVenta(int factura)
        {
            return ventaD.ObtenerVenta(factura);
        }
        public List<Proveedor> ObtenerProveedores(string a)
        {
            return ventaD.ObtenerProveedor(a);
        }
        public int ObtenerProximoDetalleVenta()
        {
            return ventaD.ObtenerProximoNumeroDetalleVenta();
        }
        public void GuardarCompra(int numFactura, List<DetalleArticulo> detallesArticulos, string metodo, decimal total, DateTime fechahora, int idProveedor, int activa)
        {
            ventaD.GuardarDetalleCompra(numFactura, detallesArticulos, metodo, total, fechahora, idProveedor, activa);
        }

        public int ObtenerProximoDetalleCompra()
        {
            return ventaD.ObtenerProximoNumeroDetalleCompra();
        }
        public bool ActualizarStock(string nombreArticulo, int cantidad)
        {
            return ventaD.ActualizarStockCompra(nombreArticulo, cantidad);
        }
        public bool ActualizarDeuda(int idproveedor, decimal total)
        {
            return ventaD.ActualizarDeuda(idproveedor, total);
        }
        public List<DetalleArticulo> ObtenerDetalleCompra (int numFact)
        {
            return ventaD.ObtenerDetalleCompra(numFact);
        }
        public List<Venta> ObtenerVentasActivas()
        {
            return ventaD.ObtenerVentasActivas();
        }
        public List<Venta> ObtenerVentasEfectivo()
        {
            return ventaD.ObtenerVentasEfectivo();
        }
        public List<Venta> ObtenerVentasTarjeta()
        {
            return ventaD.ObtenerVentasTarjeta();
        }
        public bool AnularVenta(int numFactura)
        {
            return ventaD.AnularVenta(numFactura);
        }
        public List<Venta> ObtenerVentasAnuladas()
        {
            return ventaD.ObtenerVentasAnuladas();
        }
        public bool ReactivarVenta(int numFactura)
        {
            return ventaD.ReactivarVenta(numFactura);
        }
        public Venta ObtenerDetalle_Venta(int numFact)
        {
            return ventaD.ObtenerDetalle_Venta(numFact);
        }
        public List<string> ObtenerTarjetas()
        {
            return ventaD.ObtenerTarjeta(); 
        }
        public List<Venta> ObtenerComprasActivas()
        {
            return ventaD.ObtenerComprasActivas();
        }
        public List<Venta> ObtenerComprasAnuladas()
        {
            return ventaD.ObtenerComprasAnuladas();
        }
        public List<Venta> ObtenerComprasEfectivo()
        {
            return ventaD.ObtenerComprasEfectivo();
        }
        public List<Venta> ObtenerComprasTarjeta()
        {
            return ventaD.ObtenerComprasTarjeta();
        }
        public bool AnularCompra(int numFactura)
        {
            return ventaD.AnularCompra(numFactura);
        }
        public bool ReactivarCompra(int numFactura)
        {
            return ventaD.ReactivarCompra(numFactura);
        }
        public Venta ObtenerDetalle_Compra(int numFact)
        {
            return ventaD.ObtenerDetalle_Compra(numFact);
        }
        public Dictionary<string, List<VentaDetalle>> CargarResumen(string fechaInicio, string fechaFin)
        {
            return ventaD.CargarResumen(fechaInicio, fechaFin);
        }
    }
}
