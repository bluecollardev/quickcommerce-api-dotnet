using System;
using System.ComponentModel.DataAnnotations;

namespace inventoryapi.Resources
{
    public class SaveTagResource
    {
        public SaveTagResource()
        {
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
