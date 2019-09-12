using System;
namespace inventoryapi.Domain.Models
{
    public class Address
    {
        public Address()
        {
        }

        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        // Prov / state / territory
        public int ZoneId { get; set; }
        public string Zone { get; set; }
        public int CountryId { get; set; }
        public string Postcode { get; set; }
    }
}
