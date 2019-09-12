using System;
namespace inventoryapi.Domain.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        // TODO: Prevent serialization, causes infinite loop
        //public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}
