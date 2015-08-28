using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using ShoppingTech.DAL;
using ShoppingTech.Helper;

namespace ShoppingTech.Areas.Admin.Controllers
{
    public class CategoriesController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: api/Categories
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> GetCategory(Guid id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory(Guid id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            db.Entry(category).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }        

        // POST: api/Categories        
        public async Task<IHttpActionResult> PostCategory()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Resources/img");
            var provider = new CustomMultipartFormDataStreamProvider(root);

            try
            {
                //read content into a buffer
                Request.Content.LoadIntoBufferAsync().Wait();                

                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);

                var categoryName = "notfound";

                if (provider.FormData.AllKeys.Contains("cat-name"))
                {
                    categoryName = provider.FormData.GetValues("cat-name")[0];
                }

                var fileName = FileNameHelper.GetFileNameFromLocalPath(provider.FileData[0].LocalFileName);
                var path = WebConfigurationManager.AppSettings["ImageUrlPath"];
                Category category = new Category
                {
                    Name = categoryName,
                    ImageUrl = String.Format("{0}/{1}", path, fileName)
                };
                db.Categories.Add(category);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);                          
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public async Task<IHttpActionResult> DeleteCategory(Guid id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(Guid id)
        {
            return db.Categories.Count(e => e.CategoryId == id) > 0;
        }
    }
}