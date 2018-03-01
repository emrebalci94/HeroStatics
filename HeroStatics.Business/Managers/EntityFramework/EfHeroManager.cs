using HeroStatics.Business.Managers;
using HeroStatics.Business.Services;
using HeroStatics.Core.DataAccess;
using HeroStatics.Core.DataAccess.EntityFreamework;
using HeroStatics.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroStatics.Business.EntityFramework.Managers
{
    public class EfHeroManager : ManagerBase<Hero>, IHeroServices
    {
        private readonly IRepository<Hero> _dbContext;
        public EfHeroManager(IRepository<Hero> dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        //Listeleme ekleme silme güncellme zzaten basede var  burda IHeroServices den gelen şeyleri yapıcaz.
    }
}
