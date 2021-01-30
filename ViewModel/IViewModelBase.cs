using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Factory;

namespace ViewModel
{
    interface IViewModelBase
    {
        List<string> GetNames<T>(T t);
    }
}
