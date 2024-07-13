using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;
using System.Net;

namespace negocio.Utils
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient smtp;

        public EmailService()
        {
            smtp = new SmtpClient();
            //smtp.Credentials = new NetworkCredential("ignacioromano77@gmail.com", "cecj iyom rnws vfud");
            smtp.Credentials = new NetworkCredential("ManoExperta.Soporte@gmail.com", "Man03xP3r7a2@24");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
        }

        public void armarMail(string destino, string asunto, string cuerpo)
        {

            email = new MailMessage();
            email.From = new MailAddress("Actaulizaciones@ManoExperta.com", "Soporte ManoExperta");
            email.Subject = asunto;
            email.To.Add(destino);
            email.IsBodyHtml = true;
            email.Body = "<!DOCTYPE html><html><head><meta charset='utf-8'><meta http - equiv='X-UA-Compatible' content='IE=edge'><title> Actualizaciones ManoExperta </title><meta name='viewport' content='width=device-width, initial-scale=1'></head><body><header><p style='font-family: Impact, Haettenschweiler,  Arial Narrow Bold, sans-serif; font-style: italic; font-size: 2em;'> ManoExperta </p></header><section><div style='background-color: azure; font-family: Arial, Helvetica, sans-serif;'><p><span> Estimado/a </span></p><p>" + cuerpo + "</p></div><a href=\"https://google.com.ar\" target=\"_blank\" style='background-color: #428eff; border: none; color: white; padding: 15px 32px; text-align: center;text-decoration: none;display: inline-block; font-size:16px; margin: 4px 2px; cursor:pointer'> Mi Ticket</a></section></body ></html>";
        }

        public void enviarCorreo()
        {
            try
            {
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
