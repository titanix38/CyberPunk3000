using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.RelationManyToMany;

namespace Data.Entities.Cyber
{
    [Table("Weapons")]
    public class Weapon : IModel<Weapon>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }
        public int? Magazine { get; set; }
        public int? Range { get; set; }
        public int AccuracyBonus { get; set; }
        public bool Silencer { get; set; }

        public int DamageMultiplier { get; set; }
        public int DamageBonus { get; set; }
        public int IdDice { get; set; }
        public int IdCategory { get; set; }
        public int IdConcealment { get; set; }
        public int IdPlace { get; set; }

        public virtual Dice Dice { get; set; }
        public virtual WeaponCategory WeaponCategory { get; set; }
        public virtual Concealment Concealment { get; set; }
        public virtual Place Place { get; set; }

        public ICollection<CharacterWeapon> CharacterWeapons { get; set; }


    }
}
