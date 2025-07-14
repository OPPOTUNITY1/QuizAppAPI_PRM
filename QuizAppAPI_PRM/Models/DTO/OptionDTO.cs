using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.DTO
{
    public class OptionDTO
    {
        public Guid OptionId { get; set; }
        
        public Guid QuestionId { get; set; }

        public string Content { get; set; } = null!;

        public bool IsCorrect { get; set; }
    }
}
