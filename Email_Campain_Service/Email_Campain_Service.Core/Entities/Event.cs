using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Email_Campain_Service.Core.Entities
{
    public class Event   
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Campaign Naame")]
        public String CampaignName { get; set; }
        public DateTime CampaignDate { get; set; } 
    }
}
