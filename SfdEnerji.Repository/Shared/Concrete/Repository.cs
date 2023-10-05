using Microsoft.EntityFrameworkCore;
using SfdEnerji.Data;
using SfdEnerji.Models;
using SfdEnerji.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SfdEnerji.Repository.Shared.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet =_context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.IsActive = false;
            entity.ModifitedDate = DateTime.Now;
            _dbSet.Update(entity);
        }
        public void DeLeteById(int id)
        {
            T entity = _dbSet.Find(id);
            entity.IsDeleted = true;
            entity.IsActive=false;
            entity.ModifitedDate = DateTime.Now;
            _dbSet.Update(entity);
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => x.IsDeleted==false);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return GetAll().Where(filter);
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(x=>x.IsDeleted==false).FirstOrDefault(filter);
        }
        public void Update(T entity)
        {
            entity.ModifitedDate= DateTime.Now;
            _dbSet.Update(entity);
        }
    }
}
