using Backend.API.Entities;

namespace Backend.API.Extensions.Entities;

public static class LanguageExtensions
{
    /// <returns>Entity converted to DTO</returns>
    public static LanguageDTO ToDto(this LanguageEntity entity) => new LanguageDTO()
    {
        Id = entity.Id,
        Name = entity.Name,
        Level = entity.Level,
        Person = entity.Person.ToDto(),
    };
}