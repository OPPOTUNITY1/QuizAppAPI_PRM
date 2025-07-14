namespace QuizAppAPI_PRM.Models.DTO
{
    public class UpdateSubjectRequestDTO
    {
        public string SubjectName { get; set; } = null!;

        public string SubjectDetail { get; set; } = null!;

        public string? UrlImage { get; set; }

        public string? VideoUrl { get; set; }

        public Guid UserId { get; set; }
    }
}
