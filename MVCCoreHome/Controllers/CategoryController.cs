using Microsoft.AspNetCore.Mvc;
using MVCCoreHome.Models;

namespace MVCCoreHome.Controllers
{
    public class CategoryController : Controller
    {

        private Category GetCategory(int id)
        {
            var model = categories.Where(x => x.id == id).FirstOrDefault();
            if (model != null)
            {
                return model;
            }
            else
            {
                return new Category();
            }
        }

        public static List<Category> categories = new List<Category>
        {
            new Category{ id=1,Name="Phone"},
            new Category{ id=2,Name="Laptop"},
            new Category{ id=3,Name="Car"}

        };

        public IActionResult Index()
        {
            return View(categories);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                 var categories = new List<Category>();
                categories.Add(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = categories.FirstOrDefault(x => x.id == id);
            if(model != null)
            {
                return View("Create", model);
            }
            return RedirectToAction(nameof(Index));
        }


        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Category category)
        {
            try
            {
                var model = categories.Where(x => x.id == id).FirstOrDefault();
                if (model != null)
                {
                    model.id = category.id;
                    model.Name = category.Name;
                   
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var model = GetCategory(id);
            return View(model);
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var model = GetCategory(id);
                if (model != null)
                {
                    categories.Remove(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }
        public ActionResult Details(int id)
        {
           

            return View(categories);
        }
    }
}
