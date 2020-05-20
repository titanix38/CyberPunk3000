using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Enterprise
{
    public enum EnumCategory
    {
        Circle = 1,
        Triangle = 2,
        Star = 4
    }

    public interface IGrade
    {
        int Id { get; set; }
        string Category { get; set; }
        int Quantity { get; set; }
        int Resource { get; set; }
        int Salary { get; set; }

        ICollection<Character> Characters { get; set; }

    }
}
