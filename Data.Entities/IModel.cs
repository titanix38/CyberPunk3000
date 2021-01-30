using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public interface IModel<TEntity> where TEntity : class
    {
        int Id { get; set; }
        /// <summary>
        /// Wording : display in GUI
        /// </summary>
        string Wording { get; set; }

        /// <summary>
        /// Alias : for build item
        /// </summary>
        string Alias { get; set; }
    }
}
