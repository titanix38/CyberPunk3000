using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ViewModel
{

    public class ViewModelSkills
    {
#if DEBUG
        private FakeSpecialAbility _specialAbility;
        public List<FakeSpecialAbility> Special { get; private set; }

#else
        private SpecialAbility _specialAbility;
        public List<SpecialAbility> Special { get; private set; }
#endif



        public ViewModelSkills()
        {
#if DEBUG
            _specialAbility = new FakeSpecialAbility();
            Special = _specialAbility.Fakes;
#else

#endif
        }


        //public void SetFakeSpecialAbilities()
        //{

        //    FakeSpecialAbility fakeSpecAbil = new FakeSpecialAbility();

        //    List<FakeSpecialAbility> fakes = fakeSpecAbil.Fakes;
        //    //UserControlSpecialAbilities UcSpecial = null;

        //    //foreach(var fake in fakes) 
        //    //{
        //    //    UcSpecial = new UserControlSpecialAbilities();
        //    //}


        //}
    }
}
