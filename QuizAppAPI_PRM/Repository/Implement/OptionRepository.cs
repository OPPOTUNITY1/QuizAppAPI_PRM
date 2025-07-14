using Microsoft.EntityFrameworkCore;
using QuizAppAPI_PRM.Data;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Repository.Implement
{
    public class OptionRepository : IOptionRepository
    {
        private readonly ApplicationDbContext db;

        public OptionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Option> CreateOptionAsync(Option option)
        {
            await db.Options.AddAsync(option);
            db.SaveChangesAsync();
            return option;
        }

        public async Task<Option> DeleteOptionAsync(Guid optionId)
        {
            var existingopstion  = await db.Options.FirstOrDefaultAsync(o => o.OptionId == optionId);
            if(existingopstion is null)
            {
                return null;
            }
            db.Options.Remove(existingopstion);
            await db.SaveChangesAsync();
            return existingopstion;
        }

        public async Task<IEnumerable<Option>> GetAllOptionByQuestionIAsync(Guid questionId)
        {
            var exsitingOptions = await db.Options.Where(o => o.QuestionId == questionId)
                .Include(o => o.Question)
                .ToListAsync();
            if (exsitingOptions is null || !exsitingOptions.Any())
            {
                return null;
            }
            return exsitingOptions;
        }

        public Task<Option> GetOptionByIdAsync(Guid optionId)
        {
            var existingOption = db.Options
                .Include(o => o.Question)
                .FirstOrDefaultAsync(o => o.OptionId == optionId);
            if (existingOption is null)
            {
                return null;
            }
            return existingOption;
        }

        public async Task<Option> UpdateOptionAsync(Option option)
        {
            var existingOption = db.Options.FirstOrDefaultAsync(o => o.OptionId == option.OptionId);
            if (existingOption is null)
            {
                return null;
            }
            db.Entry(existingOption).CurrentValues.SetValues(option);
            await db.SaveChangesAsync();
            return option;
        }
    }
}
