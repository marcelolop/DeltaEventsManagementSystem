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
    /// This class is responsible for handling all the database operations related to the Attendees entity.
    /// </summary>
    public class AttendeesRepository
    {
        /// <summary>
        /// This method is responsible for getting all the attendees of a registration from the database.
        /// </summary>
        /// <param name="registrationId"> The registration id to get the attendees of the specific registration</param>
        /// <returns> A list of attendees of the registration</returns>
        public List<Attendees> GetAllAttendeesOfRegistration(int registrationId)
        {
            List<Attendees> attendees = new List<Attendees>();

            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_GetAttendeesOfRegistration";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@RegistrationId", registrationId);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    attendees.Add(new Attendees
                    {
                        AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                        AttendeeName = Convert.ToString(row["AttendeeName"]),
                        AttendeeEmail = Convert.ToString(row["AttendeeEmail"]),
                        AttendeePhoneNumber = Convert.ToString(row["AttendeePhoneNumber"]),
                        AttendeeAddress = Convert.ToString(row["AttendeeAddress"]),
                        HasConfirmedAttendance = Convert.ToBoolean(row["HasConfirmedAttendance"])
                    });
                }
            }
            return attendees;
        }

        /// <summary>
        /// This method is responsible for adding an attendee to the database.
        /// </summary>
        /// <param name="attendees"> The attendee to be added</param>
        /// <returns> True if the attendee was added, false if not</returns>
        public bool AddAttendee(Attendees attendees)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_AddAttendee";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@AttendeeName", attendees.AttendeeName);
                sqlCommand.Parameters.AddWithValue("@AttendeeEmail", attendees.AttendeeEmail);
                sqlCommand.Parameters.AddWithValue("@AttendeePhoneNumber", attendees.AttendeePhoneNumber);
                sqlCommand.Parameters.AddWithValue("@AttendeeAddress", attendees.AttendeeAddress);
                sqlCommand.Parameters.AddWithValue("@HasConfirmedAttendance", attendees.HasConfirmedAttendance);

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
        /// This method is responsible for updating an attendee in the database.
        /// </summary>
        /// <param name="attendees"> The attendee to be updated</param>
        /// <returns> True if the attendee was updated, false if not</returns>
        public bool UpdateAttendee(Attendees attendees)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_UpdateAttendee";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@AttendeeId", attendees.AttendeeId);
                sqlCommand.Parameters.AddWithValue("@AttendeeName", attendees.AttendeeName);
                sqlCommand.Parameters.AddWithValue("@AttendeeEmail", attendees.AttendeeEmail);
                sqlCommand.Parameters.AddWithValue("@AttendeePhoneNumber", attendees.AttendeePhoneNumber);
                sqlCommand.Parameters.AddWithValue("@AttendeeAddress", attendees.AttendeeAddress);
                sqlCommand.Parameters.AddWithValue("@HasConfirmedAttendance", attendees.HasConfirmedAttendance);

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
        /// This method is responsible for deleting an attendee from the database.
        /// </summary>
        /// <param name="attendeeId"> The id of the attendee to be deleted</param>
        /// <returns> True if the attendee was deleted, false if not</returns>
        public bool DeleteAttendee(int attendeeId)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_DeleteAttendee";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

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
