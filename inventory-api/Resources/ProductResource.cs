using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using inventoryapi.Domain.Enums;
using inventoryapi.Domain.Models;

namespace inventoryapi.Resources
{
    public class ProductResource
    {
        public ProductResource()
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
        public IList<ProductCategory> ProductCategories { get; set; }
    }
}
