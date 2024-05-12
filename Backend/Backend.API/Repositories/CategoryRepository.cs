using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Interfaces;

namespace Backend.API.Repositories
{
    public class CategoryRepository : IRepository<CategoryIncludedDTO>
    {
        private CvContext _context;
        public Task<CategoryIncludedDTO> CreateAsync(CategoryIncludedDTO createDto)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryIncludedDTO?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryIncludedDTO> Get(bool included = true)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryIncludedDTO?> GetByIdAsync(int id, bool included = true)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryIncludedDTO?> UpdateAsync(CategoryIncludedDTO updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
