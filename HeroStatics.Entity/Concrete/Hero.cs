using HeroStatics.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroStatics.Entity.Concrete
{
    public class Hero : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Ability { get; set; }
        public string PictureUrl { get; set; }
    }
}
