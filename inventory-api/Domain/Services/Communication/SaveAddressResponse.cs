using System;
using inventoryapi.Domain.Models;

namespace inventoryapi.Domain.Services.Communication
{
    public class SaveAddressResponse : BaseResponse<Address>
    {
        public SaveAddressResponse(Address model) : base(true, string.Empty, model)
        {
        }

        public SaveAddressResponse(string message) : base(false, message)
        {
        }
    }
}
