using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPDAL;
using IPENTITIES;

namespace IPBLL
{
    /// <summary>
    /// This class is responsible for handling the business logic for the Tickets entity
    /// </summary>
    public class TicketsService
    {
        /// <summary>
        /// This method gets all the tickets for a specific event
        /// </summary>
        /// <param name="eventId"> The event id for which the tickets are being retrieved</param>
        /// <returns> A list of tickets for the event</returns>
        public List<Tickets> GetTickets(int eventId)
        {
            List<Tickets> tickets = new List<Tickets>();
            TicketRepository ticketRepository = new TicketRepository();
            tickets = ticketRepository.GetAllTickets(eventId);

            return tickets;
        }

        /// <summary>
        /// This method is used to add a ticket to the database
        /// </summary>
        /// <param name="createTicketsRequest"> The ticket to be added</param>
        /// <returns> True if the ticket was added, false if not</returns>
        /// <exception cref="ArgumentOutOfRangeException"> TicketQuantity, TicketPrice</exception>
        /// <exception cref="ArgumentNullException"> TicketType</exception>
        public bool AddTicket(CreateTicketsRequest createTicketsRequest)
        {
            Tickets tickets = new Tickets
            {
                TicketQuantity = createTicketsRequest.TicketQuantity,
                TicketPrice = createTicketsRequest.TicketPrice,
                TicketType = createTicketsRequest.TicketType
            };

            #region Validations

            if (tickets.TicketQuantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tickets.TicketQuantity), "TicketQuantity cannot be less than or equal to 0");
            }
            if (tickets.TicketPrice <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tickets.TicketPrice), "TicketPrice cannot be less than or equal to 0");
            }
            if (string.IsNullOrEmpty(tickets.TicketType))
            {
                throw new ArgumentNullException(nameof(tickets.TicketType), "TicketType cannot be null or empty");
            }
            if (tickets.TicketType != "VIP" && tickets.TicketType != "General Admission" && tickets.TicketType != "Student")
            {
                throw new ArgumentOutOfRangeException(nameof(tickets.TicketType), "TicketType must be VIP, General Admission, or Student");
            }

            #endregion Validations

            TicketRepository ticketRepository = new TicketRepository();
            return ticketRepository.AddTicket(tickets);
        }

        public bool UpdateTicket(UpdateTicketsRequest updateTicketsRequest)
        {
            Tickets tickets = new Tickets
            {
                TicketId = updateTicketsRequest.TicketId,
                TicketQuantity = updateTicketsRequest.TicketQuantity,
                TicketPrice = updateTicketsRequest.TicketPrice,
                TicketType = updateTicketsRequest.TicketType
            };

            #region Validations

            if (tickets.TicketId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tickets.TicketId), "TicketId cannot be less than or equal to 0");
            }
            if (tickets.TicketQuantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tickets.TicketQuantity), "TicketQuantity cannot be less than or equal to 0");
            }
            if (tickets.TicketPrice <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(tickets.TicketPrice), "TicketPrice cannot be less than or equal to 0");
            }
            if (string.IsNullOrEmpty(tickets.TicketType))
            {
                throw new ArgumentNullException(nameof(tickets.TicketType), "TicketType cannot be null or empty");
            }
            if (tickets.TicketType != "VIP" && tickets.TicketType != "General Admission" && tickets.TicketType != "Student")
            {
                throw new ArgumentOutOfRangeException(nameof(tickets.TicketType), "TicketType must be VIP, General Admission, or Student");
            }

            #endregion Validations

            TicketRepository ticketRepository = new TicketRepository();
            return ticketRepository.UpdateTicket(tickets);
        }

        public bool DeleteTicket(int ticketId)
        {
            TicketRepository ticketRepository = new TicketRepository();
            return ticketRepository.DeleteTicket(ticketId);
        }
    }
}
