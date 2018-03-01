using HeroStatics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroStatics.Entity.Concrete
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public virtual List<Hero> Heroes { get; set; }

    }
}
