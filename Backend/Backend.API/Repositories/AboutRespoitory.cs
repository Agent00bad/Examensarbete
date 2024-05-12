using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Backend.API.Extensions.Entities;
using Backend.API.DTOs.RelationsIncluded;

namespace Backend.API.Repositories
{
    public class AboutRespoitory : IRepository<AboutIncludedDTO>
    {
        private readonly CvContext _context;

        public AboutRespoitory(CvContext context)
        {
            _context = context;
        }

        public async Task<AboutIncludedDTO> CreateAsync(AboutIncludedDTO createDto)
        {
            var entity = createDto.ToEntity();
            entity.Id = 0;
            var result = await _context.Abouts.AddAsync(entity);
            var saves = await _context.SaveChangesAsync();
            return result.Entity.ToIncludedDto();
        }

        public async Task<AboutIncludedDTO?> DeleteAsync(int id)
        {
            var deleteEntity = await _context.Abouts.FirstOrDefaultAsync(s => s.Id == id);
            if (deleteEntity == null) return null;
            _context.Abouts.Remove(deleteEntity);
            await _context.SaveChangesAsync();
            return deleteEntity.ToIncludedDto();
        }

        public IEnumerable<AboutIncludedDTO> Get(bool included = true)
        {
            IEnumerable<AboutEntity?> abouts;
            if (included)
            {
                abouts = _context.Abouts.Include(a => a.Languages).Include(a => a.Interessts);
            }
            else abouts = _context.Abouts;

            return abouts.Select(s => s.ToIncludedDto()).ToList();
        }

        public async Task<AboutIncludedDTO?> GetByIdAsync(int id, bool included = true)
        {
            AboutEntity? about;
            if (included)
            {
                about = await _context.Abouts.Include(a => a.Languages).Include(a => a.Interessts).FirstOrDefaultAsync(s => s.Id == id);
            }
            else about = await _context.Abouts.FirstOrDefaultAsync(s => s.Id == id);

            return about?.ToIncludedDto();
        }

        public async Task<AboutIncludedDTO?> UpdateAsync(AboutIncludedDTO updateDto)
        {
            //TODO: Check logic, could be improved
            var updateentity = await _context.Abouts.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
            if (updateentity == null) return null;


            _context.Entry(updateentity).State = EntityState.Detached;
            _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateDto;
        }
    }
}
