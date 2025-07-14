using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.DTO
{
    public class QuestionDTO
    {
        public Guid QuestionId { get; set; }
        public Guid SemesterId { get; set; }
        public string Content { get; set; } = null!;
    }
}
