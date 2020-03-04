using ConsoleTEstFilters.Entity;
using DoroboShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            List<CategoryViewModelcs> Categories = _context.dbCategories.Select(e => new CategoryViewModelcs
            {
                Name = e.Name,
                ParentId=e.ParentId

            }).ToList();

            return View(Categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(CategoryViewModelcs model)
        {

            if (ModelState.IsValid)
            {
                _context.dbCategories.Add(new Category
                {
                    Name = model.Name,
                    ParentId = model.ParentId
                });
                _context.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            else { return View(model); }

        }

        public ActionResult Delete(int id)
        {

            _context.dbCategories.Remove(_context.dbCategories.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();


            return RedirectToAction("Index", "Category");

        }



    }
}