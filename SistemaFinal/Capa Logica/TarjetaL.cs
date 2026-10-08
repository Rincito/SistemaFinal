using SistemaFinal.Capa_Datos;
using static SistemaFinal.Capa_Datos.TarjetaD;

namespace SistemaFinal.Capa_Logica
{
    internal class TarjetaL
    {
        TarjetaD tarjetaD = new TarjetaD();
        public bool ExisteTarjeta(string nombreTarjeta)
        {
            return tarjetaD.ExisteTarjeta(nombreTarjeta);
        }
        public bool GuardarTarjeta(string nombreTarjeta)
        {
            if (string.IsNullOrEmpty(nombreTarjeta))
            {
                throw new ArgumentException("El nombre de la tarjeta no puede estar vacío.");
            }
            if (ExisteTarjeta(nombreTarjeta))
            {
                throw new ArgumentException("Ya existe una tarjeta con este nombre.");
            }
            return tarjetaD.GuardarTarjeta(nombreTarjeta);
        }
        public bool BajaTarjeta(string nombreTarjeta, int estado)
        {
            if (string.IsNullOrEmpty(nombreTarjeta))
            {
                throw new ArgumentException("El nombre de la tarjeta no puede estar vacío.");
            }
            return tarjetaD.BajaTarjeta(nombreTarjeta, estado);
        }
        public bool ReactTarjeta(string nombreTarjeta)
        {
            return tarjetaD.ReactTarjeta(nombreTarjeta);
        }
        public List<Tarjeta> ListarTarjetas()
        {
            return tarjetaD.ListarTarjetas();
        }
    }
}
