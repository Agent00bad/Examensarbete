using Backend.API.Entities;

namespace Backend.API.Extensions.Entities;


/// <summary>
/// Dividing entity model logic into their own class so entities only handles parameters
/// </summary>
public  static class AdminExtensions
{
    /// <returns>Entity converted to DTO</returns>
    public static AdminDTO ToDto(this AdminEntity entity)
    {
        AdminDTO dto = new AdminDTO
        {
            Id = entity.Id,
            Email = entity.Email,
            Password = entity.Password
        };
        return dto;
    }
}