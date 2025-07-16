using Microsoft.EntityFrameworkCore;
using QuizAppAPI_PRM.Data;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Repository.Implement
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext db;

        public SubjectRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            await db.Subjects.AddAsync(subject);
            await db.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> DeleteSubjectAsync(Guid subjectId)
        {
            var subject = await db.Subjects.FirstOrDefaultAsync(s => s.SubjectId == subjectId);
            if ( subject is null)
            {
                return null;
            }
            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();
            return subject;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectAsync()
        {
            return await db.Subjects.ToListAsync();

        }

        public async Task<Subject> GetSubjectByIdAsync(Guid id)
        {
            var subject = await db.Subjects.FirstOrDefaultAsync(s => s.SubjectId == id);
            if (subject is null)
            {
                return null;
            }
            return subject;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectByTeacherAsync(Guid teacherId)
        {
            return await db.Subjects
                .Where(s => s.UserId == teacherId)
                .ToListAsync();
        }

        public async Task<Subject> GetSubjectByNameAsync(string name)
        {
            var subject = await db.Subjects.FirstOrDefaultAsync(s => s.SubjectName == name);
            if (subject is null)
            {
                return null;
            }
            return subject;
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            var existing = db.Subjects.FirstOrDefault(s => s.SubjectId == subject.SubjectId);
            if (existing is null)
            {
                return null;
            }
            db.Subjects.Entry(existing).CurrentValues.SetValues(subject);
            await db.SaveChangesAsync();
            return subject;

        }
    }
}
