using IPBLL;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    /// <summary>
    /// This Controller is used to handle the Events Service and the views for the Events
    /// </summary>
    [Route("Events")]
    public class EventsController : Controller
    {
        /// <summary>
        /// This method will get all the events from the database
        /// </summary>
        /// <returns> The view with all the events</returns>
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            EventsService eventsService = new EventsService();
            var events = eventsService.GetAllEvents();

            var data = events.Select(@event => new UpdateEventRequest()
            {
                EventId = @event.EventId,
                EventDescription = @event.EventDescription,
                EventName = @event.EventName,
                EventDate = @event.EventDate,
                EventLocation = @event.EventLocation,
                MaxAttendees = @event.MaxAttendees,
                OrganizerName = @event.OrganizerName,
                OrganizerContact = @event.OrganizerContact
            }).ToList();


            return View("Index", data);
        }


        /// <summary>
        /// This method will return the view to create an event
        /// </summary>
        /// <returns> The view to create an event</returns>
        [HttpGet, Route("Create")]
        public IActionResult CreateEventView()
        {
            return View();
        }

        /// <summary>
        /// This method will create an event
        /// </summary>
        /// <param name="events"> The event to be created</param>
        /// <returns> The view with the event created</returns>
        [HttpPost, Route("Create")]
        public IActionResult CreateEvent(CreateEventRequest events)
        {
            EventsService eventsService = new EventsService();
            try
            {
                eventsService.CreateEvent(events);
                return RedirectToAction("Index");
            }
            catch (ArgumentOutOfRangeException execption)
            {
                switch (execption.ParamName)
                {
                    case nameof(events.EventName):
                        ModelState.AddModelError("EventName", execption.Message);
                        break;
                    case nameof(events.EventDescription):
                        ModelState.AddModelError("EventDescription", execption.Message);
                        break;
                    case nameof(events.EventDate):
                        ModelState.AddModelError("EventDate", "Error: EventDate cannot be in the past and cannot be less than 2 days from now");
                        break;
                    case nameof(events.EventLocation):
                        ModelState.AddModelError("EventLocation", execption.Message);
                        break;
                    case nameof(events.MaxAttendees):
                        ModelState.AddModelError("MaxAttendees", execption.Message);
                        break;
                    case nameof(events.OrganizerName):
                        ModelState.AddModelError("OrganizerName", execption.Message);
                        break;
                    case nameof(events.OrganizerContact):
                        ModelState.AddModelError("OrganizerContact", execption.Message);
                        break;
                    default:
                        ViewBag.Message = "Error: " + execption.Message;
                        break;

                }
            }
            catch (ArgumentNullException execption)
            {
                switch (execption.ParamName)
                {
                    case nameof(events.EventName):
                        ModelState.AddModelError("EventName", execption.Message);
                        break;
                    case nameof(events.EventDescription):
                        ModelState.AddModelError("EventDescription", execption.Message);
                        break;
                    case nameof(events.EventLocation):
                        ModelState.AddModelError("EventLocation", execption.Message);
                        break;
                    case nameof(events.OrganizerName):
                        ModelState.AddModelError("OrganizerName", execption.Message);
                        break;
                    case nameof(events.OrganizerContact):
                        ModelState.AddModelError("OrganizerContact", execption.Message);
                        break;
                    default:
                        ViewBag.Message = "Error: " + execption.Message;
                        break;
                }
            }
            catch (Exception execption)
            {
                ModelState.AddModelError("Error", "Error: " + execption.Message);
            }
            return View("CreateEventView", events);
        }


        /// <summary>
        /// This method will return the view to edit an event
        /// </summary>
        /// <param name="eventId"> The event to be edited</param>
        /// <returns> The view to edit an event</returns>
        [HttpGet, Route("Edit/{eventId}")]
        public IActionResult EditEventView(int eventId)
        {
            EventsService eventsService = new EventsService();
            var eventInfo = eventsService.GetAllEvents().Find(@event => @event.EventId == eventId);
           
            var data = new UpdateEventRequest()
            {
                EventId = eventInfo.EventId,
                EventDescription = eventInfo.EventDescription,
                EventName = eventInfo.EventName,
                EventDate = eventInfo.EventDate,
                EventLocation = eventInfo.EventLocation,
                MaxAttendees = eventInfo.MaxAttendees,
                OrganizerName = eventInfo.OrganizerName,
                OrganizerContact = eventInfo.OrganizerContact
            };
            
            return View("EditEventView", data);
        }

        /// <summary>
        /// This method will edit an event
        /// </summary>
        /// <param name="events"> The event to be edited</param>
        /// <returns> The view with the event edited</returns>
        [HttpPost, Route("Edit")]
        public IActionResult EditEvent(UpdateEventRequest events)
        {
            EventsService eventsService = new EventsService();
            try
            {
                var eventInfo = eventsService.GetAllEvents().Find(@event => @event.EventId == events.EventId);
                if (eventInfo == null)
                {
                    ModelState.AddModelError("EventId", "EventId not found");
                    return View("Edit", events);
                }
                eventsService.UpdateEvent(events);
                return RedirectToAction("Index");
                
            }
            catch (ArgumentOutOfRangeException exception)
            {
                switch (exception.ParamName)
                {
                    case nameof(events.EventId):
                        ModelState.AddModelError("EventId", exception.Message);
                        break;
                    case nameof(events.EventName):
                        ModelState.AddModelError("EventName", exception.Message);
                        break;
                    case nameof(events.EventDescription):
                        ModelState.AddModelError("EventDescription", exception.Message);
                        break;
                    case nameof(events.EventDate):
                        ModelState.AddModelError("EventDate", "Error: EventDate cannot be in the past and cannot be less than 2 days from now");
                        break;
                    case nameof(events.EventLocation):
                        ModelState.AddModelError("EventLocation", exception.Message);
                        break;
                    case nameof(events.MaxAttendees):
                        ModelState.AddModelError("MaxAttendees", exception.Message);
                        break;
                    case nameof(events.OrganizerName):
                        ModelState.AddModelError("OrganizerName", exception.Message);
                        break;
                    case nameof(events.OrganizerContact):
                        ModelState.AddModelError("OrganizerContact", exception.Message);
                        break;
                    default:
                        ViewBag.Message = "Error: " + exception.Message;
                        break;
                }
            }
            catch (ArgumentNullException exception)
            {
                switch (exception.ParamName)
                {
                    case nameof(events.EventName):
                        ModelState.AddModelError("EventName", exception.Message);
                        break;
                    case nameof(events.EventDescription):
                        ModelState.AddModelError("EventDescription", exception.Message);
                        break;
                    case nameof(events.EventLocation):
                        ModelState.AddModelError("EventLocation", exception.Message);
                        break;
                    case nameof(events.OrganizerName):
                        ModelState.AddModelError("OrganizerName", exception.Message);
                        break;
                    case nameof(events.OrganizerContact):
                        ModelState.AddModelError("OrganizerContact", exception.Message);
                        break;
                    default:
                        ViewBag.Message = "Error: " + exception.Message;
                        break;
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Error", "Error: " + exception.Message);
            }
            return View("EditEventView", events);
        }

        /// <summary>
        /// This method will delete an event from the database
        /// </summary>
        /// <param name="eventId"> The event to be deleted</param>
        /// <returns> The view with the event deleted</returns>
        [HttpGet, Route("Delete/{eventId}")]
        public IActionResult DeleteEvent(int eventId)
        {
            EventsService eventsService = new EventsService();
            eventsService.DeleteEvent(eventId);
            return RedirectToAction("Index");
        }


    }
}
