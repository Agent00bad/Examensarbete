using Backend.API.AbstractClasses;
using Backend.API.Enums;

namespace Backend.API.Entities;
/// <summary>
/// Explains a personal project
/// <example>If you make a website you can write about it here and showcase that project and skills associated with it</example>
/// </summary>
public class PersonalProjectDTO : BaseDto
{
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
}