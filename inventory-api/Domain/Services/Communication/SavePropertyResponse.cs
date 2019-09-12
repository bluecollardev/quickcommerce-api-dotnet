using System;
using inventoryapi.Domain.Models;

namespace inventoryapi.Domain.Services.Communication
{
    public class SavePropertyResponse : BaseResponse<Property>
    {
        public SavePropertyResponse(Property model) : base(true, string.Empty, model)
        {
        }

        public SavePropertyResponse(string message) : base(false, message)
        {
        }
    }
}
