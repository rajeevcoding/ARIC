using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AricMiddlewareAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AricMiddlewareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly AricdbContext _aricdbContext;

        public MessageController(AricdbContext aricdbContext)
        {
            _aricdbContext = aricdbContext;
        }

        [HttpPost]
        [Route("PostCustomerMessage/{chatsessionid}")]
        public bool PostCustomerMessage(int chatsessionid, [FromBody] string message)
        {
            _aricdbContext.CustomerMessage.Add(new CustomerMessage
            {
                ChatSessionId = chatsessionid,
                DatetimeStamp = DateTime.Now,
                Message = message
            });
            _aricdbContext.SaveChanges();

            return true;
        }

        [HttpPost]
        [Route("PostAgentMessage/{customerMessageId}")]
        public bool PostAgentMessage(int customerMessageId, [FromBody] string message)
        {
            _aricdbContext.AgentMessage.Add(new AgentMessage
            {
                CustomerMessageId = customerMessageId,
                DatetimeStamp = DateTime.Now,
                Message = message
            });
            _aricdbContext.SaveChanges();

            return true;
        }
    }
}
