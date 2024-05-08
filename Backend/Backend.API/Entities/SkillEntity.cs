using Backend.API.AbstractClasses;
using Backend.API.Enums;

namespace Backend.API.Entities;
/// <summary>
/// Aquired skill
/// <example>Examples of things to add as a skill are if you've learned a new programming language or to do backflips</example>
/// </summary>
public class SkillEntity : BaseEntity
{
    /// <summary>
    /// Optional description of skill
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// How good you are at the skill, using a <c>SkillLevel</c> <c>Enum</c>
    /// </summary>
    public SkillLevel? SkillLevel { get; set; }
    /// <summary>
    /// How relevent the skill are and therefore how prioritized it being shown should be
    /// </summary>
    public required SkillRelevance SkillRelevance { get; set; }
    /// <summary>
    /// Logo to use for skill, either remote uri or local
    /// <example>If you know python, you might want to use pythons logo for the skill</example>
    /// </summary>
    public string? LodoUri { get; set; }

    /// <summary>
    /// Associated Personal projects
    /// </summary>
    public ICollection<PersonalProjectEntity>? PersonalProjects { get; set; }
    /// <summary>
    /// Associated work places
    /// </summary>
    public ICollection<WorkExperienceEntity>? WorkPlaces { get; set; }
    /// <summary>
    /// Associated Categories
    /// </summary>
    public ICollection<CategoryEntity>? Categories { get; set; }
    /// <summary>
    /// Associated Educations
    /// </summary>
    public ICollection<EducationEntity>? Educations { get; set; }
    /// <summary>
    /// Associated Certifications
    /// </summary>
    public ICollection<CertificationEntity>? Certifications { get; set; }
}