using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Place;

namespace Data.Entities.RelationManyToMany
{
    /// <summary>
    /// Knowledge of an area
    /// </summary>
    [Table("CharacterAreas")]
    public class CharacterArea
    {
        [Key, Column(Order = 0)]
        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [Key, Column(Order = 1)]
        public int IdArea { get; set; }
        public virtual Area Areas { get; set; }

        public int Value { get; set; }
    }
}
