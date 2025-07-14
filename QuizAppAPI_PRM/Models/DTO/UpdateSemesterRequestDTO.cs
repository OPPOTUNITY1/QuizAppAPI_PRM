namespace QuizAppAPI_PRM.Models.DTO
{
    public class UpdateSemesterRequestDTO
    {
        public Guid SubjectId { get; set; }

        public string? SemesterName { get; set; }
    }
}
