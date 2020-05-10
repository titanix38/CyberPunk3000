using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Characterize
{
    [Table("Features")]
    public class Feature : ICharacteristic<Feature>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]      
        public int Id { get; set; }        
        public string Name { get; set; }
        

        /// <summary>
        /// Relationships
        /// </summary>
        //public ICollection<AttributeFeature> AttributeFeatures { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }

}
