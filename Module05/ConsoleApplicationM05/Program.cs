using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module05;
using NLog;
using NLog.Extensions.Logging;

namespace ConsoleApplicationM05
{
    public class Program
    {
        private static NLog.ILogger _logger;

        public static void Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.Debug("Program started");

            Console.WriteLine("Enter string to convert to int");

            var servicesProvider = BuildDi();

            var converter = servicesProvider.GetRequiredService<Converter>();

            HandleExceptions(str => converter.ConvertToIntNumber(str));

            logger.Debug("Program completed");
        }

        public static void HandleExceptions(Func<string, int> converterFunc)
        {
            try
            {
                var number = converterFunc(Console.ReadLine());
                PushToOutput(number);
            }
            catch (ArgumentNullException)
            {
                ExceptionOutput(nameof(ArgumentNullException));
            }
            catch (IndexOutOfRangeException)
            {
                ExceptionOutput(nameof(IndexOutOfRangeException));
            }
            catch (ArgumentException)
            {
                ExceptionOutput(nameof(ArgumentException));
            }
            catch (OverflowException)
            {
                ExceptionOutput(nameof(OverflowException));
            }
        }

        private static IServiceProvider BuildDi() 
        {
            return new ServiceCollection()
                .AddTransient<Converter>()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog();
                })
                .BuildServiceProvider();
        }

        private static void ExceptionOutput(string exceptionType)
        {
            _logger.Error(exceptionType);
            Console.WriteLine(exceptionType);
        }

        private static void PushToOutput(int number) => Console.WriteLine(number);
    }
}