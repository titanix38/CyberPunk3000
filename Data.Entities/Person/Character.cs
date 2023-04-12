using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Enterprise;
using Data.Entities.Injury;
using Data.Entities.Place;
using Data.Entities.RelationManyToMany;

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdCharacter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsNpc { get; set; }
        public int IdGender { get; set; }
        public int IdEthnic { get; set; }

        public Guid IdPlayer { get; set; }

        public int Chance { get; set; }

        // ------------------------------------------
        //              Injuries
        public int IdDamage { get; set; }
        public int? DamageSlash { get; set; }
        public int? DamageCross { get; set; }
        public bool? Stabilized { get; set; }
        public bool Alive { get; set; }
        // ------------------------------------------
        // ------------------------------------------
        //              Affiliate
        public int? IdCorporation { get; set; }
        public int? IdGrade { get; set; }
        // ------------------------------------------
        // ------------------------------------------
        //  Localization
        public int? IdArea { get; set; }
        // ------------------------------------------
        public virtual Damage Damage { get; set; }
        public virtual Player Player { get; set; }
        public virtual Ethnic Ethnic { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Corporation Corporation { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Area Area { get; set; }

        public ICollection<CharacterFeature> CharacterFeatures { get; set; }
        public ICollection<CharacterPseudo> CharacterPseudos { get; set; }
        public ICollection<CharacterSkill> CharacterSkills { get; set; }
        public ICollection<CharacterSpecialAbility> CharacterSpecialAbilities { get; set; }
        public virtual ICollection<CharacterArea> CharacterAreas { get; set; }
        public ICollection<CharacterResourceCharacter> CharacterResourceCharacters { get; set; }
        public ICollection<CharacterResourceCorporation> CharacterResourceCorporations { get; set; }
        public ICollection<CharacterProperty> CharacterProperties { get; set; }
        public ICollection<CharacterProtection> CharacterProtections { get; set; }
        public ICollection<CharacterWeapon> CharacterWeapons { get; set; }
        #endregion

        #region Constructor


        public Character()
        {

        }
        #endregion
    }
}
