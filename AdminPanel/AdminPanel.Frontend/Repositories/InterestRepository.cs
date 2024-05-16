using AdminPanel.Frontend.AbstractClasses;
using Backend.API.Models;

namespace AdminPanel.Frontend.Repositories
{
    public class InterestRepository : RepositoryBase<InterestModel>
    {
        public InterestRepository(IConfiguration configuration, IHttpClientFactory clientFactory) : base(configuration, clientFactory)
        {
            this._apiPath = "Interest";
        }
    }
}
