using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using inventoryapi.Domain.Enums;
using inventoryapi.Domain.Models.Interfaces;

namespace inventoryapi.Domain.Models
{
    /* A product that can be sold as a single unit - may be physical or not */
    [Table("products")]
    public class Product : IRentable
    {
        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        /* Quantity in stock */
        public short? QuantityInStock { get; set; }
        /* Not the same as packages - use this if the product contains multiple units of an item eg. 6 pack of Coca-Cola vs a 12 pack of Coca-Cola */
        public short? QuantityInPack { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        public IList<Price> Prices { get; set; }
        public bool IsRentable { get; set; }
        public IList<ProductCategory> ProductCategories { get; set; }
    }
}
