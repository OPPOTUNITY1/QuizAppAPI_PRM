namespace QuizAppAPI_PRM.Models.DTO
{
    public class LoginRequestDTO
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
