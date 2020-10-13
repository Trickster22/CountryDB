using CountryProject.Storage.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Storage
{
    public class CountryDataContext:DbContext
    {
        public CountryDataContext(DbContextOptions<CountryDataContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Country> countries { get; set; }
        public DbSet<Faith> faiths { get; set; }

        public DbSet<Polity> polities { get; set; }
    }

    
}
