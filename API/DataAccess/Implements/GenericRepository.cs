using System;
using System.Linq.Expressions;
using API.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Implements;

    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {


        protected readonly InventoryDbContext _context;

        protected GenericRepository(InventoryDbContext context)
        {
            _context = context;

        }
        public void Add(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<T> GetWhere(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            var query = _context.Set<T>().AsQueryable();
            if (include != null && include.Count() > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return await query.Where(where).FirstOrDefaultAsync();
        }
    }
