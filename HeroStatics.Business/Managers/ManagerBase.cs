using HeroStatics.Core.DataAccess;
using HeroStatics.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HeroStatics.Business.Managers
{
    public abstract class ManagerBase<TEntity> where TEntity : BaseEntity // Yani DB deki classlarıma yakın bir class olmalı.
    {
        private readonly IRepository<TEntity> _repository;
        public ManagerBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public List<TEntity> GetList()
        {
            return _repository.GetList();
        }

        public TEntity Get(Expression<Func<TEntity,bool>> expression)
        {
            return _repository.Get(expression);
        }

        public virtual bool Insert(TEntity entity)
        {
            return _repository.Insert(entity);
        }

        public bool Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public bool Delete(TEntity entity)
        {
            return _repository.Delete(entity);
        }

     
        public IQueryable<TEntity> GetQueryable(params Expression<Func<TEntity, object>>[] includes)
        {
            return _repository.GetQueryable(includes);
        }
    }
}
