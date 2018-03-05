using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroStatics.Business.Services;
using HeroStatics.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeroStatics.UI.ViewComponents
{
    public class Navbar : ViewComponent
    {
        private readonly ICategoryServices _categoryServices;
        public Navbar(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new NavbarViewModel
            {
                Categories = _categoryServices.GetList(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["categoryId"])
            };
            return View(model);
        }
    }
}
