using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.Domain;

public partial class Question
{
    [Key]
    public Guid QuestionId { get; set; }
    [ForeignKey("Semester")]
    public Guid SemesterId { get; set; }

    public string Content { get; set; } = null!;

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    public virtual Semester Semester { get; set; } = null!;
}
