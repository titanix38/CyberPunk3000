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

namespace ViewModel
{
    public abstract class ViewModelBase : IViewModelBase, INotifyPropertyChanged
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
    }
}
