using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using inventoryapi.Domain.Models.Interfaces;

namespace inventoryapi.Domain.Models
{
    /// <summary>
    /// This model represents a minimal Asset listing, as it would be displayed
    /// on a web page. Extend this model, or use a join table when implementing
    /// custom asset types.
    /// </summary>
    public class Asset : IRentable
    {
        public Asset()
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
        // TODO: Add Array of [Location & LocationId]
        public IList<Price> Prices { get; set; }
        // TODO: Partial models?
        public string PrimaryImage { get; set; }
        public string PrimaryImageId { get; set; }
        public string GalleryFolder { get; set; }
        public bool IsRentable { get; set; }
    }
}
