using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;
using Data.Entities.Person;

namespace Data.Entities.RelationManyToMany
{
    [Table("CharacterSkills")]
    public class CharacterSkill
    {
        [Key, Column(Order = 0)]
        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [Key, Column(Order = 1)]
        public int IdSkill { get; set; }
        public virtual Skill Skills { get; set; }

        public int Value { get; set; }

        public int Point { get; set; }
    }
}
