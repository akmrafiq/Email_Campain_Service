using Email_Campain_Service.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Services
{
    public interface ICampaignEventService
    {
        void AddEvent(CampaignEvent campaignEvent);
        IEnumerable<CampaignEvent> GetAllEvents();
    }
}
