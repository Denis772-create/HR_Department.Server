using HR.Department.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Department.Infrastructure.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //var navigation = builder.Metadata.FindNavigation(nameof(Employee.Positions));
            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            
            builder.Property(e => e.RequiredSalary)
                .HasColumnType("decimal(18,2")
                .IsRequired();

            builder.Property(e => e.FirstName)
                .IsRequired();

            builder.Property(e => e.Surname)
                .IsRequired();

            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.OwnsOne(e => e.Address, a =>
            {
                a.WithOwner();

                a.Property(a => a.Street)
                    .HasMaxLength(180)
                    .IsRequired();

                a.Property(a => a.Country)
                    .HasMaxLength(90)
                    .IsRequired();

                a.Property(a => a.City)
                    .HasMaxLength(100)
                    .IsRequired();
            });
        }
    }
}
