using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Enterprise;
using Data.Entities.Place;

namespace Data.Entities.Person
{
    public enum EnumGender
    {
        Male,
        Female,
        CyberRobot
    }
    [Table("Characters")]
    public class Character : ICharacter
    {
        #region Properties
        [Key]
        public int IdCharactere { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudo { get; set; }

        public int IdGender { get; set; }

        public int Chance { get; set; }

        public bool Alive { get; set; }



        public int? IdCorporation { get; set; }

        public int? IdGrade { get; set; }

        public int IdEthnic { get; set; }

        public int? IdArea { get; set; }


        public virtual Ethnic Ethnic { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Corporation Corporation { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Area Area { get; set; }
        //public ICollection<AttributeProtection> AttributeProtections { get; set; }
        //public ICollection<AttributeFeature> AttributeFeatures { get; set; }
        //public ICollection<AttributeSpecialAbility> AttributeSpecialAbilities { get; set; }
        //public ICollection<AttributeSkill> AttributeSkills { get; set; }
        //public ICollection<AttributeResource> AttributeResource { get; set; }
        //public ICollection<AttributeKnowledgeArea> AttributeKnowledgeArea { get; set; }

        #endregion

        #region Constructor
        //public Character(
        //    ICharacteristic<Feature> feature,
        //    ICharacteristic<Skill> skill,
        //    ICorporation corporation,
        //    IEthnic ethnic)
        //{
        //    _feature = feature ?? throw new ArgumentNullException(nameof(feature));
        //    _skill = skill ?? throw new ArgumentNullException(nameof(skill));
        //    _ethnie = ethnic ?? throw new ArgumentNullException(nameof(ethnic));
        //    _corporation = corporation ?? throw new ArgumentNullException(nameof(corporation));
        //}

        public Character()
        {
            //_feature = new Feature();
            //_special = new SpecialAbility();
            //_skill = new Skill();
            //_ethnie = new Ethnic();
        }
        #endregion
    }
}
