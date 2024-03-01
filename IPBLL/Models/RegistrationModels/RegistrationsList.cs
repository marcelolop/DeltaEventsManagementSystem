using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL.Models.RegistrationModels
{
    public class RegistrationsList
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int AttendeeId { get; set; }
        public int TicketId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public string AttendeeName { get; set; }
        public string AttendeeEmail { get; set; }
        public string AttendeePhoneNumber { get; set; }
        public string AttendeeAddress { get; set; }
        public bool HasConfirmedAttendance { get; set; }
        public int TicketQuantity { get; set; }
        public decimal TicketPrice { get; set; }
        public string TicketType { get; set; }
    }
}
