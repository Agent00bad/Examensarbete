using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;

namespace Backend.API.Extensions.Entities;

public static class SkillExtensions
{
    /// <returns>Entity converted to DTO with no relations</returns>
    public static SkillDTO ToDto(this SkillEntity entity) => new SkillDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description, 
        SkillRelevance = entity.SkillRelevance, 
        SkillLevel = entity.SkillLevel,
        LogoUri = entity.LogoUri
    };
    
    public static SkillIncludedDTO ToIncludedDto(this SkillEntity entity) => new SkillIncludedDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description, 
        SkillRelevance = entity.SkillRelevance, 
        SkillLevel = entity.SkillLevel,
        LogoUri = entity.LogoUri, 
        Categories = entity.Categories?.Select(c => c.ToDto()).ToList(), 
        Certifications = entity.Certifications?.Select(c => c.ToDto()).ToList(), 
        Educations = entity.Educations?.Select(e => e.ToDto()).ToList(), 
        PersonalProjects = entity.PersonalProjects?.Select(p => p.ToDto()).ToList(), 
        WorkPlaces = entity.WorkPlaces?.Select(w => w.ToDto()).ToList(),
    };
}