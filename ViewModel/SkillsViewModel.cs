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
    public class SkillsViewModel : FeaturesViewModel,IViewModelBase<Skill>
    {
        public List<string> GetNames<T>(T t)
        {
            throw new NotImplementedException();
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
