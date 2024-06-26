using System;
using System.Collections.Generic;

namespace Forum.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? LastName { get; set; }

    public string? EMail { get; set; }

    public int? PhoneNo { get; set; }
}
