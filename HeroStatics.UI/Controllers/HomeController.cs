using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HeroStatics.Business.Services;
using HeroStatics.Entity.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HeroStatics.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeroServices _heroServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHeroServices heroServices, ICategoryServices categoryServices, IHostingEnvironment hostingEnvironment)
        {
            _heroServices = heroServices;
            _categoryServices = categoryServices;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View(_heroServices.GetQueryable(p => p.Category).ToList());
        }

        public IActionResult Category(int? categoryId)
        {
            if (categoryId == null || categoryId > _categoryServices.GetListCount())
            {
                return BadRequest("Geçersiz istek !!! ");
            }
            return View("Index", _heroServices.GetQueryable(p => p.Category).Where(p => p.CategoryId == categoryId).ToList());
        }
        public async Task<IActionResult> YeniHero()
        {

            Hero hero = new Hero
            {
                Ability = new Random().Next(0, 100),
                CategoryId = new Random().Next(1, _categoryServices.GetListCount() + 1),
                Name = FakeData.NameData.GetFirstName(),
                Power = new Random().Next(0, 100)
            };
            HttpClient client = new HttpClient();
            var response = await client.GetByteArrayAsync("https://loremflickr.com/g/350/250/hero");
            string path = _hostingEnvironment.WebRootPath + $"/Images/{hero.Name}.jpg";
            System.IO.File.WriteAllBytesAsync(path, response);
            hero.PictureUrl = $"/Images/{hero.Name}.jpg";
            TempData["mesaj"] = _heroServices.Insert(hero) ? "İşlem Başarılı" : "İşlem Başarısız";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> NewHero(Hero hero)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetByteArrayAsync("https://loremflickr.com/g/350/250/hero");
            string path = _hostingEnvironment.WebRootPath + $"/Images/{hero.Name}.jpg";
            System.IO.File.WriteAllBytesAsync(path, response);
            hero.PictureUrl = $"/Images/{hero.Name}.jpg";
            TempData["mesaj"] = _heroServices.Insert(hero) ? "İşlem Başarılı" : "İşlem Başarısız";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHero(int? id)
        {
            Hero hero;
            if (id.HasValue)
            {
                hero = _heroServices.GetHero(id.Value);
                string path = _hostingEnvironment.WebRootPath + $"/Images/{hero.Name}.jpg";
                bool durum = _heroServices.Delete(hero);
                if (durum)
                {
                    System.IO.File.Delete(path);
                }
                TempData["mesaj"] = durum ? "İşlem Başarılı" : "İşlem Başarısız";
                return RedirectToAction("Index");
            }
            else
            {
                var heroes = _heroServices.GetList();
                hero = heroes[new Random().Next(0, heroes.Count - 1)];
                string path = _hostingEnvironment.WebRootPath + $"/Images/{hero.Name}.jpg";

                var durum = _heroServices.Delete(hero);
                if (durum)
                {
                    System.IO.File.Delete(path);
                }
                TempData["mesaj"] = durum ? "İşlem Başarılı" : "İşlem Başarısız";
                return RedirectToAction("Index");
            }
         
        }

        public async Task<IActionResult> ApiDeneme()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetByteArrayAsync("https://loremflickr.com/g/350/250/hero");
            string path = _hostingEnvironment.WebRootPath + "/Images/deneme.jpg";
            System.IO.File.WriteAllBytesAsync(path, response);
            return RedirectToAction("Index");
        }

    }
}