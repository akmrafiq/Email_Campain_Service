using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Entities
{
    public class Event   
    {
        public int Id { get; set; }
        public String CampaignName { get; set; }
        public DateTime CampaignDate { get; set; } 
    }
}
