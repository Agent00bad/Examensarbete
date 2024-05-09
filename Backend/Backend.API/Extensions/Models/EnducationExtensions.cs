using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;

namespace Backend.API.Extensions.Entities;

public static class EnducationExtensions
{
    /// <returns>Entity converted to DTO with no relations</returns>
    public static EducationDTO ToDto(this EducationEntity entity) => new EducationDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Enrolled = entity.Enrolled,
        LogoUri = entity.LogoUri, 
    };

    /// <returns>Entity converted to DTO with relations</returns>
    public static EducationIncludedDTO ToIncludedDto(this EducationEntity entity) => new EducationIncludedDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Enrolled = entity.Enrolled,
        LogoUri = entity.LogoUri,
        AsociatedSkills = entity.AsociatedSkills?.Select(s => s.ToDto()).ToList(),
        Categories = entity.Categories?.Select(c => c.ToDto()).ToList(),
        Certifications = entity.Certifications?.Select(c => c.ToDto()).ToList(),
    };
}