using Backend.API.Entities.Interface;
using Backend.API.Entities.RelationsIncluded;

namespace Backend.API.Interfaces;

public interface IRepository<TDto>
    where TDto : IDto
{
    /// <summary>
    /// Get all data about the entity from the database
    /// </summary>
    /// <param name="included"></param>
    /// <param name="includeded">If the DTO should include relational data</param>
    /// <returns></returns>
    public IEnumerable<SkillIncludedDTO> Get(bool included = true);
    /// <summary>
    /// Get data about specific entity
    /// </summary>
    /// <param name="id">Id for entity you want to get </param>
    /// <param name="included">If the DTO should include relational data</param>
    /// <returns></returns>
    public Task<SkillIncludedDTO?> GetById(int id, bool included = true);
    /// <summary>
    /// Creates entity and adds it to database
    /// </summary>
    /// <param name="createDto">DTO to create</param>
    /// <returns>Created entity as DTO</returns>
    public Task<TDto> Create(TDto createDto);
    /// <summary>
    /// Updates Entity
    /// </summary>
    /// <param name="updateDto">Dto to update</param>
    /// <returns>Updated entity as DTO or null if entity wasn't updated</returns>
    public Task<TDto?> Update(TDto updateDto);
    /// <summary>
    /// Deletes entity from database
    /// </summary>
    /// <param name="id">Id of entity to remove</param>
    /// <returns>Copy of removed entity as DTO or null if entity wasn't deleted</returns>
    public Task<TDto?> Delete(int id);
}