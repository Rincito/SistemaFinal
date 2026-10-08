using SistemaFinal.Capa_Datos;
using SistemaFinal.Capa_Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Capa_Logica
{
    internal class CajaL
    {
        CajaD CajaD = new CajaD();
        public bool CajaInicialExistente(string fecha)
        {
            return CajaD.CajaInicialExistente(fecha);
        }
        
        public void GuardarMontoInicial(string fecha, decimal monto)
        {
            CajaD.GuardarMontoInicial(fecha, monto);
        }
        public string MontoInicio(string fecha)
        {
            return CajaD.MontoInicio(fecha);
        }
        public string VentasEfect(string fecha)
        {
            return CajaD.VentasEfect(fecha);
        }
        public string OtrosEfect(string fecha)
        {
            return CajaD.OtrosEfect(fecha);
        }
        public string CCEfect(string fecha)
        {
            return CajaD.CCEfect(fecha);
        }
        public string VentasTarj(string fecha)
        {
            return CajaD.VentasTarj(fecha);
        }
        public string OtrosTarj(string fecha)
        {
            return CajaD.OtrosTarj(fecha);
        }
        public string EgresoOtrosTarj(string fecha)
        {
            return CajaD.EgresoOtrosTarj(fecha);
        }
        public string CCTarj(string fecha)
        {
            return CajaD.CCTarj(fecha);
        }
        public string ComprasEfect(string fecha)
        {
            return CajaD.ComprasEfect(fecha);
        }
        public string PagosProvEfect(string fecha)
        {
            return CajaD.PagosProvEfect(fecha);
        }
        public string PagosVendEfect(string fecha)
        {
            return CajaD.PagosVendEfect(fecha);
        }
        public string RetiroOtrosEfect(string fecha)
        {
            return CajaD.RetiroOtrosEfect(fecha);
        }
        public string ComprasTarj(string fecha)
        {
            return CajaD.ComprasTarj(fecha);
        }
        public string PagosProvTarj(string fecha)
        {
            return CajaD.PagosProvTarj(fecha);
        }
        public string PagosVendTarj(string fecha)
        {
            return CajaD.PagosVendTarj(fecha);
        }

        public void GuardarIngreso(string fecha, decimal ingreso, string formapago)
        {
            CajaD.GuardarIngreso(fecha, ingreso, formapago);
        }
        public void GuardarGasto(string fecha, decimal ingreso, string formapago, string detalle)
        {
            CajaD.GuardarGasto(fecha, ingreso, formapago, detalle);
        }
        public void GuardarRetiro(string fecha, decimal retiro)
        {
            CajaD.GuardarRetiro(fecha, retiro);
        }
        public void CierreCaja(string fecha, decimal totalEfect, decimal totalTarj, decimal totalDia, decimal Cierre, decimal Inicio)
        {
            CajaD.CierreCaja(fecha, totalEfect, totalTarj, totalDia, Cierre, Inicio);
        }
        public void GuardarVentaTarjeta(int numFact, string tarjeta)
        {
            CajaD.GuardarVentaTarjeta(numFact, tarjeta);
        }
        public void ModMontoInicio(string montoNuevo)
        {
            CajaD.ModMontoInicio(montoNuevo);
        }
        public void PagoCC(string fechaActual, decimal ingreso, string formapago)
        {
            CajaD.PagoCC(fechaActual, ingreso, formapago);
        }
        public bool CajaCerrada(string fecha)
        {
            return CajaD.CajaCerrada(fecha);
        }
        public void NotifiCaja(string cajaActu, string cajaNueva)
        {
            CajaD.NotifiCaja(cajaActu, cajaNueva);
        }
        public void NotifiCierreCaja(decimal totalEfect, decimal totalTarj, decimal totalDia, decimal Cierre, decimal Inicio)
        {
            CajaD.NotifiCierreCaja(totalEfect, totalTarj, totalDia, Cierre, Inicio);
        }
        public void NotifiRetiro(decimal monto)
        {
            CajaD.NotifiRetiro(monto);
        }
        public void NotifiGasto(decimal monto, string formapago, string detalle)
        {
            CajaD.NotifiGasto(monto, formapago, detalle);
        }
        public void NotifiIngreso(decimal monto, string formapago)
        {
            CajaD.NotifiIngreso(monto, formapago);
        }
        public void NotifiPagoVend(decimal pago, string formapago, string vendedor)
        {
            CajaD.NotifiPagoVend(pago, formapago, vendedor);
        }
        public void GuardarPago(decimal pago, string formapago, string vendedor)
        {
            CajaD.GuardarPago(pago, formapago, vendedor);
        }
    }
}
