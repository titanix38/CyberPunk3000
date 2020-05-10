using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbCharacterizeRepository<T> : IDisposable where T : class, ICharacteristic<T>
    {
        IQueryable<TEntity> GetAll<TEntity>(bool noTracking = true) where TEntity : class, ICharacteristic<TEntity>;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>;


        TEntity Delete<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>;
        TEntity Attach<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>;
        TEntity AttachIfNot<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>;

        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        TResult Execute<TResult>(string functionName, params object[] parameters);


        int GetId<TEntity>(TEntity entity, string name) where TEntity : class, ICharacteristic<TEntity>;
    }
}
