﻿namespace HRMS.DTOs.ResponseDtos
{
    public class UserAddressResponceDtos
    {
        public Guid Id { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }



        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }
    }
}