using Backend.API.AbstractClasses;

namespace Backend.API.Entities;

public class InterestEntity : BaseEntity
{
    public string? Description { get; set; }
    public required AboutEntity Person { get; set; }
}