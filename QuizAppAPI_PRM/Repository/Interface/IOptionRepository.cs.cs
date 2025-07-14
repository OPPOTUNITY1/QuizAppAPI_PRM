using QuizAppAPI_PRM.Models.Domain;

namespace QuizAppAPI_PRM.Repository.Interface
{
    public interface IOptionRepository
    {
        Task<IEnumerable<Option>> GetAllOptionByQuestionIAsync(Guid questionId);
        Task<Option> GetOptionByIdAsync(Guid optionId);
        Task<Option> CreateOptionAsync(Option option);
        Task<Option> UpdateOptionAsync(Option option);
        Task<Option> DeleteOptionAsync(Guid optionId);

    }
}
