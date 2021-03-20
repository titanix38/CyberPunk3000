using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Cyber;
using Data.Entities.Person;

namespace Data.Entities.RelationManyToMany
{
    /// <summary>
    /// Weapon owned by character
    /// </summary>
    [Table("CharactersWeapons")]
    public class CharacterWeapon
    {
        [Key, Column(Order = 0)]
        public Guid IdCharacter { get; set; }
        public virtual Character Characters { get; set; }

        [Key, Column(Order = 1)]
        public int IdWeapon { get; set; }
        public virtual Weapon Weapons { get; set; }
    }
}
