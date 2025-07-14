namespace QuizAppAPI_PRM.Models.DTO
{
    public class AddSemesterRequestDTO
    {
        public Guid SubjectId { get; set; }

        public string? SemesterName { get; set; }
    }
}
