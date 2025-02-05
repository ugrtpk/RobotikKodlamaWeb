using Microsoft.AspNetCore.Mvc;
using RobotikKodlama.WebUI.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Text;
using RobotikKodlama.WebUI.Infrastructure;

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

        public IActionResult Blog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendContactForm([FromBody] ContactViewModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BU MESAJ TECHBOT ACADEMY ÝLETÝÞÝM SAYFASINDAN GELMÝÞTÝR.<br /><br />");
            sb.AppendLine("Ad Soyad: " + model.AdSoyad + "<br />");
            sb.AppendLine("Konu: " + model.Konu + "<br />");
            sb.AppendLine("Telefon: " + model.Telefon + "<br />");
            sb.AppendLine("Email: " + model.Email + "<br />");
            sb.AppendLine("Mesaj: " + model.Mesaj + "<br />");
            sb.AppendLine("Tarih: " + DateTime.Now + "<br />");

            return Ok(Email.SendEmail("Techbot Academy - ÝLETÝÞÝM - " + model.Konu, sb.ToString()));
        }

    }
}
