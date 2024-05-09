using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;

namespace Backend.API.Extensions.Entities;

/// <summary>
/// Dividing entity model logic into their own class so entities only handles parameters
/// </summary>
public static class CategoryExtensions
{
    /// <returns>Entity converted to DTO with no relations</returns>
    public static CategoryDTO ToDto(this CategoryEntity entity) => new CategoryDTO
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Name,
    };

    /// <returns>Entity converted to DTO with relations</returns>
    public static CategoryIncludedDTO ToIncludedDto(this CategoryEntity entity)
    {
        CategoryIncludedDTO dto = new CategoryIncludedDTO
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Name,
            AsociatedSkills = entity.AsociatedSkills?.Select(s => s.ToDto()).ToList(),
            Educations = entity.Educations?.Select(e => e.ToDto()).ToList(),
            PersonalProjects = entity.PersonalProjects?.Select(p => p.ToDto()).ToList(),
            WorkExperiences = entity.WorkExperiences?.Select(w => w.ToDto()).ToList(),
            Certifications = entity.Certifications?.Select(c => c.ToDto()).ToList()
        };
        return dto;
    }
}