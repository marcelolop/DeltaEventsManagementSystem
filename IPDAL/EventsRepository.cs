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
    /// This class will handle all the database operations for the events
    /// </summary>
    public class EventsRepository
    {
        /// <summary>
        /// This method will get all the events from the database
        /// </summary>
        /// <param name="eventId"> The event id to get the specific event</param>
        /// <returns><
        public List<Events> GetEvents()
        {
            List<Events> events = new List<Events>();

            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_GetEvents";
                SqlCommand sqlcommand = new SqlCommand(commandText, connection);
                sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    events.Add(new Events
                    {
                        EventId = Convert.ToInt32(row["EventId"]),
                        EventName = Convert.ToString(row["EventName"]),
                        EventDate = Convert.ToDateTime(row["EventDate"]),
                        EventLocation = Convert.ToString(row["EventLocation"]),
                        EventDescription = Convert.ToString(row["EventDescription"]),
                        MaxAttendees = Convert.ToInt32(row["MaxAttendees"]),
                        OrganizerName = Convert.ToString(row["OrganizerName"]),
                        OrganizerContact = Convert.ToString(row["OrganizerContact"])
                    });
                }
            }
            return events;
        }

        /// <summary>
        /// This method will get a specific event from the database
        /// </summary>
        /// <param name="eventId"> The event id to get the specific event</param>
        /// <returns> The specific event</returns>
        public Events GetEvent(int eventId)
        {
            Events events = new Events();

            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_GetEvent";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventId", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    events.EventId = Convert.ToInt32(row["EventId"]);
                    events.EventName = Convert.ToString(row["EventName"]);
                    events.EventDate = Convert.ToDateTime(row["EventDate"]);
                    events.EventLocation = Convert.ToString(row["EventLocation"]);
                    events.EventDescription = Convert.ToString(row["EventDescription"]);
                    events.MaxAttendees = Convert.ToInt32(row["MaxAttendees"]);
                    events.OrganizerName = Convert.ToString(row["OrganizerName"]);
                    events.OrganizerContact = Convert.ToString(row["OrganizerContact"]);
                }
            }
            return events;
        }


        /// <summary>
        /// This method will create a new event in the database
        /// </summary>
        /// <param name="events"> The event to be created</param>
        /// <returns> True if the event was created, false if not</returns>
        public bool CreateEvent(Events events)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_CreateEvent";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventName", events.EventName);
                sqlCommand.Parameters.AddWithValue("@EventDescription", events.EventDescription);
                sqlCommand.Parameters.AddWithValue("@EventDate", events.EventDate);
                sqlCommand.Parameters.AddWithValue("@EventLocation", events.EventLocation);
                sqlCommand.Parameters.AddWithValue("@MaxAttendees", events.MaxAttendees);
                sqlCommand.Parameters.AddWithValue("@OrganizerName", events.OrganizerName);
                sqlCommand.Parameters.AddWithValue("@OrganizerContact", events.OrganizerContact);
                

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
        /// This method will update an event in the database
        /// </summary>
        /// <param name="events">   The event to be updated</param>
        /// <returns> True if the event was updated, false if not</returns>
        public bool UpdateEvent(Events events)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_UpdateEvent";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventId", events.EventId);
                sqlCommand.Parameters.AddWithValue("@EventName", events.EventName);
                sqlCommand.Parameters.AddWithValue("@EventDescription", events.EventDescription);
                sqlCommand.Parameters.AddWithValue("@EventDate", events.EventDate);
                sqlCommand.Parameters.AddWithValue("@EventLocation", events.EventLocation);
                sqlCommand.Parameters.AddWithValue("@MaxAttendees", events.MaxAttendees);
                sqlCommand.Parameters.AddWithValue("@OrganizerName", events.OrganizerName);
                sqlCommand.Parameters.AddWithValue("@OrganizerContact", events.OrganizerContact);

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
        /// This method will delete an event from the database
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public bool DeleteEvent(int eventId)
        {
            using(SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                string commandText = "usp_DeleteEvent";
                SqlCommand sqlCommand = new SqlCommand(commandText, connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventId", eventId);

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
