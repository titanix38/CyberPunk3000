using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Person;
using Data.Entities.Possession;

namespace Data.Entities.RelationManyToMany
{
    public class PeopleProperties
    {
        public int IdCharacter { get; set; }
        public Character Character { get; set; }

        public int IdFeature { get; set; }
        public Property Property { get; set; }

    }
}
