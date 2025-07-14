using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppAPI_PRM.Models.DTO
{
    public class InformationDTO
    {
        public Guid InfoId { get; set; }
        public Guid UserId { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string? UrlImage { get; set; }
    }
}
