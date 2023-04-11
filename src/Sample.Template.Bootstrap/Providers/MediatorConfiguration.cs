using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Template.Bootstrap.Providers
{
    public static  class MediatorConfiguration
    {
        private const string APPLICATION_NAMESPACE = "Sample.Template.Application";

        public static void ConfigureMediatrServices(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load(APPLICATION_NAMESPACE);
            services.AddMediatR(assembly);
        }
    }
}
