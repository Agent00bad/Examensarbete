using AdminPanel.Frontend.Interfaces;
using AdminPanel.Frontend.Repositories;
using Backend.API.Models;

namespace AdminPanel.Frontend.Extensions
{
    public static class ServiceExstension
    {
        public static void AddCustomScopes(this IServiceCollection services)
        {
            services.AddScoped<IRepository<AboutModel>, AboutRepository>();
        }
    }
}
