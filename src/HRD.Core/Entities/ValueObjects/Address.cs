namespace HR.Department.Core.Entities.ValueObjects
{
    public class Address
    {
        public string Street { get; }

        public string City { get; }

        public string Country { get; }

        public Address() { }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

    }
}
