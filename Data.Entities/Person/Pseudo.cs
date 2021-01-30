using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.RelationManyToMany;

namespace Data.Entities.Person
{
    public class Pseudo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdPseudo { get; set; }

        public string Name { get; set; }

        public ICollection<CharacterPseudo> CharacterPseudos { get; set; }

    }
}
