using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Person
{
    public interface IEthnic
    {
        int IdEthnic { get; set; }

        string Name { get; set; }


        ICollection<Character> Characters { get; set; }
    }
}
