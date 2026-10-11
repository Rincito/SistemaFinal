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
        public int ObtenerProximoDetalleVenta()
        {
            return ventaD.ObtenerProximoNumeroDetalleVenta();
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
        
        public Dictionary<string, List<VentaDetalle>> CargarResumen(string fechaInicio, string fechaFin)
        {
            return ventaD.CargarResumen(fechaInicio, fechaFin);
        }

        public Dictionary<string, List<VentaDetalle>> CargarResumenTarjetasDelDia(string fecha)
        {
            VentasD ventasD = new VentasD();
            return ventasD.CargarResumenTarjetasDelDia(fecha);
        }
    }
}
