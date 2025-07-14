using QuizAppAPI_PRM.Models.Domain;

namespace QuizAppAPI_PRM.Repository.Interface
{
    public interface IInformationRepository
    {
        Task<Information> GetInformationByUserIdAsync(Guid id);
        Task<IEnumerable<Information>> GetAllInformationsAsync();
        Task<Information> GetInformationByIdAsync(Guid id);
        Task<Information> AddInformationAsync(Information information);
        Task<Information> UpdateInformationAsync(Information information);
        Task<Information> DeleteInformationAsync(Guid informationId);
    }
}
