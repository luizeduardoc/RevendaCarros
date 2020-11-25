using System;
using System.Linq;

namespace LibraryManager.Domain.Repositories.Core
{
    public interface IRepository<TEntity> : IDisposable
    {
        public TEntity Insert(TEntity entity);
        public IQueryable<TEntity> Query();

    }
}