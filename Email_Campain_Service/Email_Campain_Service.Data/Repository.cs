using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email_Campain_Service.Data
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _dbContext;
        private DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual void Add(T entity) => _dbSet.Add(entity);

        public IEnumerable<T> GetAllItem()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
}
