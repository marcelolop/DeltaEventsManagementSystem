using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public class CreateTicketsRequest
    {
        public int EventId { get; set; }
        public int TicketQuantity { get; set; }
        public decimal TicketPrice { get; set; }
        public required string TicketType { get; set; }
    }
}
