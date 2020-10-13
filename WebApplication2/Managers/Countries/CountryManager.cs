using CountryProject.Storage;
using CountryProject.Storage.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//gjndfdsbfdsb
namespace CountryProject.Managers.Countries
{
    public class CountryManager : ICountryManager
    {
        private readonly CountryDataContext _dbContext;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CountryManager(CountryDataContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<Country> AddCountry(Country country)
        {
           
            var cntry = _dbContext.countries.Add(country);
            await _dbContext.SaveChangesAsync();
            return cntry.Entity;
        }
        public async Task<IReadOnlyCollection<Country>> GetAll()
        {
            var query = _dbContext.countries.Include(st => st.faith).OrderBy(st => st.Name).AsNoTracking();

            var entities = await query.ToListAsync();

            return entities;
        }

        public async Task<Country> GetByID(Guid id)
        {
            Country country = await _dbContext.countries.Include(r => r.faith).Include(r => r.Polity).FirstOrDefaultAsync(u => u.Id == id);
            return country;
        }
        public async Task<Country> UpdateCountry(Country country)
        {
            var entity = await _dbContext.countries.FirstOrDefaultAsync(g => g.Id == country.Id);

            if(entity!=null)
            {
                entity.Name = country.Name;
                entity.Mainland = country.Mainland;
                entity.faith = country.faith;
                entity.Area = country.Area;
                entity.Polity = country.Polity;
            }

            await _dbContext.SaveChangesAsync();

            return entity;

        }

    }
}
