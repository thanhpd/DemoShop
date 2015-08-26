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

        public async Task<ActionResult> Browse(string id)
        {
            var products = await _store.GetProductsForCategoryAsync(id);
            ViewBag.ListCat = await _store.GetCategoriesAsync();

            if (!products.Any()) return HttpNotFound();

            ViewBag.CategoryName = id;
            return View(products);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var product = await _store.GetProductByIdAsync(id);
            ViewBag.ListCat = await _store.GetCategoriesAsync();

            if (product == null) return HttpNotFound();

            return View(product);
        }
    }
}