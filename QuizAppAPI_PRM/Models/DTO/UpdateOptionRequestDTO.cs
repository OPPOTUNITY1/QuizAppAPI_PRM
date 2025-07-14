namespace QuizAppAPI_PRM.Models.DTO
{
    public class UpdateOptionRequestDTO
    {
        public Guid QuestionId { get; set; }

        public string Content { get; set; } = null!;

        public bool IsCorrect { get; set; }
    }
}
