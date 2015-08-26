using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingTech.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("DefaultConnection")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    internal class DbInitializer : MigrateDatabaseToLatestVersion<StoreContext, Migrations.Configuration>
    {

    }
}