using Data.Entities.Characterize;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.RelationManyToMany;

namespace Data.Entities.Enterprise
{
    [Table("Corporations")]
    public class Corporation : IModel<Corporation>
    {
        [Key]
        public int Id { get; set; }

        public IGrade Grade { get; set; }

        public string Wording { get; set; }

        public string Alias { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<CharacterResourceCorporation> CharacterResourceCorporations { get; set; }
        public bool IsGang { get; set; }
        public string Color { get; set; }


    }
}
