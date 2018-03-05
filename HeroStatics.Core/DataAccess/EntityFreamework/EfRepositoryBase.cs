using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HeroStatics.Core.DataAccess.EntityFreamework
{
    public class EfRepositoryBase<T> : IRepository<T> where T : class
    {
        
        private DbSet<T> Table { get; }
        private readonly DbContext _dbContext;
        public EfRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            Table = _dbContext.Set<T>();
        }


        public IQueryable<T> GetQueryable()
        {
            return Table;
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return Table.FirstOrDefault(expression);
        }

        public List<T> GetList()
        {
            return Table.ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression).ToList();
        }

        public bool Insert(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public IQueryable<T> GetQueryableOrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            return isDesc ? Table.OrderByDescending(orderBy)
                :Table.OrderBy(orderBy);
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> where)
        {
            return Table.Where(where);
        }

        private bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch( Exception ex)
            {
                // TODO: Log Exceptions
                return false;
            }
        }

        public int GetListCount()
        {
            return Table.Count();
        }

        public IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includes)
        {
            var query = GetQueryable();  //Aggrate methodu Queryable beklediği için direk Table ı veremedik.
            return includes != null ?
                 includes.Aggregate(query, (current, include) => current.Include(include)) : query; //Aggregate methodu ilgili Queryable a parametreden gelen includeları otomatik basıyo.
        }
    }
}
