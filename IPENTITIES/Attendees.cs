using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPENTITIES
{
    /// <summary>
    /// This class is used to represent the Attendees entity.
    /// </summary>
    public class Attendees
    {
        // Private fields
        private int _attendeeId;
        private string _attendeeName;
        private string _attendeeEmail;
        private string _attendeePhoneNumber;
        private string _attendeeAddress;
        private bool _hasConfirmedAttendance;

        // Public properties
        public int AttendeeId
        {
            get => _attendeeId;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(AttendeeId), "AttendeeId cannot be less than or equal to 0");
                }
                _attendeeId = value;
            }
        }

        public string AttendeeName
        {
            get => _attendeeName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(AttendeeName), "AttendeeName cannot be null or empty");
                }
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(_attendeeName), "AttendeeName cannot be more than 100 characters");
                }
                _attendeeName = value;
            }
        }

        public string AttendeeEmail
        {
            get => _attendeeEmail;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(AttendeeEmail), "AttendeeEmail cannot be null or empty");
                }
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(AttendeeEmail), "AttendeeEmail cannot be more than 100 characters");
                }
                _attendeeEmail = value;
            }
        }

        public string AttendeePhoneNumber
        {
            get => _attendeePhoneNumber;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(AttendeePhoneNumber), "AttendeePhoneNumber cannot be null or empty");
                }
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(AttendeePhoneNumber), "AttendeePhoneNumber must be 10 characters long");
                }
                _attendeePhoneNumber = value;
            }
        }

        public bool HasConfirmedAttendance
        {
            get => _hasConfirmedAttendance;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(HasConfirmedAttendance), "HasConfirmedAttendance cannot be null");
                }
                _hasConfirmedAttendance = value;
            }
        }

        public string AttendeeAddress
        {
            get => _attendeeAddress;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(AttendeeAddress), "AttendeeAddress cannot be null or empty");
                }
                if (value.Length > 255)
                {
                    throw new ArgumentOutOfRangeException(nameof(AttendeeAddress), "AttendeeAddress cannot be more than 100 characters");
                }
                _attendeeAddress = value;
            }
        }

        //Default constructor
        public Attendees()
        {
        }

        //Parameterized constructor with all properties
        public Attendees(int attendeeId, string attendeeName, string attendeeEmail, string attendeePhoneNumber, string attendeeAddress, bool hasConfirmedAttendance)
        {
            AttendeeId = attendeeId;
            AttendeeName = attendeeName;
            AttendeeEmail = attendeeEmail;
            AttendeePhoneNumber = attendeePhoneNumber;
            AttendeeAddress = attendeeAddress;
            HasConfirmedAttendance = hasConfirmedAttendance;
        }

        //Parameterized constructor without AttendeeId
        public Attendees(string attendeeName, string attendeeEmail, string attendeePhoneNumber, string attendeeAddress, bool hasConfirmedAttendance)
        {
            AttendeeName = attendeeName;
            AttendeeEmail = attendeeEmail;
            AttendeePhoneNumber = attendeePhoneNumber;
            AttendeeAddress = attendeeAddress;
            HasConfirmedAttendance = hasConfirmedAttendance;
        }
    }
}
