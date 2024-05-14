using Microsoft.AspNetCore.SignalR;

namespace AdminPanel.Frontend.Interfaces
{
    public interface IRepository<TModel> 
        where TModel :IModel
    {
        public Task<List<TModel>> GetAllAsync();
        public Task<TModel?> GetByIdAsync (int id);
        public Task<TModel?> CreateAsync(TModel model);
        public Task<TModel?> UpdateAsync(TModel model);
        public Task<TModel?> DeleteByIdAsync(int id);
    }
}
