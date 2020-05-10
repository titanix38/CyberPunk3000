using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Enterprise
{
    public interface ICorporation
    {
        /// <summary>
        /// Columns
        /// </summary>
       
        int Id { get; set; }
        string Name { get; set; }

        bool IsGang { get; set; }

        string Color { get; set; }

        ICollection<Character> Characters { get; set; }

    }
}
