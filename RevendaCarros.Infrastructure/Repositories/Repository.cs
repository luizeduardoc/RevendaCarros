using Microsoft.EntityFrameworkCore;
using RevendaCarros.Domain.Entities;
using RevendaCarros.Domain.Repositories;
using System;
using System.Linq;

namespace RevendaCarros.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public Repository(RevendaCarrosContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public TEntity Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            dbSet.Add(entity);
            Commit();

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            dbSet.Update(entity);
            Commit();

            return entity;
        }

        public IQueryable<TEntity> Query()
        {
            return dbSet.AsNoTracking();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}