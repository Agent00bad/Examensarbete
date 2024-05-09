namespace Backend.API.Entities.RelationsIncluded;

public class WorkExperienceIncludedDTO : WorkExperienceDTO
{
    public ICollection<SkillDTO>? AsociatedSkills { get; set; }
    
    public ICollection<ConnectedCompanyDTO>? ConnectedCompanies { get; set; } 
    
    public ICollection<CertificationDTO>? Certifications { get; set; }
    public ICollection<CategoryDTO>? Categories { get; set; }
}