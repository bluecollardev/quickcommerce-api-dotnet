using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventoryapi.Domain.Models
{
    [Table("prices")]
    public class Price
    {
        public Price()
        {
        }

        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? PropertyId { get; set; }
        public double Amount { get; set; }
        public int CurrencyId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Name { get; set; }
    }
}
