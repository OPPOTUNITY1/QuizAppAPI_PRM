namespace QuizAppAPI_PRM.Models.DTO
{
    public class AddUserRequestDTO
    {

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
        public Guid RoleId { get; set; }
    }
}
