using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siraye.Application.Interfaces;
using Siraye.Domain.Settings;
using Siraye.Infrastructure.Shared.Services;

namespace Siraye.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
