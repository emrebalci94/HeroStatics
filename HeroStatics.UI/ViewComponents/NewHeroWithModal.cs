using HeroStatics.Business.Services;
using HeroStatics.Entity.Concrete;
using HeroStatics.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroStatics.UI.ViewComponents
{
    public class NewHeroWithModal : ViewComponent
    {
        private readonly IHeroServices _heroServices;
        private readonly ICategoryServices _categoryServices;
        public NewHeroWithModal(IHeroServices heroServices, ICategoryServices categoryServices)
        {
            _heroServices = heroServices;
            _categoryServices = categoryServices;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new NewHeroViewModel
            {
                Hero = new Hero(),
                Categories = _categoryServices.GetList()

            };
            return View(model);
        }
       
    }
}
