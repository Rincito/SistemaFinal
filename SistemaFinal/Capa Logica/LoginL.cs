using SistemaFinal.Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using static SistemaFinal.Capa_Datos.LoginD;

namespace SistemaFinal.Capa_Logica
{
    internal class LoginL
    {
        private LoginD datos = new LoginD();

        public bool ValidarIngreso(string contraIngresada, string rolTexto, out string mensajeError, out int rolNumero, out UsuarioDTO usuarioLogueado)
        {
            mensajeError = string.Empty;
            usuarioLogueado = null;

            // Mapeamos el texto del ComboBox al número de la BD
            // 1 = Administrador, 0 = Vendedor
            rolNumero = (rolTexto == "Administrador") ? 1 : 0;

            // Validamos que se haya ingresado contraseña
            if (string.IsNullOrWhiteSpace(contraIngresada))
            {
                mensajeError = "Por favor, ingrese su contraseña.";
                return false;
            }

            // 1. Obtenemos los usuarios activos con ese rol desde la Capa de Datos
            List<UsuarioDTO> usuariosConRol = datos.ObtenerUsuariosPorRol(rolNumero);

            if (usuariosConRol.Count == 0)
            {
                mensajeError = "No hay usuarios activos registrados con este rol.";
                return false;
            }

            // 2. Convertimos la contraseña ingresada a Hash SHA256
            string hashIngresado = GenerarHashSHA256(contraIngresada);

            // 3. Buscamos si el hash coincide con alguno de los usuarios de ese rol
            foreach (var usuario in usuariosConRol)
            {
                if (usuario.ContraHash == hashIngresado)
                {
                    usuarioLogueado = usuario; // Guardamos el usuario autenticado
                    return true; // Encontró coincidencia, login exitoso
                }
            }

            // Si terminó el bucle sin coincidir
            mensajeError = "Contraseña incorrecta para el rol seleccionado.";
            return false;
        }

        public async Task<(bool Exito, string Mensaje)> ProcesarRecuperacion(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return (false, "Por favor, ingrese un correo electrónico.");
            }

            UsuarioDTO usuario = datos.ObtenerUsuarioPorEmail(email);

            if (usuario == null)
            {
                return (false, "El correo ingresado no se encuentra registrado.");
            }

            if (usuario.Activo == 0)
            {
                return (false, "El correo ingresado no se encuentra registrado.");
            }

            // Genera clave temporal y usa tu GenerarHashSHA256 ya existente
            string claveTemporal = GenerarClaveAleatoria(8);
            string claveTemporalHash = GenerarHashSHA256(claveTemporal);

            if (!datos.ActualizarContraseña(usuario.Id, claveTemporalHash))
            {
                return (false, "Error al actualizar la base de datos.");
            }

            bool correoEnviado = await EnviarCorreoSendGrid(usuario.Email, claveTemporal);

            if (correoEnviado)
            {
                return (true, "Se ha enviado la nueva contraseña a su correo electrónico.");
            }
            else
            {
                return (false, "No se pudo enviar el correo mediante SendGrid.");
            }
        }

        private string GenerarClaveAleatoria(int longitud)
        {
            const string caracteres = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789#$";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < longitud; i++)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        private async Task<bool> EnviarCorreoSendGrid(string emailDestino, string claveTemporal)
        {
            try
            {
                // 1. Pega aquí tu API Key generada en el panel de SendGrid
                string apiKey = "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";

                var client = new SendGridClient(apiKey);

                // 2. Email remitente (DEBE ser una casilla o dominio verificado en SendGrid)
                var from = new EmailAddress("tomas86597@gmail.com", "Sistema de Ventas");

                // 3. Email destinatario
                var to = new EmailAddress(emailDestino);

                string subject = "Restablecimiento de Contraseña";

                // Mensaje en texto plano y HTML (opcional para mejor formato)
                string plainTextContent = $"Hola,\n\nTu nueva contraseña temporal de acceso es: {claveTemporal}\n\nSe recomienda cambiarla al ingresar.";
                string htmlContent = $"<p>Hola,</p><p>Tu nueva contraseña temporal de acceso es: <strong>{claveTemporal}</strong></p><p>Se recomienda cambiarla al ingresar.</p>";

                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                // 4. Envío del correo
                var response = await client.SendEmailAsync(msg);

                if (!response.IsSuccessStatusCode)
                {
                    // Leemos la respuesta exacta que manda el servidor de SendGrid
                    string errorBody = await response.Body.ReadAsStringAsync();
                    System.Windows.Forms.MessageBox.Show(
                        $"Error SendGrid Status: {response.StatusCode}\nDetalle: {errorBody}",
                        "Error de Envío SendGrid",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Excepción C#: {ex.Message}","Excepción",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        private string GenerarHashSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
