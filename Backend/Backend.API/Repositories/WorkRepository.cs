using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.API.Repositories;

public class WorkRepository : IRepository<WorkExperienceIncludedDTO>
{
    private CvContext _context;

    public WorkRepository(CvContext context)
    {
        _context = context;
    }

    public IEnumerable<WorkExperienceIncludedDTO> Get(bool included = true) => included
        ? GetIncluded().Select(w => w.ToIncludedDto())
        : _context.WorkExperiences.Select(w => w.ToIncludedDto());

    public async Task<WorkExperienceIncludedDTO?> GetByIdAsync(int id, bool included = true)
    {
        var work = included
            ? await GetIncluded().FirstOrDefaultAsync(w => w.Id == id)
            : await _context.WorkExperiences.FirstOrDefaultAsync(w => w.Id == id);
        
        return work?.ToIncludedDto();
    }

    public async Task<WorkExperienceIncludedDTO> CreateAsync(WorkExperienceIncludedDTO createDto)
    {
        var entity = createDto.ToEntity();
        entity.Id = 0;
        var result = await _context.WorkExperiences.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToIncludedDto();
    }

    public async Task<WorkExperienceIncludedDTO?> UpdateAsync(WorkExperienceIncludedDTO updateDto)
    {
        //TODO: Check logic, could be improved
        var updateentity = await _context.WorkExperiences.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateentity == null) return null;

        _context.Entry(updateentity).State = EntityState.Detached;
        _context.Entry(updateDto.ToEntity()).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return updateDto;    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deleteEntity = await _context.WorkExperiences.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return false;

        _context.WorkExperiences.Remove(deleteEntity);
        await _context.SaveChangesAsync();
        return true;  
    }
    private IIncludableQueryable<WorkExperienceEntity, ICollection<CertificationEntity>?> GetIncluded()
    {
        return _context.WorkExperiences
            .Include(w => w.AsociatedSkills)
            .Include(w => w.ConnectedCompanies)
            .Include(w => w.Categories)
            .Include(w => w.Certifications);
    }
}