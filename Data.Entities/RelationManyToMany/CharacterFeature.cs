using Data.Entities.Characterize;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.RelationManyToMany
{
    public class CharacterFeature
    {
        [Key]
        public int IdCharacter { get; set; }
        public Character Character { get; set; }
        [Key]
        public int IdFeature { get; set; }
        public Feature Feature { get; set; }

        public int Value { get; set; }
    }
}
