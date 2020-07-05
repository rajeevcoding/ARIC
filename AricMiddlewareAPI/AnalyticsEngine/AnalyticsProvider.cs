using Microsoft.Extensions.Configuration;
using Azure.AI.TextAnalytics;
using Azure;
using System;

namespace AnalyticsEngine
{
    public interface IAnalyticsProvider
    {
        string AnalyzeSentiment(string inputMessage);
    }
    public class AnalyticsProvider : IAnalyticsProvider
    {
        private readonly IConfiguration _configuration;
        private readonly AzureKeyCredential credentials;
        private readonly Uri endpoint;
        public AnalyticsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            credentials = new AzureKeyCredential(configuration.GetSection("APIKey").Value);
            endpoint = new Uri(configuration.GetSection("endpoint").Value);
        }
        public string AnalyzeSentiment(string inputMessage)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(inputMessage);
            return documentSentiment.Sentiment.ToString();
        }
    }
}
