using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Factory;
using Data.Entities;

namespace ViewModel
{
    public abstract class ViewModelBase : IViewModelBase
    {
        protected Factory _factory;
        protected const string JsonInitFile = @".\Input\CyberPunkInit.json";



        public string ErrorMessage { get; protected set; }

        public bool Success { get; protected set; }


        public List<string> GetNames<T>(T t)
        {
            throw new NotImplementedException();
        }
    }
}
