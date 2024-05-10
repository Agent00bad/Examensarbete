using Backend.API.Entities;
using Backend.API.Entities.RelationsIncluded;

namespace Backend.API.Extensions.Entities;

public static class PersonalProjectExtensions
{
    /// <returns>Entity converted to DTO with no relations</returns>
    public static PersonalProjectDTO ToDto(this PersonalProjectEntity entity) => new PersonalProjectDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Documentation = entity.Documentation,
        Status = entity.Status
    };
    
    public static PersonalProjectIncludedDTO ToIncludedDto(this PersonalProjectEntity entity) => new PersonalProjectIncludedDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Documentation = entity.Documentation,
        Status = entity.Status,
        ProjectUri = entity.ProjectUri?.Select(p => p.ToDto()).ToList(), 
        Categories = entity.Categories?.Select(c => c.ToDto()).ToList(), 
        AsociatedSkills = entity.AsociatedSkills?.Select(s => s.ToDto()).ToList(),
    };

    public static PersonalProjectEntity ToEntity(this PersonalProjectDTO dto) => new PersonalProjectEntity()
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        Documentation = dto.Documentation,
        Status = dto.Status
    };
    public static PersonalProjectEntity ToEntity(this PersonalProjectIncludedDTO dto) => new PersonalProjectEntity()
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        Documentation = dto.Documentation,
        Status = dto.Status,
        ProjectUri = dto.ProjectUri?.Select(p => p.ToEntity()).ToList(), 
        Categories = dto.Categories?.Select(c => c.ToEntity()).ToList(), 
        AsociatedSkills = dto.AsociatedSkills?.Select(s => s.ToEntity()).ToList(),
    };
}