using AdminPanel.Frontend.Interfaces;

namespace Backend.API.Entities;

public class PersonalProjectUriModel : IModel
{
    public int Id { get; set; }
    public required string Uri { get; set; }
    public required PersonalProjectModel PersonalProject {get; set; }
}