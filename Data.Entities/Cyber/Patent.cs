using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Cyber
{
    [Table("Patents")]
    public class Patent : IModel<Patent>
    {
        [Key]
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }
        public int Price { get; set; }
        public int Empathy { get; set; }
        public string Description { get; set; }      
        public string SecondEffect { get; set; }
        public decimal ChanceToDie { get; set; }
        public decimal ChanceToBeMad { get; set; }

        public int? IdFeature { get; set; }

        public virtual Feature Feature { get; set; }

    }
}
