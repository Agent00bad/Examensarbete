using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

public class CertificationEntity : BaseEntity
{
    /// <summary>
    /// DEscription of certificate
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Image of the certification
    /// </summary>
    public string? ImageUri { get; set; }
    /// <summary>
    /// If you want to use a logo image for your certification
    /// <example>If you have a certification from CodeCademy you might want to use their logo</example>
    /// </summary>
    public string? LogoUri { get; set; }
    /// <summary>
    /// Exrternal Certification site, some sites provide certification links
    /// </summary>
    public string? CertificationUrl { get; set; }
    /// <summary>
    /// Skills associated with the certification
    /// </summary>
    public ICollection<SkillEntity>? AsociatedSkills { get; set; }

}