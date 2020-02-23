using Email_Campain_Service.Core.Entities;
using Email_Campain_Service.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Repositories
{
    public class EventRepository : Repository<CampaignEvent>, IEventRepository
    {
        public EventRepository(DbContext dbContext)
            : base(dbContext)
        {
              
        }
    }
}
