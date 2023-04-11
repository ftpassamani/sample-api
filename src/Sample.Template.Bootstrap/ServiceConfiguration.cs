using Microsoft.Extensions.DependencyInjection;
using Sample.Template.Bootstrap.Providers;

namespace Sample.Template.Bootstrap
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.ConfigureMvcServices();
            services.ConfigurePersistenceServices();
            services.ConfigureMediatrServices();
            services.ConfigureCommandServices();
            services.ConfigureProfileServices();
            services.ConfigureLogServices();
        }
    }
}
