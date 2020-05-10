using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Characterize
{
    public interface ICharacteristic<TEntity> where TEntity : class
    {
        int Id { get; set; }
        string Name { get; set; }

    }
}
