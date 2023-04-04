using Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Context
{
    public static class TestContextServices
    {
        public static IServiceCollection AddDBContext(this IServiceCollection services)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile($"appsettings{(string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")) ? "" : "." + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))}.json", optional: true, reloadOnChange: false);
            var configuration = configurationBuilder.Build();
            services.AddDbContext<TestDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("TestDB")));
            return services;
        }
    }
}
