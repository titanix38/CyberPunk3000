using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Cyber;

namespace Data.Entities
{
    [Table("Dices")]
    public class Dice
    {
        [Key]
        public int IdDice { get; set; }
        public int Face { get; set; }

        public int? Bonus { get; set; }
        public int? Malus { get; set; }

        public ICollection<Weapon> Weapons { get; set; }


    }
}
