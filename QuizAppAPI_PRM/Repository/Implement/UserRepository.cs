using Microsoft.EntityFrameworkCore;
using QuizAppAPI_PRM.Data;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Repository.Interface;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace QuizAppAPI_PRM.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null || password == null || user.Username != username || password != user.PasswordHash)
            {
                return null;
            }
            return user;
        }

        public async Task<User> CreateAsync(User user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.Users.Include(u => u.Role)
                .Include(u => u.Information)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            var existingUser = await db.Users
                .Include(u => u.Role)
                .Include(u => u.Information)
                .FirstOrDefaultAsync(u => u.UserId == userId);
            if (existingUser is null)
            {
                return null;
            }
            return existingUser;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var existingUser = await db.Users
                .Include(u => u.Role)
                .Include(u => u.Information)
                .FirstOrDefaultAsync(u => u.Username == username);
            if (existingUser is null)
            {
                return null;
            }
            return existingUser;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await db.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);
            if (existingUser is null)
            {
                return null;
            }
            db.Entry(existingUser).CurrentValues.SetValues(user);
            await db.SaveChangesAsync();
            return user;
        }

        public Task<bool> UsernameExistsAsync(string username)
        {
            var exists = db.Users.AnyAsync(u => u.Username == username);
            return exists;
        }
    }
}
