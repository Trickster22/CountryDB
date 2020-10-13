using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CountryProject.Storage
{
   public interface IUniqueID
    {
        [Key]
        [Required]
        [Column("gID")]
        public Guid Id { get; set; }
    }
}
