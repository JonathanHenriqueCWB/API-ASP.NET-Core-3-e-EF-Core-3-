using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.models;
using Repository.Data;

namespace TesteEf.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        #region Get default
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] Context context)
        {
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }
        #endregion
        #region Post Default
        public async Task<ActionResult<Product>> Post([FromServices]Context context, [FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        } 
        #endregion
        #region Get By Id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] Context context, int id)
        {
            var product = await context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
        #endregion
        #region Get By Categories
        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory([FromServices] Context context, int id)
        {
            var product = await context.Products
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.CategoryId == id) // Nome da chava estrangeira definida na classe
                .ToListAsync();
            return product;
        }
        #endregion
    }
}