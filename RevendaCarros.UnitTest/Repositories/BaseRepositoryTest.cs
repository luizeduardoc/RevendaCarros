using Microsoft.EntityFrameworkCore;
using RevendaCarros.Infrastructure;
using System;
using System.Collections.Generic;

namespace RevendaCarros.UnitTest.Repositories
{
    public class BaseRepositoryTest
    {
        private static readonly DbContextOptionsBuilder<RevendaCarrosContext> DbContextOptionsBuilder = new DbContextOptionsBuilder<RevendaCarrosContext>();
        public RevendaCarrosContext DbContext { get; set; }

        public BaseRepositoryTest()
        {
            var options = DbContextOptionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            DbContext = new RevendaCarrosContext(options);
        }

        public void AddRange<T>(IEnumerable<T> list)
            where T : class
        {
            DbContext.Set<T>().AddRange(list);
            DbContext.SaveChanges();
        }
    }
}
