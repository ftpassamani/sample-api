using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sample.Template.Application.Requests.MySqlSamples.Commun;

namespace Sample.Template.Bootstrap.Providers
{
    public static class ProfileConfiguration
    {
        public static void ConfigureProfileServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(typeof(MySqlSampleProfile));
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
