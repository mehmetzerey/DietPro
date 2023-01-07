﻿namespace Identity.Domain.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
}
