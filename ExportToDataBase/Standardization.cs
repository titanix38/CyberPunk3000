using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Cyber;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ExportToDataBase
{
    public static class Standardization
    {
        public static Dictionary<Type, string> DictionnaryStandards { get; private set; } = new Dictionary<Type, string>()
            {
                {typeof(Feature),"caracteristiques" },
                {typeof(Skill),"competences" },
                {typeof(SpecialAbility),"capacites_speciales" },
                {typeof(Corporation),"ressources" },
                {typeof(Patent),"brevets" }
            };

        private static Dictionary<string, string> GetStandard(string type)
        {
            string sesssion = @"^\[\w+\]|\[\w+\s\w+\]$";

            Dictionary<string, string> output = new Dictionary<string, string>();
            bool read = false;
            //^\[\w+\]|\[\w+\s\w+\]$
            using (var stream = File.OpenRead(@".\Config\Standard.ini"))
            {

                if (stream == null)
                {
                    throw new FileNotFoundException("Erreur : le fichier Standard.ini est manquant");
                }

                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = Regex.Replace(reader.ReadLine(), @"^\s+|\s+$", string.Empty);

                        // Ne prend pas en compte les lignes commençant par #
                        if (!Regex.IsMatch(line, @"^\s+#|^#") && !string.IsNullOrEmpty(line))
                        {
                            if (Regex.IsMatch(line, sesssion))
                            {
                                // Lecture du parametre entre crochet
                                if (line.Trim(new char[] { '[', ']' }).ToLower() == type.ToLower())
                                {
                                    read = true;
                                }
                                else
                                {
                                    read = false;
                                }
                            }
                            if (read && !Regex.IsMatch(line, @"^\["))
                            {
                                //line = Regex.Replace(line, @"\s+", string.Empty);
                                if (!line.Contains("="))
                                {
                                    throw new StandardException(string.Concat("Erreur : Format incorrect :",
                                        Environment.NewLine,
                                        "\"KEY\"=\"VALUE\""));
                                }

                                string[] item = line.Split('=');
                                string key = GetCleanValue(item[0]);
                                string value = GetCleanValue(item[1]);
                                output.Add(key, value);
                            }
                        }
                    }
                }

            }
            return output;
        }


        /// <summary>
        /// Standardize all fields
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static List<string> Standardize<T>(T t, List<string> datas)
        {
            List<string> listDatas = new List<string>();
            IDictionary<string, string> standard = new Dictionary<string, string>();

            listDatas.AddRange(datas);
            listDatas.Remove(string.Empty);

            string type = string.Empty;
            try
            {
                standard = Standardization.GetStandard(DictionnaryStandards[t.GetType()]);
            }
            catch (StandardException e)
            {
                throw new StandardException(e.Message);
            }

            List<string> lstTemp = new List<string>();

            foreach (string l in listDatas)
            { 
                string key = l.Remove(l.IndexOf(' '));
               
                string tmp = string.Empty;

                if (standard.TryGetValue(key, out string itemStandard))
                {
                    tmp = Regex.Replace(l, key, itemStandard, RegexOptions.IgnoreCase);
                    lstTemp.Add(tmp);
                    continue;
                }

                //if (!string.IsNullOrWhiteSpace(feature))
                //{
                //    tmp += feature;
                //}
                
                lstTemp.Add(l);
            }

            return lstTemp;
        }

        private static string GetCleanValue(string value)
        {
            //^\s +|\s +$
            return value.Replace("\"", string.Empty).Trim();
            //return Regex.Replace(value, @"^\s+|\s+$", string.Empty).Trim(new char[] { '\"',',' }).Trim();
        }
    }
}
