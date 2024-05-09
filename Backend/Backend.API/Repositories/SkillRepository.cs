using Backend.API.Database;
using Backend.API.Entities;
using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Extensions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Backend.API.Repositories;

public class SkillRepository : IRepository<SkillEntity, SkillIncludedDTO>
{
    private CvContext _context;

    public SkillRepository(CvContext context)
    {
        _context = context;
    }


    //TODO: Maybe remove async
    public async Task<IEnumerable<SkillIncludedDTO>> Get(bool includeded = true)
    {
        IEnumerable<SkillEntity>? skills = new List<SkillEntity>();
        if (includeded)
        {
            skills = _context.Skills
                .Include(s => s.WorkPlaces)
                .Include(s => s.Categories)
                .Include(s => s.PersonalProjects)
                .Include(s => s.Educations)
                .Include(s => s.Certifications);
        }
        else skills = _context.Skills;

        return skills.Select(s => s.ToIncludedDto()).ToList();
    }


    public Task<IEnumerable<SkillIncludedDTO>> QueryGet(Func<SkillEntity, bool> expresion, bool included = true)
    {
        throw new NotImplementedException();
    }

    public Task<SkillIncludedDTO> Create(SkillIncludedDTO createDto)
    {
        throw new NotImplementedException();
    }

    public Task<SkillIncludedDTO> Update(SkillIncludedDTO updateDto)
    {
        throw new NotImplementedException();
    }

    public Task<SkillIncludedDTO> Delete(int id)
    {
        throw new NotImplementedException();
    }
}