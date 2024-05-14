using AdminPanel.Frontend.Interfaces;

namespace Backend.API.Entities;

public class EducationModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
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
    public ICollection<SkillModel>? AsociatedSkills { get; set; }
    public ICollection<CertificationModel>? Certifications { get; set; }
    public ICollection<CategoryModel>? Categories  { get; set; }

}