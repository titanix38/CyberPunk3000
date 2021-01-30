﻿using Data.Context;
using Data.Entities;
using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Place;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DbModelRepository<T> : IDbModelRepository<T> where T : class, IModel<T>
    {
        protected CyberContext _context;
        private readonly int _idCharacter;

        public int Id { get; private set; }

        public CyberContext Context { get { return _context; } }


        public DbModelRepository(T entity, int idCharactere, CyberContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
            _idCharacter = idCharactere;
            //Mapper(entity);
        }

        public DbModelRepository(T entity, int idCharactere)
        {
            _context = new CyberContext();
            _context.Configuration.LazyLoadingEnabled = false;
            _idCharacter = idCharactere;
            //Mapper(entity);
        }
        public DbModelRepository(T entity)
        {
            _context = new CyberContext();
            _context.Configuration.LazyLoadingEnabled = false;
            //_idCharacter = idCharactere;
            //Mapper(entity);
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public TEntity Attach<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>
        {
            throw new NotImplementedException();
        }

        public TEntity AttachIfNot<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>
        {
            return _context.Set<TEntity>().Attach(entity);

        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>
        {
            return _context.Set<TEntity>().Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TResult Execute<TResult>(string functionName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll<TEntity>(bool noTracking = true) where TEntity : class, IModel<TEntity>
        {
            DbSet<TEntity> entityDbSet = _context.Set<TEntity>();

            return entityDbSet;
        }

       

        public int GetId<TEntity>(TEntity entity, string name) where TEntity : class, IModel<TEntity>
        {
            try
            {
                int id = GetAll<TEntity>().FirstOrDefault(t => t.Wording == name).Id;
                return id;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        public TEntity GetEntity<TEntity>(int id) where TEntity : class, IModel<TEntity>
        {
            try
            {
                TEntity entity = GetAll<TEntity>().FirstOrDefault(t => t.Id == id);
                return entity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

       
        private string GetIdFeature(int idSkill)
        {
            //int idFeature = GetAll<Skill>().FirstOrDefault(t => t.Id == idSkill).Wording;
            return GetAll<Skill>().FirstOrDefault(t => t.Id == idSkill).Wording;

        }


        public void Create<IModel>(T entity, IModel<T> characr, string name, string alias)
        {
            int id = GetId(entity, name);

            // Not found so add it
            if (id == 0)
            {
                entity.Wording = name;
                entity.Alias = alias;
                
                
                Add<T>(entity);
                Save();
                id = GetId(entity, name);
            }
            Id = id;
            //Mapper<T>(entity, value);
        }



        /// <summary>
        /// Create a new skill
        /// </summary>
        /// <typeparam name="ICharacteristic"></typeparam>
        /// <param name="entity"></param>
        /// <param name="charac"></param>
        /// <param name="name"></param>
        /// <param name="idFeature">Features dependance</param>
        /// <param name="idSpecialAbility">Special Ability dependance</param>
        public void Create<IModel>(T entity, IModel<T> charac, string name, string alias, int factor,int idFeature, int? idSpecialAbility)
        {
            int id = GetId(entity, name);

            // Not found so add entity
            if (id == 0)
            {
                if (entity is Skill)
                {
                    Skill skill = new Skill
                    {
                        Wording = name,
                        Alias = alias,
                        Factor = factor,
                        IdFeature = idFeature,
                        IdSpecialAbility = idSpecialAbility
                    };
                    Add(skill);
                    Save();
                    Id = GetId(skill, name);
                }
            }
        }

        public void Create<IModel>(T entity, IModel<T> charac, string name, string alias,int idCity)
        {
            int id = GetId(entity, name);

            if (id == 0)
            {
                if (entity is Area)
                {
                    Area area = new Area
                    {
                        Wording = name,
                        Alias = alias,
                        IdCity = idCity
                    };
                    Add(area);
                    Save();
                    Id = GetId(area, name);
                }
            }
        }

        public void CreateCorporation<IModel>(T entity, IModel<T> charac, string name, string alias,bool isGang = false, string color = null)
        {


            int id = GetId(entity, name);

            if (id == 0)
            {
                if (entity is Corporation)
                {
                    Corporation area = new Corporation
                    {
                        Wording = name,
                        Alias = alias,
                        IsGang = isGang
                    };
                    Add(area);
                    Save();
                    Id = GetId(area, name);
                }                
            }
        }

        

        public string GetFeature(string skillName)
        {
            int idSkill = GetId<Skill>(new Skill(), skillName);

            // IdSpecial not found, so not associated feature
            if (idSkill == 0)
            {
                return string.Empty;
            }
            return GetAll<Skill>().FirstOrDefault(t => t.Id == idSkill).Wording;
        }

        //private void Mapper<TEntity>(TEntity entity, int value) where TEntity : class, ICharacteristic<TEntity>
        //{

        //    //TEntity anotherEntity = Activator.CreateInstance<TEntity>();

        //    //Dictionary<object, object> setEntities = new Dictionary<object, object>()
        //    //{
        //    //    {new Features(),new AttributeFeature() }
        //    //};
        //    object destination;
        //    if (entity is Features)
        //    {
        //        destination = ToDestination<AttributeFeature>(value);
        //        DbAttributeRepository<AttributeFeature> repository = new DbAttributeRepository<AttributeFeature>(destination as AttributeFeature, _idCharacter);
        //        repository.Create(destination as AttributeFeature);
        //    }

        //    if (entity is SpecialAbility)
        //    {
        //        destination = ToDestination<AttributeSpecialAbility>(value);
        //        DbAttributeRepository<AttributeSpecialAbility> repository = new DbAttributeRepository<AttributeSpecialAbility>(destination as AttributeSpecialAbility, _idCharacter);
        //        repository.Create(destination as AttributeSpecialAbility);
        //    }

        //    if (entity is Skill)
        //    {
        //        destination = ToDestination<AttributeSkill>(value);
        //        DbAttributeRepository<AttributeSkill> repository = new DbAttributeRepository<AttributeSkill>(destination as AttributeSkill, _idCharacter);
        //        repository.Create(destination as AttributeSkill);
        //    }

        //    if (entity is Protection)
        //    {
        //        destination = ToDestination<AttributeProtection>(value);
        //        DbAttributeRepository<AttributeProtection> repository = new DbAttributeRepository<AttributeProtection>(destination as AttributeProtection, _idCharacter);
        //        repository.Create(destination as AttributeProtection);
        //    }



        //var retour = ToStatic<AttributeFeature>(setEntities);
        //var retour = ToDestination<AttributeFeature>(entity, Id, value);

        //foreach (var item in setEntities)
        //{

        //    Type type = item.Key.GetType();
        //    var retour = ToStatic<type>(setEntities.Values.FirstOrDefault())
        //}



        //MapperConfiguration cfgFrmEntity = null;
        //MapperConfiguration cfgCharacter = null;


        //AttributeFeature destination = null;
        ////DbAttributeRepository attributeRepository = new DbAttributeRepository();

        ////Type objDest = null;
        ////object objDest = null;

        //Characters srceCharacter = new Characters()
        //{
        //    IdCharactere = _idCharacter
        //};

        //switch (entity)
        //{
        //    case Features f:
        //        AttributeFeature attribute = new AttributeFeature();

        //        cfgFrmEntity = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Features, AttributeFeature>();
        //        });

        //        //cfgCharacter = new MapperConfiguration(cfg =>
        //        //{
        //        //    cfg.CreateMap<Characters, AttributeSkill>();
        //        //});

        //        Features srceEntity = new Features()
        //        {
        //            Id = this.Id,
        //        };

        //        IMapper mapperFrmEntity = cfgFrmEntity.CreateMapper();
        ////        IMapper mapperCharacter = cfgCharacter.CreateMapper();

        //AttributeFeature destFrmEntity = mapperFrmEntity.Map<Features, AttributeFeature>(srceEntity);
        //        //        //destination = mapperFrmEntity.Map<Features, AttributeFeature>(srceEntity);
        //        //        var other = mapperCharacter.Map<Characters, AttributeFeature>(srceCharacter);

        //        //return attribute;
        //        break;

        //    default:
        //        break;
        //}
        //return null;
        //MapperConfiguration cfgSkillToAttibute = new MapperConfiguration(cfg => cfg.CreateMap<Skill, AttributeSkill>());
        //MapperConfiguration cfgCharactereToAttibute = new MapperConfiguration(cfg => cfg.CreateMap<Characters, AttributeSkill>());
        //IMapper mapSkillToAtt = cfgSkillToAttibute.CreateMapper();
        //IMapper mapCharToAtt = cfgCharactereToAttibute.CreateMapper();

        //Skill frmSkill = new Skill();
        //AttributeSkill toAttribSkill = mapSkillToAtt.Map<Skill, AttributeSkill>(frmSkill);
        //}

        //private TEntity ToDestination<TEntity>(int value) where TEntity : class, IAttribute<TEntity>
        //{
        //    var entity = Activator.CreateInstance<TEntity>();

        //    entity.Id = this.Id;
        //    entity.IdCharactere = _idCharacter;
        //    entity.Value = value;
        //    entity.Factor = 1;
        //    entity.Acquired = 0;

        //    return entity;
        //}

        private void Save()
        {
            _context.SaveChanges();
        }

    }
}
