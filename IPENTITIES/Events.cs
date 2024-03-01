using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IPENTITIES
{
    /// <summary>
    /// This class represents the Events entity
    /// </summary>
    public class Events
    {
        //private fields
        private int _eventId;
        private string _eventName;
        private string _eventDescription;
        private DateTime _eventDate;
        private string _eventLocation;
        private int _maxAttendees;
        private string _organizerName;
        private string _organizerContact;


        //public properties
        public int EventId
        {
            get => _eventId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(EventId), "EventId cannot be less than or equal to 0");
                }
                //checking if the id value matches the id in the database
                _eventId = value;
            }
        }

        public string EventName
        {
            get => _eventName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(EventName), "EventName cannot be null or empty");
                }
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(EventName), "EventName cannot be more than 255 characters");
                }
                _eventName = value;
            }
        }

        public string EventDescription
        {
            get => _eventDescription;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(EventDescription), "EventDescription cannot be null or empty");
                }
                if (value.Length > 1000)
                {
                    throw new ArgumentOutOfRangeException(nameof(EventDescription), "EventDescription cannot be more than 1000 characters");
                }
                _eventDescription = value;
            }
        }

        public DateTime EventDate
        {
            get => _eventDate;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(nameof(EventDate), "EventDate cannot be in the past");
                }
                if (value < DateTime.Now.AddDays(2))
                {
                    throw new ArgumentOutOfRangeException(nameof(EventDate), "EventDate cannot be less than 2 days from now");
                }
                _eventDate = value;
            }
        }

        public string EventLocation
        {
            get => _eventLocation;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(EventLocation), "EventLocation cannot be null or empty");
                }
                if (value.Length > 500)
                {
                    throw new ArgumentOutOfRangeException(nameof(EventLocation), "EventLocation cannot be more than 255 characters");
                }
                _eventLocation = value;
            }
        }

        public int MaxAttendees
        {
            get => _maxAttendees;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(MaxAttendees), "MaxAttendees cannot be less than or equal to 0");
                }
                _maxAttendees = value;
            }
        }

        public string OrganizerName
        {
            get => _organizerName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(OrganizerName), "OrganizerName cannot be null or empty");
                }
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(OrganizerName), "OrganizerName cannot be more than 255 characters");
                }
                _organizerName = value;
            }
        }

        public string OrganizerContact
        {
            get => _organizerContact;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(OrganizerContact), "OrganizerContact cannot be null or empty");
                }
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(OrganizerContact), "OrganizerContact cannot be more than 255 characters");
                }
                _organizerContact = value;
            }
        }


        //default constructor
        public Events()
        {
        }

        //parameterized constructor
        public Events(int eventId, string eventName, string eventDescription, DateTime eventDate, string eventLocation, int maxAttendees, string organizerName, string organizerContact)
        {
            EventId = eventId;
            EventName = eventName;
            EventDescription = eventDescription;
            EventDate = eventDate;
            EventLocation = eventLocation;
            MaxAttendees = maxAttendees;
            OrganizerName = organizerName;
            OrganizerContact = organizerContact;
        }

    }
}
