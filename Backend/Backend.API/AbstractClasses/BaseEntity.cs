using Backend.API.Entities.Interface;

namespace Backend.API.AbstractClasses;

/// <summary>
/// BaseEntity has a <c>Guid Id</c> and <c>string Name</c> properties in it and derives from the <c>IEntity</c> interface
/// </summary>
public class BaseEntity : IEntity
{
    /// <value><c>Id</c> sets the Id in entity framework></value>
    public int Id { get; set; }
    /// <value><c>Name</c> of the entity</value>
    /// <example>A name for a person could be "Jane" and for a company "Hello World Co" </example>
    public string Name { get; set; }
}