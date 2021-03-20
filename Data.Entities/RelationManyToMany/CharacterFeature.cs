using Data.Entities.Characterize;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.RelationManyToMany
{
    [Table("CharacterFeatures")]
    public class CharacterFeature
    {
        [Key, Column(Order = 0)]
        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [Key, Column(Order = 1)]
        public int IdFeature { get; set; }
        public virtual Feature Features { get; set; }

        public int Value { get; set; }
    }
}
