using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using Data.Entities;
using Data.Entities.Person;
using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Place;
using Data.Entities.Cyber;
using Data.Entities.Possession;
using Data.Entities.RelationManyToMany;

namespace Data.Context
{
    public class CyberContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<SpecialAbility> SpecialAbilities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Ethnic> Ethnics { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Protection> Protections { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Patent> Patents { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<WeaponCategory> WeaponCategories { get; set; }
        public DbSet<Concealment> Concealments { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Dice> Dices { get; set; }

        public DbSet<CharacterFeature> CharactersFeatures { get; set; }
        public DbSet<CharacterSkill> CharactersSkills { get; set; }
        public DbSet<CharacterArea> CharacterAreas { get; set; }
        public DbSet<CharacterResourceCharacter> CharacterResourceCharacters { get; set; }
        public DbSet<CharacterResourceCorporation> CharacterResourceCorporations { get; set; }
        public DbSet<CharacterSpecialAbility> CharacterSpecialAbilities { get; set; }
        public DbSet<CharacterProperty> CharacterProperties { get; set; }
        public DbSet<CharacterWeapon> CharacterWeapons { get; set; }


        public CyberContext() : base("CyberPunk3000")
        {
            // Important : Do not delete the below line
            SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Character>()
                .HasRequired(c => c.Ethnic)
                .WithMany(e => e.Characters)
                .HasForeignKey<int>(c => c.IdEthnic);

            modelBuilder.Entity<Character>()
                .HasRequired(c => c.Gender)
                .WithMany(g => g.Characters)
                .HasForeignKey<int>(c => c.IdGender);

            modelBuilder.Entity<Character>()
                .HasOptional<Corporation>(c => c.Corporation)
                .WithMany(c => c.Characters)
                .HasForeignKey<int?>(c => c.IdCorporation);

            modelBuilder.Entity<Character>()
                .HasOptional<IGrade>(c => c.Grade)
                .WithMany(c => c.Characters)
                .HasForeignKey<int?>(c => c.IdGrade);

            modelBuilder.Entity<Character>()
                .HasOptional<Area>(c => c.Area)
                .WithMany(c => c.Characters)
                .HasForeignKey<int?>(c => c.IdArea);

            modelBuilder.Entity<Skill>()
                .HasRequired(s => s.Feature)
                .WithMany(s => s.Skills)
                .HasForeignKey<int>(s => s.IdFeature);

            modelBuilder.Entity<Skill>()
                .HasOptional(s => s.SpecialAbility)
                .WithMany(s => s.Skills)
                .HasForeignKey<int?>(s => s.IdSpecialAbility);

            modelBuilder.Entity<Area>()
                .HasRequired(c => c.City)
                .WithMany(s => s.Areas)
                .HasForeignKey<int>(s => s.IdCity);

            modelBuilder.Entity<Protection>()
                .HasRequired(p => p.Part)
                .WithMany(p => p.Protections)
                .HasForeignKey(p => p.IdPart);

            modelBuilder.Entity<Property>()
                .HasRequired(p => p.Area)
                .WithMany(a => a.Properties)
                .HasForeignKey<int>(a => a.IdArea);

            modelBuilder.Entity<Patent>()
                .HasOptional(p => p.Feature)
                .WithMany(p => p.Patents)
                .HasForeignKey<int?>(s => s.IdFeature);

            modelBuilder.Entity<Weapon>()
                .HasRequired(w => w.WeaponCategory)
                .WithMany(wc => wc.Weapons)
                .HasForeignKey<int>(w => w.IdCategory);

            modelBuilder.Entity<Weapon>()
                .HasRequired(w => w.Concealment)
                .WithMany(c => c.Weapons)
                .HasForeignKey<int>(w => w.IdConcealment);

            modelBuilder.Entity<Weapon>()
                .HasRequired(w => w.Place)
                .WithMany(p => p.Weapons)
                .HasForeignKey<int>(w => w.IdPlace);

            modelBuilder.Entity<Weapon>()
                .HasRequired(w => w.Dice)
                .WithMany(d => d.Weapons)
                .HasForeignKey<int>(w => w.IdPlace);

            #region <Many-To-Many> Characters <-> Area
            modelBuilder.Entity<CharacterArea>()
                .HasKey(area => new
                {
                    area.IdArea,
                    area.IdCharacter
                });
            modelBuilder.Entity<CharacterArea>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterAreas)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterArea>()
                .HasRequired(pc => pc.Areas)
                .WithMany(c => c.CharacterAreas)
                .HasForeignKey(pc => pc.IdArea);
            #endregion <Many-To-Many> Characters <-> Area

            #region <Many-To-Many> Characters <-> Skills
            modelBuilder.Entity<CharacterFeature>()
                .HasKey(area => new
                {
                    area.IdCharacter,
                    area.IdFeature,
                });
            modelBuilder.Entity<CharacterFeature>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterFeatures)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterFeature>()
                .HasRequired(pc => pc.Features)
                .WithMany(c => c.CharacterFeatures)
                .HasForeignKey(pc => pc.IdFeature);
            #endregion <Many-To-Many> Characters <-> Skills

            #region <Many-To-Many> Characters <-> Pseudo
            modelBuilder.Entity<CharacterPseudo>()
                .HasKey(pseudo => new
                {
                    pseudo.IdCharacter,
                    pseudo.IdPseudo
                });
            modelBuilder.Entity<CharacterPseudo>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterPseudos)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterPseudo>()
                .HasRequired(pc => pc.Pseudos)
                .WithMany(c => c.CharacterPseudos)
                .HasForeignKey(pc => pc.IdPseudo);
            #endregion <Many-To-Many> Characters <-> Pseudo

            #region <Many-To-Many> Characters <-> ResourceCharacter
            modelBuilder.Entity<CharacterResourceCharacter>()
                .HasKey(character => new
                {
                    character.IdCharacter,
                    character.IdOtherCharacter
                });
            
            modelBuilder.Entity<CharacterResourceCharacter>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterResourceCharacters)
                .HasForeignKey(pc => pc.IdCharacter);

            //modelBuilder.Entity<CharacterResourceCharacter>()
            //    .HasRequired(pc => pc.Characters)
            //    .WithMany(p => p.CharacterResourceCharacters)
            //    .HasForeignKey(pc => pc.IdOtherCharacter);

            #endregion <Many-To-Many> Characters <-> ResourceCharacter

            #region <Many-To-Many> Characters <-> ResourceCorporation

            modelBuilder.Entity<CharacterResourceCorporation>()
                .HasKey(corpo => new
                {
                    corpo.IdCharacter,
                    corpo.IdCorpo
                });
            modelBuilder.Entity<CharacterResourceCorporation>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterResourceCorporations)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterResourceCorporation>()
                .HasRequired(pc => pc.Corporations)
                .WithMany(c => c.CharacterResourceCorporations)
                .HasForeignKey(pc => pc.IdCorpo);
            #endregion <Many-To-Many> Characters <-> ResourceCorporation

            #region <Many-To-Many> Characters <-> Skill
            modelBuilder.Entity<CharacterSkill>()
                .HasKey(skill => new
                {
                    skill.IdSkill,
                    skill.IdCharacter
                });
            modelBuilder.Entity<CharacterSkill>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterSkills)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterSkill>()
                .HasRequired(pc => pc.Skills)
                .WithMany(c => c.CharacterSkills)
                .HasForeignKey(pc => pc.IdSkill);
            #endregion <Many-To-Many> Characters <-> Skill

            #region <Many-To-Many> Characters <-> SpecialAbility
            modelBuilder.Entity<CharacterSpecialAbility>()
                .HasKey(special => new
                {
                    special.IdCharacter,
                    special.IdSpecial
                });
            modelBuilder.Entity<CharacterSpecialAbility>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterSpecialAbilities)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterSpecialAbility>()
                .HasRequired(pc => pc.SpecialAbilities)
                .WithMany(c => c.CharacterSpecialAbilities)
                .HasForeignKey(pc => pc.IdSpecial);
            #endregion <Many-To-Many> Characters <-> SpecialAbility

            #region <Many-To-Many> Characters <-> Properties

            modelBuilder.Entity<CharacterProperty>()
                .HasKey(property => new
                {
                    property.IdCharacter,
                    property.IdProperty
                });
            modelBuilder.Entity<CharacterProperty>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterProperties)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterProperty>()
                .HasRequired(pc => pc.Properties)
                .WithMany(c => c.CharacterProperties)
                .HasForeignKey(pc => pc.IdProperty);
            #endregion <Many-To-Many> Characters <-> Properties

            #region <Many-To-Many> Characters <-> Protections
            modelBuilder.Entity<CharacterProtection>()
                .HasKey(protection => new
                {
                    protection.IdCharacter,
                    protection.IdProtection
                });
            modelBuilder.Entity<CharacterProtection>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterProtections)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterProtection>()
                .HasRequired(pc => pc.Protections)
                .WithMany(c => c.CharacterProtections)
                .HasForeignKey(pc => pc.IdProtection);
            #endregion <Many-To-Many> Characters <-> Protections

            #region <Many-To-Many> Characters <-> Weapons
            modelBuilder.Entity<CharacterWeapon>()
                .HasKey(w => new
                {
                    w.IdCharacter,
                    w.IdWeapon
                });
            modelBuilder.Entity<CharacterWeapon>()
                .HasRequired(pc => pc.Characters)
                .WithMany(p => p.CharacterWeapons)
                .HasForeignKey(pc => pc.IdCharacter);

            modelBuilder.Entity<CharacterWeapon>()
                .HasRequired(pc => pc.Weapons)
                .WithMany(c => c.CharacterWeapons)
                .HasForeignKey(pc => pc.IdWeapon);
            #endregion <Many-To-Many> Characters <-> Protections
        }
    }
}
