﻿using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;
using HR.Department.Core.Entities.ValueObjects;

namespace HR.Department.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; private set; }
        public string Surname { get; private set; }
        public Address Address { get; private set; }
        public virtual string Phone { get; private set; }
        public int Age { get; private set; }
        public decimal RequiredSalary { get; private set; }

        private readonly List<Position> _positions = new();
        public virtual IReadOnlyCollection<Position> Positions => _positions.AsReadOnly();
        public Employee(string firstName,
            string surname,
            Address address,
            string phone,
            int age,
            decimal defaultSalary)
        {
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Surname = surname;
            Address = address;
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            Age = Guard.Against.NegativeOrZero(age, nameof(age));
            RequiredSalary = Guard.Against.Negative(defaultSalary, nameof(defaultSalary));
        }

        public Employee()
        { }

        public void UpdateAddress(Address address) =>
            Address = Guard.Against.Null(address, nameof(address));


        public void UpdatePhone(string phone) =>
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));

        public void AddPosition(Position position)
        {
            if (!Positions.Any(ps => ps.Id == position.Id))
                _positions.Add(position);
        }
    }

}
