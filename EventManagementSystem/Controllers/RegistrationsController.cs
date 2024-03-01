using IPBLL;
using IPBLL.Models.RegistrationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventManagementSystem.Controllers
{
    /// <summary>
    /// This Controller is used to handle all the Registration Services and the views related to the Registration Services
    /// </summary>
    [Route("Registrations")]
    public class RegistrationsController : Controller
    {
        /// <summary>
        /// This method is used to get all the Registrations and display them in the Index View
        /// </summary>
        /// <returns> The Index View with all the Registrations</returns>
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            RegistrationsService registrationsService = new RegistrationsService();
            var registrations = registrationsService.GetAllRegistrations();

            var data = registrations.Select(registration => new RegistrationsList()
            {
                RegistrationDate = registration.RegistrationDate,
                PaymentStatus = registration.PaymentStatus,
                PaymentMethod = registration.PaymentMethod,
                TotalAmountPaid = registration.TotalAmountPaid,
                EventName = registration.Event.EventName,
                EventId = registration.EventId,
                AttendeeId = registration.AttendeeId,
                TicketId = registration.TicketId,
                AttendeeName = registration.Attendee.AttendeeName,
                AttendeeEmail = registration.Attendee.AttendeeEmail,
                AttendeePhoneNumber = registration.Attendee.AttendeePhoneNumber,
                AttendeeAddress = registration.Attendee.AttendeeAddress,
                HasConfirmedAttendance = registration.Attendee.HasConfirmedAttendance,
                TicketQuantity = registration.Ticket.TicketQuantity,
                TicketPrice = registration.Ticket.TicketPrice,
                TicketType = registration.Ticket.TicketType
            }).ToList();

            return View("Index", data);
        }

        /// <summary>
        /// This method is used to get the Create Registration View
        /// </summary>
        /// <returns> Create Registration View</returns>
        [HttpGet, Route("Create")]
        public IActionResult CreateRegistrationView()
        {
            EventsService eventsService = new EventsService();
            var events = eventsService.GetAllEvents();
            ViewBag.Events = events.Select(x => new SelectListItem(
                x.EventName,
                x.EventId.ToString()
                )).ToList();
            ;

            return View();
        }

        /// <summary>
        /// This method is used to create a new Registration
        /// </summary>
        /// <param name="registration"> The Registration to be created</param>
        /// <returns> The Index View with the new Registration</returns>
        [HttpPost, Route("Create")]
        public IActionResult CreateRegistration(CreateRegistrationRequest registration)
        {
            RegistrationsService registrationsService = new RegistrationsService();
            try
            {
                registrationsService.AddRegistration(registration);
                return RedirectToAction("Index");
            }
            catch (ArgumentOutOfRangeException exception)
            {
                switch (exception.ParamName)
                {
                    case nameof(registration.EventId):
                        ModelState.AddModelError("EventId", exception.Message);
                        break;
                    case nameof(registration.AttendeeId):
                        ModelState.AddModelError("AttendeeId", exception.Message);
                        break;
                    case nameof(registration.TicketId):
                        ModelState.AddModelError("TicketId", exception.Message);
                        break;
                    case nameof(registration.RegistrationDate):
                        ModelState.AddModelError("RegistrationDate", exception.Message);
                        break;
                    case nameof(registration.PaymentStatus):
                        ModelState.AddModelError("PaymentStatus", exception.Message);
                        break;
                    case nameof(registration.PaymentMethod):
                        ModelState.AddModelError("PaymentMethod", exception.Message);
                        break;
                    case (nameof(registration.AttendeeName)):
                        ModelState.AddModelError("AttendeeName", exception.Message);
                        break;
                    case (nameof(registration.AttendeeEmail)):
                        ModelState.AddModelError("AttendeeEmail", exception.Message);
                        break;
                    case (nameof(registration.AttendeePhoneNumber)):
                        ModelState.AddModelError("AttendeePhoneNumber", exception.Message);
                        break;
                    case (nameof(registration.AttendeeAddress)):
                        ModelState.AddModelError("AttendeeAddress", exception.Message);
                        break;
                    case (nameof(registration.TicketQuantity)):
                        ModelState.AddModelError("TicketQuantity", exception.Message);
                        break;
                    case (nameof(registration.TicketPrice)):
                        ModelState.AddModelError("TicketPrice", exception.Message);
                        break;
                    case (nameof(registration.TicketType)):
                        ModelState.AddModelError("TicketType", exception.Message);
                        break;
                    default:
                        ModelState.AddModelError("Registration", exception.Message);
                        break;
                }

            }
            catch (ArgumentNullException exception)
            {
                switch (exception.ParamName)
                {
                    case (nameof(registration.PaymentStatus)):
                        ModelState.AddModelError("PaymentStatus", exception.Message);
                        break;
                    case (nameof(registration.PaymentMethod)):
                        ModelState.AddModelError("PaymentMethod", exception.Message);
                        break;
                    case (nameof(registration.AttendeeName)):
                        ModelState.AddModelError("AttendeeName", exception.Message);
                        break;
                    case (nameof(registration.AttendeeEmail)):
                        ModelState.AddModelError("AttendeeEmail", exception.Message);
                        break;
                    case (nameof(registration.AttendeePhoneNumber)):
                        ModelState.AddModelError("AttendeePhoneNumber", exception.Message);
                        break;
                    case (nameof(registration.AttendeeAddress)):
                        ModelState.AddModelError("AttendeeAddress", exception.Message);
                        break;
                    case (nameof(registration.TicketQuantity)):
                        ModelState.AddModelError("TicketQuantity", exception.Message);
                        break;
                    case (nameof(registration.TicketPrice)):
                        ModelState.AddModelError("TicketPrice", exception.Message);
                        break;
                    case (nameof(registration.TicketType)):
                        ModelState.AddModelError("TicketType", exception.Message);
                        break;
                    case (nameof(registration.RegistrationDate)):
                        ModelState.AddModelError("RegistrationDate", exception.Message);
                        break;
                    default:
                        ModelState.AddModelError("Registration", exception.Message);
                        break;
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Error", "Error: " + exception.Message);
            }
            return View("CreateRegistrationView", registration);
        }

        /// <summary>
        /// This method is used to get the Edit Registration View
        /// </summary>
        /// <param name="eventId"> The Event Id of the Registration</param>
        /// <param name="attendeeId"> The Attendee Id of the Registration</param>
        /// <returns> The Edit Registration View</returns>
        [HttpGet, Route("Edit/{eventId}/{attendeeId}")]
        public IActionResult EditRegistrationView(int eventId, int attendeeId)
        {
            RegistrationsService registrationsService = new RegistrationsService();
            var registrationinfo = registrationsService.GetAllRegistrations().FirstOrDefault(@event => @event.EventId == eventId && @event.AttendeeId == attendeeId);

            var data = new UpdateRegistrationRequest()
            {
                RegistrationDate = registrationinfo.RegistrationDate,
                PaymentStatus = registrationinfo.PaymentStatus,
                PaymentMethod = registrationinfo.PaymentMethod,
                EventId = registrationinfo.EventId,
                AttendeeId = registrationinfo.AttendeeId,
                TicketId = registrationinfo.TicketId,
                AttendeeName = registrationinfo.Attendee.AttendeeName,
                AttendeeEmail = registrationinfo.Attendee.AttendeeEmail,
                AttendeePhoneNumber = registrationinfo.Attendee.AttendeePhoneNumber,
                AttendeeAddress = registrationinfo.Attendee.AttendeeAddress,
                HasConfirmedAttendance = registrationinfo.Attendee.HasConfirmedAttendance,
                TicketQuantity = registrationinfo.Ticket.TicketQuantity,
                TicketPrice = registrationinfo.Ticket.TicketPrice,
                TicketType = registrationinfo.Ticket.TicketType
            };
            return View("EditRegistrationView", data);
        }

        /// <summary>
        /// This method is used to edit a Registration
        /// </summary>
        /// <param name="registration"> The Registration to be edited</param>
        /// <returns> The Index View with the edited Registration</returns>
        [HttpPost, Route("Edit")]
        public IActionResult EditRegistration(UpdateRegistrationRequest registration)
        {
            RegistrationsService registrationsService = new RegistrationsService();

            try
            {
                var registrationInfo = registrationsService.GetAllRegistrations().FirstOrDefault(@event => @event.EventId == registration.EventId && @event.AttendeeId == registration.AttendeeId);
                if (registrationInfo == null)
                {
                    ModelState.AddModelError("Registration", "Registration not found");
                    return View("EditRegistrationView", registration);
                }
                registrationsService.UpdateRegistration(registration);
                return RedirectToAction("Index");
            }
            catch (ArgumentOutOfRangeException exception)
            {
                switch (exception.ParamName)
                {
                    case nameof(registration.EventId):
                        ModelState.AddModelError("EventId", exception.Message);
                        break;
                    case nameof(registration.AttendeeId):
                        ModelState.AddModelError("AttendeeId", exception.Message);
                        break;
                    case nameof(registration.TicketId):
                        ModelState.AddModelError("TicketId", exception.Message);
                        break;
                    case nameof(registration.RegistrationDate):
                        ModelState.AddModelError("RegistrationDate", exception.Message);
                        break;
                    case nameof(registration.PaymentStatus):
                        ModelState.AddModelError("PaymentStatus", exception.Message);
                        break;
                    case nameof(registration.PaymentMethod):
                        ModelState.AddModelError("PaymentMethod", exception.Message);
                        break;
                    case (nameof(registration.AttendeeName)):
                        ModelState.AddModelError("AttendeeName", exception.Message);
                        break;
                    case (nameof(registration.AttendeeEmail)):
                        ModelState.AddModelError("AttendeeEmail", exception.Message);
                        break;
                    case (nameof(registration.AttendeePhoneNumber)):
                        ModelState.AddModelError("AttendeePhoneNumber", exception.Message);
                        break;
                    case (nameof(registration.AttendeeAddress)):
                        ModelState.AddModelError("AttendeeAddress", exception.Message);
                        break;
                    case (nameof(registration.TicketQuantity)):
                        ModelState.AddModelError("TicketQuantity", exception.Message);
                        break;
                    case (nameof(registration.TicketPrice)):
                        ModelState.AddModelError("TicketPrice", exception.Message);
                        break;
                    case (nameof(registration.TicketType)):
                        ModelState.AddModelError("TicketType", exception.Message);
                        break;
                    default:
                        ModelState.AddModelError("Registration", exception.Message);
                        break;
                }
            }
            catch (ArgumentNullException exception)
            {
                switch (exception.ParamName)
                {
                    case (nameof(registration.PaymentStatus)):
                        ModelState.AddModelError("PaymentStatus", exception.Message);
                        break;
                    case (nameof(registration.PaymentMethod)):
                        ModelState.AddModelError("PaymentMethod", exception.Message);
                        break;
                    case (nameof(registration.AttendeeName)):
                        ModelState.AddModelError("AttendeeName", exception.Message);
                        break;
                    case (nameof(registration.AttendeeEmail)):
                        ModelState.AddModelError("AttendeeEmail", exception.Message);
                        break;
                    case (nameof(registration.AttendeePhoneNumber)):
                        ModelState.AddModelError("AttendeePhoneNumber", exception.Message);
                        break;
                    case (nameof(registration.AttendeeAddress)):
                        ModelState.AddModelError("AttendeeAddress", exception.Message);
                        break;
                    case (nameof(registration.TicketQuantity)):
                        ModelState.AddModelError("TicketQuantity", exception.Message);
                        break;
                    case (nameof(registration.TicketPrice)):
                        ModelState.AddModelError("TicketPrice", exception.Message);
                        break;
                    case (nameof(registration.TicketType)):
                        ModelState.AddModelError("TicketType", exception.Message);
                        break;
                    case (nameof(registration.RegistrationDate)):
                        ModelState.AddModelError("RegistrationDate", exception.Message);
                        break;
                    default:
                        ModelState.AddModelError("Registration", exception.Message);
                        break;
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("Error", "Error: " + exception.Message);
            }
            return View("EditRegistrationView", registration);
        }

        /// <summary>
        /// This method is used to delete a Registration
        /// </summary>
        /// <param name="eventId"> The Event Id of the Registration</param>
        /// <param name="attendeeId"> The Attendee Id of the Registration</param>
        /// <returns> The Index View without the deleted Registration</returns>
        [HttpGet, Route("Delete/{eventId}/{attendeeId}")]
        public IActionResult DeleteRegistration(int eventId, int attendeeId)
        {
            RegistrationsService registrationsService = new RegistrationsService();
            registrationsService.DeleteRegistration(eventId, attendeeId);
            return RedirectToAction("Index");
        }

    }
}
