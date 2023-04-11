using Microsoft.Extensions.DependencyInjection;

namespace Sample.Template.Data.Dapper
{
    public static class RegisterExtensions
    {
        public static void AddDapper(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionFactory, SqlDbConnectionFactory>();
        }
    }
}
