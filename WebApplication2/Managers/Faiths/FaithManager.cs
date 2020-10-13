using CountryProject.Storage;
using CountryProject.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Managers.Faiths
{
    public class FaithManager : IFaithManager
    {
        private readonly CountryDataContext _dbContext;

        public FaithManager(CountryDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Faith> AddFaith(Faith faith)
        {
            
            var ft = _dbContext.faiths.Add(faith);
            await _dbContext.SaveChangesAsync();
            return ft.Entity;
        }

        public async Task<Faith> GetFaithByName(string Name)
        {
            Faith faith = await _dbContext.faiths.FirstOrDefaultAsync(u => u.Name == Name);
            return faith;
        }

        public async Task<Faith> UpdateFaith(Guid id,  Faith faith)
        {
            var entity = await _dbContext.faiths.FirstOrDefaultAsync(g => g.Id == id);

            if(entity!=null)
            {
                entity.Name = faith.Name;
            }

            await _dbContext.SaveChangesAsync();

            return entity;

        }
        public async Task<IReadOnlyCollection<Faith>> GetAll()
        {
            var query = _dbContext.faiths.AsNoTracking();

            var entities = await query.ToListAsync();

            return entities;
        }

        public async Task<Faith> GetByID(Guid id)
        {
            return await _dbContext.faiths.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Faith> RemoveFaith(Guid Id)
        {
            var entity = await _dbContext.faiths.FirstOrDefaultAsync(u => u.Id == Id);
            
            if (entity!=null)
            {
                _dbContext.Entry(entity).Collection(c => c.Country).Load();
                _dbContext.faiths.Remove(entity);

               
            }

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
