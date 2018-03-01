using HeroStatics.Core.DataAccess;
using HeroStatics.Core.Entities;
using System;
using System.Collections.Generic;
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

        public TEntity Get(int id)
        {
            return _repository.Get(p => p.Id == id);
        }

        public bool Insert(TEntity entity)
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
    }
}
