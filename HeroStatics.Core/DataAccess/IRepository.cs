using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HeroStatics.Core.DataAccess
{
    public interface IRepository<T> where T : class
    {
     

        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        List<T> GetList();
        List<T> GetList(Expression<Func<T,bool>> expression);

        T Get(Expression<Func<T, bool>> expression);


        IQueryable<T> GetQueryable();
        /// <summary>
        /// Queryable getirirken ayrıca gelmesini istediğiniz (birbiriyle ilişkili) tabloyu getirir.
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> GetQueryable(params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> where);
        IQueryable<T> GetQueryableOrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);

        int GetListCount();
    }
}
