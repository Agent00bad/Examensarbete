using System.Collections;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Entities.Interface;

public interface IRepository<TEntity, TDto>
    where TDto : IDto
    where TEntity : IEntity
{
    /// <summary>
    /// Get's ecerything from the database
    /// </summary>
    /// <param name="includeded">If the DTO should include relational data</param>
    /// <returns></returns>
    public Task<IEnumerable<TDto>> Get(bool includeded = true);

    /// <summary>
    /// Lets you query what data to get from database
    /// </summary>
    /// <param name="expresion">Lambda expression for querying data gotten from database</param>
    /// <param name="included">If the DTO should include relational data</param>
    /// <returns></returns>
    public Task<IEnumerable<TDto>> QueryGet(Func<TEntity, bool> expresion, bool included = true);

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
    /// <returns>Updated entity as DTO</returns>
    public Task<TDto> Update(TDto updateDto);
    /// <summary>
    /// Deletes entity from database
    /// </summary>
    /// <param name="id">Id of entity to remove</param>
    /// <returns>Copy of removed entity as DTO</returns>
    public Task<TDto> Delete(int id);
}