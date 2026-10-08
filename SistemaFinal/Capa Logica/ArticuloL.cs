using SistemaFinal.Capa_Datos;

namespace SistemaFinal.Capa_Logica
{
    internal class ArticuloL
    {
        ArticuloD articuloD = new ArticuloD();
        public List<string> ObtenerListaRubros()
        {
            return articuloD.ObtenerRubros();
        }
        public List<string> ObtenerListaMarcas()
        {
            return articuloD.ObtenerMarcas();
        }
        public List<string> ObtenerListaProvs()
        {
            return articuloD.ObtenerProveedores();
        }
        public bool GuardarProducto(string codigo, string nombre, int stock, decimal costo, decimal precio, int stockCritico, decimal iva, decimal ganancia, string marca, string rubro, string proveedor)
        {
            try
            {

                int proveedorID = articuloD.ObtenerIDProveedorPorNombre(proveedor);

                if (proveedorID == 0)
                {
                    throw new Exception("El proveedor seleccionado no existe.");
                }
                if (articuloD.ExisteArticulo(codigo, nombre))
                {
                    throw new Exception("Ya existe un artículo con el mismo código o nombre.");
                }

                return articuloD.GuardarProducto(codigo, nombre, stock, costo, precio, stockCritico, iva, ganancia, marca, rubro, proveedorID);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la capa lógica al guardar el producto: " + ex.Message + "\n" + ex.StackTrace);
            }
        }
        public List<Articulo> ListarArticulos()
        {
            return articuloD.ListarArticulos();
        }
        public bool DarDeBajaArticulo(string codigo)
        {
            try
            {
                return articuloD.DarDeBajaArticulo(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el artículo: " + ex.Message);
            }
        }
        public bool DarDeAltaArticulo(string codigo)
        {
            try
            {
                return articuloD.DarDeAltaArticulo(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el artículo: " + ex.Message);
            }
        }
        public bool ActualizarArticulo(Articulo articulo, string codviejo)
        {
            ArticuloD articuloD = new ArticuloD();

            if (string.IsNullOrWhiteSpace(articulo.Codigo))
            {
                throw new ArgumentException("El código del artículo no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(articulo.Nombre))
            {
                throw new ArgumentException("El nombre del artículo no puede estar vacío.");
            }

            if (articulo.Precio <= 0)
            {
                throw new ArgumentException("El precio debe ser mayor a 0.");
            }

            if (articulo.Costo <= 0)
            {
                throw new ArgumentException("El costo debe ser mayor a 0.");
            }

            if (articulo.Stock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }

            return articuloD.ActualizarArticulo(articulo, codviejo);

        }
        public bool BorrarArticulo(string codigo)
        {
            try
            {
                ArticuloD articuloD = new ArticuloD();
                return articuloD.BorrarArticulo(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar eliminar el artículo.", ex);
            }
        }

    }
}
