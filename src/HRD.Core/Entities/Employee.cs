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
        public virtual string Phone { get;  set; }
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
            FirstName = firstName;
            Surname = surname;
            Address = address;
            Phone = phone;
            Age = age;
            RequiredSalary = defaultSalary;
        }

        public Employee()
        { }

        public void UpdateAddress(Address address)
        {
            Guard.Against.Null(address, nameof(address));

            Address = address;
        }

        public void UpdatePhone(string phone)
        {
            Guard.Against.NullOrEmpty(phone, nameof(phone));

            Phone = phone;
        }

        public void AddPosition(Position position)
        {
            if (!Positions.Any(ps => ps.Id == position.Id))
                _positions.Add(position);
        }
    }
}
