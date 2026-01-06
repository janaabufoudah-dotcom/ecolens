using Microsoft.AspNetCore.Mvc;
using EcoBuildAI.Models;
using EcoBuildAI.Services;
using System.Net;
using System.Net.Mail;

namespace EcoBuildAI.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly AiAnalysisService _ai;

        public AnalysisController()
        {
            _ai = new AiAnalysisService();
        }

        // Display the form
        public IActionResult Form()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        public IActionResult Submit(ConstructionInput input)
        {
            // Call the service to analyze input
            var analysis = _ai.Analyze(input);

            // Send email to the client using the email they entered
            SendEmail(input.ClientEmail, "Your Construction Analysis", analysis);

            // Show the result on the web page
            ViewBag.Result = analysis;
            return View("Result");
        }

        // --------------------------
        // Private method to send email
        // --------------------------
        private void SendEmail(string toEmail, string subject, string body)
        {
            var fromEmail = "ecolensai26@gmail.com";      // <-- Replace with your email (sender)
            var fromPassword = "gkxj nzss oemj iodz";           // <-- Replace with app password
            var smtpServer = "smtp.gmail.com";         // <-- Replace with SMTP server (e.g., smtp.gmail.com)

            var smtp = new SmtpClient(smtpServer)
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true,
            };

            var message = new MailMessage(fromEmail, toEmail, subject, body);
            smtp.Send(message);
        }
    }
}
