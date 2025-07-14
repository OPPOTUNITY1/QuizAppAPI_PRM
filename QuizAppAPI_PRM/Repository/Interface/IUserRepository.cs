using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Models.DTO;

namespace QuizAppAPI_PRM.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid userId);
        Task<User?> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(User user);
        Task<bool> UsernameExistsAsync(string username);
        Task<User?> AuthenticateAsync(string username, string password);
    }
}
