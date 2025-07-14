using Microsoft.EntityFrameworkCore;
using QuizAppAPI_PRM.Data;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Repository.Implement
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext db;

        public QuestionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Question> CreateQuestionAsync(Question question)
        {
            await db.Questions.AddAsync(question);
            await db.SaveChangesAsync();
            return question;
        }

        public async Task<Question> DeleteQuestionAsync(Guid questionId)
        {
            var question = await db.Questions.FirstOrDefaultAsync(q => q.QuestionId == questionId);
            if(question is null)
            {
                return null;
            }
            db.Questions.Remove(question);
            await db.SaveChangesAsync();
            return question;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync(Guid semesterId)
        {
            return await db.Questions
                .Where(q => q.SemesterId == semesterId)
                .Include(q => q.Semester)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(Guid questionId)
        {
            var question = await db.Questions
                .Include(q => q.Semester)
                .FirstOrDefaultAsync(q => q.QuestionId == questionId);
            if(question is null)
            {
                return null;
            }
            return question;
        }

        public async Task<Question> UpdateQuestionAsync(Question question)
        {
            var existingQuestion = await db.Questions.FirstOrDefaultAsync(q => q.QuestionId == question.QuestionId);
            if(existingQuestion is null)
            {
                return null;
            }
            db.Entry(existingQuestion).CurrentValues.SetValues(question);
            await db.SaveChangesAsync();
            return question;
        }
    }
}
