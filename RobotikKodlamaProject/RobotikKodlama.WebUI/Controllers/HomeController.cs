using Microsoft.AspNetCore.Mvc;
using RobotikKodlama.WebUI.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace RobotikKodlama.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Communication()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Educations()
        {
            return View();
        }

        public IActionResult SSS()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendContactForm([FromBody] ContactViewModel model)
        {
            try
            {
                // G�nderici (Gmail hesab�n)
                string fromEmail = "aysedmrrs@gmail.com";
                string appPassword = "vomqvzdvqemixcxh"; // Buraya Google'dan ald���n 16 karakterli �ifreyi yaz.

                // Al�c�
                string toEmail = "aysedmrrs@gmail.com";

                // SMTP Ayarlar�
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Gmail i�in TLS portu
                    Credentials = new NetworkCredential(fromEmail, appPassword),
                    EnableSsl = true
                };

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("BU MESAJ TECHBOT ACADEMY �LET���M SAYFASINDAN GELM��T�R.<br /><br />");
                sb.AppendLine("Ad Soyad: " + model.AdSoyad + "<br />");
                sb.AppendLine("Konu: " + model.Konu + "<br />");
                sb.AppendLine("Telefon: " + model.Telefon + "<br />");
                sb.AppendLine("Email: " + model.Email + "<br />");
                sb.AppendLine("Mesaj: " + model.Mesaj + "<br />");
                sb.AppendLine("Tarih: " + DateTime.Now + "<br />");
                // E-Posta ��eri�i
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "Techbot Academy - �LET���M - " + model.Konu,
                    Body = sb.ToString(),
                    IsBodyHtml = true
                };

                mail.To.Add(toEmail); // Al�c� e-posta adresini ekle

                // E-Postay� G�nder
                smtpClient.Send(mail);

            }
            catch (Exception ex)
            {
                return Ok("hata");
            }
            
            return Ok("ok");
        }

    }
}
