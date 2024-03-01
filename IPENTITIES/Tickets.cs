using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPENTITIES
{
    /// <summary>
    /// This class contains the properties of the Tickets entity
    /// </summary>
    public class Tickets
    {
        //Private fields
        private int _ticketId;
        private int _ticketQuantity;
        private decimal _ticketPrice;
        private string _ticketType;


        //Public properties
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

        public int TicketQuantity
        {
            get => _ticketQuantity;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(TicketQuantity), "TicketQuantity cannot be less than or equal to 0");
                }
                _ticketQuantity = value;
            }
        }

        public decimal TicketPrice
        {
            get => _ticketPrice;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(TicketPrice), "TicketPrice cannot be less than or equal to 0");
                }
                _ticketPrice = value;
            }
        }

        public string TicketType
        {
            get => _ticketType;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(TicketType), "TicketType cannot be null or empty");
                }
                if (value.Length > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(TicketType), "TicketType cannot be more than 255 characters");
                }
                _ticketType = value;
            }
        }

        //Default constructor
        public Tickets()
        {
        }

        //Parameterized constructor
        public Tickets(int ticketId, int ticketQuantity, decimal ticketPrice, string ticketType)
        {
            TicketId = ticketId;
            TicketQuantity = ticketQuantity;
            TicketPrice = ticketPrice;
            TicketType = ticketType;
        }



    }
}
