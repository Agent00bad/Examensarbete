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
    
    /// <returns>Entity converted to DTO with relations</returns>
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

    public static WorkExperienceEntity ToEntity(this WorkExperienceDTO dto) => new WorkExperienceEntity()
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Relavent = dto.Relavent,
        Role = dto.Role,
        LogoUri = dto.LogoUri
    };
    public static WorkExperienceEntity ToEntity(this WorkExperienceIncludedDTO dto) => new WorkExperienceEntity()
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Relavent = dto.Relavent,
        Role = dto.Role,
        LogoUri = dto.LogoUri,
        Categories = dto.Categories?.Select(c => c.ToEntity()).ToList(), 
        Certifications = dto.Certifications?.Select(c => c.ToEntity()).ToList(), 
        AsociatedSkills = dto.AsociatedSkills?.Select(s => s.ToEntity()).ToList(), 
        ConnectedCompanies = dto.ConnectedCompanies?.Select(c => c.ToEntity()).ToList()
    };
}