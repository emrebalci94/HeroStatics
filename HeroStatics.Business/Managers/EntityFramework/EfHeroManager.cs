using HeroStatics.Business.Services;
using HeroStatics.Core.DataAccess;
using HeroStatics.Core.DataAccess.EntityFreamework;
using HeroStatics.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroStatics.Business.Managers.EntityFramework
{
    public class EfHeroManager : ManagerBase<Hero>, IHeroServices
    {
        private readonly IRepository<Hero> _dbContext;
        public EfHeroManager(IRepository<Hero> dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Hero GetHero(int id)
        {
            return Get(p => p.Id == id);
        }

        public override bool Insert(Hero entity)
        {
            var sonuc = Get(p => p.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase)) == null ? base.Insert(entity) : false;
            return sonuc;
        }

        //Listeleme ekleme silme güncellme zzaten basede var  burda IHeroServices den gelen şeyleri yapıcaz.
    }
}
