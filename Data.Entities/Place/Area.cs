using Data.Entities.Person;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.RelationManyToMany;

namespace Data.Entities.Place
{
    [Table("Areas")]
    public class Area : IModel<Area>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }

        public int IdCity { get; set; }

        public int Safety { get; set; }

        public virtual City City { get; set; }
        public ICollection<CharacterArea> CharacterAreas { get; set; }
        
    }
}
