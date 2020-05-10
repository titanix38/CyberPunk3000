using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Patent
{
    public interface IPatent
    {
        int Id { get; set; }
        string Name { get; set; }
        int Price { get; set; }
        string Description { get; set; }
        string SecondEffect { get; set; }
        decimal ChanceToDie { get; set; }
        decimal ChanceToBeMad { get; set; }       
    }
}
