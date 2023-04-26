using Data.Entities.Characterize;
using Data.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SpecialAbilitiesViewModel : IViewModelBase<SpecialAbility>
    {
        private Factory _factory;

        public ObservableCollection<SpecialAbility> Specials { get; set; }

        public List<string> GetNames<T>(T t)
        {
            throw new NotImplementedException();
        }

        public void LoadItems()
        {
#if DEBUG

            List<SpecialAbility> fakes = GetFakeSpecials();


            Specials = ParseListToObservable(fakes);
#else
            // TODO : Read from DataBase
            _factory = new Factory();
            List<SpecialAbility> abilities = _factory.GetSpecial();
            Specials = ParseListToObservable(abilities);
#endif
        }

        public ObservableCollection<SpecialAbility> ParseListToObservable(List<SpecialAbility> entities)
        {
            ObservableCollection<SpecialAbility> specialAbilities = new ObservableCollection<SpecialAbility>();
            foreach (var entity in entities)
            {
                specialAbilities.Add(new SpecialAbility { Id = entity.Id, Alias = entity.Alias, Wording = entity.Wording });

            }
            return specialAbilities;
        }

        /// <summary>
        /// This method is used only in debug mode, create Stub list
        /// </summary>
        /// <returns></returns>
        private List<SpecialAbility> GetFakeSpecials()
        {
            Dictionary<string, string> dico = new Dictionary<string, string>()
            {
                {"SDC","Sens du combat"},
                {"FUR","Furtivité"},
                {"RES","Ressource"},
                {"SYSTD","Systeme D"},
                {"INTER","Interface"},
                {"AUTOR","Autorite" },
                {"CHAR","Charisme" },
                {"FIXER","Fixer" },
                {"MEDT","Medtech" },
                {"MED","Media" },
                {"TECH","Techi" },

            };

            List<SpecialAbility> Fakes = new List<SpecialAbility>();
            int i = 1;
            foreach (var item in dico)
            {
                Fakes.Add(new SpecialAbility()
                {
                    Alias = item.Key,
                    Id = i,
                    Wording = item.Value
                });
                i++;
            }

            return Fakes;
        }

        //private ObservableCollection<SpecialAbility> ParseListToObservable(List<SpecialAbility> entities)
        //{
        //    ObservableCollection<SpecialAbility> specialAbilities = new ObservableCollection<SpecialAbility>();

        //    foreach (var entity in entities)
        //    {
        //        specialAbilities.Add(new SpecialAbility { Id = entity.Id, Alias = entity.Alias, Wording = entity.Wording });

        //    }
        //    return specialAbilities;
        //}
    }
}
