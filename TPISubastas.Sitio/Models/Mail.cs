using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TPISubastas.Sitio.Models
{
    public class Mail
    {
        /*  public string From { get; set; }
          public string To = "gastondeniscomutec@gmail.com";
          public string Subject = "Curriculum Vitae";
          public string Body { get; set; }
        */
        private string EmailOrigen = "emaildevpruebas@gmail.com";
        string password = "devpruebas";
        public string EmailDestino { get; set; }
        public string AsuntoEmail { get; set; }

        public void enviar(string _body)
        {
            MailMessage mailMessage = new MailMessage(EmailOrigen, EmailDestino, AsuntoEmail, _body);
            mailMessage.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            //client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(EmailOrigen, password);

            client.Send(mailMessage);
            client.Dispose();
        }

    }
}
