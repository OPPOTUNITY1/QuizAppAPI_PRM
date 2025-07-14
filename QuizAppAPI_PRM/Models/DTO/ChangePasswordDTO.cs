namespace QuizAppAPI_PRM.Models.DTO
{
    public class ChangePasswordDTO
    {
        public string Username { get; set; } = null!;
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
