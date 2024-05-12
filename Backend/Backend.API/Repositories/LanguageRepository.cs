using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories;

public class LanguageRepository : IRepository<LanguageDTO>
{
    private CvContext _context;

    public LanguageRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<LanguageDTO> Get(bool included = true) =>
        _context.Languages.Include(l => l.Person).Select(l => l.ToDto());

    public async Task<LanguageDTO?> GetByIdAsync(int id, bool included = true)
    {
        var entity =
            await _context.Languages.Include(l => l.Person).FirstOrDefaultAsync(l => l.Id == id);
        return entity?.ToDto();
    }

    public async Task<LanguageDTO?> CreateAsync(LanguageDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var result = await _context.Languages.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToDto();
    }

    public async Task<LanguageDTO?> UpdateAsync(LanguageDTO updateDto)
    {
        //TODO: Check logic, could be improved
        var updateentity = await _context.Languages.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;


        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;
    }

    public async Task<LanguageDTO?> DeleteAsync(int id)
    {
        var deleteEntity = await _context.Languages.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return null;
        _context.Languages.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return deleteEntity.ToDto();
    }
}