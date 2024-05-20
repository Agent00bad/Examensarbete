using Backend.API.DTOs.RelationsIncluded;
using Backend.API.Entities;
using Backend.API.Entities.Interface;

namespace Backend.API.Extensions.Entities;

/// <summary>
/// Dividing entity model logic into their own class so entities only handles parameters
/// </summary>
public static class AboutExtensions
{
    
    /// <returns>Entity converted to DTO</returns>
    public static AboutDTO ToDto(this AboutEntity entity)
    {
        AboutDTO dto = new AboutDTO
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Description = entity.Description,
            MiddleNames = entity.MiddleNames,
            BirthDate = entity.BirthDate,
            ImageUri = entity.ImageUri,
        };
        return dto;
    }
    public static AboutIncludedDTO ToIncludedDto(this AboutEntity entity) => new AboutIncludedDTO
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Description = entity.Description,
        MiddleNames = entity.MiddleNames,
        BirthDate = entity.BirthDate,
        ImageUri = entity.ImageUri,
        Languages = entity.Languages?.Select(l => l.ToDto()).ToList(),
        Interests = entity.Interests?.Select(i => i.ToDto()).ToList(),
    };
    public static AboutEntity ToEntity(this AboutDTO dto) => new AboutEntity
    {
        Id = dto.Id,
        FirstName = dto.FirstName,
        LastName = dto.LastName,
        Description = dto.Description,
        MiddleNames = dto.MiddleNames,
        BirthDate = dto.BirthDate,
        ImageUri = dto.ImageUri,
    };
 }