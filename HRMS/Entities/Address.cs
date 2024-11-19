using System.Net.Http.Headers;

namespace HRMS.Entities
{
    public class Address
    {
        public Guid Id { get; set; } 

        public string HouseNumber { get; set; } 

        public string Street { get; set; } 

        public string Lane { get; set; } 

        public string City { get; set; } 

        public string State { get; set; } 

        public string PostalCode { get; set; } 

        public string Country { get; set; } 

        public Guid StudentId { get; set; }

        public Students Student { get; set; }

    }
}
