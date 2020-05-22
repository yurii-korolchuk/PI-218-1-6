using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DAL.Repository
{
    internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;

        private readonly DbSet<TEntity> _dataBaseSet;

        public GenericRepository(Context context)
        {
            _context = context;
            _dataBaseSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dataBaseSet.Add(item);
        }

        public TEntity FindById(int id)
        {
            return _dataBaseSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dataBaseSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dataBaseSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity GetOne(Func<TEntity, bool> predicate)
        {
            return _dataBaseSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Remove(TEntity item)
        {
            try
            {
                _dataBaseSet.Remove(item);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Data cannot be removed. Removable item is null.");
            }
        }

        public void Update(TEntity item)
        {
            _context.Set<TEntity>().AddOrUpdate(item);
            _context.SaveChanges();
        }
    }
}
