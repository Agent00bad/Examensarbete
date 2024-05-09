namespace Backend.API.Entities.RelationsIncluded;

public class CertificationIncludedDTO : CertificationDTO
{
    /// <summary>
    /// Skills associated with the certification
    /// </summary>
    public ICollection<SkillDTO>? AsociatedSkills { get; set; }
    public ICollection<WorkExperienceDTO>? WorkExperiences { get; set; }
    public ICollection<EducationDTO>? Educations { get; set; }
    public ICollection<CategoryDTO>? Categories { get; set; }
}