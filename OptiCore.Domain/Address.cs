using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Domain
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }

        public Address(string street, string city, string county, string postcode, string country)
        {
            Street = street;
            City = city;
            County = county;
            Postcode = postcode;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Street}, {City}, {County}, {Postcode}, {Country}";
        }
    }

}
