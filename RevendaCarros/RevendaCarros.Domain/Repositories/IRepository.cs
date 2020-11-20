using System;
using System.Linq;

namespace LibraryManager.Domain.Repositories.Core
{
    public interface IRepository<TEntity> : IDisposable
    {
        public bool Insert(TEntity entity);
        public IQueryable<TEntity> Query();

    }
}