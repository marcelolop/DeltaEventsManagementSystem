using IPDAL;
using IPENTITIES;

namespace IPBLL
{
    /// <summary>
    /// This class is responsible for handling the business logic of the Registrations entity.
    /// </summary>
    public class RegistrationsService
    {
        /// <summary>
        /// This method gets all the registrations for all events
        /// </summary>
        /// <returns> A list of registrations for all events</returns>
        public List<Registrations> GetAllRegistrations()
        {
            List<Registrations> registrations = new List<Registrations>();
            RegistrationsRepository registrationsRepository = new RegistrationsRepository();
            registrations = registrationsRepository.GetAllEventsRegistrations();

            return registrations;
        }

        /// <summary>
        /// This method Adds a registration to the database
        /// </summary>
        /// <param name="createRegistrationRequest"> The registration to be added</param>
        /// <returns> True if the registration was added, false if not</returns>
        public bool AddRegistration(CreateRegistrationRequest createRegistrationRequest)
        {
            Registrations registrations = new Registrations()
            {
                RegistrationDate = createRegistrationRequest.RegistrationDate,
                PaymentStatus = createRegistrationRequest.PaymentStatus,
                PaymentMethod = createRegistrationRequest.PaymentMethod,
                EventId = createRegistrationRequest.EventId,
                Attendee = new Attendees()
                {
                    AttendeeName = createRegistrationRequest.AttendeeName,
                    AttendeeEmail = createRegistrationRequest.AttendeeEmail,
                    AttendeePhoneNumber = createRegistrationRequest.AttendeePhoneNumber,
                    AttendeeAddress = createRegistrationRequest.AttendeeAddress,
                    HasConfirmedAttendance = createRegistrationRequest.HasConfirmedAttendance
                },
                Ticket = new Tickets()
                {
                    TicketQuantity = createRegistrationRequest.TicketQuantity,
                    TicketPrice = createRegistrationRequest.TicketPrice,
                    TicketType = createRegistrationRequest.TicketType
                }
                
            };

            RegistrationsRepository registrationsRepository = new RegistrationsRepository();

            return registrationsRepository.AddRegistration(registrations);

        }

        /// <summary>
        /// This method updates a registration in the database
        /// </summary>
        /// <param name="updateRegistrationRequest"> The registration to be updated</param>
        /// <returns> True if the registration was updated, false if not</returns>
        public bool UpdateRegistration(UpdateRegistrationRequest updateRegistrationRequest)
        {

            RegistrationsRepository registrationsRepository = new RegistrationsRepository();

            Registrations registrations = new Registrations()
            {
                EventId = updateRegistrationRequest.EventId,
                AttendeeId = updateRegistrationRequest.AttendeeId,
                TicketId = updateRegistrationRequest.TicketId,
                RegistrationDate = updateRegistrationRequest.RegistrationDate,
                PaymentStatus = updateRegistrationRequest.PaymentStatus,
                PaymentMethod = updateRegistrationRequest.PaymentMethod,
                Attendee = new Attendees()
                {
                    AttendeeName = updateRegistrationRequest.AttendeeName,
                    AttendeeEmail = updateRegistrationRequest.AttendeeEmail,
                    AttendeePhoneNumber = updateRegistrationRequest.AttendeePhoneNumber,
                    AttendeeAddress = updateRegistrationRequest.AttendeeAddress,
                    HasConfirmedAttendance = updateRegistrationRequest.HasConfirmedAttendance
                },
                Ticket = new Tickets()
                {
                    TicketQuantity = updateRegistrationRequest.TicketQuantity,
                    TicketPrice = updateRegistrationRequest.TicketPrice,
                    TicketType = updateRegistrationRequest.TicketType
                }
            };

            return registrationsRepository.UpdateRegistration(registrations);
        }


        /// <summary>
        /// This method is used to delete a registration from the database
        /// </summary>
        /// <param name="eventId"> The event id of the registration to be deleted</param>
        /// <param name="attendeeId"> The attendee id of the registration to be deleted</param>
        /// <returns> True if the registration was deleted, false if not</returns>
        public bool DeleteRegistration(int eventId, int attendeeId)
        {

            RegistrationsRepository registrationsRepository = new RegistrationsRepository();

            return registrationsRepository.DeleteRegistration(eventId, attendeeId);
        }

    }
}
