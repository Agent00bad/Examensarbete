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


    //TODO: Maybe remove async
    public async Task<IEnumerable<SkillIncludedDTO>> Get(bool included = true)
    {
        IEnumerable<SkillEntity>? skills;
        if (included)
        {
            skills = await GetIncluded().ToListAsync();
        }
        else skills = await _context.Skills.ToListAsync();

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

    public Task<SkillIncludedDTO> Update(SkillIncludedDTO updateDto)
    {
        throw new NotImplementedException();
    }

    public Task<SkillIncludedDTO> Delete(int id)
    {
        throw new NotImplementedException();
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