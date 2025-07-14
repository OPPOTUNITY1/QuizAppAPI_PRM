using QuizAppAPI_PRM.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
        public Guid RoleId { get; set; }
    }
}
