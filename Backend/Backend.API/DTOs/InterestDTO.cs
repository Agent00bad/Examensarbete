using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

public class InterestDTO : BaseDto
{
    public string? Description { get; set; }
    public required AboutDTO Person { get; set; }

}