using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroStatics.Business.Services;
using HeroStatics.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HeroStatics.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeroServices _heroServices;
        public HomeController(IHeroServices heroServices)
        {
            _heroServices = heroServices;
        }
        public IActionResult Index()
        {
            return View(_heroServices.GetList());
        }

        public IActionResult YeniHero()
        {
            Hero hero = new Hero
            {
                Ability = new Random().Next(0, 100),
                Category = new Category() { Name = "Deneme" },
                Name = "Deneme",
                Power = new Random().Next(0, 100)
            };
            TempData["mesaj"] = _heroServices.Insert(hero) ? "İşlem Başarılı" : "İşlem Başarısız";
            return RedirectToAction("Index");
        }
    }
}