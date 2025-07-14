namespace QuizAppAPI_PRM.Models.DTO
{
    public class AddOptionRequestDTO
    {
        public Guid QuestionId { get; set; }

        public string Content { get; set; } = null!;

        public bool IsCorrect { get; set; }
    }
}
