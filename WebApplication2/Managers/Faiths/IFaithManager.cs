using CountryProject.Managers.Countries;
using CountryProject.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Managers.Faiths
{
    public interface IFaithManager
    {
        Task<IReadOnlyCollection<Faith>> GetAll();

        Task<Faith> AddFaith(Faith faith);

        Task<Faith> UpdateFaith(Guid id, Faith faith);
        Task<Faith> GetByID(Guid id);
        Task<Faith> GetFaithByName(string Name);
        Task<Faith> RemoveFaith(Guid Id);
    }
}
