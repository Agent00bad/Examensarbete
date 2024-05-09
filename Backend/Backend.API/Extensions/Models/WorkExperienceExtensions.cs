using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;

namespace Backend.API.Extensions.Entities;

public static class WorkExperienceExtensions
{
    /// <returns>Entity converted to DTO with no relations</returns>
    public static WorkExperienceDTO ToDto(this WorkExperienceEntity entity) => new WorkExperienceDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Relavent = entity.Relavent,
        Role = entity.Role,
        LogoUri = entity.LogoUri
    };
    
    public static WorkExperienceIncludedDTO ToIncludedDto(this WorkExperienceEntity entity) => new WorkExperienceIncludedDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Relavent = entity.Relavent,
        Role = entity.Role,
        LogoUri = entity.LogoUri,
        Categories = entity.Categories?.Select(c => c.ToDto()).ToList(), 
        Certifications = entity.Certifications?.Select(c => c.ToDto()).ToList(), 
        AsociatedSkills = entity.AsociatedSkills?.Select(s => s.ToDto()).ToList(), 
        ConnectedCompanies = entity.ConnectedCompanies?.Select(c => c.ToDto()).ToList()
    };
}