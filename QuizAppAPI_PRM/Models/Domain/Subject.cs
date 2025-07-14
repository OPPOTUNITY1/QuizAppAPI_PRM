using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.Domain;

public partial class Subject
{
    [Key]
    public Guid SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public string SubjectDetail { get; set; } = null!;

    public string? UrlImage { get; set; }

    public string? VideoUrl { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }

    public virtual ICollection<Semester> Semesters { get; set; } = new List<Semester>();

    public virtual User User { get; set; } = null!;
}
