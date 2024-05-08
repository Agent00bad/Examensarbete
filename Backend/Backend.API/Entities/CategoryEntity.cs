using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

/// <summary>
/// optional category entity for grouping diffirent things together
/// <example>If you have programming skills you might want them to be under the programming category and so on</example>
/// </summary>
public class CategoryEntity : BaseEntity
{
    public string? Description { get; set; }
    public ICollection<SkillEntity>? AsociatedSkills { get; set; }
    public ICollection<EducationEntity>? Educations { get; set; }
    public ICollection<WorkExperienceEntity>? WorkExperiences { get; set; }
    public ICollection<PersonalProjectEntity>? PersonalProjects { get; set; }
    public ICollection<CertificationEntity>? Certifications { get; set; }
}