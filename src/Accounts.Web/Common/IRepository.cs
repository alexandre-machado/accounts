using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Repository
{
    public interface IRepository
    {
        IQueryable<T> Query<T>() where T : class;

        T Insert<T>(T entity) where T : class;

        T Update<T>(T entity) where T : class;

        T AddOrUpdate<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void Delete<T>(int id) where T : class;

        T GetById<T>(int id, bool reload = false) where T : class;

        T GetByIdOrNew<T>(int id) where T : class, new();

        IList<T> GetByIds<T>(IList<int> ids) where T : class;

        bool HasRecord<T>(Expression<Func<T, bool>> condition) where T : class;

        int SaveChanges();
    }
}