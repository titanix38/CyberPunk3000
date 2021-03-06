using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Cyber
{
    [Table("Categories")]

    public class CategoryWeapon : IModel<CategoryWeapon>
    {
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias  { get; set; }

        public ICollection<Weapon> Weapons { get; set; }
    }
}
