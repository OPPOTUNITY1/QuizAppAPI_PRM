namespace QuizAppAPI_PRM.Models.DTO
{
    public class UpdateQuestionRequestDTO
    {
        public Guid SemesterId { get; set; }
        public string Content { get; set; } = null!;
    }
}
