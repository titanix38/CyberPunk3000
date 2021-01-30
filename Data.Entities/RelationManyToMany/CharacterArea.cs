using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Place;

namespace Data.Entities.RelationManyToMany
{
    public class CharacterArea
    {
        [Key]
        public int IdCharacter { get; set; }
        public Character Character { get; set; }
        [Key]
        public int IdArea { get; set; }
        public Area Areas { get; set; }
        public int Value { get; set; }
    }
}
