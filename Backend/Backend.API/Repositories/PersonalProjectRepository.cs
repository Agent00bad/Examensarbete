using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.API.Repositories;

public class PersonalProjectRepository : IRepository<PersonalProjectIncludedDTO>
{
    private CvContext _context;

    public PersonalProjectRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<PersonalProjectIncludedDTO> Get(bool included = true) => included
        ? GetIncluded().Select(p => p.ToIncludedDto())
        : _context.PersonalProjects.Select(p => p.ToIncludedDto());

    public async Task<PersonalProjectIncludedDTO?> GetByIdAsync(int id, bool included = true)
    {
        var entity = included
            ? await GetIncluded().FirstOrDefaultAsync(p => p.Id == id)
            : await _context.PersonalProjects.FirstOrDefaultAsync(p => p.Id == id);
        return entity?.ToIncludedDto();
    }

    public async Task<PersonalProjectIncludedDTO?> CreateAsync(PersonalProjectIncludedDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var result = await _context.PersonalProjects.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToIncludedDto();
    }

    public async Task<PersonalProjectIncludedDTO?> UpdateAsync(PersonalProjectIncludedDTO updateDto)
    {
        var updateentity = await _context.PersonalProjects.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;


        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;
    }

    public async Task<PersonalProjectIncludedDTO?> DeleteAsync(int id)
    {
        var deleteEntity = await _context.PersonalProjects.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return null;
        _context.PersonalProjects.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return deleteEntity.ToIncludedDto();
    }

    private IIncludableQueryable<PersonalProjectEntity, ICollection<PersonalProjectUriEntity>?> GetIncluded()
    {
        return _context.PersonalProjects
            .Include(p => p.AsociatedSkills)
            .Include(p => p.Categories)
            .Include(p => p.ProjectUri);
    }
}