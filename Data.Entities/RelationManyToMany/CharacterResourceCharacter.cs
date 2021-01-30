using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Enterprise;

namespace Data.Entities.RelationManyToMany
{
    public class CharacterResourceCharacter
    {
        [ForeignKey("IdCharacter"), Column(Order = 0)]
        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [ForeignKey("IdOtherCharacters"), Column(Order = 1)]
        public Guid IdOtherCharacter { get; set; }
        public virtual Character OtherCharacters { get; set; }

        public int Value { get; set; }
    }
}
