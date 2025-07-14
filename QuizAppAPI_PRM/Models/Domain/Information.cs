using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.Domain;

public partial class Information
{
    [Key]
    public Guid InfoId { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? UrlImage { get; set; }

    public virtual User User { get; set; } = null!;
}
