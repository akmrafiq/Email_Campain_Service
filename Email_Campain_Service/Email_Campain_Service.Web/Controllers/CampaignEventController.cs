using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Email_Campain_Service.Core.Services;
using Microsoft.Extensions.Logging;
using Email_Campain_Service.Core.Entities;

namespace Email_Campain_Service.Web.Controllers
{
    public class CampaignEventController : Controller
    {
        private ICampaignEventService _campaignEventService;
        private readonly ILogger _logger;

        public CampaignEventController(ICampaignEventService campaignEventService)
        {
            _campaignEventService = campaignEventService;
        }
        public ActionResult<CampaignEvent> Index()
        {
            var list = _campaignEventService.GetAllEvents();
            return View(list);
        }
        public IActionResult Add()
        {
            var model = new CampaignEvent();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(CampaignEvent  campaignEvent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _campaignEventService.AddEvent(campaignEvent);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Exception", ex);
                    return View(campaignEvent);
                };
            }
            return RedirectToAction("Index");
        }
    }
}