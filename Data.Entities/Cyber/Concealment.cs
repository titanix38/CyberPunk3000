using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Cyber
{
    /// <summary>
    /// Body part which could hide the weapon (e.g. Pocket, Jacket, Long coat, Unconcealable)
    /// </summary>
    [Table("Concealments")]
    public class Concealment : IModel<Concealment>
    {
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
    }
}
