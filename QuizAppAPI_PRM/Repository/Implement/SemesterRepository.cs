using Microsoft.EntityFrameworkCore;
using QuizAppAPI_PRM.Repository.Interface;
using QuizAppAPI_PRM.Data;
using QuizAppAPI_PRM.Models.Domain;

namespace QuizAppAPI_PRM.Repository.Implement
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly ApplicationDbContext db;

        public SemesterRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Semester> AddSemesterAsync(Semester semester)
        {
            await db.Semesters.AddAsync(semester);
            await db.SaveChangesAsync();
            return semester;
        }

        public async Task<Semester> DeleteSemesterAsync(Guid semesterId)
        {
            var semester =await db.Semesters.FirstOrDefaultAsync(s => s.SemesterId == semesterId);
            if (semester is null)
            {
                return null;
            }
            db.Semesters.Remove(semester);
            await db.SaveChangesAsync();
            return semester;
        }

        public async Task<IEnumerable<Semester>> GetAllSemestersAsync()
        {
            return await db.Semesters.Include(s => s.Subject).ToListAsync();
        }

        public Task<Semester> GetSemesterByIdAsync(Guid id)
        {
            var semester = db.Semesters.Include(s => s.Subject).FirstOrDefaultAsync(s => s.SemesterId == id);
            if (semester is null)
            {
                return null;
            }
            return semester;
        }

        public async Task<IEnumerable<Semester>> GetSemesterBySubjectAsync(Guid id)
        {
            return await db.Semesters
                .Where(s => s.SubjectId == id)
                .Include(s => s.Subject)
                .ToListAsync();
        }

        public async Task<Semester> UpdateSemesterAsync(Semester semester)
        {
            var existingSemester = await db.Semesters.FirstOrDefaultAsync(s => s.SemesterId == semester.SemesterId);
            if (existingSemester is null)
            {
                return null;
            }
            db.Entry(existingSemester).CurrentValues.SetValues(semester);
            db.SaveChangesAsync();
            return semester;
        }
    }
}
