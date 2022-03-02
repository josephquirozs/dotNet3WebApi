using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetApiExample.Models
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public long? CustomerId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("credit_line", TypeName = "decimal(8, 2)")]
        public decimal CreditLine { get; set; }

        [Column("is_vip")]
        public bool IsVip { get; set; }

        [Column("member_since")]
        public DateTime MemberSince { get; set; }
    }
}
