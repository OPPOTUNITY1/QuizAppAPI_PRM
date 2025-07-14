using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.Domain;

public partial class Option
{
    [Key]
    public Guid OptionId { get; set; }
    [ForeignKey("Question")]
    public Guid QuestionId { get; set; }

    public string Content { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public virtual Question Question { get; set; } = null!;
}
