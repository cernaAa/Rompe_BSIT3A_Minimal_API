using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPIDemo.Data;
using ProductAPIDemo.Models;

namespace ProductAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public ProductsController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get: api/products - Get all products records || Select * from products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }

        //Post: api/products - Create a new product record || Insert into products values(...)
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return Ok(product);
        }

        //Put: api/products/{id} - Update an existing product record || Update products set ... where id = ...

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _dbContext.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Product updated successfully" });
        }

        //Delete: api/products/{id} - Delete a product record || Delete from products where id = ...
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = await _dbContext.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            _dbContext.Products.Remove(existingProduct);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
