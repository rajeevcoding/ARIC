using AnalyticsEngine;
using Microsoft.AspNetCore.Mvc;

namespace AricMiddlewareAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ChatController : ControllerBase
    {
        private readonly IAnalyticsProvider _analyticsProvider;

        public ChatController(IAnalyticsProvider analyticsProvider)
        {
            _analyticsProvider = analyticsProvider;
        }
        [HttpPost("{id}")]
        public string PostMessage(string id, [FromBody] string message)
        {
            return _analyticsProvider.AnalyzeSentiment(message);
        }
    }
}