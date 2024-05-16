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
    public IEnumerable<TDto> Get(bool included = true);
    /// <summary>
    /// Get data about specific entity
    /// </summary>
    /// <param name="id">Id for entity you want to get </param>
    /// <param name="included">If the DTO should include relational data</param>
    /// <returns></returns>
    public Task<TDto?> GetByIdAsync(int id, bool included = true);
    /// <summary>
    /// Creates entity and adds it to database
    /// </summary>
    /// <param name="createDto">DTO to create</param>
    /// <returns>Created entity as DTO</returns>
    public Task<TDto?> CreateAsync(TDto createDto);
    /// <summary>
    /// Updates Entity
    /// </summary>
    /// <param name="updateDto">Dto to update</param>
    /// <returns>Updated entity as DTO or null if entity wasn't updated</returns>
    public Task<TDto?> UpdateAsync(TDto updateDto);
    /// <summary>
    /// Deletes entity from database
    /// </summary>
    /// <param name="id">Id of entity to remove</param>
    /// <returns>True if deleted successfully and false if something went wrong</returns>
    public Task<bool> DeleteAsync(int id);
}