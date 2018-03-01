using HeroStatics.Core.DataAccess;
using HeroStatics.Entity.Concrete;
using System;
using System.Collections.Generic;
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


        //Managerbase de olmayan şeyler buraya girilicek.Örnek atıyorum sadece heroların adını dönen method gibi bişi.
    }
}
