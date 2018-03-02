using CasaDeTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CasaDeTech.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void ContactUs(Form fm)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("info@casadetech.com");

            mail.From = new MailAddress(fm.email);
            mail.Subject = fm.subject.ToString();
            string Body = fm.message;
            mail.Body = "From: "+fm.email+System.Environment.NewLine+Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential
            ("work.casadetech@gmail.com", "abcd_1234");
            
            smtp.Send(mail);
        }
    }
}