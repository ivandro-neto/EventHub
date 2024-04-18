using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Communication.Responses
{
    public class CheckInResponseJson
    {
        public Guid ID_CheckIn { get; set; }

        public Guid ID_Event { get; set; }

        public Guid ID_Attendee { get; set; }

        public string State { get; set; } = string.Empty;

        public DateTime RegistedDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }

    }
}
