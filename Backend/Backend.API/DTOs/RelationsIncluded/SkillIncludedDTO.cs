namespace Backend.API.Entities.RelationsIncluded;

public class SkillIncludedDTO : SkillDTO
{
    
    /// <summary>
    /// Associated Personal projects
    /// </summary>
    public ICollection<PersonalProjectDTO>? PersonalProjects { get; set; }
    /// <summary>
    /// Associated work places
    /// </summary>
    public ICollection<WorkExperienceDTO>? WorkPlaces { get; set; }
    /// <summary>
    /// Associated Categories
    /// </summary>
    public ICollection<CategoryDTO>? Categories { get; set; }
    /// <summary>
    /// Associated Educations
    /// </summary>
    public ICollection<EducationDTO>? Educations { get; set; }
    /// <summary>
    /// Associated Certifications
    /// </summary>
    public ICollection<CertificationDTO>? Certifications { get; set; }
}