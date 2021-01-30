using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Person
{
    public interface ICharacter
    {
        Guid IdCharactere { get; set; }
        string FirstName { get; set; }

        string LastName { get; set; }

        int IdGender { get; set; }

        bool Alive { get; set; }

    }

}
