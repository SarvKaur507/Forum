using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models;

public partial class User
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    [Required]
    [Display(Name = "User Name")]
    public string Username { get; set; } = null!;
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;
    [Required]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    [Required]
    [EmailAddress]
    [Display(Name = "EMail")]
    public string? EMail { get; set; }
    [Required]
    [Display(Name = "Phone No")]
    public int? PhoneNo { get; set; } = null;

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }
}
