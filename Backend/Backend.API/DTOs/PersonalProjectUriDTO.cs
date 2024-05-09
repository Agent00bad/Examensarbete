using System.ComponentModel.DataAnnotations.Schema;
using Backend.API.Entities.Interface;

namespace Backend.API.Entities;

public class PersonalProjectUriDTO : IDto
{
    public int Id { get; set; }
    public required string Uri { get; set; }
    public required PersonalProjectDTO PersonalProject {get; set; }
}