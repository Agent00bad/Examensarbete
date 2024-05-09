using System.ComponentModel.DataAnnotations.Schema;
using Backend.API.Entities.Interface;

namespace Backend.API.Entities;

public class PersonalProjectUriDTO : IDto
{
    public int Id { get; set; }
    public string Uri { get; set; }
    public PersonalProjectDTO PersonalProject {get; set; }
}