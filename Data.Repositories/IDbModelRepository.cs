using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbModelRepository<T> : IDisposable where T : class, IModel<T>
    {
        IQueryable<TEntity> GetAll<TEntity>(bool noTracking = true) where TEntity : class, IModel<TEntity>;
        TEntity Add<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>;


        TEntity Delete<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>;
        TEntity Attach<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>;
        TEntity AttachIfNot<TEntity>(TEntity entity) where TEntity : class, IModel<TEntity>;

        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        TResult Execute<TResult>(string functionName, params object[] parameters);


        int GetId<TEntity>(TEntity entity, string name) where TEntity : class, IModel<TEntity>;
    }
}
