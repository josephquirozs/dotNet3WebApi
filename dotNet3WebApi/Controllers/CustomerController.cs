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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly MyDbContext _myDbContext;

        public CustomerController(ILogger<ProductController> logger, MyDbContext myDbContext)
        {
            _logger = logger;
            _myDbContext = myDbContext;
        }

        // GET: api/customers
        [HttpGet(CustomerEndpoints.GetAll)]
        public async Task<IEnumerable<Customer>> GetAll(
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize,
            [FromQuery] string searchValue
        )
        {
            _logger.LogInformation($"Executing GET request to endpoint '{CustomerEndpoints.GetAll}'");
            int fPageNumber = pageNumber ?? 1;
            int fPageSize = pageSize ?? 10;
            string fSearchValue = searchValue == null ? "%%" : $"%{searchValue.Trim().ToUpper()}%";
            int offsetValue = (fPageNumber - 1) * fPageSize;
            return await _myDbContext.Customers.FromSqlInterpolated($@"
                select *
                from dbo.customer c
                where c.name like {fSearchValue}
                order by c.customer_id desc
                offset {offsetValue} rows fetch next {fPageSize} rows only
            ").ToListAsync();
        }

        // POST api/customers
        [HttpPost(CustomerEndpoints.Post)]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer resource)
        {
            _logger.LogInformation($"Executing POST request to endpoint '{CustomerEndpoints.Post}'");
            if (resource.CustomerId != null)
            {
                return BadRequest("Property 'customerId' should be sent as null");
            }
            _myDbContext.Customers.Add(resource);
            await _myDbContext.SaveChangesAsync();
            return Ok(resource);
        }
    }
}
