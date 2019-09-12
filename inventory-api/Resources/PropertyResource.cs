using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using inventoryapi.Domain.Models;

namespace inventoryapi.Resources
{
    public class PropertyResource
    {
        public PropertyResource()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        // TODO: Partial models?
        public string Summary { get; set; }
        public string Description { get; set; }
        // TODO: Partial models?
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        // TODO: Partial models?
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public IList<Price> Prices { get; set; }
        // TODO: Partial models?
        public string PrimaryImage { get; set; }
        public string PrimaryImageId { get; set; }
        public string GalleryFolder { get; set; }
    }
}
