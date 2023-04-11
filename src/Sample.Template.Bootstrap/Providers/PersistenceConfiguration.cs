using Microsoft.Extensions.DependencyInjection;
using Sample.Template.Data.Dapper;

namespace Sample.Template.Bootstrap.Providers
{
    public static class PersistenceConfiguration
    {
        public static void ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddDapper();
        }
    }
}
