using Backend.API.Entities.Interface;

namespace Backend.API.AbstractClasses;

public class BaseDto : IDto
{
    /// <value><c>Id</c> sets the Id in entity framework></value>
    public int Id { get; set; }
    /// <value><c>Name</c> of the entity</value>
    /// <example>A name for a person could be "Jane" and for a company "Hello World Co" </example>
    public required string Name { get; set; }
}