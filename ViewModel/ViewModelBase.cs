using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Factory;
using Data.Entities;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public abstract class ViewModelBase<T> : IViewModelBase<T>, INotifyPropertyChanged where T : class, IModel<T>, new()
    {
        protected Factory _factory;
        protected const string JsonInitFile = @".\Input\CyberPunkInit.json";

        public event PropertyChangedEventHandler PropertyChanged;

        public string ErrorMessage { get; protected set; }

        public bool Success { get; protected set; }


        public List<string> GetNames<T>(T t)
        {
            throw new NotImplementedException();
        }
               

        ObservableCollection<T> IViewModelBase<T>.ParseListToObservable(List<T> entities)
        {
            ObservableCollection<T> observableItems = new ObservableCollection<T>();

            foreach (var entity in entities)
            {
                T t = new T()
                {
                    Id = entity.Id,
                    Alias = entity.Alias,
                    Wording = entity.Wording
                };
                observableItems.Add(t);

            }
            return observableItems;
        }
    }
}
