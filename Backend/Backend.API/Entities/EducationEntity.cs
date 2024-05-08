using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

public class EducationEntity : BaseEntity
{
    public string? Description { get; set; }
    
    //TODO:Make sure DateOnly works or change to DateTime
    /// <summary>
    /// When you started your education
    /// </summary>
    public required DateOnly StartDate { get; set; }
    /// <summary>
    /// Estimated graduation date or the date you graduated/stopped the education
    /// </summary>
    public DateOnly? EndDate { get; set; }
    /// <summary>
    /// Is <c>True</c> if you are enrolled. False if you have graduated
    /// </summary>
    public bool? Enrolled { get; set; }
    /// <summary>
    /// local or remote logo for the education
    /// </summary>
    public string? LogoUri { get; set; }
    /// <summary>
    /// Skills associated with the education
    /// </summary>
    public ICollection<SkillEntity>? AsociatedSkills { get; set; }
    public ICollection<CertificationEntity>? Certifications { get; set; }
    public ICollection<CategoryEntity>? Categories  { get; set; }

}