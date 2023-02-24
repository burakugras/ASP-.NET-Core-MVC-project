using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Controllers
{
    //[Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private readonly IMapper _mapper;

        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _productRepository = new ProductRepository();
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index() 
        {
            var products = _context.Products.ToList();
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        [Route("[controller]/[action]/{page}/{pageSize}",Name ="productpage")]
        public IActionResult Pages(int page,int pageSize)
        {
            var products = _context.Products.Skip((page-1)*pageSize).Take(3).ToList(); 

            ViewBag.page = page;
            ViewBag.pageSize = pageSize;

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }


        [Route("urunler/urun/{productid}",Name ="product")]
        public IActionResult GetById(int productId)
        {
            var product = _context.Products.Find(productId);
            return View(_mapper.Map<ProductViewModel>(product));
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
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 },
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){ Data="Mavi" ,Value="Mavi" },
                new(){ Data="Kırmızı" ,Value="Kırmızı" },
                new(){ Data="Sarı" ,Value="Sarı" }
            },"Value","Data");

            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {

            //if (!string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A"))
            //{
            //    ModelState.AddModelError(String.Empty, "Ürün ismi A harfi ile başlayamaz.");
            //}

            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 },
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){ Data="Mavi" ,Value="Mavi" },
                new(){ Data="Kırmızı" ,Value="Kırmızı" },
                new(){ Data="Sarı" ,Value="Sarı" }
            }, "Value", "Data");


            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges();

                    TempData["status"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty,"Ürün kaydedilirken bir hata meydana geldi. Lütfen daha sonra tekrar deneyiniz.");
                    return View();
                }
                
            }
            else
            {
                
                return View();
            }
            
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product= _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 },
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){ Data="Mavi" ,Value="Mavi" },
                new(){ Data="Kırmızı" ,Value="Kırmızı" },
                new(){ Data="Sarı" ,Value="Sarı" }
            }, "Value", "Data",product.Color);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            if (!ModelState.IsValid)
            {                 
                ViewBag.ExpireValue = updateProduct.Expire;
                ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1 },
                {"3 Ay",3 },
                {"6 Ay",6 },
                {"12 Ay",12 },
            };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){ Data="Mavi" ,Value="Mavi" },
                new(){ Data="Kırmızı" ,Value="Kırmızı" },
                new(){ Data="Sarı" ,Value="Sarı" }
            }, "Value", "Data", updateProduct.Color);

                return View();
            }

            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        
        [AcceptVerbs("GET","POST")]
        public IActionResult HasProductName(string Name)
        {
            var anyProduct= _context.Products.Any(x=> x.Name.ToLower()==Name.ToLower());

            if (anyProduct)
            {
                return Json("Kaydetmeye çalıştığınız ürün ismi veritabanında bulunmaktadır.");
            }
            else
            {
                return Json(true);
            }
        }
    }
}
