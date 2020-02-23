using Email_Campain_Service.Core.Entities;
using Email_Campain_Service.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Services
{
    public class EventService : IEventService
    {
        private ICampignUnitOfWork _campignUnitOfWork;

        public EventService(ICampignUnitOfWork campignUnitOfWork)
        {
            _campignUnitOfWork = campignUnitOfWork;
        }
        public void AddEvent(CampaignEvent campaignEvent)
        {
            if (campaignEvent == null || string.IsNullOrWhiteSpace(campaignEvent.CampaignName))
                throw new InvalidOperationException("Incomplete information");
            _campignUnitOfWork.EventRepository.Add(campaignEvent);
            _campignUnitOfWork.Save();
        }
    }
}
