using HeroStatics.Core.DataAccess;
using HeroStatics.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HeroStatics.Business.Services
{
    public interface IHeroServices
    {
        //ManagerBase de zaten bunlar var fakat control tarafından ulaşmak istiyorsak yazmamız gerekicek

        bool Insert(Hero hero);
        bool Update(Hero hero);
        bool Delete(Hero hero);
        List<Hero> GetList();
        Hero GetHero(int id);
        /// <summary>
        /// Queryable getirirken ayrıca gelmesini istediğiniz (birbiriyle ilişkili) tabloyu getirir.
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<Hero> GetQueryable(params Expression<Func<Hero, object>>[] includes);

        //Managerbase de olmayan şeyler buraya girilicek.Örnek atıyorum sadece heroların adını dönen method gibi bişi.
    }
}
