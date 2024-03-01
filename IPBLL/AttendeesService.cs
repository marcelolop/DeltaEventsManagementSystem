using IPDAL;
using IPENTITIES;


namespace IPBLL
{
    /// <summary>
    /// This class is responsible for handling all the business logic for the Attendees entity
    /// </summary>
    public class AttendeesService
    {
        /// <summary>
        /// This method gets all the attendees for a specific registration
        /// </summary>
        /// <param name="registrationId"> The registration id for which the attendees are being retrieved</param>
        /// <returns> A list of attendees for the registration</returns>
        public List<Attendees> GetAllAttendeesFromRegistration(int registrationId)
        {
            List<Attendees> attendees = new List<Attendees>();
            AttendeesRepository attendeesRepository = new AttendeesRepository();

            attendees = attendeesRepository.GetAllAttendeesOfRegistration(registrationId);

            return attendees;
        }

        /// <summary>
        /// This method is used to add an attendee to the database
        /// </summary>
        /// <param name="createAttendeeRequest"> The attendee to be added</param>
        /// <returns> True if the attendee was added, false if not</returns>
        /// <exception cref="ArgumentOutOfRangeException"> AttendeeId, AttendeeName, AttendeeEmail, AttendeePhoneNumber, AttendeeAddress</exception>
        /// <exception cref="ArgumentNullException"> HasConfirmedAttendance</exception>
        public bool AddAttendee(CreateAttendeeRequest createAttendeeRequest)
        {
            Attendees attendees = new Attendees()
            {
                AttendeeName = createAttendeeRequest.AttendeeName,
                AttendeeEmail = createAttendeeRequest.AttendeeEmail,
                AttendeePhoneNumber = createAttendeeRequest.AttendeePhoneNumber,
                AttendeeAddress = createAttendeeRequest.AttendeeAddress,
                HasConfirmedAttendance = createAttendeeRequest.HasConfirmedAttendance
            };

            AttendeesRepository attendeesRepository = new AttendeesRepository();

            #region Validations

            //if (attendees.AttendeeId == 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeId), "AttendeeId cannot be less than or equal to 0");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeeName))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeeName), "AttendeeName cannot be null or empty");
            //}
            //if(attendees.AttendeeName.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeName), "AttendeeName cannot be more than 255 characters");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeeEmail))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeeEmail), "AttendeeEmail cannot be null or empty");
            //}
            //if (attendees.AttendeeEmail.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeEmail), "AttendeeEmail cannot be more than 255 characters");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeePhoneNumber))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeePhoneNumber), "AttendeePhoneNumber cannot be null or empty");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeeAddress))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeeAddress), "AttendeeAddress cannot be null or empty");
            //}
            //if (attendees.AttendeeAddress.Length > 500)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeAddress), "AttendeeAddress cannot be more than 500 characters");
            //}
            //if (attendees.HasConfirmedAttendance == null)
            //{
            //    throw new ArgumentNullException(nameof(attendees.HasConfirmedAttendance), "HasConfirmedAttendance cannot be null");
            //}

            #endregion Validations

            return attendeesRepository.AddAttendee(attendees);
        }

        /// <summary>
        /// This method is used to update an attendee in the database
        /// </summary>
        /// <param name="updateAttendeeRequest"> The attendee to be updated</param>
        /// <returns> True if the attendee was updated, false if not</returns>
        public bool UpdateAttendee(UpdateAttendeeRequest updateAttendeeRequest)
        {

            Attendees attendees = new Attendees()
            {
                AttendeeId = updateAttendeeRequest.AttendeeId,
                AttendeeName = updateAttendeeRequest.AttendeeName,
                AttendeeEmail = updateAttendeeRequest.AttendeeEmail,
                AttendeePhoneNumber = updateAttendeeRequest.AttendeePhoneNumber,
                AttendeeAddress = updateAttendeeRequest.AttendeeAddress,
                HasConfirmedAttendance = updateAttendeeRequest.HasConfirmedAttendance
            };

            AttendeesRepository attendeesRepository = new AttendeesRepository();
            
            #region Validations

            //if (attendees.AttendeeId == 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeId), "AttendeeId cannot be less than or equal to 0");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeeName))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeeName), "AttendeeName cannot be null or empty");
            //}
            //if (attendees.AttendeeName.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeName), "AttendeeName cannot be more than 255 characters");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeeEmail))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeeEmail), "AttendeeEmail cannot be null or empty");
            //}
            //if (attendees.AttendeeEmail.Length > 255)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeEmail), "AttendeeEmail cannot be more than 255 characters");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeePhoneNumber))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeePhoneNumber), "AttendeePhoneNumber cannot be null or empty");
            //}
            //if (string.IsNullOrEmpty(attendees.AttendeeAddress))
            //{
            //    throw new ArgumentNullException(nameof(attendees.AttendeeAddress), "AttendeeAddress cannot be null or empty");
            //}
            //if (attendees.AttendeeAddress.Length > 500)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendees.AttendeeAddress), "AttendeeAddress cannot be more than 500 characters");
            //}
            //if (attendees.HasConfirmedAttendance == null)
            //{
            //    throw new ArgumentNullException(nameof(attendees.HasConfirmedAttendance), "HasConfirmedAttendance cannot be null");
            //}


            #endregion Validations
            
            return attendeesRepository.UpdateAttendee(attendees);
        }

        /// <summary>
        /// This method is used to delete an attendee from the database
        /// </summary>
        /// <param name="attendeeId"> The id of the attendee to be deleted</param>
        /// <returns> True if the attendee was deleted, false if not</returns>
        /// <exception cref="ArgumentOutOfRangeException"> AttendeeId</exception>
        public bool DeleteAttendee(int attendeeId)
        {
            #region Validations

            //if (attendeeId <= 0)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(attendeeId), "AttendeeId cannot be less than or equal to 0");
            //}

            #endregion Validations

            AttendeesRepository attendeesRepository = new AttendeesRepository();
            return attendeesRepository.DeleteAttendee(attendeeId);
        }
    }
}
