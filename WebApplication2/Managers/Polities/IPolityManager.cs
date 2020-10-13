using CountryProject.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Managers.Polities
{
   public interface IPolityManager
    {
        Task<IReadOnlyCollection<Polity>> GetAll();
        Task<Polity> GetByID(Guid id);
        Task<Polity> GetPolityByName(string Name);
        Task<Polity> AddPolity(Polity polity);
    }
}
