using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using System.Configuration;
using dominio;
using SendGrid.Helpers.Mail.Model;
using SendGrid.Helpers.Mail;
using System.Xml.Linq;
using System.Net.Mail;

namespace negocio
{
    public class EmailService
    {
        private readonly SendGridClient _cliente;
        private SendGridMessage _mensaje;
        public EmailService()
        {
            _cliente = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_API_KEY"));
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            var from = new EmailAddress("catalogowebnivel3@gmail.com");
            var to = new EmailAddress(emailDestino);
            _mensaje = MailHelper.CreateSingleEmail(from, to, asunto, cuerpo, null);
        }


        public async Task EnviarEmailAsync()
        {
            try
            {
                var response = await _cliente.SendEmailAsync(_mensaje);
                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    throw new Exception($"Error al enviar el correo: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar el correo", ex);
            }
        }
    }
}
