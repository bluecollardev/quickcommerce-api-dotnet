using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using inventoryapi.Domain.Models;

namespace inventoryapi.Resources
{
    public class TagResource
    {
        public TagResource()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
