using PaymentProject;
using PaymentProject.Interfaces;
using PaymentProject.Services;
using ProductOrdersProject.Interfaces;
using ProductOrdersProject.Repositories;
using Shared.Logger;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IFileLogger, FileLogger>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton(builder.Configuration);



var host = builder.Build();
host.Run();
