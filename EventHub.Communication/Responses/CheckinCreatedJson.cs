using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Communication.Responses
{
    public class CheckinCreatedJson
    {
        public Guid id {  get; set; }
        public Guid AccountID { get; set; }
        public Guid EventID { get; set; }

    }
}
