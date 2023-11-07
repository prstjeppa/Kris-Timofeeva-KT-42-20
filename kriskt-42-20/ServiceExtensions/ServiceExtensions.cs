using kriskt_42_20.Interfaces.PrepodInterfaces;
using static kriskt_42_20.Interfaces.PrepodInterfaces.IPrepodService;

namespace kriskt_42_20.ServiceInterfaces
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPrepodService, PrepodService>();

            return services;
        }
    }
}
