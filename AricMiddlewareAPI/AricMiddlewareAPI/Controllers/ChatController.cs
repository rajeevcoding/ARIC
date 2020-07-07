using AnalyticsEngine;
using AricMiddlewareAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AricMiddlewareAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ChatController : ControllerBase
    {
        private readonly IAnalyticsProvider _analyticsProvider;
        private readonly AricdbContext aricdbContext;

        public ChatController(IAnalyticsProvider analyticsProvider, AricdbContext aricdbContext)
        {
            _analyticsProvider = analyticsProvider;
            this.aricdbContext = aricdbContext;
        }
        [HttpPost("{workflowId}")]
        public int OpenSession(int workflowId)
        {
            var createdChatSession = aricdbContext.ChatSession.Add(new ChatSession
            {
                WorkFlowId = workflowId
            });
            aricdbContext.SaveChanges();
            return createdChatSession.Entity.ChatSessionId;
        }

        [HttpPost("{chatSessionId}")]
        public bool CloseSession(int chatSessionId)
        {
            // Close the session by calculating the overall score.
            return true;
        }

        [HttpGet]
        public IEnumerable<WorkFlow> GetWorkFlows()
        {
            return aricdbContext.WorkFlow;
        }
    }
}