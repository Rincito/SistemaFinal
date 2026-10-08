using SistemaFinal.Capa_Datos;
using static SistemaFinal.Capa_Datos.RubroD;

namespace SistemaFinal.Capa_Logica
{
    internal class RubroL
    {
        private RubroD datosRubro = new RubroD();

        public bool GuardarRubro(string nombreRubro)
        {
            if (string.IsNullOrWhiteSpace(nombreRubro))
            {
                throw new ArgumentException("El nombre del rubro no puede estar vacío.");
            }

            return datosRubro.InsertarRubro(nombreRubro);
        }
        public List<Rubro> ListarRubros()
        {
            return datosRubro.Rubros();
        }
        public bool BajaRubro(string Rubro, int nuevoActivo)
        {
            return datosRubro.BajaRubro(Rubro, nuevoActivo);
        }
        public bool ReactRubro(string Rubro, int nuevoActivo)
        {
            return datosRubro.ReactRubro(Rubro, nuevoActivo);
        }
    }
}
