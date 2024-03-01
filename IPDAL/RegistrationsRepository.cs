using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPENTITIES;
using Microsoft.Data.SqlClient;

namespace IPDAL
{
    /// <summary>
    /// This class handles all the database operations for the Registrations entity
    /// </summary>
    public class RegistrationsRepository
    {
        /// <summary>
        /// This method is used to get all the registrations from the database
        /// </summary>
        /// <returns> A list of registrations</returns>
        public List<Registrations> GetAllEventsRegistrations()
        {
            List<Registrations> registrations = new List<Registrations>();
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_GetAllRegistrations";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
          
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    registrations.Add(new Registrations
                    {
                        EventId = Convert.ToInt32(row["EventId"]),
                        Event = new Events
                        { 
                            EventName = Convert.ToString(row["EventName"]),
                        },
                        AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                        TicketId = Convert.ToInt32(row["TicketId"]),
                        RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]),
                        PaymentStatus = Convert.ToString(row["PaymentStatus"]),
                        PaymentMethod = Convert.ToString(row["PaymentMethod"]),
                        TotalAmountPaid = Convert.ToDecimal(row["TotalAmountPaid"]),
                        Attendee = new Attendees
                        {
                            AttendeeName = Convert.ToString(row["AttendeeName"]),
                            AttendeeEmail = Convert.ToString(row["AttendeeEmail"]),
                            AttendeePhoneNumber = Convert.ToString(row["AttendeePhoneNumber"]),
                            AttendeeAddress = Convert.ToString(row["AttendeeAddress"]),
                            HasConfirmedAttendance = Convert.ToBoolean(row["HasConfirmedAttendance"])
                        },
                        Ticket = new Tickets
                        {
                            TicketQuantity = Convert.ToInt32(row["TicketQuantity"]),
                            TicketPrice = Convert.ToDecimal(row["TicketPrice"]),
                            TicketType = Convert.ToString(row["TicketType"])
                        }

                    });
                }
            }
            return registrations;
        }

        /// <summary>
        /// This method is used to add a registration to the database
        /// </summary>
        /// <param name="registrations"> The registration to be added</param>
        /// <returns> True if the registration was added, false if not</returns>
        public bool AddRegistration(Registrations registrations)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_AddRegistration";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventId", registrations.EventId);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registrations.RegistrationDate);
                sqlCommand.Parameters.AddWithValue("@PaymentStatus", registrations.PaymentStatus);
                sqlCommand.Parameters.AddWithValue("@PaymentMethod", registrations.PaymentMethod);
                sqlCommand.Parameters.AddWithValue("@TotalAmountPaid", registrations.Ticket.TicketQuantity * registrations.Ticket.TicketPrice);
                sqlCommand.Parameters.AddWithValue("@AttendeeName", registrations.Attendee.AttendeeName);
                sqlCommand.Parameters.AddWithValue("@AttendeeEmail", registrations.Attendee.AttendeeEmail);
                sqlCommand.Parameters.AddWithValue("@AttendeePhoneNumber", registrations.Attendee.AttendeePhoneNumber);
                sqlCommand.Parameters.AddWithValue("@AttendeeAddress", registrations.Attendee.AttendeeAddress);
                sqlCommand.Parameters.AddWithValue("@HasConfirmedAttendance", registrations.Attendee.HasConfirmedAttendance);
                sqlCommand.Parameters.AddWithValue("@TicketQuantity", registrations.Ticket.TicketQuantity);
                sqlCommand.Parameters.AddWithValue("@TicketPrice", registrations.Ticket.TicketPrice);
                sqlCommand.Parameters.AddWithValue("@TicketType", registrations.Ticket.TicketType);


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
        /// This method is used to update a registration in the database
        /// </summary>
        /// <param name="registrations"> The registration to be updated</param>
        /// <returns> True if the registration was updated, false if not</returns>
        public bool UpdateRegistration(Registrations registrations)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_UpdateRegistration";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventId", registrations.EventId);
                sqlCommand.Parameters.AddWithValue("@AttendeeId", registrations.AttendeeId);
                sqlCommand.Parameters.AddWithValue("@AttendeeName", registrations.Attendee.AttendeeName);
                sqlCommand.Parameters.AddWithValue("@AttendeeEmail", registrations.Attendee.AttendeeEmail);
                sqlCommand.Parameters.AddWithValue("@AttendeePhoneNumber", registrations.Attendee.AttendeePhoneNumber);
                sqlCommand.Parameters.AddWithValue("@AttendeeAddress", registrations.Attendee.AttendeeAddress);
                sqlCommand.Parameters.AddWithValue("@HasConfirmedAttendance", registrations.Attendee.HasConfirmedAttendance);
                sqlCommand.Parameters.AddWithValue("@TicketQuantity", registrations.Ticket.TicketQuantity);
                sqlCommand.Parameters.AddWithValue("@TicketPrice", registrations.Ticket.TicketPrice);
                sqlCommand.Parameters.AddWithValue("@TicketType", registrations.Ticket.TicketType);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registrations.RegistrationDate);
                sqlCommand.Parameters.AddWithValue("@PaymentStatus", registrations.PaymentStatus);
                sqlCommand.Parameters.AddWithValue("@PaymentMethod", registrations.PaymentMethod);
                sqlCommand.Parameters.AddWithValue("@TotalAmountPaid", registrations.Ticket.TicketQuantity * registrations.Ticket.TicketPrice);

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
        /// This method is used to delete a registration from the database
        /// </summary>
        /// <param name="eventId"> The event id of the registration to be deleted</param>
        /// <param name="attendeeId"> The attendee id of the registration to be deleted</param>
        /// <returns> True if the registration was deleted, false if not</returns>
        public bool DeleteRegistration(int eventId, int attendeeId)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_DeleteRegistration";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventId", eventId);
                sqlCommand.Parameters.AddWithValue("@AttendeeId", attendeeId);

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

    }
}
