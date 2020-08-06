using BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Services.NotifierServices
{
    public class SmsService : INotifierService
    {
        private readonly ILogger _logger;

        public SmsService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SmsService>();
        }

        public void Notify(string receiverName)
        {
            _logger.LogInformation($"SMS Service Info: {receiverName} was notified");
        }
    }
}
