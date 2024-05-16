using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.API.Repositories;

public class CertificationRepository : IRepository<CertificationIncludedDTO>
{
    private CvContext _context;

    public CertificationRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<CertificationIncludedDTO> Get(bool included = true) =>
        included
            ? GetIncluded().Select(c => c.ToIncludedDto())
            : _context.Certifications.Select(c => c.ToIncludedDto());

    public async Task<CertificationIncludedDTO?> GetByIdAsync(int id, bool included = true)
    {
        var certification = included
            ? await GetIncluded().FirstOrDefaultAsync(c => c.Id == id)
            : await _context.Certifications.FirstOrDefaultAsync(c => c.Id == id);

        return certification?.ToIncludedDto();
    }

    public async Task<CertificationIncludedDTO> CreateAsync(CertificationIncludedDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var result = await _context.Certifications.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToIncludedDto();
    }

    public async Task<CertificationIncludedDTO?> UpdateAsync(CertificationIncludedDTO updateDto)
    {
        //TODO: Check logic, could be improved
        var updateentity = await _context.Certifications.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;

        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleteEntity = await _context.Certifications.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return false;

        _context.Certifications.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return true;
    }

    public IIncludableQueryable<CertificationEntity, ICollection<SkillEntity>?> GetIncluded()
    {
        return _context.Certifications
            .Include(c => c.WorkExperiences)
            .Include(c => c.Educations)
            .Include(c => c.Categories)
            .Include(c => c.AsociatedSkills);
    }
}