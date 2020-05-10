using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Patent
{
    public class Patent : IPatent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Empathy { get; set; }
        public string Description { get; set; }      
        public string SecondEffect { get; set; }
        public decimal ChanceToDie { get; set; }
        public decimal ChanceToBeMad { get; set; }
    }
}
