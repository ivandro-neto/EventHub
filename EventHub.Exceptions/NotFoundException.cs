﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Exceptions
{
    public class NotFoundException : EventHubException
    {
        public NotFoundException(string message) : base(message) { }
    }
}
