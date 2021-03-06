using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Cyber
{
    [Table("Weapons")]
    public class Weapon : IModel<Weapon>
    {
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }
        public int Magazine { get; set; }
        public int Range { get; set; }
        public int AccuracyBonus { get; set; }
        public bool Silencer { get; set; }

        public int DamageMultiplier { get; set; }
        public int DamageBonus { get; set; }

        public int IdDice { get; set; }

        public int IdCategory { get; set; }

        public virtual Dice Dice { get; set; }


        public virtual CategoryWeapon Category { get; set; }

    }
}
