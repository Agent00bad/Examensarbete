using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

/// <summary>
/// optional category entity for grouping diffirent things together
/// <example>If you have programming skills you might want them to be under the programming category and so on</example>
/// </summary>
public class CategoryDTO : BaseDto
{
    public string? Description { get; set; }
}