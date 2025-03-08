using Microsoft.Extensions.Hosting;
using PaymentProject.Interfaces;
using Shared.Logger;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentProject
{
    public class Worker : BackgroundService
    {
        private readonly IFileLogger _fileLogger;
        private readonly IPaymentService _paymentService;

        // Injectează FileLogger
        public Worker(IFileLogger fileLogger, IPaymentService paymentService)
        {
            _fileLogger = fileLogger;
            _paymentService = paymentService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var processedIds = await _paymentService.ProcessPaymentsAsync();

                if (_fileLogger != null && processedIds != null && processedIds.Count() > 0)
                {
                    foreach (var processedId in processedIds)
                        _fileLogger.Log($"[PaymentProject] Products with ID: {processedId.ToString()} have been paid");
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
