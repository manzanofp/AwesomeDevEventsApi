using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDevEvents.Data.Context
{
    public class DevEventsContext
    {
        public List<DevEvent> DevEvents { get; set; }

        public DevEventsContext()
        {
            DevEvents = new List<DevEvent>();
        }
    }
}