using DotNetCore.CAP;
using Microsoft.Extensions.Logging;

namespace CAPDemo
{
    public class HelloWorldReceiver : ICapSubscribe
    {
        private readonly ILogger<HelloWorldReceiver> _logger;

        public HelloWorldReceiver(ILogger<HelloWorldReceiver> logger)
        {
            _logger = logger;
        }
        
        [CapSubscribe("helloWorld")]
        public void Handle(string value)
        {
            _logger.Log(LogLevel.Debug, value);
        }
    }
}