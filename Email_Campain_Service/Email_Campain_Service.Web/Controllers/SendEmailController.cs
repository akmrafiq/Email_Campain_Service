using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Email_Campain_Service.Core.Entities;
using Email_Campain_Service.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Email_Campain_Service.Web.Controllers
{
    public class SendEmailController : Controller
    {
        private readonly ILogger<SendEmailController> _logger;
        private readonly IConfiguration _config;

        public SendEmailController(ILogger<SendEmailController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            using (var mailsender = new MailSender(_config))
            {
                mailsender.Send(new List<MailMessage>
                {
                    new MailMessage
                    {
                        Body = "This is test",
                        Receiver = "akmrafiq450@gmail.com",
                        Sender = "akmrafiq485@gmail.com",
                        SenderName = "AKM Rafiqul Alam",
                        Subject = "Testing"
                    }
                });
            }

            _logger.LogInformation("Hello, {Name}!", "Rafiqul Alam");
            return View();
        }
    }
}