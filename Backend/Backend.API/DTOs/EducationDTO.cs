using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

public class EducationDTO : BaseDto
{
    public string? Description { get; set; }
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
}