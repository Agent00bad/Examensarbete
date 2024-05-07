using System.Runtime.CompilerServices;
using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

public class WorkExperienceEntity : BaseEntity
{
    //TODO: Check if DateOnly works or change to DateTime
    /// <summary>
    /// The date you started working at the company/started the company
    /// </summary>
    public DateOnly StartDate { get; set; }
    /// <summary>
    /// The date you stoped working at the company
    /// </summary>
    public DateOnly? EndDate { get; set; }
    /// <summary>
    /// Is this company/work relevant to the positions you are looking for? Then set this to true
    /// </summary>
    public bool Relavent { get; set; }
    /// <summary>
    /// Describe your work at the company
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Your official role at the company
    /// </summary>
    public string? Role { get; set; }
    /// <summary>
    /// Company logo uri. Can be remote or locally stored
    /// </summary>
    public string? LogoUri { get; set; }
    public ICollection<SkillEntity>? AsociatedSkills { get; set; }
    
    public ICollection<ConnectedCompanyEntity>? ConnectedCompany { get; set; } 
}