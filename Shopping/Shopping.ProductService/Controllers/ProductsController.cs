using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Model;
using Shopping.ProductService.Data;

namespace Shopping.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }
    }
}
