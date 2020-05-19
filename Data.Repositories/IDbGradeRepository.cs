using Data.Entities.Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbGradeRepository : IDisposable
    {
        IQueryable<Grade> GetAll(bool noTracking = true);
        Grade Add(Grade grade);


        Grade Delete(Grade grade);
        Grade Attach(Grade grade);
        Grade AttachIfNot(Grade grade);

        int Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);

        TResult Execute<TResult>(string functionName, params object[] parameters);


        int GetId(string category,int quatity);
    }
}
