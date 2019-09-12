using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using inventoryapi.Domain.Models;

namespace inventoryapi.Domain.Interfaces
{
    public interface IRentable
    {
        IList<Price> Prices();
    }
}
