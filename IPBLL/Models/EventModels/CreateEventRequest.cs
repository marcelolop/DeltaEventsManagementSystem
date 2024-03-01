using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public class CreateEventRequest
    {
        public required string EventName { get; set; }
        public required string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public required string EventLocation { get; set; }
        public int MaxAttendees { get; set; }
        public required string OrganizerName { get; set; }
        public required string OrganizerContact { get; set; }

    }
}
