using AdminPanel.Frontend.Interfaces;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace AdminPanel.Frontend.AbstractClasses
{
    //TODO: Implement error handling
    public abstract class RepositoryBase<TModel> : IRepository<TModel>
        where TModel : IModel
    {
        /// <summary>
        /// Base uri for accessing API
        /// </summary>
        protected string _apiUri;
        private IHttpClientFactory _clientFactory;
        /// <summary>
        /// Path for accessing resource in api, must be set
        /// </summary>
        protected string _apiPath;

        /// <summary>
        /// To overwrite default error messages
        /// </summary>
        protected string? _errorMessage; //TODO: Maybe expand to error messages individually for each CRUD operation
        
        /// <summary>
        /// <c>_apiPath</c> must be set to work
        /// </summary>
        public RepositoryBase(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _apiUri = configuration["ApiUri"] != null ? configuration["ApiUri"] : "";
            _clientFactory = clientFactory;
        }
        public virtual async Task<TModel?> CreateAsync(TModel createModel)
        {
            using var client = _clientFactory.CreateClient();

            var result = await client.PostAsJsonAsync<TModel>($"{_apiUri}/{_apiPath}", createModel);

            //TODO: Validate result before conversion
            var model = await result.Content.ReadFromJsonAsync<TModel>();

            return model;
        }

        public virtual async Task<TModel?> DeleteByIdAsync(int id)
        {
            using var client = _clientFactory.CreateClient();

            var result = await client.DeleteAsync($"{_apiUri}/{_apiPath}/{id}");

            //TODO: Validate result before conversion
            var model = await result.Content.ReadFromJsonAsync<TModel>();

            return model;
        }

        public virtual async Task<List<TModel>> GetAllAsync()
        {
            using var client = _clientFactory.CreateClient();

            var models = await client.GetFromJsonAsync<List<TModel>>($"{_apiUri}/{_apiPath}");
            return models;
        }

        public virtual async Task<TModel?> GetByIdAsync(int id)
        {
            using var client = _clientFactory.CreateClient();

            var model = await client.GetFromJsonAsync<TModel>($"{_apiUri}/{_apiPath}?id={id}");
            return model;
        }

        public virtual async Task<TModel?> UpdateAsync(TModel updateModel)
        {
            using var client = _clientFactory.CreateClient();

            var result = await client.PutAsJsonAsync<TModel>($"{_apiUri}/{_apiPath}", updateModel);

            //TODO: Validate result before conversion
            var model = await result.Content.ReadFromJsonAsync<TModel>();

            return model;
        }
    }
}
