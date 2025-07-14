using QuizAppAPI_PRM.Models.Domain;

namespace QuizAppAPI_PRM.Repository.Interface
{
    public interface ISemesterRepository
    {
        Task<IEnumerable<Semester>> GetSemesterBySubjectAsync(Guid id);
        Task<IEnumerable<Semester>> GetAllSemestersAsync();
        Task<Semester> GetSemesterByIdAsync(Guid id);
        Task<Semester> AddSemesterAsync(Semester semester);
        Task<Semester> UpdateSemesterAsync(Semester semester);
        Task<Semester> DeleteSemesterAsync(Guid semesterId);
    }
}
