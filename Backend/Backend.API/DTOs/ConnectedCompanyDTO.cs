using System.ComponentModel.DataAnnotations.Schema;
using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

/// <summary>
/// Company connected to work, example is if you work as a consultant and hop between clients
/// </summary>
public class ConnectedCompanyDTO : BaseDto
{
    //TODO: Check if DateOnly works or change to DateTime
    /// <summary>
    /// The date you started working at the company/started the company
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// The date you stoped working at the company
    /// </summary>
    public DateOnly? EndDate { get; set; }

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

    /// <summary>
    /// Connection between this company and the workplace/work experience
    /// </summary>
    public required WorkExperienceDTO Work { get; set; }
}