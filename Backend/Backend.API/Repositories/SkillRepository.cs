using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions;
using Backend.API.Extensions.Entities;
using Backend.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.API.Repositories;

public class SkillRepository : IRepository<SkillIncludedDTO> 
{
    private CvContext _context;
    public SkillRepository(CvContext context )  
    {
        _context = context;
    }
    public IEnumerable<SkillIncludedDTO>Get(bool included = true)
    {
        IEnumerable<SkillEntity>? skills;
        if (included)
        {
            skills = GetIncluded();
        }
        else skills = _context.Skills;

        return skills.Select(s => s.ToIncludedDto()).ToList();
    }

    public async Task<SkillIncludedDTO?> GetById(int id, bool included = true)
    {
        SkillEntity? skill;
        if (included)
        {
            skill = await GetIncluded().FirstOrDefaultAsync(s => s.Id == id);
        }
        else skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);

        return skill?.ToIncludedDto();
    }
    
    //TODO:Add better handling if error occurs
    public async Task<SkillIncludedDTO> Create(SkillIncludedDTO createDto)
    {
        var entity = createDto.ToEntity();
        var result = await _context.Skills.AddAsync(entity);
        var saves = await _context.SaveChangesAsync();
        return result.Entity.ToIncludedDto();
    }

    public async Task<SkillIncludedDTO?> Update(SkillIncludedDTO updateDto)
    {
        var updateEntity = await _context.Skills.FirstOrDefaultAsync(s => s.Id == updateDto.Id);
        if (updateEntity == null) return null;

        updateEntity = updateDto.ToEntity();
        await _context.SaveChangesAsync();

        return updateEntity.ToIncludedDto();
    }

    public async Task<SkillIncludedDTO?> Delete(int id)
    {
        var deleteEntity = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);
        if (deleteEntity == null) return null;
        _context.Skills.Remove(deleteEntity);
       await _context.SaveChangesAsync();
       return deleteEntity.ToIncludedDto();
    }
    
  
    /// <returns>Get entities from context with includes</returns>
    private IIncludableQueryable<SkillEntity, ICollection<CertificationEntity>?> GetIncluded()
    {
        return _context.Skills
            .Include(s => s.WorkPlaces)
            .Include(s => s.Categories)
            .Include(s => s.PersonalProjects)
            .Include(s => s.Educations)
            .Include(s => s.Certifications);
    }
}