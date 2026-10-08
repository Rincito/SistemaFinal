using SistemaFinal.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using static SistemaFinal.Capa_Datos.UsuarioD;

namespace SistemaFinal.Capa_Logica
{
    internal class UsuarioL
    {
        private UsuarioD usuarioD = new UsuarioD();

        public List<UsuarioDTO> ListarUsuarios()
        {
            return usuarioD.ObtenerUsuarios();
        }

        public bool GuardarUsuario(string email, string contraTextoPlano, int rol)
        {
            // Validaciones básicas de negocio
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contraTextoPlano))
            {
                return false;
            }

            // Aplicamos Hash SHA-256 a la contraseña
            string contraHash = GenerarHashSHA256(contraTextoPlano);

            // Guardamos en la base de datos
            return usuarioD.InsertarUsuario(email, contraHash, rol);
        }

        public bool CambiarEstadoUsuario(int idUsuario, int nuevoEstado)
        {
            return usuarioD.ActualizarEstadoUsuario(idUsuario, nuevoEstado);
        }

        public bool ModificarUsuario(int idUsuario, string email, int rol, string nuevaContraTextoPlano)
        {
            if (idUsuario <= 0 || string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string nuevaContraHash = null;

            // Solo generamos Hash si el usuario escribió una contraseña nueva
            if (!string.IsNullOrWhiteSpace(nuevaContraTextoPlano))
            {
                nuevaContraHash = GenerarHashSHA256(nuevaContraTextoPlano);
            }

            return usuarioD.ModificarUsuario(idUsuario, email, rol, nuevaContraHash);
        }

        private string GenerarHashSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
