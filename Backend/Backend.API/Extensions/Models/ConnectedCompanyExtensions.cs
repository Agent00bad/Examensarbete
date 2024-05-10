using Backend.API.Entities;

namespace Backend.API.Extensions.Entities;

public static  class ConnectedCompanyExtensions
{
    /// <returns>Entity converted to DTO</returns>
    public static ConnectedCompanyDTO ToDto(this ConnectedCompanyEntity entity) => new ConnectedCompanyDTO
    {
        Id = entity.Id,
        Description = entity.Description,
        Work = entity.Work.ToDto(),
        Name = entity.Name,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Role = entity.Role,
        LogoUri = entity.LogoUri
    };

    public static ConnectedCompanyEntity ToEntity(this ConnectedCompanyDTO dto) => new ConnectedCompanyEntity()
    {
        Id = dto.Id,
        Description = dto.Description,
        Work = dto.Work.ToEntity(),
        Name = dto.Name,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Role = dto.Role,
        LogoUri = dto.LogoUri
    };
}