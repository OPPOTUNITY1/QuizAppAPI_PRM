using Microsoft.EntityFrameworkCore;
using QuizAppAPI_PRM.Data;
using QuizAppAPI_PRM.Models.Domain;
using QuizAppAPI_PRM.Repository.Interface;

namespace QuizAppAPI_PRM.Repository.Implement
{
    public class InformationRepository : IInformationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public InformationRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Information> AddInformationAsync(Information information)
        {
            await dbContext.Informations.AddAsync(information);
            dbContext.SaveChanges();
            return information;
        }

        public async Task<Information> DeleteInformationAsync(Guid informationId)
        {
            var existingInformation = await dbContext.Informations.Include(x=> x.User).FirstOrDefaultAsync(x=> x.InfoId == informationId);
            if(existingInformation is null)
            {
                return null;
            }
            dbContext.Remove(existingInformation);
            await dbContext.SaveChangesAsync();
            return existingInformation; 
        }

        public async Task<IEnumerable<Information>> GetAllInformationsAsync()
        {
            return await dbContext.Informations.Include(x => x.User).ToListAsync();
        }

        public async Task<Information> GetInformationByIdAsync(Guid id)
        {
            var existingInformation = await dbContext.Informations.Include(x => x.User).FirstOrDefaultAsync(x => x.InfoId == id);
            if (existingInformation is null)
            {
                return null;
            }
            return existingInformation;
        }

        public async Task<Information> GetInformationByUserIdAsync(Guid id)
        {
            var existingInformation = await dbContext.Informations.Include(x => x.User).FirstOrDefaultAsync(x => x.UserId == id);
            if (existingInformation is null)
            {
                return null;
            }
            return existingInformation;
        }

        public async Task<Information> UpdateInformationAsync(Information information)
        {
            var existingInformation = await dbContext.Informations.Include(x=> x.User).FirstOrDefaultAsync(x => x.InfoId == information.InfoId);
            if (existingInformation is null)
            {
                return null;
            }
            dbContext.Informations.Entry(existingInformation).CurrentValues.SetValues(information);
            await dbContext.SaveChangesAsync();
            return information;

        }
    }
}
