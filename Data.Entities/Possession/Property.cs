using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Place;
using Data.Entities.RelationManyToMany;

namespace Data.Entities.Possession
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProperty { get; set; } 

        public string Style { get; set; }
        public double Price { get; set; }

        public int IdArea { get; set; }
        public virtual Area Area { get; set; }

        public ICollection<CharacterProperty> CharacterProperties { get; set; }

    }
}
