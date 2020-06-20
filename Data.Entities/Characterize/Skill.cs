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
    public class Skill : IModel<Skill>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int Factor { get; set; }
        //[ForeignKey("Feature")]
        public int IdFeature { get; set; }
        //[ForeignKey("SpecialAbility")]
        public int? IdSpecialAbility { get; set; }
        /// <summary>
        /// Relationships
        /// </summary>
        public virtual Feature Feature { get; set; }
        public virtual SpecialAbility SpecialAbility { get; set; }
        //public ICollection<AttributeSkill> AttributeSkills { get; set; }

    }
}
