using Email_Campain_Service.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Email_Campain_Service.Core.Services
{
    interface IEventService
    {
        void AddEvent(Event @event);
    }
}
