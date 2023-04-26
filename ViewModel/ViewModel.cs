using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Factory;
using Newtonsoft.Json;

namespace ViewModel
{
    public class ViewModel
    {
        private dynamic _datas;
        private Factory _factory;
        private string _json;

        private string[] _initFiles = Directory.GetFiles((@".\Input")).Where(f => Path.GetExtension(f) == ".json").ToArray();

        public string[] InitFiles => _initFiles;
        public dynamic Datas => _datas;

        public string Json => _json;

        public string ErrorMessage { get; private set; }
        public bool Success { get; private set; }

        public void ExtractDatasFromInit()
        {
            string message = string.Empty;
            try
            {
                _factory = new Factory();

                foreach (var jsonFile in InitFiles)
                {
                    _json = File.ReadAllText(jsonFile, Encoding.UTF8);
                    _datas = JsonConvert.DeserializeObject(Json, typeof(object));
                    //_factory.SetDatasToDB(Datas);
                }

                //string json = File.ReadAllText(JsonInitFile, Encoding.UTF8);
                Success = true;
            }
            catch (Exception e)
            {
                if (e is ArgumentException)
                {
                    message = "Le fichier pour la lecture des données initiales est introuvable";
                }
                else if (e is FactoryException)
                {
                    message = "La base de donneés est inaccessibls";
                }
                else
                {
                    message = "Please send the log file by an email to creator's address";
                }
                ErrorMessage = "Oh ! Une erreur s'est produite : " + Environment.NewLine + message;
                Success = false;
            }
        }

        public int GetFeatureValue(string alias)
        {
            throw new NotImplementedException();
        }

    }
}
