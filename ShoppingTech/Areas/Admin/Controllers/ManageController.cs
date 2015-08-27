using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShoppingTech.Service;

namespace ShoppingTech.Areas.Admin.Controllers
{
    public class ManageController : Controller
    {
        private readonly StoreService _store;
        public ManageController() : this(new StoreService()) {}

        public ManageController(StoreService service)
        {
            _store = service;
        }

        // GET: Admin/Manage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public async Task<ActionResult> Category()
        {
            var categories = await _store.GetCategoriesAsync();
            if (!categories.Any()) return HttpNotFound();
            return View(categories);
        }

        public ActionResult Order()
        {
            return View();
        }
    }
}