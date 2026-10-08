using SistemaFinal.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SistemaFinal.Capa_Datos.GastoD;

namespace SistemaFinal.Capa_Logica
{
    internal class GastoL
    {
        private GastoD Gastos = new GastoD();

        public bool GuardarGasto(string nombreGasto)
        {
            if (string.IsNullOrWhiteSpace(nombreGasto))
            {
                throw new ArgumentException("El nombre del gasto no puede estar vacío.");
            }

            return Gastos.InsertarGasto(nombreGasto);
        }
        public List<Gasto> ListarGastos()
        {
            return Gastos.Gastos();
        }
        public bool BajaGasto(string Gasto, int nuevoActivo)
        {
            return Gastos.BajaGasto(Gasto, nuevoActivo);
        }
        public bool ReactGasto(string Gasto, int nuevoActivo)
        {
            return Gastos.ReactGasto(Gasto, nuevoActivo);
        }
        public List<string> obtenerGastos()
        {
            return Gastos.ObtenerGasto();
        }
    }
}
