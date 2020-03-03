using DoroboShop.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoroboShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
       
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());


        //GET: AdminPanel/Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            var list = _context.Users.ToList();


            return View(list);
        }

        public ActionResult BanUser(string id)
        {
            _userManager.SetLockoutEnabled(id, true);
            DateTime dt = new DateTime(2020, 2, 27);
            _userManager.SetLockoutEndDate(id, dt);
            return RedirectToAction("Index");
        }

        public ActionResult UnbanUser(string id)
        {
            _userManager.SetLockoutEnabled(id, false);
            DateTime date1 = new DateTime(2020, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0);
            _userManager.SetLockoutEndDate(id, date1);
            return RedirectToAction("Index");
        }



    }
}
    
