using AdminPanel.Frontend.Interfaces;

namespace Backend.API.Entities;
//TODO:Depending on how auth0 integration is made this might not be needed 
public class AdminModel : IModel
{
    public int Id { get; set; }
    /// <summary>
    /// The admins login email
    /// </summary>
    public required string Email { get; set; }
    /// <summary>
    /// admins password, will be hashed
    /// </summary>
    public required string Password { get; set; }
}