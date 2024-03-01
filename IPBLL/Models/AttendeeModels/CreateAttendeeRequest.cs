using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public class CreateAttendeeRequest
    {
        public required string AttendeeName { get; set; }
        public required string AttendeeEmail { get; set; }
        public required string AttendeePhoneNumber { get; set; }
        public required string AttendeeAddress { get; set; }
        public bool HasConfirmedAttendance { get; set; }
    }
}
