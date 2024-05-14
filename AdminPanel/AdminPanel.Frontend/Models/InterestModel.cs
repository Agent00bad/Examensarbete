using AdminPanel.Frontend.Interfaces;

namespace Backend.API.Entities;

public class InterestModel : IModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public required AboutModel Person { get; set; }
}