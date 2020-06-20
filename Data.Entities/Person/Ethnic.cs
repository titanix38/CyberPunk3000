using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Person
{
    [Table("Ethnics")]
    public class Ethnic : IModel<Ethnic>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Alias { get; set; }

        public string Description { get; set; }
        /// <summary>
        /// Relationships
        /// </summary>
        public virtual ICollection<Character> Characters { get; set; }

    }
}
