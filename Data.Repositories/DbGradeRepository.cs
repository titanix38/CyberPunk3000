using Data.Context;
using Data.Entities.Enterprise;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DbGradeRepository : IDbGradeRepository
    {
        protected CyberContext _context;
        public int Id { get; private set; }


        public DbGradeRepository()
        {
            _context = new CyberContext();
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public Grade Add(Grade grade)
        {
            return _context.Set<Grade>().Add(grade);

        }

        private int GetId(string category, int quantity)
        {
            try
            {
                int id = GetAll().FirstOrDefault(g => g.Category == category && g.Quantity == quantity).Id;
                return id;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        private IQueryable<Grade> GetAll(bool noTracking = true)
        {
            DbSet<Grade> entityDbSet = _context.Set<Grade>();

            return entityDbSet;

        }

        public Grade Attach(Grade grade)
        {
            throw new NotImplementedException();
        }

        public Grade AttachIfNot(Grade grade)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Grade Delete(Grade grade)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(string functionName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Create(string category, int quantity, int resource, int salary)
        {
            int idGrade = GetId(category, quantity);

            if (idGrade == 0)
            {
                Grade grade = new Grade()
                {
                    Category = category,
                    Quantity = quantity,
                    Resource = resource,
                    Salary = salary
                };
                Add(grade);
                Save();
                Id = GetId(category, quantity);
            }
        }
        private void Save()
        {
            _context.SaveChanges();
        }
        #region IDisposable Support
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).
                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        // ~DbGradeRepository() {
        //   // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
        //   Dispose(false);
        // }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            // Ne modifiez pas ce code. Placez le code de nettoyage dans Dispose(bool disposing) ci-dessus.
            Dispose(true);
            // TODO: supprimer les marques de commentaire pour la ligne suivante si le finaliseur est remplacé ci-dessus.
            // GC.SuppressFinalize(this);
        }

        IQueryable<Grade> IDbGradeRepository.GetAll(bool noTracking)
        {
            throw new NotImplementedException();
        }

        int IDbGradeRepository.GetId(string category, int quatity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
