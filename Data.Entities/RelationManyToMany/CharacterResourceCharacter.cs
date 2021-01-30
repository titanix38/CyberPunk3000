using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Enterprise;

namespace Data.Entities.RelationManyToMany
{
    public class CharacterResourceCharacter
    {
        [Key]
        public int IdCharacter { get; set; }
        public Character People { get; set; }
        [Key]
        public int IdOtherCharacter { get; set; }
        public Character OtherPeople { get; set; }
        public int Value { get; set; }
    }
}
