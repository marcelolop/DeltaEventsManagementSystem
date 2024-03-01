using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public class UpdateEventRequest : CreateEventRequest
    {
        public int EventId { get; set; }
    }
}
