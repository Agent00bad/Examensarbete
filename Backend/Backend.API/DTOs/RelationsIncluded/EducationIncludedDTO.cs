namespace Backend.API.Entities.RelationsIncluded;

public class EducationIncludedDTO : EducationDTO
{
    /// <summary>
    /// Skills associated with the education
    /// </summary>
    public ICollection<SkillDTO>? AsociatedSkills { get; set; }
    public ICollection<CertificationDTO>? Certifications { get; set; }
    public ICollection<CategoryDTO>? Categories  { get; set; }
}