using Microsoft.Extensions.Hosting;
using Shared.Logger;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentService
{
    public class Worker : BackgroundService
    {
        private readonly IFileLogger _fileLogger;

        // Injectează FileLogger
        public Worker(IFileLogger fileLogger)
        {
            _fileLogger = fileLogger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_fileLogger != null)
                {
                    _fileLogger.Log($"Worker running at: {DateTimeOffset.Now}");
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
