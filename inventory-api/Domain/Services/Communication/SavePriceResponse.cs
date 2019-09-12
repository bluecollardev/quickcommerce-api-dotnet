using System;
using inventoryapi.Domain.Models;

namespace inventoryapi.Domain.Services.Communication
{
    public class SavePriceResponse : BaseResponse<Price>
    {
        public SavePriceResponse(Price model) : base(true, string.Empty, model)
        {
        }

        public SavePriceResponse(string message) : base(false, message)
        {
        }
    }
}
