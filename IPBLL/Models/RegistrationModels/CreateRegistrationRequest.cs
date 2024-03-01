using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public class CreateRegistrationRequest
    {
        public int EventId { get; set; }
        public int AttendeeId { get; set; }
        public int TicketId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public required string PaymentStatus { get; set; }
        public required string PaymentMethod { get; set; }
        public required string AttendeeName { get; set; }
        public required string AttendeeEmail { get; set; }
        public required string AttendeePhoneNumber { get; set; }
        public required string AttendeeAddress { get; set; }
        public bool  HasConfirmedAttendance { get; set; }
        public required int TicketQuantity { get; set; }
        public required decimal TicketPrice { get; set; }
        public required string TicketType { get; set; }

    }
}
