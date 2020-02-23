using Email_Campain_Service.Core.Entities;
using Email_Campain_Service.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Services
{
    public class CampaignEventService : ICampaignEventService
    {
        private ICampignUnitOfWork _campignUnitOfWork;

        public CampaignEventService(ICampignUnitOfWork campignUnitOfWork)
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
        public IEnumerable<CampaignEvent> GetAllEvents()
        {
            return _campignUnitOfWork.EventRepository.GetAllItem();
        }
    }
}
