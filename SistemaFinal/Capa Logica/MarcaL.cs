using SistemaFinal.Capa_Datos;
using static SistemaFinal.Capa_Datos.MarcaD;

namespace SistemaFinal.Capa_Logica
{
    internal class MarcaL
    {
        private MarcaD marcaD = new MarcaD();

        public bool GuardarMarca(string nombreMarca)
        {
            if (string.IsNullOrWhiteSpace(nombreMarca))
            {
                throw new ArgumentException("El nombre de la marca no puede estar vacío.");
            }

            return marcaD.InsertarMarca(nombreMarca);
        }
        public List<Marca> ListarMarcas()
        {
            return marcaD.Marcas();
        }
        public bool BajaMarca(string Marca, int nuevoActivo)
        {
            return marcaD.BajaMarca(Marca, nuevoActivo);
        }
        public bool ReactMarca(string Marca, int nuevoActivo)
        {
            return marcaD.ReactMarca(Marca, nuevoActivo);
        }
    }
}
