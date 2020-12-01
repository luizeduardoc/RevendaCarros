using System;
using System.Linq;

namespace RevendaCarros.Domain.Repositories
{
    public interface IRepository<TEntity> : IDisposable
    {
        public TEntity Insert(TEntity entity);
        public IQueryable<TEntity> Query();

    }
}