using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Person;
using Data.Entities.Possession;

namespace Data.Entities.RelationManyToMany
{
    public class CharacterPseudo
    {
        [Key, Column(Order = 0)]

        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [Key, Column(Order = 1)]
        public Guid IdPseudo { get; set; }
        public virtual Pseudo Pseudos { get; set; }
    }
}
