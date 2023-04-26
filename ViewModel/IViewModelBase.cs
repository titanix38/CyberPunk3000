using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Factory;
using Data.Entities;
using System.Collections.ObjectModel;

namespace ViewModel
{
    interface IViewModelBase<T> where T : class, IModel<T>, new()
    {
        List<string> GetNames<T>(T t);

        ObservableCollection<T> ParseListToObservable(List<T> entities);
    }
}
