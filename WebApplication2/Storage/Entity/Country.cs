using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Storage.Entity
{
    public class Country
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

       [Required]
       public string Name { get; set; }
       public string Mainland { get; set; }
       public double Area { get; set; }


        public Guid? FaithId { get; set; }
        public  Faith faith { get; set; }

        public Guid? PolityId { get; set; }
        public  Polity Polity { get; set; }
    }
}
