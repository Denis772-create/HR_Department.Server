namespace HR.Department.Core.Entities.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        private Address() { }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

    }
}
