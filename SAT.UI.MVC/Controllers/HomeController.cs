using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using SAT.UI.MVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace SAT.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string message = $"You have recieved an email from {cvm.Name} with a subject of + " +
                $"{cvm.Subject}. Respond to {cvm.Email}. Message:<br />{cvm.Message}";

            MailMessage mm = new MailMessage("admin@mitchellandtech.com", "mitchellb.67577@gmail.com",
               cvm.Subject, message);

            mm.IsBodyHtml = true;

            mm.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient("mail.mitchellandtech.com");

            client.Credentials = new NetworkCredential("admin@mitchellandtech.com", "Blackjack17!");

            try
            {
                client.Send(mm);
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = $"Your message could not be sent at this time. Please" +
                    $"try again later. <br />Error message:<br />{ex.Message}.";

                return View(cvm);
            }


            return View("EmailConfirmation", cvm);
        }
    }
}
