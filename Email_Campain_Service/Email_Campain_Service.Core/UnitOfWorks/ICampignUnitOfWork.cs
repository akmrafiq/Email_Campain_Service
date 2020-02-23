using Email_Campain_Service.Core.Contexts;
using Email_Campain_Service.Core.Repositories;
using Email_Campain_Service.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.UnitOfWorks
{
   
    public interface ICampignUnitOfWork : IUnitOfWork<CampaignDbContext>
    {
        ICustomerRepository CustomerRepository { get; set; }
        IEventRepository EventRepository { get; set; }
    }
}
