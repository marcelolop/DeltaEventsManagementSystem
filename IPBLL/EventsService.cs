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
    /// This class is responsible for handling all the business logic for the Events
    /// </summary>
    public class EventsService
    {
        /// <summary>
        /// This method is responsible for getting all the events
        /// </summary>
        /// <returns></returns>
        public  List<Events> GetAllEvents()
        {
            List<Events> events = new List<Events>();
            EventsRepository eventsRepository = new EventsRepository();

            events = eventsRepository.GetEvents();

            return events;
        }

        /// <summary>
        /// This method is responsible for creating an event
        /// </summary>
        /// <param name="eventCreationRequest"> The event to be created</param>
        /// <returns> True if the event was created, false if not</returns>
        /// <exception cref="ArgumentNullException"> EventName, EventDescription, EventLocation, OrganizerName, OrganizerContact</exception>
        /// <exception cref="ArgumentOutOfRangeException"> EventDescription, EventDate, EventLocation, MaxAttendees, OrganizerName, OrganizerContact</exception>
        public bool CreateEvent(CreateEventRequest eventCreationRequest)
        {
            EventsRepository eventsRepository = new EventsRepository();

            Events events = new Events()
            {
                EventName = eventCreationRequest.EventName,
                EventDescription = eventCreationRequest.EventDescription,
                EventDate = eventCreationRequest.EventDate,
                EventLocation = eventCreationRequest.EventLocation,
                MaxAttendees = eventCreationRequest.MaxAttendees,
                OrganizerName = eventCreationRequest.OrganizerName,
                OrganizerContact = eventCreationRequest.OrganizerContact
            };

            #region Validations

            //if (string.IsNullOrEmpty(events.EventName))
            //{
            //    throw new ArgumentNullException(nameof(events.EventName), "EventName cannot be null or empty");
            //}
            //if (string.IsNullOrEmpty(events.EventDescription))
            //{
            //    throw new ArgumentNullException(nameof(events.EventDescription), "EventDescription cannot be null or empty");
            //}
            //if (events.EventDescription.Length > 1000)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventDescription), "EventDescription cannot be more than 1000 characters");
            //}
            //if (events.EventDate < DateTime.Now)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventDate), "EventDate cannot be in the past");
            //}
            //if (events.EventDate < DateTime.Now.AddDays(2))
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventDate), "EventDate cannot be less than 2 days from now");
            //}
            //if (string.IsNullOrEmpty(events.EventLocation))
            //{
            //    throw new ArgumentNullException(nameof(events.EventLocation), "EventLocation cannot be null or empty");
            //}
            //if (events.EventLocation.Length > 500)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventLocation), "EventLocation cannot be more than 100 characters");
            //}
            //if (events.MaxAttendees <= 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.MaxAttendees), "MaxAttendees cannot be less than or equal to 0");
            //}
            //if (string.IsNullOrEmpty(events.OrganizerName))
            //{
            //    throw new ArgumentNullException(nameof(events.OrganizerName), "OrganizerName cannot be null or empty");
            //}
            //if (events.OrganizerName.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.OrganizerName), "OrganizerName cannot be more than 100 characters");
            //}
            //if (string.IsNullOrEmpty(events.OrganizerContact))
            //{
            //    throw new ArgumentNullException(nameof(events.OrganizerContact), "OrganizerContact cannot be null or empty");
            //}
            //if (events.OrganizerContact.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.OrganizerContact), "OrganizerContact cannot be more than 100 characters");
            //}

            #endregion Validations

            return eventsRepository.CreateEvent(events);

        }

        /// <summary>
        /// This method is responsible for updating an event
        /// </summary>
        /// <param name="eventUpdateRequest"> The event to be updated</param>
        /// <returns> True if the event was updated, false if not</returns>
        public bool UpdateEvent(UpdateEventRequest eventUpdateRequest)
        {
            EventsRepository eventsRepository = new EventsRepository();
           
            Events events = new Events()
            {
                EventId = eventUpdateRequest.EventId,
                EventName = eventUpdateRequest.EventName,
                EventDescription = eventUpdateRequest.EventDescription,
                EventDate = eventUpdateRequest.EventDate,
                EventLocation = eventUpdateRequest.EventLocation,
                MaxAttendees = eventUpdateRequest.MaxAttendees,
                OrganizerName = eventUpdateRequest.OrganizerName,
                OrganizerContact = eventUpdateRequest.OrganizerContact
            };

            #region Validations

            //if (events.EventId == 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventId), "EventId cannot be less than or equal to 0");
            //}
            //if (string.IsNullOrEmpty(events.EventName))
            //{
            //    throw new ArgumentNullException(nameof(events.EventName), "EventName cannot be null or empty");
            //}
            //if (string.IsNullOrEmpty(events.EventDescription))
            //{
            //    throw new ArgumentNullException(nameof(events.EventDescription), "EventDescription cannot be null or empty");
            //}
            //if (events.EventDescription.Length > 1000)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventDescription), "EventDescription cannot be more than 1000 characters");
            //}
            //if (events.EventDate < DateTime.Now)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventDate), "EventDate cannot be in the past");
            //}
            //if (events.EventDate < DateTime.Now.AddDays(2))
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventDate), "EventDate cannot be less than 2 days from now");
            //}
            //if (string.IsNullOrEmpty(events.EventLocation))
            //{
            //    throw new ArgumentNullException(nameof(events.EventLocation), "EventLocation cannot be null or empty");
            //}
            //if (events.EventLocation.Length > 500)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.EventLocation), "EventLocation cannot be more than 100 characters");
            //}
            //if (events.MaxAttendees <= 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.MaxAttendees), "MaxAttendees cannot be less than or equal to 0");
            //}
            //if (string.IsNullOrEmpty(events.OrganizerName))
            //{
            //    throw new ArgumentNullException(nameof(events.OrganizerName), "OrganizerName cannot be null or empty");
            //}
            //if (events.OrganizerName.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.OrganizerName), "OrganizerName cannot be more than 100 characters");
            //}
            //if (string.IsNullOrEmpty(events.OrganizerContact))
            //{
            //    throw new ArgumentNullException(nameof(events.OrganizerContact), "OrganizerContact cannot be null or empty");
            //}
            //if (events.OrganizerContact.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(events.OrganizerContact), "OrganizerContact cannot be more than 100 characters");
            //}

            #endregion Validations
            
            return eventsRepository.UpdateEvent(events);
        }

        /// <summary>
        /// This method is responsible for deleting an event
        /// </summary>
        /// <param name="eventId"> The event to be deleted</param>
        /// <returns> True if the event was deleted, false if not</returns>
        /// <exception cref="ArgumentOutOfRangeException"> EventId</exception>
        public bool DeleteEvent(int eventId)
        {
            #region Validations

            if (eventId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(eventId), "EventId cannot be less than or equal to 0");
            }

            #endregion Validations

            EventsRepository eventsRepository = new EventsRepository();

            return eventsRepository.DeleteEvent(eventId);
        }
    }
}
