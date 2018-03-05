using HeroStatics.Business.Services;
using HeroStatics.Core.DataAccess;
using HeroStatics.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HeroStatics.Business.Managers.EntityFramework
{
    public class EfCategoryManager : ManagerBase<Category>, ICategoryServices
    {
        private readonly IRepository<Category> _dbContext;
        public EfCategoryManager(IRepository<Category> dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Category GetCategory(Expression<Func<Category, bool>> expression)
        {
            return Get(expression);
        }

        public int GetListCount()
        {
            return _dbContext.GetListCount();
        }
    }
}
