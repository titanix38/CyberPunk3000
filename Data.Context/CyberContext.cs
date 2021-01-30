using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Data.Entities.Person;
using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Place;
using Data.Entities.Cyber;
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

        public DbSet<CharacterFeature> CharactersFeatures { get; set; }
        public DbSet<CharacterSkill> CharactersSkills { get; set; }

        public CyberContext() : base("CyberPunk3000")
        {
            // Important : Do not delete the below line
            SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>()
                .HasRequired(c => c.Ethnic)
                .WithMany(e => e.Characters)
                .HasForeignKey<int>(c => c.IdEthnic);

            modelBuilder.Entity<Character>()
                .HasRequired(c => c.Gender)
                .WithMany(e => e.Characters)
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
                .HasOptional(c => c.Area)
                .WithMany(c => c.Characters)
                .HasForeignKey<int?>(c => c.IdArea);

            modelBuilder.Entity<Pseudo>()
                .HasOptional(c => c.Person)
                .WithMany(e => e.Pseudos)
                .HasForeignKey<int?>(c => c.IdPseudo);

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

            modelBuilder.Entity<Patent>()
                .HasOptional(p => p.Feature)
                .WithMany(p => p.Patents)
                .HasForeignKey<int?>(s => s.IdFeature);

            modelBuilder.Entity<CharacterFeature>()
                .HasKey(cf => new
                {
                    cf.IdFeature,
                    cf.IdCharacter
                });

            modelBuilder.Entity<CharacterSkill>()
                .HasKey(cf => new
                {
                    cf.IdSkill,
                    cf.IdCharacter
                });

            //modelBuilder.Entity<Feature>()
            //    .HasRequired(f=>f.Characters)
            //    .WithMany(f=>f.Features)
            //    .

            //modelBuilder.Entity<Character>()
            //    //.HasRequired(f => f.Features)
            //    //.WithRequiredDependent(c=>c.C)
            //    //.WithMany(c => c.)
            //    .HasKey(c => new
            //    {
            //        c.IdCharactere,
            //        c.IdFeature
            //    });

            //modelBuilder.Entity<AttributeFeature>().HasKey(a =>
            //new
            //{
            //    a.IdCharactere,
            //    a.Id
            //});

            //modelBuilder.Entity<AttributeSpecialAbility>().HasKey(a =>
            //new
            //{
            //    a.IdCharactere,
            //    a.Id
            //});

            //modelBuilder.Entity<AttributeSkill>().HasKey(a =>
            //new
            //{
            //    a.IdCharactere,
            //    a.Id
            //});

            //modelBuilder.Entity<AttributeResource>().HasKey(a =>
            //new
            //{
            //    a.IdCharactere,
            //    a.Id
            //});
            //modelBuilder.Entity<AttributeKnowledgeArea>().HasKey(a =>
            //new
            //{
            //    a.IdCharactere,
            //    a.Id
            //});
            //******************************************************************************************
            // Relationships 
            //-----------------------------------------------------------------
            //  between Characteres and Features
            //modelBuilder.Entity<AttributeFeature>()
            //    .HasRequired(t => t.Character)
            //    .WithMany(t => t.AttributeFeatures)
            //    .HasForeignKey(t => t.IdCharactere);

            //modelBuilder.Entity<AttributeFeature>()
            //    .HasRequired(t => t.Feature)
            //    .WithMany(t => t.AttributeFeatures)
            //    .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //-----------------------------------------------------------------
            //  between Characteres and SpecialAbilities
            //modelBuilder.Entity<AttributeSpecialAbility>()
            //    .HasRequired(t => t.Character)
            //    .WithMany(t => t.AttributeSpecialAbilities)
            //    .HasForeignKey(t => t.IdCharactere);

            //modelBuilder.Entity<AttributeSpecialAbility>()
            //    .HasRequired(t => t.SpecialAbility)
            //    .WithMany(t => t.AttributeSpecialAbility)
            //    .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //-----------------------------------------------------------------
            //  between Characteres and Skills
            //modelBuilder.Entity<AttributeSkill>()
            //    .HasRequired(t => t.Character)
            //    .WithMany(t => t.AttributeSkills)
            //    .HasForeignKey(t => t.IdCharactere);

            //modelBuilder.Entity<AttributeSkill>()
            //    .HasRequired(t => t.Skill)
            //    .WithMany(t => t.AttributeSkills)
            //    .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //  between Characteres and Areas
            //modelBuilder.Entity<AttributeKnowledgeArea>()
            //    .HasRequired(t => t.Character)
            //    .WithMany(t => t.AttributeKnowledgeArea)
            //    .HasForeignKey(t => t.IdCharactere);

            //modelBuilder.Entity<AttributeKnowledgeArea>()
            //    .HasRequired(t => t.Area)
            //    .WithMany(t => t.AttributeKnowledgeArea)
            //    .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //******************************************************************************************

            //modelBuilder.Entity<Character>()
            //    .HasMany<Feature>(f => f.Features)
            //    .WithMany(c => c.Characters)                
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("CharacterRefId");
            //        cs.MapRightKey("FeatureRefId");
            //        cs.ToTable("AttributesFeatures");                    
            //    });
        }
    }
}
