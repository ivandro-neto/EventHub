using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Communication.Responses
{
    public class ErrorResponseJson
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public ErrorResponseJson(int code, string message)
        {
            ErrorCode = code;
            Message = message;

        }
    }
}
