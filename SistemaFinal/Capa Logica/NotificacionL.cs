using SistemaFinal.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFinal.Capa_Logica
{
    internal class NotificacionL
    {
        private NotificacionD notificacionD = new NotificacionD();

        public bool RegistrarNotificacion(string tema, string titulo, string descripcion)
        {
            return notificacionD.RegistrarNotificacion(tema, titulo, descripcion);
        }

        public List<Notificacion> ObtenerNotificaciones(string categoria = "Todas")
        {
            return notificacionD.ObtenerNotificaciones(categoria);
        }

        public int ObtenerCantidadNoLeidas()
        {
            return notificacionD.ObtenerCantidadNoLeidas();
        }

        public void MarcarTodasComoLeidas()
        {
            notificacionD.MarcarTodasComoLeidas();
        }
    }
}
