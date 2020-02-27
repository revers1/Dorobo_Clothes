using ConsoleTEstFilters.Entity;
using DoroboShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class FilterValueController : Controller
    {
        // GET: FilterValue
        private ApplicationDbContext _context;

        public FilterValueController()
        {
            _context = new ApplicationDbContext();
        }


        public ActionResult Index()
        {
            List<FilterValueViewModel> Filters = _context.dbFilterValue.Select(e => new FilterValueViewModel
            {
                Name = e.Name

            }).ToList();

            return View(Filters);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FilterNameViewModel model)
        {

            if (ModelState.IsValid)
            {
                _context.dbFilterValue.Add(new FilterValue
                {
                    Name = model.Name
                });
                _context.SaveChanges();

                return RedirectToAction("Index", "FilterValue");
            }
            else { return View(model); }

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            _context.dbFilterValue.Remove(_context.dbFilterValue.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();


            return RedirectToAction("Index", "FilterValue");

        }

    }
}