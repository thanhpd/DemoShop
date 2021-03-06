﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ShoppingTech.DAL;

namespace ShoppingTech.Service
{
    public class StoreService
    {
        private readonly StoreContext _db;

        public StoreService() : this(new StoreContext()) { }

        public StoreService(StoreContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _db.Categories.OrderBy(c => c.Name).ToArrayAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsForCategoryAsync(string category)
        {
            return await _db.Products.Include("Category").Where(p => p.Category.Name == category).ToArrayAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _db.Products.Where(p => p.ProductId == id).SingleOrDefaultAsync();
        }
    }
}