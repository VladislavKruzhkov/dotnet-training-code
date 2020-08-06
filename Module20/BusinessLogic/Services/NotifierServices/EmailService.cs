using BusinessLogic.Interfaces;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Services.NotifierServices
{
    public class EmailService : INotifierService
    {
        private readonly ILogger _logger;

        public EmailService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EmailService>();
        }

        public void Notify(string receiverName)
        {
            _logger.LogInformation($"Email Service Info: {receiverName} was notified");
        }
    }
}