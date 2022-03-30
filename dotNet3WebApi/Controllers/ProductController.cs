using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetApiExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dotNetApiExample.Controllers
{
    [Route("my-api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly MyDbContext _myDbContext;

        public ProductController(ILogger<ProductController> logger, MyDbContext myDbContext)
        {
            _logger = logger;
            _myDbContext = myDbContext;
        }

        // GET: api/products
        [HttpGet(ProductEndpoints.GetAll)]
        public async Task<IEnumerable<Product>> GetAll(
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize,
            [FromQuery] string searchValue
        )
        {
            _logger.LogInformation($"Executing GET request to endpoint '{ProductEndpoints.GetAll}'");
            int fPageNumber = pageNumber ?? 1;
            int fPageSize = pageSize ?? 10;
            string fSearchValue = searchValue == null ? "%%" : $"%{searchValue.Trim().ToUpper()}%";
            int offsetValue = (fPageNumber - 1) * fPageSize;
            return await _myDbContext.Products.FromSqlInterpolated($@"
                select *
                from dbo.product p
                where p.name like {fSearchValue}
                order by p.product_id desc
                offset {offsetValue} rows fetch next {fPageSize} rows only
            ").ToListAsync();
        }

        // GET api/products/5
        [HttpGet(ProductEndpoints.GetOne)]
        public async Task<ActionResult<Product>> GetOne(long productId)
        {
            _logger.LogInformation($"Executing GET request to endpoint '{ProductEndpoints.GetOne}'");
            Product resource = await _myDbContext.Products.FindAsync(productId);
            if (resource == null)
            {
                return BadRequest("Resource not found");
            }
            return Ok(resource);
        }

        // POST api/products
        [HttpPost(ProductEndpoints.Post)]
        public async Task<ActionResult<Product>> Post([FromBody] Product resource)
        {
            _logger.LogInformation($"Executing POST request to endpoint '{ProductEndpoints.Post}'");
            if (resource.ProductId != null)
            {
                return BadRequest("Property 'productId' should be sent as null");
            }
            _myDbContext.Products.Add(resource);
            await _myDbContext.SaveChangesAsync();
            return Ok(resource);
        }

        // PUT api/products
        [HttpPut(ProductEndpoints.Put)]
        public async Task<ActionResult<Product>> Put([FromBody] Product resource)
        {
            _logger.LogInformation($"Executing PUT request to endpoint '{ProductEndpoints.Put}'");
            if (resource.ProductId == null)
            {
                return BadRequest("Property 'productId' must not be sent as null");
            }
            Product serverResource = await _myDbContext.Products.FindAsync(resource.ProductId);
            if (serverResource == null)
            {
                return BadRequest("Resource not found");
            }
            serverResource.ProductId = resource.ProductId;
            serverResource.Name = resource.Name;
            serverResource.Price = resource.Price;
            serverResource.Stock = resource.Stock;
            serverResource.Unit = resource.Unit;
            serverResource.Expiration = resource.Expiration;
            await _myDbContext.SaveChangesAsync();
            return Ok(serverResource);
        }

        // DELETE api/products/5
        [HttpDelete(ProductEndpoints.Delete)]
        public async Task<IActionResult> Delete(long productId)
        {
            _logger.LogInformation($"Executing DELETE request to endpoint '{ProductEndpoints.Delete}'");
            Product resource = await _myDbContext.Products.FindAsync(productId);
            if (resource == null)
            {
                return BadRequest("Resource not found");
            }
            _myDbContext.Products.Remove(resource);
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
