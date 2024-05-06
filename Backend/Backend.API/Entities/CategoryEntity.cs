using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

/// <summary>
/// optional category entity for grouping diffirent things together
/// <example>If you have programming skills you might want them to be under the programming category and so on</example>
/// </summary>
public class CategoryEntity : BaseEntity
{
    //TODO: if implemented, flesh it out or remove categories depending on how far i get
    public string? Description { get; set; }
    public ICollection<SkillEntity>? AsociatedSkills { get; set; }
}