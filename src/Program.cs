using Bazario.AspNetCore.Shared.Infrastructure.MessageBroker.DependencyInjection;
using Bazario.Notification.Emails;
using Bazario.Notification.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.ConfigureOptions();

builder.Services.AddFluentEmailSender();

builder.Services.AddSingleton<IEmailSender, EmailSender>();

builder.Services.AddMessageBroker();

builder.Services.AddMessageConsumers();

var host = builder.Build();

host.Services.ValidateOptionsOnStart();

host.Run();