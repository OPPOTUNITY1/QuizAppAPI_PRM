using QuizAppAPI_PRM.Models.Domain;

namespace QuizAppAPI_PRM.Repository.Interface
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestionsAsync(Guid semesterId);
        Task<Question> GetQuestionByIdAsync(Guid questionId);
        Task<Question> CreateQuestionAsync(Question question);
        Task<Question> UpdateQuestionAsync(Question question);
        Task<Question> DeleteQuestionAsync(Guid questionId);
    }
}
