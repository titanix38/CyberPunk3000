using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.RelationManyToMany
{
    [Table("CharacterSpecialAbilities")]
    public class CharacterSpecialAbility
    {
        [Key, Column(Order = 0)]
        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [Key, Column(Order = 1)]
        public int IdSpecial { get; set; }
        public virtual SpecialAbility SpecialAbilities { get; set; }

        public int Value { get; set; }

        public int Point { get; set; }
    }
}
