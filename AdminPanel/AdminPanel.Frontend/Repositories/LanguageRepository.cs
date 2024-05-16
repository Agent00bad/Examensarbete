using AdminPanel.Frontend.AbstractClasses;
using Backend.API.Models;

namespace AdminPanel.Frontend.Repositories
{
    public class LanguageRepository : RepositoryBase<LanguageModel>
    {
        public LanguageRepository(IConfiguration configuration, IHttpClientFactory clientFactory) : base(configuration, clientFactory)
        {
            this._apiPath = "Language";
        }
    }
}
