using System.Collections.Generic;
using System.Linq;
using dotNetApiExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dotNetApiExample.Controllers
{
    [Route("api")]
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
        public IEnumerable<Product> GetAll()
        {
            _logger.LogInformation($"Executing GET request to endpoint '{ProductEndpoints.GetAll}'");
            return _myDbContext.Products.ToList();
        }

        // GET api/products/5
        [HttpGet(ProductEndpoints.GetOne)]
        public Product GetOne(long productId)
        {
            _logger.LogInformation($"Executing GET request to endpoint '{ProductEndpoints.GetOne}'");
            return _myDbContext.Products.Find(productId);
        }

        // POST api/products
        [HttpPost(ProductEndpoints.Post)]
        public Product Post([FromBody] Product resource)
        {
            _logger.LogInformation($"Executing POST request to endpoint '{ProductEndpoints.Post}'");
            _myDbContext.Products.Add(resource);
            _myDbContext.SaveChanges();
            return resource;
        }

        // PUT api/products
        [HttpPut(ProductEndpoints.Put)]
        public Product Put([FromBody] Product resource)
        {
            _logger.LogInformation($"Executing PUT request to endpoint '{ProductEndpoints.Put}'");
            _myDbContext.Entry(resource).State = EntityState.Modified;
            _myDbContext.SaveChanges();
            return resource;
        }

        // DELETE api/products/5
        [HttpDelete(ProductEndpoints.Delete)]
        public void Delete(long productId)
        {
            _logger.LogInformation($"Executing DELETE request to endpoint '{ProductEndpoints.Delete}'");
            var resource = _myDbContext.Products.Find(productId);
            _myDbContext.Products.Remove(resource);
            _myDbContext.SaveChanges();
        }
    }
}
