using CountryProject.Storage;
using CountryProject.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Managers.Polities
{
    public class PolityManager:IPolityManager
    {
        private readonly CountryDataContext _dbContext;
        public PolityManager(CountryDataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyCollection<Polity>> GetAll()
        {
            var query = _dbContext.polities.AsNoTracking();

            var entities = await query.ToListAsync();

            return entities;
        }
        public async Task<Polity> GetByID(Guid id)
        {
            return await _dbContext.polities.FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<Polity> GetPolityByName(string Name)
        {
            Polity polity = await _dbContext.polities.FirstOrDefaultAsync(u => u.Name == Name) ;
            return polity;
        }
        public async Task<Polity> AddPolity(Polity polity)
        {

            var pt = _dbContext.polities.Add(polity);
            await _dbContext.SaveChangesAsync();
            return pt.Entity;
        }
    }
}
