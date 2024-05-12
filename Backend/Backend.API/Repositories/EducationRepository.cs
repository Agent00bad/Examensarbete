using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.API.Repositories;

public class EducationRepository : IRepository<EducationIncludedDTO>
{
    private CvContext _context;

    public EducationRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<EducationIncludedDTO> Get(bool included = true) => included
        ? GetIncluded().Select(e => e.ToIncludedDto())
        : _context.Educations.Select(e => e.ToIncludedDto());

    public async Task<EducationIncludedDTO?> GetByIdAsync(int id, bool included = true)
    {
        var education = included
            ? await GetIncluded().FirstOrDefaultAsync(e => e.Id == id)
            : await _context.Educations.FirstOrDefaultAsync(e => e.Id == id);
        return education?.ToIncludedDto();
    }

    public async Task<EducationIncludedDTO> CreateAsync(EducationIncludedDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var result = await _context.Educations.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToIncludedDto();
    }

    public async Task<EducationIncludedDTO?> UpdateAsync(EducationIncludedDTO updateDto)
    {
        //TODO: Check logic, could be improved
        var updateentity = await _context.Educations.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;


        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;
    }

    public async Task<EducationIncludedDTO?> DeleteAsync(int id)
    {
        var deleteEntity = await _context.Educations.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return null;
        _context.Educations.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return deleteEntity.ToIncludedDto();
    }

    // <returns>Get entities from context with includes</returns>
    private IIncludableQueryable<EducationEntity, ICollection<CertificationEntity>?> GetIncluded()
    {
        return _context.Educations
            .Include(e => e.AsociatedSkills)
            .Include(e => e.Categories)
            .Include(e => e.Certifications);
    }
}