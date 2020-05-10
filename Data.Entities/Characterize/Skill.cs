using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Characterize
{
    [Table("Skills")]
    public class Skill : ICharacteristic<Skill>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Factor { get; set; }
        public int IdFeature { get; set; }
        public int? IdSpecialAbility { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        public virtual Feature Feature { get; set; }
        public virtual SpecialAbility SpecialAbility { get; set; }
        //public ICollection<AttributeSkill> AttributeSkills { get; set; }

    }
}
