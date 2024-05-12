using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Repositories;

public class PersonalProjectUriRepository : IRepository<PersonalProjectUriDTO>
{
    private CvContext _context;

    public PersonalProjectUriRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<PersonalProjectUriDTO> Get(bool included = true) =>
        _context.PersonalProjectUris.Include(p => p.PersonalProject).Select(p => p.ToDto());

    public async Task<PersonalProjectUriDTO?> GetByIdAsync(int id, bool included = true)
    {
        var uri =
            await _context.PersonalProjectUris.Include(p => p.PersonalProject)
                .FirstOrDefaultAsync(p => p.Id == id);
        return uri?.ToDto();
    }

    public async Task<PersonalProjectUriDTO?> CreateAsync(PersonalProjectUriDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var result = await _context.PersonalProjectUris.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToDto();
    }

    public async Task<PersonalProjectUriDTO?> UpdateAsync(PersonalProjectUriDTO updateDto)
    {
        var updateentity = await _context.PersonalProjectUris.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;


        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;
    }

    public async Task<PersonalProjectUriDTO?> DeleteAsync(int id)
    {
        var deleteEntity = await _context.PersonalProjectUris.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return null;
        _context.PersonalProjectUris.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return deleteEntity.ToDto();
    }
}