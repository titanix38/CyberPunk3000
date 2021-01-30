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
    public class CharacterResourceCorporation
    {
        [Key]
        public int IdCharacter { get; set; }
        public Character Character { get; set; }
        [Key]
        public int IdArea { get; set; }
        public Corporation Corporations { get; set; }
        public int Value { get; set; }
    }
}
