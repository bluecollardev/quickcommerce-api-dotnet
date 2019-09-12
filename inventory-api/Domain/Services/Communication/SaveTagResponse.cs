using System;
using inventoryapi.Domain.Models;

namespace inventoryapi.Domain.Services.Communication
{
    public class SaveTagResponse : BaseResponse<Tag>
    {
        public SaveTagResponse(Tag model) : base(true, string.Empty, model)
        {
        }

        public SaveTagResponse(string message) : base(false, message)
        {
        }
    }
}
