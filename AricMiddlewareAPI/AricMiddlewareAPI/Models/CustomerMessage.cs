using System;
using System.Collections.Generic;

namespace AricMiddlewareAPI.Models
{
    public partial class CustomerMessage
    {
        public int CustomerMessageId { get; set; }
        public int ChatSessionId { get; set; }
        public string Message { get; set; }
        public DateTime DatetimeStamp { get; set; }
    }
}
