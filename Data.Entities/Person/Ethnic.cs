using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Person
{
    [Table("Ethnics")]
    public class Ethnic : IEthnic
    {
        [Key]
        public int IdEthnic { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Character> Characters { get; set; }

    }
}
