using HeroStatics.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroStatics.UI.ViewModels
{
    public class NewHeroViewModel
    {
        public Hero Hero { get; set; }
        public List<Category> Categories { get; set; }
    }
}
