using dotNetApiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetApiExample
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
