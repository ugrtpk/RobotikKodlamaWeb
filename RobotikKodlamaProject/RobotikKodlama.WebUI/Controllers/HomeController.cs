using Microsoft.AspNetCore.Mvc;
using RobotikKodlama.WebUI.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Text;
using RobotikKodlama.WebUI.Infrastructure;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;

namespace RobotikKodlama.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
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
            sb.AppendLine("BU MESAJ TECHBOT ACADEMY �LET���M SAYFASINDAN GELM��T�R.<br /><br />");
            sb.AppendLine("Ad Soyad: " + model.AdSoyad + "<br />");
            sb.AppendLine("Konu: " + model.Konu + "<br />");
            sb.AppendLine("Telefon: " + model.Telefon + "<br />");
            sb.AppendLine("Email: " + model.Email + "<br />");
            sb.AppendLine("Mesaj: " + model.Mesaj + "<br />");
            sb.AppendLine("Tarih: " + DateTime.Now + "<br />");

            return Ok(Email.SendEmail("Techbot Academy - �LET���M - " + model.Konu, sb.ToString()));
        }

        public IActionResult CKEditor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CKEditor(string editorContent)
        {
            ViewBag.Message = editorContent; // Veriyi al�p View'e geri d�nd�r�yoruz
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                try
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UploadedImages");

                    // E�er klas�r yoksa olu�tur
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(upload.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Dosyay� kaydet
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await upload.CopyToAsync(fileStream);
                    }

                    // Resmin URL'sini olu�tur
                    string fileUrl = $"{Request.Scheme}://{Request.Host}/UploadedImages/{uniqueFileName}";

                    return Json(new { url = fileUrl });
                }
                catch (Exception ex)
                {
                    return Json(new { error = ex.Message });
                }
            }

            return Json(new { error = "Resim y�klenemedi." });
        }

    }
}
