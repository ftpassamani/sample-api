using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Sample.Template.Bootstrap.Providers
{
    public static class MvcConfiguration
    {
        public static void ConfigureMvcServices(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.Load("Sample.Template.Application"))); ;
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
