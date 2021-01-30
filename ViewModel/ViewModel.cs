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
    public class ViewModel : ViewModelBase
    {   
        public void InitDataBase()
        {
            string message = string.Empty;
            try
            {
                _factory = new Factory();
                string json = File.ReadAllText(JsonInitFile, Encoding.UTF8);
                dynamic datas = JsonConvert.DeserializeObject(json, typeof(object));
                _factory.SetDatasToDB(datas);
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
