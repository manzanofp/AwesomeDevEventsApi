using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDevEvents.Entities
{
    public class DevEventSpeaker
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string LinkedProfile {get; set;}
    }
}