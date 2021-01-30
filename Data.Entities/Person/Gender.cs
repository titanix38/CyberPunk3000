using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Person
{
    [Table("Genders")]
    public class Gender
    {  
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGender { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        public virtual ICollection<Character> Characters { get; set; }

    }
}
