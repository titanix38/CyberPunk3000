using Autofac;
using Data.Entities;
using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Data.Factory;

namespace ExportToDataBase
{
    // Fields found in a profil
    public enum EnumFields
    {
        CARACTERISTIQUES,
        CAPACITES_SPECIALES,
        COMPETENCES,
        RESSOURCES,
        BREVETS
    }

    public enum EnumCategory
    {
        Circle = 1,
        Triangle = 2,
        Star = 4
    }
    public enum EnumGender
    {
        Male,
        Female,
        CyberRobot
    }


    //  TODO : A supprimer apres avoir fait les repositories
    public enum EnumFeatures
    {
        BT = 0,
        CON = 1,
        EMP = 2,
        MVT = 3,
        SF = 4,
        TECH = 5,
        INT = 6,
        REF = 7
    }

    public class Export
    {
        #region <Attributs>        
        private List<string> _characterize;

        private IFactory _factory;
        private List<string> _missed;
        private List<string> _fields;

        private string _named;

        private Dictionary<string, int> _dicCharacValue;
        private Character _character;
        private Corporation _corporation;


        //private string _json;
        private string _fileName;
        private IContainer _container;

        #endregion <Attributs> 

        #region <Properties>
        public string Message { get; private set; }
        public bool Success { get; private set; }
        #endregion <Properties> 

        #region <Constructor>
        public Export()
        {
            Init();
        }
        #endregion <Constructor>

        #region Private Methods
        private void Init()
        {
            //_factory = new Factory();
            _fields = GetEnumList(new EnumFields());
            Success = false;
            BuildDependency();
        }

        private void BuildDependency()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<Character>().As<ICharacter>();

            builder.RegisterType<Skill>().As<IModel<Skill>>();
            builder.RegisterType<Feature>().As<IModel<Feature>>();
            builder.RegisterType<SpecialAbility>().As<IModel<SpecialAbility>>();
            //builder.RegisterType<Protection>().As<ICharacteristic<Protection>>();

            builder.RegisterType<Corporation>().As< IModel<Corporation>>();
            builder.RegisterType<Grade>().As<IGrade>();

            //builder.RegisterType<Patent>().As<IPatent>();

            //builder.RegisterType<AttributeFeature>().As<IAttribute<AttributeFeature>>();
            //builder.RegisterType<AttributeSpecialAbility>().As<IAttribute<AttributeSpecialAbility>>();
            //builder.RegisterType<AttributeSkill>().As<IAttribute<AttributeSkill>>();
            //builder.RegisterType<AttributeFeature>().As<IAttribute<AttributeFeature>>();
            //builder.RegisterType<AttributeProtection>().As<IAttribute<AttributeProtection>>();

            //builder.

            _container = builder.Build();
        }

        private List<string> GetEnumList<T>(T t)
        {
            List<string> list = new List<string>();

            IEnumerable<T> enumItem = Enum.GetValues(typeof(T)).Cast<T>();

            foreach (var e in enumItem)
            {
                list.Add(e.ToString().ToUpper());
            }
            return list;
        }

        /// <summary>
        /// Read text to export and set datas to correct format
        /// </summary>
        /// <param name="content"></param>
        private List<string> GetFormat(string content)
        {
            List<string> lst = new List<string>();
            string item = string.Empty;
            List<string> newContent = Transtorm(content).ToList();

            newContent.RemoveAll(n => string.IsNullOrWhiteSpace(n) || n.Trim().Substring(0, 1).Equals("#"));

            // Add Charactere's name and corporation(or null)
            lst.Add(newContent[0]);
            bool keep = false;
            foreach (var c in newContent)
            {
                if (Regex.IsMatch(c.ToUpper(), _fields[0].ToUpper()))
                {
                    keep = true;
                }

                if (!keep)
                {
                    continue;
                }

                item = c.ToUpper().Trim();

                lst.Add(item);
            }
            return lst;
        }


        /// <summary>
        /// Set entries to a string array and remove accent on cultural letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string[] </returns>
        private string[] Transtorm(string input)
        {

            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            string output = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            output = Regex.Replace(output, "capacites speciales", "capacites_speciales", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, @"cyber & brevets", "brevets", RegexOptions.IgnoreCase);
            output = output.Replace(Environment.NewLine, "|");
            return output.Split('|');
        }


        /// <summary>
        /// Check the required fields, even if the caracter does not have any resources or 
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            _missed = new List<string>
            {
                string.Concat("Il manque les champs suivants :", Environment.NewLine)
            };

            _missed.AddRange(_fields);

            foreach (string f in _fields)
            {
                _missed.Remove(_characterize.FirstOrDefault(c => c == f));
            }

            return (_missed.Count == 1);
        }
        private Corporation GetCorpo()
        {
            // MR TOTO (^^^^ G500)
            // MR TOTO (^^^^ G500
            // MR TOTO ^^^^ G500)
            // MR TOTO ^^^^ G500

            string[] charac = ExtractCharacter(_characterize[0]);

            // No corporation
            if (charac == null)
            {
                return null;
            }

            _characterize[0] = string.Join(" ", charac);

            return CreateEmployee(charac);

        }

        private string[] ExtractCharacter(string input)
        {
            List<string> typeGrade = new List<string>()
            {
                " o ",
                " oo",
                "^",
                "^^",
                "*",
                "**"
            };

            string tmp = input;
            // o G500  or ooo IMF => grade            
            // For example : freelance, agent immobilier => no corporation neither grade
            // *** Waterloo => grade = ***
            tmp = Regex.Replace(tmp, @"\s+", " ").Trim();

            if (!typeGrade.Any(tmp.ToLower().Contains))
            {
                _named = tmp.Substring(0, tmp.IndexOf('(')).Trim();
                return null;
            }

            if (!tmp.Contains(")"))
            {
                tmp += ")";
            }

            foreach (string t in typeGrade)
            {
                int before = tmp.ToLower().IndexOf(t);
                int after = tmp.ToLower().LastIndexOf(t);

                if (before >= 0)
                {
                    tmp = tmp.Insert(after + 1, "|");

                    if (!tmp.Contains("("))
                    {
                        tmp = tmp.Insert(before, "(");
                    }
                    break;
                }
            }
            _named = tmp.Split(new char[] { '(', ')' })[0].Trim();
            string corpo = tmp.Split(new char[] { '(', ')' })[1].Trim();
            return corpo.Trim().Split('|');
        }


        private EnumCategory GetEnumCategory(string category)
        {
            EnumCategory eCategory;

            switch (category.Substring(0, 1))
            {
                case "o":
                    eCategory = EnumCategory.Circle;
                    break;
                case "^":
                    eCategory = EnumCategory.Triangle;
                    break;
                case "*":
                    eCategory = EnumCategory.Star;
                    break;
                default:
                    eCategory = EnumCategory.Circle;
                    break;
            }
            return eCategory;
        }
        private string SetRank(EnumCategory category)
        {
            char r;
            // 
            char[] rk = { '\u25CF', '\u25BC', '\u2605' };
            switch (category)
            {
                case EnumCategory.Circle:
                    r = rk[0];
                    break;
                case EnumCategory.Triangle:
                    r = rk[1];
                    break;
                case EnumCategory.Star:
                    r = rk[2];
                    break;
                default:
                    r = rk[0];
                    break;
            }

            return r.ToString();
        }
        private Corporation CreateEmployee(string[] employee)
        {
            string name = employee[1].ToUpper().Trim();
            //string stGrade = employee[0].ToLower().Trim();
            int qty = employee[0].ToLower().Trim().Length;
            EnumCategory category = GetEnumCategory(employee[0].ToLower().Trim());

            Corporation corporation = Activator.CreateInstance<Corporation>();

            using (ILifetimeScope scope = _container.BeginLifetimeScope())
            {
                IModel<Corporation> corpo = scope.Resolve<IModel<Corporation>>();
                IGrade grade = scope.Resolve<IGrade>();

                //grade.WeaponCategory = category;
                grade.Quantity = qty;
                grade.Category = SetRank(category);

                corporation.Wording = name;
                corporation.Grade = (Grade)grade;

                return corporation;
            }
        }

        private void CreateCharacter(List<string> characterize, string gender)
        {
            _characterize = characterize;
            if (!CheckFields())
            {
                throw new CharacterException(string.Concat(_missed));
            }
            _corporation = GetCorpo();
            SetCharacter(gender);
            Success = true;
        }

        private void SetCharacter(string gender)
        {
            Dictionary<string, EnumGender> dicGender = new Dictionary<string, EnumGender>()
            {
                {"Homme",EnumGender.Male },
                {"Femme",EnumGender.Female },
                {"Cyber Robot",EnumGender.CyberRobot }
            };

            EnumGender genderEnum = EnumGender.Male;
            if (!dicGender.TryGetValue(gender, out genderEnum))
            {
                genderEnum = EnumGender.Male;
            }

            string[] named = GetName(_named, genderEnum);

            _character = new Character()
            {
                FirstName = named[0],
                LastName = named[1]

                //Grade = _corporation.Grade,

            };

            SetCharacterize(new Feature());
            //SetCharacterize(new SpecialAbility());
            //SetCharacterize(new Skill());
            //SetResource();

            // TODO : Faire les brevets
            // A voit aussi pour les protections
            //ExtractPatents();
        }

        private string[] GetName(string name, EnumGender gender)
        {
            string[] temp = name.Split(' ');
            List<string> names = new List<string>();
            string other = string.Empty;

            names.AddRange(temp);

            Dictionary<EnumGender, string> dicGender = new Dictionary<EnumGender, string>()
            {
                {EnumGender.Male,"Mr"},
                {EnumGender.Female,"Mrs"},
                {EnumGender.CyberRobot,"Cyb"}
            };

            if (names.Count == 2)
            {
                names.Add(string.Empty);
                return names.ToArray();
            }

            if (names.Count < 2)
            {
                names.Insert(0, dicGender[gender]);
                names[1] = temp[0];
                names.Add(string.Empty);
            }

            if (names.Count >= 3)
            {
                for (int i = 2; i < names.Count; i++)
                {
                    other += names[i] + " ";
                }
                names[2] = other;
            }

            return names.ToArray();
        }
        private void SetCharacterize<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>
        {
            _dicCharacValue = new Dictionary<string, int>();
            Dictionary<string, string> dicSkillFeature = new Dictionary<string, string>();

            _missed = new List<string>();

            // For Features, all fields are required
            if (entity.GetType() == typeof(Feature))
            {
                _missed.Add(string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine));
            }

            //if (entity.GetType() == typeof(Skill))
            //{

            //    if (!CheckSkill(ref dicCharacValue, ref dicSkillFeature))
            //    {
            //        throw new CharacterException(string.Concat(_missed));
            //    }
            //}
            //else
            //{
            if (!CheckCharacterize(entity))
            {
                throw new CharacterException(string.Concat(_missed));
            }
            //}

            //DbCharacterizeRepository<TEntity> repository = new DbCharacterizeRepository<TEntity>(entity, _idCharactere);

            foreach (KeyValuePair<string, int> item in _dicCharacValue)
            {
                if (entity.GetType() == typeof(Skill))
                {
                    string feature = string.Empty;

                    if (dicSkillFeature.TryGetValue(item.Key, out feature))
                    {
                        //repository.Create<ICharacteristic<TEntity>>(entity, entity, item.Key, item.Value, feature);
                    }
                }
                //repository.Create<ICharacteristic<TEntity>>(entity, entity, item.Key, item.Value);
            }

            //repository.Dispose();
        }



        //private bool CheckSkill(ref Dictionary<string, int> dicCharacValue, ref Dictionary<string, string> dicSkillFeature)
        //{
        //    string lineCharacterize;

        //    if (!ExtractSkills(out lineCharacterize))
        //    {
        //        return false;
        //    }

        //    List<string> characterize = Standardization.Standardize(new Skill(), Regex.Replace(lineCharacterize, @"\s+", " ").Split('|').ToList());

        //    List<string> skillsValue = SetSkillsFeature(characterize, ref dicSkillFeature);

        //    if (!CheckValue(skillsValue, ref dicCharacValue))
        //    {
        //        throw new CharacterException(string.Concat(_missed));
        //    }
        //    return true;
        //}

        //private bool ExtractSkills(out string datas)
        //{
        //    datas = string.Empty;
        //    bool isMatch = false;
        //    string feature = string.Empty;

        //    Regex match = new Regex(_dictionnaryStandards[typeof(Skill)], RegexOptions.IgnoreCase);

        //    List<char> Readfeatures = new List<char>() { '[', ']' };

        //    foreach (string c in _characterize)
        //    {
        //        if (match.IsMatch(c))
        //        {
        //            isMatch = true;
        //            continue;
        //        }

        //        if (isMatch)
        //        {
        //            if (_fields.Exists(f => f == c))
        //            {
        //                break;
        //            }

        //            if (Readfeatures.Any(c.Contains))
        //            {
        //                feature = c.Replace("[", string.Empty).Replace("]", string.Empty);
        //                continue;
        //            }
        //            // datas for skills is e.g. PERCEPTION 6§INT|SOCIAL 5§EMP| ...
        //            if (!string.IsNullOrWhiteSpace(c))
        //            {
        //                datas += c.Trim() + "§" + feature + "|";
        //            }
        //        }
        //    }

        //    if (string.IsNullOrEmpty(datas))
        //    {
        //        _missed.Add(string.Concat("Aucune Competences n'a été renseigné",
        //                         Environment.NewLine,
        //                         "Veuillez regarder un exemple",
        //                         Environment.NewLine));
        //        return false;
        //    }
        //    return true;


        //    // Concerne les brevets ou la cyber (Ceci est optionnel) donc si ce champ est vide non retour d'erreur
        //    //int index = _characterize.FindIndex(c => c == _dictionnaryStandards[typeof(Patent)]);

        //    //if (index > 0)
        //    //{
        //    //    for (int i = index + 1; i < _characterize.Count; i++)
        //    //    {
        //    //        datas += _characterize[i] + "|";
        //    //    }
        //    //}

        //    //return true;
        //}

        private bool CheckCharacterize<T>(T t)
        {
            //dico = new Dictionary<string, int>();
            string lineCharacterize = ExtractDatas(t);
            if (string.IsNullOrEmpty(lineCharacterize))
            {
                return false;
            }

            List<string> characterize = Standardization.Standardize(t, Regex.Replace(lineCharacterize, @"\s+", " ").Split('|').ToList());
            // TODO : Mettre dans BdD les corporations 
            // Dans le cas Features toutes les valeurs sont requises
            if (t.GetType() == typeof(Feature))
            {
                return CheckFeatures(characterize);
            }

            return CheckValue(characterize);
        }

        private string ExtractDatas<T>(T t)
        {
            string datas = string.Empty;
            bool isMatch = false;
            string requiredField = string.Empty;

            //if (t.GetType() != typeof(Patent))
            //{
            
            Regex match = new Regex(Standardization.DictionnaryStandards[t.GetType()], RegexOptions.IgnoreCase);

            foreach (var a in _characterize)
            {
                if (match.IsMatch(a))
                {
                    isMatch = true;
                    continue;
                }

                if (isMatch)
                {
                    if (_fields.Exists(f => f == a))
                    {
                        break;
                    }
                    if (!string.IsNullOrWhiteSpace(a))
                    {
                        datas += a + "|";
                    }
                }
            }

            return datas;

            //    return true;
            //}

            // Concerne les brevets ou la cyber (Ceci est optionnel) donc si ce champ est vide non retour d'erreur
            //int index = _characterize.FindIndex(c => c == _dictionnaryStandards[typeof(Patent)]);

            //if (index > 0)
            //{
            //    for (int i = index + 1; i < _characterize.Count; i++)
            //    {
            //        datas += _characterize[i] + "|";
            //    }
            //}

            //return true;
        }


        private bool CheckFeatures(List<string> datas)
        {
            List<string> items = new List<string>();
            string key = string.Empty;
            string message = string.Empty;

            foreach (var d in datas)
            {

                //pattern.Sort();

                if (!CheckFieldValue(d, out message, out key, out int value))
                {
                    _missed.Add(string.Format("{0} a renvoyé l'erreur {1}", key, message));

                }
                items.Add(key + " " + value.ToString());
            }

            items.Sort();

            // TODO : Ceci sera remplace par le champ qui viendra du résultat de repositories

            //var toto = Enum.GetValues(typeof(EnumFeatures)).Cast<EnumFeatures>().ToList();

            foreach (var f in Enum.GetValues(typeof(EnumFeatures)).Cast<EnumFeatures>().ToList())
            {
                IEnumerable<string> query = items.Where(i => i.ToUpper().Contains(f.ToString().ToUpper()));
                if (query.Count() != 1)
                {
                    _missed.Add(string.Concat(f, Environment.NewLine));
                }
            }

            if (!CheckValue(items))
            {
                _missed.Add(string.Format("{0} a renvoyé l'erreur {1}", key, message));
                return false;
            }

            return true;
        }
        /// <summary>
        /// Verifie que la valeur du champ soit un entier
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="dico"></param>
        /// <returns></returns>
        private bool CheckValue(List<string> datas)
        {
            _missed = new List<string>();

            string message = string.Empty;

            _missed.Add(string.Concat("Des erreurs ont été trouvé : ", Environment.NewLine));

            foreach (string d in datas)
            {

                if (!CheckFieldValue(d, out message, out string name, out int value))
                {
                    _missed.Add(string.Concat(string.Format("- {0} ", message), Environment.NewLine));
                }

                // Verifie l'existence de doublon, si doublon alors la nouvelle valeur ecrase l'ancienne
                if (_dicCharacValue.Keys.Contains(name))
                {
                    _dicCharacValue.Remove(name);
                }
                _dicCharacValue.Add(name, value);
            }
            return (_missed.Count < 2);
        }

        private bool CheckFieldValue(string input, out string message, out string name, out int value)
        {
            name = string.Empty;
            string val = string.Empty;
            value = 0;
            if (string.IsNullOrWhiteSpace(input))
            {
                message = "Champ vide";
                return false;
            }


            string output = input.ToUpper();

            name = Regex.Replace(output, @"\d+", string.Empty).Trim();
            name = Regex.Replace(name, "[+-]", string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                message = "Le nom du champ n'est pas valide";
                return false;
            }

            if (output.Contains(" "))
            {
                //name += output.Substring(0, output.IndexOf(" "));
                val = output.Substring(output.IndexOf(" "));
            }

            if (!int.TryParse(val, out value))
            {
                message = string.Format("Le champ {0} n'est pas associé à une valeur entière", name);
                return false;
            }
            message = string.Format("OK : {0} = {1}", name, value);
            return true;
        }

        #endregion

        #region Public Methods
        public void ImportText(string content, string gender)
        {
            CreateCharacter(GetFormat(content), gender);

            //_factory = new Factory();

            //_fileName = _factory.FirstName + "_" + _factory.LastName;
            //_json = JsonConvert.SerializeObject(_factory, Formatting.Indented);
            //File.WriteAllText(string.Format(@".\Output\{0}.json", _fileName), _json);

            if (Directory.Exists(@".\Output\"))
            {
                Directory.CreateDirectory(@".\Output\");
            }

            Success = _factory.Success;

            if (Success && File.Exists(string.Format(@".\Output\{0}.json", _fileName)))
            {
                Message = string.Format("Fichier {0}.Json {1} exporté avec succés", _fileName, Environment.NewLine);
            }

        }

        #endregion



    }
}