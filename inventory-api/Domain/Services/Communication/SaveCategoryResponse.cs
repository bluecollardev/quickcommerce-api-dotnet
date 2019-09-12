using System;
using inventoryapi.Domain.Models;

namespace inventoryapi.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse<Category>
    {
        public SaveCategoryResponse(Category model) : base(true, string.Empty, model)
        {
        }

        public SaveCategoryResponse(string message) : base(false, message)
        {
        }
    }
}
