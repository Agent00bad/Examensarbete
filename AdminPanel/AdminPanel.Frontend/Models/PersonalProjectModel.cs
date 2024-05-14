using AdminPanel.Frontend.Interfaces;
using Backend.API.Enums;

namespace Backend.API.Entities;
/// <summary>
/// Explains a personal project
/// <example>If you make a website you can write about it here and showcase that project and skills associated with it</example>
/// </summary>
public class PersonalProjectModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// General description of the project
    /// </summary>
    public required string Description { get; set; }
    /// <summary>
    /// Indepth description/documentation of the project
    /// </summary>
    public string? Documentation { get; set; }
    /// <summary>
    /// In what status a project is using the <c>PersonalProjectStatus enum</c>
    /// </summary>
    public PersonalProjectStatus Status { get; set; }
    /// <summary>
    /// Collection of project uris like external sites project sites and so on
    /// </summary>
    public ICollection<PersonalProjectUriModel>? ProjectUri { get; set; }
    /// <summary>
    /// Skills associated with the project
    /// </summary>
    public ICollection<SkillModel>? AsociatedSkills { get; set; }
    public ICollection<CategoryModel>? Categories { get; set; }
}