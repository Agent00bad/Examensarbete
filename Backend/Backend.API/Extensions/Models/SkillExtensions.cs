using Backend.API.Entities;
using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;
using Backend.API.Enums;

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
    
    /// <returns>Entity converted to DTO with relations</returns>
    public static SkillIncludedDTO? ToIncludedDto(this SkillEntity entity) => new SkillIncludedDTO()
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

    public static SkillEntity ToEntity(this SkillDTO dto) => new SkillEntity
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description, 
        SkillRelevance = dto.SkillRelevance, 
        SkillLevel = dto.SkillLevel,
        LogoUri = dto.LogoUri
    };
    public static SkillEntity ToEntity(this SkillIncludedDTO dto) => new SkillEntity
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description, 
        SkillRelevance = dto.SkillRelevance, 
        SkillLevel = dto.SkillLevel,
        LogoUri = dto.LogoUri, 
        Categories = dto.Categories?.Select(c => c.ToEntity()).ToList(), 
        Certifications = dto.Certifications?.Select(c => c.ToEntity()).ToList(), 
        Educations = dto.Educations?.Select(e => e.ToEntity()).ToList(), 
        PersonalProjects = dto.PersonalProjects?.Select(p => p.ToEntity()).ToList(), 
        WorkPlaces = dto.WorkPlaces?.Select(w => w.ToEntity()).ToList(),
    };

}