using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;

namespace RobotikKodlama.WebUI.Infrastructure
{
    public class Email
    {
        public static string SendEmail(string pSubject, string pBody)
        {
            try
            {
                // Gönderici (Gmail hesabın)
                string fromEmail = "aysedmrrs@gmail.com";
                string appPassword = "vomqvzdvqemixcxh"; // Buraya Google'dan aldığın 16 karakterli şifreyi yaz.

                // Alıcı
                string toEmail = "aysedmrrs@gmail.com";

                // SMTP Ayarları
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Gmail için TLS portu
                    Credentials = new NetworkCredential(fromEmail, appPassword),
                    EnableSsl = true
                };

                // E-Posta İçeriği
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = pSubject,
                    Body = pBody,
                    IsBodyHtml = true
                };

                mail.To.Add(toEmail); // Alıcı e-posta adresini ekle

                // E-Postayı Gönder
                smtpClient.Send(mail);

            }
            catch (Exception ex)
            {
                return "hata";
            }

            return "ok";
        }

    }
}