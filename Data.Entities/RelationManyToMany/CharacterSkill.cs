using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;
using Data.Entities.Person;

namespace Data.Entities.RelationManyToMany
{
    public class CharacterSkill
    {
        [Key]
        public int IdCharacter { get; set; }
        [Key]
        public int IdSkill { get; set; }

        public Character Character { get; set; }

        public Skill Feature { get; set; }

        public int Value { get; set; }

        public int Point { get; set; }
    }
}
