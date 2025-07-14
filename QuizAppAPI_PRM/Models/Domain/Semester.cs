using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.Domain;

public partial class Semester
{
    [Key]
    public Guid SemesterId { get; set; }
    [ForeignKey("Subject")]
    public Guid SubjectId { get; set; }

    public string? SemesterName { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual Subject Subject { get; set; } = null!;
}
