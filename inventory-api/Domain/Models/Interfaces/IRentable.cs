using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventoryapi.Domain.Models.Interfaces
{
    public interface IRentable
    {
        IList<Price> Prices { get; set; }
        bool IsRentable { get; set; }
    }
}
