using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Exceptions
{
    public class ErrorOnValidationException : EventHubException
    {
        public ErrorOnValidationException(string message) : base(message){ }
    }
}
