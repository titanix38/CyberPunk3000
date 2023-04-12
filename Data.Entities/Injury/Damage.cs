using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Injury
{
    [Table("Damages")]
    public class Damage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDamage { get; set; }
        public string Wording { get; set; }

        public int Penalty { get; set; }
        public int Factor { get; set; }
        public int BlackOut { get; set; }

    }
}
