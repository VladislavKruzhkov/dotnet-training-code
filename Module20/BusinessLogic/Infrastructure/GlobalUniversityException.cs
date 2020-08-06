using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Infrastructure
{
    public class GlobalUniversityException
    {
        private readonly RequestDelegate _next;

        private readonly ILogger _logger;

        public GlobalUniversityException(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<GlobalUniversityException>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                _logger.LogError(ex.GetType().ToString());
                _logger.LogError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetType().ToString());
                _logger.LogError(ex.Message);
            }
        }
    }
}
