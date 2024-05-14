using AdminPanel.Frontend.AbstractClasses;
using AdminPanel.Frontend.Interfaces;
using Backend.API.Entities;

namespace AdminPanel.Frontend.Repositories
{

    public class AboutRepository : RepositoryBase<AboutModel>
    {
        public AboutRepository(IConfiguration configuration, IHttpClientFactory clientFactory) : base(configuration, clientFactory)
        {
            _apiPath = "Abouts";
        }
    }
}
