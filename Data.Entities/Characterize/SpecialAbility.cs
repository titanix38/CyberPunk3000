using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.RelationManyToMany;

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
        public string Wording { get; set; }

        public string Alias { get; set; }
        /// <summary>
        /// Relationships
        /// </summary>
        //public ICollection<AttributeSpecialAbility> AttributeSpecialAbility { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<CharacterSpecialAbility> CharacterSpecialAbilities { get; set; }
    }
}
