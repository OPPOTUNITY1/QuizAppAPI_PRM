using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.Domain;

public partial class User
{
    [Key]
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
    [ForeignKey("Role")]
    public Guid RoleId { get; set; }

    public virtual Information? Information { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
