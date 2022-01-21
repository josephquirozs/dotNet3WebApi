using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetApiExample.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public long? ProductId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price", TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Column("stock", TypeName = "decimal(8, 2)")]
        public decimal Stock { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("expiration")]
        public DateTime Expiration { get; set; }
    }
}
