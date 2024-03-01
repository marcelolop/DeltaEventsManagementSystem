using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPBLL
{
    public  class UpdateRegistrationRequest : CreateRegistrationRequest
    {
        public int RegistrationId { get; set; }

    }
}
