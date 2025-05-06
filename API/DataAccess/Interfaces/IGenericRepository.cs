using System;
using System.Linq.Expressions;

namespace API.DataAccess.Interfaces;

    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        Task<T> GetWhere(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
    }
