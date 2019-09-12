using System;
using System.ComponentModel.DataAnnotations;

namespace inventoryapi.Resources
{
    public class SaveCategoryResource
    {
        public SaveCategoryResource()
        {
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
