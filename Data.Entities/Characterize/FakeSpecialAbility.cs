using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Characterize
{
    /// <summary>
    /// This class is used only debug mode, it simulates datas from SpecialAbilities Table from Database
    /// </summary>
    public class FakeSpecialAbility
    {
        public int Id { get; set; }
        public string Wording { get; set; }
        public string Alias { get; set; }

        public List<FakeSpecialAbility> Fakes { get; private set; }

        public FakeSpecialAbility() 
        {
            if (Fakes == null) SetList();
        }


        private void SetList()
        {
            Fakes = new List<FakeSpecialAbility>();
            Fakes.Add(new FakeSpecialAbility()
            {
                Alias = "SDC",
                Id = 1,
                Wording = "Sens du combat"
            });

            Fakes.Add(new FakeSpecialAbility()
            {
                Alias = "FUR",
                Id = 2,
                Wording = "Sens du combat"
            });

            Fakes.Add(new FakeSpecialAbility()
            {
                Alias = "RES",
                Id = 3,
                Wording = "Ressources"
            });
        }
    }
}