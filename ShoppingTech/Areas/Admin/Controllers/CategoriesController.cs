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
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: api/Categories
        [HttpGet]
        [Route("GetCategories")]
        public IQueryable<Category> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        [HttpGet]
        [Route("GetCategory")]
        public async Task<IHttpActionResult> GetCategory(Guid id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Categories/5
        [ResponseType(typeof(void))]
        [HttpPost]
        [Route("EditCategory")]
        public async Task<IHttpActionResult> EditCategory()
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != category.CategoryId)
            //{
            //    return BadRequest();
            //}

            //db.Entry(category).State = EntityState.Modified;

            //try
            //{
            //    await db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CategoryExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
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

                var categoryName = Extraction.ExtractValue("cat-name", provider.FormData);
                var id = Guid.Parse(Extraction.ExtractValue("cat-id", provider.FormData));

                if (CategoryExists(id))
                {
                    var category = await db.Categories.FindAsync(id);
                    category.Name = categoryName;
                    if (provider.FileData.Any())
                    {
                        var fileName = FileNameHelper.GetFileNameFromLocalPath(provider.FileData[0].LocalFileName);
                        var path = WebConfigurationManager.AppSettings["ImageUrlPath"];
                        category.ImageUrl = String.Format("{0}/{1}", path, fileName);
                    }
                    db.Entry(category).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }        

        // POST: api/Categories/CreateCategory
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IHttpActionResult> CreateCategory()
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

                var categoryName = Extraction.ExtractValue("cat-name", provider.FormData);

                var fileName = FileNameHelper.GetFileNameFromLocalPath(provider.FileData[0].LocalFileName);
                var path = WebConfigurationManager.AppSettings["ImageUrlPath"];
                Category category = new Category
                {
                    Name = categoryName,
                    ImageUrl = String.Format("{0}/{1}", path, fileName)
                };
                db.Categories.Add(category);
                await db.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IHttpActionResult> DeleteCategory(Guid id)
        {
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            string root = HttpContext.Current.Server.MapPath("~/");
            FileHelper.DeleteFile(root + category.ImageUrl);

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