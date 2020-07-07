using System;
using System.Collections.Generic;

namespace AricMiddlewareAPI.Models
{
    public partial class ChatSession
    {
        public int ChatSessionId { get; set; }
        public int WorkFlowId { get; set; }
        public int? Score { get; set; }
    }
}
