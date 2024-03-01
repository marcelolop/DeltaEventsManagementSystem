using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPENTITIES;
using Microsoft.Data.SqlClient;

namespace IPDAL
{
    /// <summary>
    /// This class will handle all the database operations for the ticket table
    /// </summary>
    public class TicketRepository
    {
        /// <summary>
        /// This method is used to get all tickets for a specific event
        /// </summary>
        /// <param name="eventId"> The event id to get the tickets for</param>
        /// <returns> A list of tickets for the event</returns>
        public List<Tickets> GetAllTickets(int eventId)
        {
            List<Tickets> tickets = new List<Tickets>();
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_GetTickets";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventId", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    tickets.Add(new Tickets
                    {
                        TicketId = Convert.ToInt32(row["TicketId"]),
                        TicketQuantity = Convert.ToInt32(row["TicketQuantity"]),
                        TicketPrice = Convert.ToDecimal(row["TicketPrice"]),
                        TicketType = Convert.ToString(row["TicketType"])
                    });
                }
            }
            return tickets;
        }


        /// <summary>
        /// This method is used to add a ticket to the database
        /// </summary>
        /// <param name="tickets"> The ticket to be added</param>
        /// <returns> True if the ticket was added, false if not</returns>
        public bool AddTicket(Tickets tickets)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_AddTicket";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@TicketQuantity", tickets.TicketQuantity);
                sqlCommand.Parameters.AddWithValue("@TicketPrice", tickets.TicketPrice);
                sqlCommand.Parameters.AddWithValue("@TicketType", tickets.TicketType);

                connection.Open();
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// This method is used to update a ticket in the database
        /// </summary>
        /// <param name="tickets"> The ticket to be updated</param>
        /// <returns> True if the ticket was updated, false if not</returns>
        public bool UpdateTicket(Tickets tickets)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_UpdateTicket";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@TicketId", tickets.TicketId);
                sqlCommand.Parameters.AddWithValue("@TicketQuantity", tickets.TicketQuantity);
                sqlCommand.Parameters.AddWithValue("@TicketPrice", tickets.TicketPrice);
                sqlCommand.Parameters.AddWithValue("@TicketType", tickets.TicketType);

                connection.Open();
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                connection.Close();

               if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// This method is used to delete a ticket from the database
        /// </summary>
        /// <param name="ticketId"> The ticket id to be deleted</param>
        /// <returns> True if the ticket was deleted, false if not</returns>
        public bool DeleteTicket(int ticketId)
        {
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_DeleteTicket";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@TicketId", ticketId);

                connection.Open();
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                connection.Close();

               if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// This method is used to get a specific ticket from the database
        /// </summary>
        /// <param name="ticketId"> The ticket id to get</param>
        /// <returns> The ticket with the specified id</returns>
        public Tickets GetTicket(int ticketId)
        {
            Tickets ticket = new Tickets();
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_GetTicket";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@TicketId", ticketId);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    ticket.TicketId = Convert.ToInt32(row["TicketId"]);
                    ticket.TicketQuantity = Convert.ToInt32(row["TicketQuantity"]);
                    ticket.TicketPrice = Convert.ToDecimal(row["TicketPrice"]);
                    ticket.TicketType = Convert.ToString(row["TicketType"]);
                }
            }
            return ticket;
        }
    }
}
