using CountryProject.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Managers.Countries
{
    public interface ICountryManager
    {
        Task<Country> AddCountry(Country country);
        Task<IReadOnlyCollection<Country>> GetAll();
        Task<Country> GetByID(Guid id);
        Task<Country> UpdateCountry(Country country);
    }


}
