using HeroStatics.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HeroStatics.Business.Services
{
    public interface ICategoryServices
    {
        Category GetCategory(Expression<Func<Category,bool>> expression);
        int GetListCount();
        bool Insert(Category category);
        List<Category> GetList();
    }
}
