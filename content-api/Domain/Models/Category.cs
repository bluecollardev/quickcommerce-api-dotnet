using System;
using System.Collections.Generic;

namespace inventoryapi.Domain.Models
{
    public class Category
    {
        public Category()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        // TODO: Prevent serialization, causes infinite loop
        //public IList<ProductCategory> CategoryProducts { get; set; }
    }
}
