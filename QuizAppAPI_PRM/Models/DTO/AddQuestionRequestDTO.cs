namespace QuizAppAPI_PRM.Models.DTO
{
    public class AddQuestionRequestDTO
    {
        public Guid SemesterId { get; set; }
        public string Content { get; set; } = null!;
    }
}
