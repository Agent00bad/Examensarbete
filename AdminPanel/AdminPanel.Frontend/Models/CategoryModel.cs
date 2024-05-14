using AdminPanel.Frontend.Interfaces;

namespace Backend.API.Entities;

/// <summary>
/// optional category entity for grouping diffirent things together
/// <example>If you have programming skills you might want them to be under the programming category and so on</example>
/// </summary>
public class CategoryModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<SkillModel>? AsociatedSkills { get; set; }
    public ICollection<EducationModel>? Educations { get; set; }
    public ICollection<WorkExperienceModel>? WorkExperiences { get; set; }
    public ICollection<PersonalProjectModel>? PersonalProjects { get; set; }
    public ICollection<CertificationModel>? Certifications { get; set; }
}