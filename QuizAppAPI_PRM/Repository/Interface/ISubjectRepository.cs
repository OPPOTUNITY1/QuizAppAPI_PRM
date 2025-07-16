using Microsoft.AspNetCore.Mvc;
using QuizAppAPI_PRM.Models.Domain;

namespace QuizAppAPI_PRM.Repository.Interface
{
    public interface ISubjectRepository
    {
        Task<Subject> GetSubjectByNameAsync(string name);
        Task<IEnumerable<Subject>> GetAllSubjectAsync();
        Task<IEnumerable<Subject>> GetAllSubjectByTeacherAsync(Guid teacherId);
        Task<Subject> GetSubjectByIdAsync(Guid id);
        Task<Subject> AddSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(Subject subject);
        Task<Subject> DeleteSubjectAsync(Guid subjectId);
    }
}
