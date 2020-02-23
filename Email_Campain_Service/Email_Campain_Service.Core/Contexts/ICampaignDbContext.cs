using Email_Campain_Service.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Contexts
{
    public interface ICampaignDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Event> Events { get; set; }
    }
}
