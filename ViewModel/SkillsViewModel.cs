using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;
using Data.Factory;
using System.Collections.ObjectModel;
using Data.Entities.Cyber;
using Data.Entities.RelationManyToMany;
using Data.Entities.Person;

namespace ViewModel
{
    public class SkillsViewModel : IViewModelBase<Skill>
    {
        private Factory _factory;

        private Feature _feature;
        private SpecialAbility _special;
        private CharacterSkill _characterSkill;
        //public ObservableCollection<Feature> Features { get; set; }
        public ObservableCollection<Skill> Skills { get; set; }

        public List<string> GetNames<T>(T t)
        {
            throw new NotImplementedException();
        }

        public void LoadItems()
        {
#if DEBUG
            //List<Feature> fakesFeature = GetFakeFeature();
            Skills = GetFakeSkills();
            //Features = ParseListToObservable(fakesFeature);
            //Skills = ParseListToObservable(fakeSkills);

#else

#endif

        }

        private ObservableCollection<Skill> GetFakeSkills()
        {
            Dictionary<string, string> dico = new Dictionary<string, string>()
            {
                {"PERC_HUM","Perception humaine"},
                {"BARA","Baratin & Persuasion"},
                {"PERF","Performance"},
                {"SOC","Social"},
                {"MEDIT","Meditation"},
                {"COMM","Commandement"},
                {"INTER","Interview"},
                {"NEGO","Negociation"},
            };

            ObservableCollection<Skill> Fakes = new ObservableCollection<Skill>();
            int i = 1;

            foreach (var item in dico)
            {
                Skill fake = new Skill();

                _feature = new Feature()
                {
                    Id = 1,
                    Wording = "Empathie",
                    Alias = "EMP"
                };

                if (i == 1)
                {
                    fake.Feature = _feature;
                }
                else 
                {
                    fake.Feature = null;
                }
                fake.Alias = item.Key;
                fake.Id = i;
                fake.Wording = item.Value;
                Fakes.Add(fake);

                i++;
            }
            return Fakes;
        }

        private List<Feature> GetFakeFeature()
        {
            Dictionary<string, string> dico = new Dictionary<string, string>()
            {
                //{"BT","Beautee"},
                //{"CON","Constitution"},
                {"EMP","Empathie"},
                //{"MVT","Mouvement"},
                //{"SF","Sang Froid"},
                //{"INT","Inteliigence"},
                //{"TECH","Technique" },
                //{"REF","Reflex" },
                //{"CHANCE","Chance" }
            };

            List<Feature> Fakes = new List<Feature>();
            int i = 1;
            foreach (var item in dico)
            {
                Fakes.Add(new Feature()
                {
                    Alias = item.Key,
                    Id = i,
                    Wording = item.Value
                });
                i++;
            }

            return Fakes;
        }

        public ObservableCollection<Feature> ParseListToObservable(List<Feature> entities)
        {
            ObservableCollection<Feature> features = new ObservableCollection<Feature>();
            foreach (var entity in entities)
            {


                features.Add(new Feature { Id = entity.Id, Alias = entity.Alias, Wording = entity.Wording, });

            }
            return features;
        }
        public ObservableCollection<Skill> ParseListToObservable(List<Skill> entities)
        {
            ObservableCollection<Skill> skills = new ObservableCollection<Skill>();
            foreach (var entity in entities)
            {
                skills.Add(new Skill { Id = entity.Id, Alias = entity.Alias, Wording = entity.Wording });

            }
            return skills;
        }
    }
}
