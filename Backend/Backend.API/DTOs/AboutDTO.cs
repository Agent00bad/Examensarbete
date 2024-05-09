using Backend.API.AbstractClasses;
using Backend.API.Entities.Interface;

namespace Backend.API.Entities;

public class AboutDTO : IDto 
{
    public int Id { get; set; }
    /// <summary>
    /// The personsn first name
    /// </summary>
    public required string FirstName { get; set; }
    /// <summary>
    /// Persons last name
    /// </summary>
    public required string LastName { get; set; }
    /// <summary>
    /// A nullable string representing the persons middle names, put them all into on string.
    /// </summary>
    public string? MiddleNames { get; set; }
    /// <summary>
    /// The persons birthdate
    /// </summary>
    public DateOnly BirthDate { get; set; } //TODO:Check to see that EF and SQLServer support DateOnly or switch to DateTime
    /// <summary>
    /// nullable Description, used like a site cover letter, the person can describe themselves
    /// </summary>
    /// <returns></returns>
    public string? Description { get; set; }
    /// <summary>
    /// nullable image uri, could be to a locally saved image or an external one.
    /// </summary>
    public string? ImageUri { get; set; }
}