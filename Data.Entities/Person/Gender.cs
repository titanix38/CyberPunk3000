using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Person
{
    [Table("Genders")]
    public class Gender : IModel<Gender>
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
        public virtual ICollection<Character> Characters { get; set; }

    }
}
