namespace QuizAppAPI_PRM.Models.DTO
{
    public class SemesterDTO
    {
        public Guid SemesterId { get; set; }

        public Guid SubjectId { get; set; }

        public string? SemesterName { get; set; }
    }
}
