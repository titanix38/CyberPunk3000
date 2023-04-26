using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;
using Data.Factory;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class FeaturesViewModel : IViewModelBase<Feature>
    {
        private Factory _factory;

        public ObservableCollection<Feature> Features { get; set; }
        public ObservableCollection<Skill> Skills { get; set; }

        public List<string> GetNames<T>(T t)
        {
            throw new NotImplementedException();
        }

        public void LoadItems()
        {
#if DEBUG

#else

#endif

        }

        public ObservableCollection<Feature> ParseListToObservable(List<Feature> entities)
        {
            ObservableCollection<Feature> features = new ObservableCollection<Feature>();
            foreach (var entity in entities)
            {
                features.Add(new Feature { Id = entity.Id, Alias = entity.Alias, Wording = entity.Wording });

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
