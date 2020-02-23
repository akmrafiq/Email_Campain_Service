using Email_Campain_Service.Core.Contexts;
using Email_Campain_Service.Core.Repositories;
using Email_Campain_Service.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.UnitOfWorks
{

    public class CampignUnitOfWork : UnitOfWork<CampaignDbContext>, ICampignUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; set; }
        public IEventRepository EventRepository { get; set; }

        public CampignUnitOfWork(string connectionString, string migrationAssemblyName)
          : base(connectionString, migrationAssemblyName)
        {
            CustomerRepository = new CustomerRepository(_dbContext);
            EventRepository = new EventRepository(_dbContext);
        }
    }
}
