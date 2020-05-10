using Data.Entities.Person;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Place
{
    [Table("Areas")]
    public class Area : IPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdCity { get; set; }

        public int Safety { get; set; }

        public virtual City City { get; set; }
        public ICollection<Character> Characters { get; set; }

    }
}
