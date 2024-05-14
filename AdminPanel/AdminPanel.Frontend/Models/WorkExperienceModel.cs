
using AdminPanel.Frontend.Interfaces;

namespace Backend.API.Entities;

public class WorkExperienceModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// The date you started working at the company/started the company
    /// </summary>
    public required DateOnly StartDate { get; set; }
    /// <summary>
    /// The date you stoped working at the company
    /// </summary>
    public DateOnly? EndDate { get; set; }
    /// <summary>
    /// Is this company/work relevant to the positions you are looking for? Then set this to true
    /// </summary>
    public required bool Relavent { get; set; }
    /// <summary>
    /// Describe your work at the company
    /// </summary>
    public required string Description { get; set; }
    /// <summary>
    /// Your official role at the company
    /// </summary>
    public string? Role { get; set; }
    /// <summary>
    /// Company logo uri. Can be remote or locally stored
    /// </summary>
    public string? LogoUri { get; set; }
    public ICollection<SkillModel>? AsociatedSkills { get; set; }
    
    public ICollection<ConnectedCompanyModel>? ConnectedCompanies { get; set; } 
    
    public ICollection<CertificationModel>? Certifications { get; set; }
    public ICollection<CategoryModel>? Categories { get; set; }
}