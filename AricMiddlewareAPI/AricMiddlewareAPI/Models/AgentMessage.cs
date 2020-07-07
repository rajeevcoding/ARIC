using System;
using System.Collections.Generic;

namespace AricMiddlewareAPI.Models
{
    public partial class AgentMessage
    {
        public int AgentMessageId { get; set; }
        public int? CustomerMessageId { get; set; }
        public string Message { get; set; }
        public DateTime? DatetimeStamp { get; set; }
    }
}
