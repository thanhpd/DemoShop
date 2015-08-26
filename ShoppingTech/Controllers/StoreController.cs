using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShoppingTech.Service;

namespace ShoppingTech.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreService _store;
        public StoreController() : this(new StoreService()) {}

        public StoreController(StoreService service)
        {
            _store = service;
        }

        // GET: Store
        public async Task<ActionResult> Index()
        {
            var categories = await _store.GetCategoriesAsync();
            return View(categories);
        }

        public async Task<ActionResult> Browse(string categoryName)
        {
            var products = await _store.GetProductsForCategoryAsync(categoryName);
            return View(products);
        }

        public ActionResult Details(int Id)
        {
            return View();
        }
    }
}