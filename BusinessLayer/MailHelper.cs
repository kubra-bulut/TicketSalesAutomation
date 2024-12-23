using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class MailHelper
    {
        // E-posta gönderme metodu
        public static void SendMail(string toEmail, string subject, string body)
        {
            try
            {
                // E-posta gönderme için SMTP ayarları
                var fromAddress = new MailAddress("kubrabuulut@gmail.com", "Ticket Sales");
                var toAddress = new MailAddress(toEmail);
                const string fromPassword = "fdtp loin kcxc ggaw"; // E-posta şifresi
                string smtpServer = "smtp.gmail.com"; // SMTP server (Gmail için: smtp.gmail.com)
                int smtpPort = 587; // SMTP port (Gmail için: 587)

                var smtp = new SmtpClient
                {
                    Host = smtpServer,
                    Port = smtpPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                // E-posta içeriğini oluştur
                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };

                // E-posta gönder
                smtp.Send(message);

                Console.WriteLine($"E-posta gönderildi: {toEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderilirken hata oluştu: {ex.Message}");
                throw;
            }
        }
    }
}
