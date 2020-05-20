using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Characterize
{
    [Table("SpecialAbilities")]
    public class SpecialAbility : IModel<SpecialAbility>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        //public ICollection<AttributeSpecialAbility> AttributeSpecialAbility { get; set; }
        public ICollection<Skill> Skills { get; set; }

    }
}
