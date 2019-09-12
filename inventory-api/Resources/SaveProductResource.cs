using System;
using System.ComponentModel.DataAnnotations;

namespace inventoryapi.Resources
{
    public class SaveProductResource
    {
        public SaveProductResource()
        {
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
