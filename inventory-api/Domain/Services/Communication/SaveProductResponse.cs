using System;
using inventoryapi.Domain.Models;

namespace inventoryapi.Domain.Services.Communication
{
    public class SaveProductResponse : BaseResponse<Product>
    {
        public SaveProductResponse(Product model) : base(true, string.Empty, model)
        {
        }

        public SaveProductResponse(string message) : base(false, message)
        {
        }
    }
}
