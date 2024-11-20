﻿namespace HRMS.Entities
{
    public class UserAddress
    {
        public Guid Id { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public Guid UserId { get; set; }
        public Users User { get; set; }
    }
}
