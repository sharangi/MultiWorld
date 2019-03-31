using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MultiWorld.DAL
{

    public interface IRepository<TEntity> where TEntity : class
    {        
        IQueryable<TEntity> GetAll();

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Commit();
    }
     public class Repository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
