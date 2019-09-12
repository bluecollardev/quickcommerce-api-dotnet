using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using inventoryapi.Domain.Models.Interfaces;

namespace inventoryapi.Domain.Models
{
    /// <summary>
    /// This model represents a minimal Property listing, as it would be displayed
    /// on a web page. It should not contain things like MLS fields. Extend this
    /// model, or use a join table when implementing custom asset types.
    /// </summary>
    [Table("properties")]
    public class Property : IRentable
    {
        public Property()
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
        public bool IsRentable { get; set; }
        // TODO: Partial models?
        public string PrimaryImage { get; set; }
        public string PrimaryImageId { get; set; }
        public string GalleryFolder { get; set; }
    }
}
