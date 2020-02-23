using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Email_Campain_Service.Core.Entities;
using Email_Campain_Service.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmailProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private ICustomerService _customerService;
        private MailSender _mailSender;
        private ICampaignEventService _campaignEventService;
        private readonly IConfiguration _config;

        public Worker(ILogger<Worker> logger,
            ICustomerService customerService,
            MailSender mailSender,
            ICampaignEventService campaignEventService,
            IConfiguration config)
        {
            _config = config;
            _logger = logger;
            _customerService = customerService;
            _campaignEventService = campaignEventService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var eventList = GetEvent();
                if (eventList != null)
                {
                    var customerlist = GetCustomers();
                    if (customerlist != null)
                    {
                        foreach (var item in customerlist)
                        {
                            using (var mailsender = new MailSender(_config))
                            {
                                mailsender.Send(new List<MailMessage>
                                {
                                    new MailMessage
                                    {
                                        Body = "This is test",
                                        Receiver = item.Email,
                                        Sender = "akmrafiq485@gmail.com",
                                        SenderName = "AKM Rafiqul Alam",
                                        Subject = "Testing"
                                    }
                                });
                            }
                            _logger.LogInformation("Hello, {Name}!", "AKM Rafiqul Alam");
                        }
                    }
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
        private IEnumerable<CampaignEvent> GetEvent()
        {
            var list = _campaignEventService.GetAllEvents();
            var currentlist = list.Where(c => c.CampaignDate == DateTime.Now).ToList();
            return list;
        }
        private IEnumerable<Customer> GetCustomers()
        {
            var list = _customerService.GetCustomers();
            return list;
        }
    }
}
