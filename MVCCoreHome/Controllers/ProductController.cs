using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreHome.Models;

namespace MVCCoreHome.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController

        public static List<Product> Products = new List<Product>
        {

          new Product { Id = 101, Name = "Samsung S20", Number = "G1032",Price=250 , Discription="Samsung Galaxy ",CategoryID=1 },
          new Product { Id = 102, Name = "Hp ", Number = "U888" ,Price=450 ,Discription="Hp laptop",CategoryID=2},
          new Product { Id = 103, Name = " Honda ", Number = "203k", Price=1500 ,Discription="Honda civc 2002",CategoryID=3 }

        };

        public static List<Category> categories = new List<Category>
        { 
            new Category{ id=1,Name="Phone"},
            new Category{ id=2,Name="Laptop"},
            new Category{ id=3,Name="Car"}

        };




        private Product GetProduct(int id)
        {
            var model = Products.Where(x => x.Id == id).FirstOrDefault();
            if (model != null)
            {
                return model;
            }
            else
            {
                return new Product();
            }
        }
        public ActionResult Index()
        {
            
            var ProductCategory = (from p in Products
                                   join c in categories on p.CategoryID equals c.id
                                   select new Product
                                   {
                                       Id = p.Id,
                                       Name = p.Name,
                                       Price = p.Price,
                                       Discription = p.Discription,
                                       Number = p.Number,
                                       CategoryID=p.CategoryID,
                                       Category=c
                                   }).ToList();
            return View(ProductCategory);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var ProductCategoryModel = (from p in Products
                                   join c in categories on p.CategoryID equals c.id
                                   select new Product
                                   {
                                       Id = p.Id,
                                       Name = p.Name,
                                       Price = p.Price,
                                       Discription = p.Discription,
                                       Number = p.Number,
                                       CategoryID = p.CategoryID,
                                       Category = c
                                   }).FirstOrDefault(x =>x.Id==id);
           
            return View(ProductCategoryModel);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.categoriesList = categories;

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
               // var products = new List<Product>();

                Products.Add(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.categoriesList = categories;

            var model = Products.Where(x => x.Id == id).FirstOrDefault();
            if(model != null)
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Product product)
        {
            try
            {
                var model = Products.Where(x => x.Id == id).FirstOrDefault();
                if(model != null)
                {
                    model.Id = product.Id;
                    model.Name = product.Name;
                    model.Number = product.Number;
                    model.Price = product.Price;
                    model.Discription = product.Discription;
                    model.CategoryID = product.CategoryID;

                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = GetProduct(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var model = GetProduct(id);
                if (model != null)
                {
                    Products.Remove(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
