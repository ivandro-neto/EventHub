using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Communication.Responses
{
    public class EventCreatedResponseJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CreatorID { get; set; }
    }
}
