using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.API.Repositories
{
    public class CategoryRepository : IRepository<CategoryIncludedDTO>
    {
        private CvContext _context;

        public CategoryRepository(CvContext context)
        {
            this._context = context;
        }
        public async Task<CategoryIncludedDTO> CreateAsync(CategoryIncludedDTO createDto)
        {
            var entity = createDto.ToEntity();
            entity.Id = 0;
            var result = await _context.Categories.AddAsync(entity);
            var saves = await _context.SaveChangesAsync();
            return result.Entity.ToIncludedDto();

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleteEntity = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (deleteEntity == null) return false;

            _context.Categories.Remove(deleteEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<CategoryIncludedDTO> Get(bool included = true) => included
            ? GetIncluded().Select(c => c.ToIncludedDto())
            : _context.Categories.Select(c => c.ToIncludedDto()).ToList();

        public async Task<CategoryIncludedDTO?> GetByIdAsync(int id, bool included = true)
        {
            CategoryEntity? category;
            if (included)
            {
                category = await GetIncluded().FirstOrDefaultAsync(c => c.Id == id);
            }
            else category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            return category?.ToIncludedDto();
        }

        public async Task<CategoryIncludedDTO?> UpdateAsync(CategoryIncludedDTO updateDto)
        {
            //TODO: Check logic, could be improved
            var updateentity = await _context.Categories.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
            if (updateentity == null) return null;

            _context.Entry(updateentity).State = EntityState.Detached;
            _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateDto;
        }

        public IIncludableQueryable<CategoryEntity,ICollection<SkillEntity>?> GetIncluded()
        {
            return _context.Categories
                .Include(c => c.PersonalProjects).ThenInclude(p => p.ProjectUri)
                .Include(c => c.Certifications)
                .Include(c => c.WorkExperiences)
                .Include(c => c.Educations)
                .Include(c => c.AsociatedSkills);

        }
    }
}
