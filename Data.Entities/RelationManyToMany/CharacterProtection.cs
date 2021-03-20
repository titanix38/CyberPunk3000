using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;

namespace Data.Entities.RelationManyToMany
{
    [Table("CharacterProtections")]
    public class CharacterProtection
    {
        [Key, Column(Order = 0)]
        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [Key, Column(Order = 1)]
        public int IdProtection { get; set; }
        public virtual Protection Protections { get; set; }
    }
}
