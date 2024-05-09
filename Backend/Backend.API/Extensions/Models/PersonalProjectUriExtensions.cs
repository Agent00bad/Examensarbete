using Backend.API.Entities;

namespace Backend.API.Extensions.Entities;

public static class PersonalProjectUriExtensions
{
    /// <returns>Entity converted to DTO</returns>
    public static PersonalProjectUriDTO ToDto(this PersonalProjectUriEntity entity) => new PersonalProjectUriDTO()
    {
        Id = entity.Id,
        Uri = entity.Uri,
        PersonalProject = entity.PersonalProject.ToDto(),
    };
}