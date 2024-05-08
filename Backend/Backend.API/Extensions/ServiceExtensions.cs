using Backend.API.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Extensions;

public static class ServiceExtensions
{
    /// <summary>
    /// Placing service configurations in a seperate extension for cleaner code
    /// </summary>
    /// <param name="configuration">Passed with the <c>builder.Configuration</c> from <c>Program.cs</c></param>
    public static void CustomConfigurations(this IServiceCollection service, IConfiguration configuration)
    {
        DatabaseConfigurations(service, configuration);
    }
    
    /// <summary>
    /// For configuring databased in <c>CustomConfiguration</c> extension method
    /// </summary>
    /// <param name="service">Is passed from <c>CustomConfiguration</c> extension method </param>
    /// <param name="config">Is passed from <c>CustomConfiguration</c> extension method</param>
    private static void DatabaseConfigurations(IServiceCollection service, IConfiguration config)
    {
         service.AddDbContext<CvContext>(options =>
        {
            options.UseSqlServer(config["Database:Cv:ConnectionString"]);
        });
    }
}