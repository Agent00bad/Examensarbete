namespace Backend.API.Entities.RelationsIncluded;

public class PersonalProjectIncludedDTO : PersonalProjectDTO
{
    /// <summary>
    /// Collection of project uris like external sites project sites and so on
    /// </summary>
    public ICollection<PersonalProjectUriDTO>? ProjectUri { get; set; }
    /// <summary>
    /// Skills associated with the project
    /// </summary>
    public ICollection<SkillDTO>? AsociatedSkills { get; set; }
    public ICollection<CategoryDTO>? Categories { get; set; }
}