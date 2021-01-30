using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities.RelationManyToMany
{
    public class CharacterSpecialAbility
    {
        [Key]
        public int IdCharacter { get; set; }
        public Character Character { get; set; }
        [Key]
        public int IdSkill { get; set; }
        public SpecialAbility Feature { get; set; }

        public int Value { get; set; }

        public int Point { get; set; }
    }
}
