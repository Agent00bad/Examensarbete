using Backend.API.Entities;

namespace Backend.API.Extensions.Entities;

public static class InterestExtensions
{
    /// <returns>Entity converted to DTO with no relations</returns>
    public static InterestDTO ToDto(this InterestEntity entity) => new InterestDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Person = entity.Person.ToDto(),
    };

    public static InterestEntity ToEntity(this InterestDTO dto) => new InterestEntity()
    {
        Id = dto.Id,
        Name = dto.Name,
        Description = dto.Description,
        Person = dto.Person.ToEntity(),
    };
}