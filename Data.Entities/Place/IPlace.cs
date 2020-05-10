using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Place
{
    public interface IPlace
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}
