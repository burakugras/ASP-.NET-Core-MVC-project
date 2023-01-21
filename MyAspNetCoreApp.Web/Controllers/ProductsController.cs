using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context)
        {
            _productRepository= new ProductRepository();

            _context = context;

            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product { Name = "Kalem 1", Price = 10, Stock = 100, Color = "Red" });
            //    _context.Products.Add(new Product { Name = "Kalem 2", Price = 15, Stock = 200, Color = "Blue" });
            //    _context.Products.Add(new Product { Name = "Kalem 3", Price = 20, Stock = 300, Color = "Purple" });

            //    _context.SaveChanges();
            //}
            

        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Remove(int id) 
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            //Request Header-Body

            //1. Yöntem
            
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock= int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color= HttpContext.Request.Form["Color"].ToString();

            //2. Yöntem
            //Product newProduct=new Product() { Name=Name,Price=Price, Color=Color, Stock = Stock };
            
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product= _context.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct)
        {
            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
