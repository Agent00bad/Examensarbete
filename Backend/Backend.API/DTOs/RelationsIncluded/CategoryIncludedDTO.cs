namespace Backend.API.Entities.RelationsIncluded;

public class CategoryIncludedDTO : CategoryDTO
{
    public ICollection<SkillDTO>? AsociatedSkills { get; set; }
    public ICollection<EducationDTO>? Educations { get; set; }
    public ICollection<WorkExperienceDTO>? WorkExperiences { get; set; }
    public ICollection<PersonalProjectDTO>? PersonalProjects { get; set; }
    public ICollection<CertificationDTO>? Certifications { get; set; }
}