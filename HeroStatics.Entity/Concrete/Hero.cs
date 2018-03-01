using HeroStatics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroStatics.Entity.Concrete
{
    public class Hero : BaseEntity
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Ability { get; set; }
    }
}
