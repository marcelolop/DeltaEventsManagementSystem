using IPBLL;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.Controllers
{
    [Route("Attendees")]
    public class AttendeesController : Controller
    {
        [HttpGet, Route("")]
        public IActionResult Index()
        {
            AttendeesService attendeesService = new AttendeesService();
            var attendees = attendeesService.GetAllAttendeesFromRegistration(1);
            return View("Index", attendees);
        }

        [HttpGet, Route("Create")]
        public IActionResult CreateAttendeeView()
        {
            return View();
        }

        [HttpPost, Route("Create")]
        public IActionResult CreateAttendee(CreateAttendeeRequest createAttendeeRequest)
        {
            AttendeesService attendeesService = new AttendeesService();
            try
            {
                attendeesService.AddAttendee(createAttendeeRequest);
                return RedirectToAction("Index");
            }
            catch (ArgumentOutOfRangeException execption)
            {
                switch (execption.ParamName)
                {
                    case nameof(createAttendeeRequest.AttendeeName):
                        ModelState.AddModelError("AttendeeName", execption.Message);
                        break;
                    case nameof(createAttendeeRequest.AttendeeEmail):
                        ModelState.AddModelError("AttendeeEmail", execption.Message);
                        break;
                    case nameof(createAttendeeRequest.AttendeePhoneNumber):
                        ModelState.AddModelError("AttendeePhoneNumber", execption.Message);
                        break;
                    case nameof(createAttendeeRequest.AttendeeAddress):
                        ModelState.AddModelError("AttendeeAddress", execption.Message);
                        break;
                    case nameof(createAttendeeRequest.HasConfirmedAttendance):
                        ModelState.AddModelError("HasConfirmedAttendance", execption.Message);
                        break;
                    default:
                        ModelState.AddModelError("Error", execption.Message);
                        break;
                }
                return View("CreateAttendeeView");
            }
            catch (ArgumentNullException execption)
            {
                ModelState.AddModelError("Error", execption.Message);
                return View("CreateAttendeeView");
            }
        }

        [HttpGet, Route("Update/{attendeeId}")]
        public IActionResult UpdateAttendeeView(int attendeeId)
        {
            AttendeesService attendeesService = new AttendeesService();
            var attendee = attendeesService.GetAllAttendeesFromRegistration(1).Find(@attendee => @attendee.AttendeeId == attendeeId);
            return View("UpdateAttendeeView", attendee);
        }
    }
}
