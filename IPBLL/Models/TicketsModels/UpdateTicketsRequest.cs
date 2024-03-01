using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public class UpdateTicketsRequest : CreateTicketsRequest
    {
        public int TicketId { get; set; }
    }
}
