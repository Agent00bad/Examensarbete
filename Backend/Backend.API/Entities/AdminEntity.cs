﻿using Backend.API.AbstractClasses;
using Backend.API.Entities.Interface;

namespace Backend.API.Entities;
//TODO:Depending on how auth0 integration is made this might not be needed 
public class AdminEntity : IEntity 
{
    public Guid Id { get; set; }
    /// <summary>
    /// The admins login email
    /// </summary>
    public required string Email { get; set; }
    /// <summary>
    /// admins password, will be hashed
    /// </summary>
    public required string Password { get; set; }
}