using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Person
{
    public interface ICharacter
    {
        int IdCharactere { get; set; }
        string FirstName { get; set; }

        string LastName { get; set; }

        EnumGender Gender { get; set; }

        bool Alive { get; set; }

    }

}
