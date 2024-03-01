namespace IPENTITIES
{
    /// <summary>
    /// This class represents the Registrations entity
    /// </summary>
    public class Registrations
    {
        //private fields
        private int _eventId;
        private int _attendeeId;
        private int _ticketId;
        private DateTime _registrationDate;
        private string _paymentStatus;
        private string _paymentMethod;
        private decimal _totalAmountPaid;
        private Attendees _attendee;
        private Tickets _ticket;
        private Events _event;


        public int EventId
        {
            get => _eventId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(EventId), "EventId cannot be less than or equal to 0");
                }
                _eventId = value;
            }
        }

        public int AttendeeId
        {
            get => _attendeeId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(AttendeeId), "AttendeeId cannot be less than or equal to 0");
                }
                _attendeeId = value;
            }
        }

        public DateTime RegistrationDate
        {
            get => _registrationDate;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(RegistrationDate), "RegistrationDate cannot be null");
                }
                if (value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(nameof(RegistrationDate), "RegistrationDate cannot be in the future");
                }
                _registrationDate = value;
            }
        }

        public string PaymentStatus
        {
            get => _paymentStatus;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(PaymentStatus), "PaymentStatus cannot be null or empty");
                }
                if (value != "Paid" && value != "Pending" && value != "Refunded")
                {
                    throw new ArgumentOutOfRangeException(nameof(PaymentStatus), "PaymentStatus must be Paid, Pending, or Refunded");
                }
                _paymentStatus = value;
            }
        }

        public string PaymentMethod
        {
            get => _paymentMethod;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(PaymentMethod), "PaymentMethod cannot be null or empty");
                }
                if (value != "Credit Card" && value != "PayPal" && value != "Cash")
                {
                    throw new ArgumentOutOfRangeException(nameof(PaymentMethod), "PaymentMethod must be Credit Card, PayPal, or Cash");
                }
                _paymentMethod = value;
            }
        }

        public decimal TotalAmountPaid
        {
            get => _totalAmountPaid;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(TotalAmountPaid), "TotalAmountPaid cannot be less than or equal to 0");
                }
                _totalAmountPaid = value;
            }
        }

        public int TicketId
        {
            get => _ticketId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(TicketId), "TicketId cannot be less than or equal to 0");
                }
                _ticketId = value;
            }
        }

        public Attendees Attendee
        {
            get => _attendee;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Attendee), "Attendee cannot be null");
                }
                _attendee = value;
            }
        }

        public Tickets Ticket
        {
            get => _ticket;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Ticket), "Ticket cannot be null");
                }
                _ticket = value;
            }
        }

        public Events Event
        {
            get => _event;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Event), "Event cannot be null");
                }
                _event = value;
            }
        }


        //default constructor
        public Registrations()
        {
        }

        //parameterized constructor
        public Registrations(int eventId, int attendeeId, int ticketId, DateTime registrationDate, string paymentStatus, string paymentMethod)
        {
            EventId = eventId;
            AttendeeId = attendeeId;
            TicketId = ticketId;
            RegistrationDate = registrationDate;
            PaymentStatus = paymentStatus;
            PaymentMethod = paymentMethod;
        }


    }
}
