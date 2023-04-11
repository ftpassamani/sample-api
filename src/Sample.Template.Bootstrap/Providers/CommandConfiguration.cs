using Microsoft.Extensions.DependencyInjection;
using Sample.Template.Application.Services.MySqlSampleRepository;
using Sample.Template.Data.Dapper.Repositories;

namespace Sample.Template.Bootstrap.Providers
{
    public static class CommandConfiguration
    {
        public static void ConfigureCommandServices(this IServiceCollection services)
        {
            services.AddScoped<IMySqlSampleRepository, MySqlSampleRepository>();
        }
    }
}
