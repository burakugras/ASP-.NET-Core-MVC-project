using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Ornek : Controller
    {
        public IActionResult Index()
        {
            var productList = new List<Product2>()
            {
                new(){Id=1,Name="Kalem"},
                new(){Id=2,Name="Defter"},
                new(){Id=3,Name="Silgi"}
            };

            return View(productList);
        }

        public IActionResult Index2() 
        {
            var surName = TempData["name"];
            return View();
        }

        public IActionResult Index3()
        {
            //veri tabanına kaydetme işlemleri
            return RedirectToAction("Index","Ornek");

        }

        public IActionResult ParametreView(int id) 
        {

            return RedirectToAction("JsonResultParametre",new {id=id});
        }

        public IActionResult JSonResultParametre(int id)
        {
            return Json(new { id = id });
        }

        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }
        
        public IActionResult JSonResult() 
        { 
            return Json(new {id= 1,name="kalem",price=100});    
        }

        public IActionResult EmptyResult() 
        {
            return new EmptyResult();
        }
    }
}
