using PaymentService;
using Shared.Logger;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IFileLogger, FileLogger>();
builder.Services.AddSingleton(builder.Configuration);



var host = builder.Build();
host.Run();
