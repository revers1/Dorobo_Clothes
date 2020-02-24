using ConsoleTEstFilters.Entity;
using DoroboShop.Models;
using DoroboShop.ModelsCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            List<ProductViewModel> Products = _context.dbProduct.Select(e => new ProductViewModel
            {
                Name = e.Name,
                Price=e.Price,
                Size=e.Size,
                Sale=e.Sale,
                Quantity=e.Quantity,
                Color=e.Color,
                Brand=e.Brand,
                Country=e.Country,
                Season=e.Season,
                Description=e.Description,
                DataCreate=e.DataCreate,
                CategoryId=e.CategoryId

            }).ToList();

            return View(Products);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {

            if (ModelState.IsValid)
            {
                _context.dbProduct.Add(new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Size = model.Size,
                    Sale = model.Sale,
                    Quantity = model.Quantity,
                    Color = model.Color,
                    Brand = model.Brand,
                    Country = model.Country,
                    Season = model.Season,
                    Description = model.Description,
                    DataCreate = model.DataCreate,
                    CategoryId = model.CategoryId

                });
                _context.SaveChanges();

                return RedirectToAction("Index", "Product");
            }
            else { return View(model); }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var temp = _context.dbProduct.FirstOrDefault(t => t.Id == id);
            EditProductViewModel model = new EditProductViewModel()
            {
                Id = temp.Id,
                Name = temp.Name,
                Price = temp.Price,
                Size = temp.Size,
                Sale = temp.Sale,
                Quantity = temp.Quantity,
                Color = temp.Color,
                Brand = temp.Brand,
                Country = temp.Country,
                Season = temp.Season,
                Description = temp.Description,
                DataCreate = temp.DataCreate,
                CategoryId = temp.CategoryId
            };

            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {

            if (ModelState.IsValid)
            {
               var foundProduct = _context.dbProduct.First(t => t.Id == model.Id);
                    foundProduct.Id = model.Id;
                    foundProduct.Name = model.Name;
                    foundProduct.Price = model.Price;
                    foundProduct.Size = model.Size;
                    foundProduct.Sale = model.Sale;
                    foundProduct.Quantity = model.Quantity;
                    foundProduct.Color = model.Color;
                    foundProduct.Brand = model.Brand;
                    foundProduct.Country = model.Country;
                    foundProduct.Season = model.Season;
                    foundProduct.Description = model.Description;
                    foundProduct.DataCreate = model.DataCreate;
                    foundProduct.CategoryId = model.CategoryId;
                _context.SaveChanges();


                return RedirectToAction("Index", "Product");
            }
            else { return View(model); }

        }



        public ActionResult Delete(int id)
        {

            _context.dbProduct.Remove(_context.dbProduct.FirstOrDefault(t => t.Id == id));
            _context.SaveChanges();


            return RedirectToAction("Index", "Product");

        }

    }
}