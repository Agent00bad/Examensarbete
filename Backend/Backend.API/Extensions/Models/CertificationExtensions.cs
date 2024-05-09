using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;

namespace Backend.API.Extensions.Entities;

public static class CertificationExtensions
{
    /// <returns>Entity converted to DTO with no relations</returns>
    public static CertificationDTO ToDto(this CertificationEntity entity) => new CertificationDTO
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        LogoUri = entity.LogoUri,
        CertificationUrl = entity.CertificationUrl, 
        ImageUri = entity.ImageUri
    };
    
    /// <returns>Entity converted to DTO with relations</returns>
    public static CertificationIncludedDTO ToIncludedDto(this CertificationEntity entity) => new CertificationIncludedDTO
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        LogoUri = entity.LogoUri,
        CertificationUrl = entity.CertificationUrl,
        AsociatedSkills = entity.AsociatedSkills?.Select(s => s.ToDto()).ToList(),
        Educations = entity.Educations?.Select(e => e.ToDto()).ToList(),
        WorkExperiences = entity.WorkExperiences?.Select(w => w.ToDto()).ToList(), 
        Categories = entity.Categories?.Select(c => c.ToDto()).ToList(), 
        ImageUri =  entity.ImageUri
    }
}