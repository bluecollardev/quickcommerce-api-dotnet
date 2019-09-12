using System;
using System.ComponentModel.DataAnnotations;

namespace inventoryapi.Resources
{
    public class SavePropertyResource
    {
        public SavePropertyResource()
        {
        }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
    }
}
