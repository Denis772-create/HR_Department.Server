using HR.Department.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Department.Infrastructure.Config
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasMany(p => p.Employees)
                .WithMany(e => e.Positions)
                .UsingEntity<PositionEmployee>(
                    j => j
                        .HasOne(pe => pe.Employee)
                        .WithMany()
                        .HasForeignKey(pe => pe.EmployeeId),
                    j => j
                        .HasOne(pe => pe.Position)
                        .WithMany()
                        .HasForeignKey(pe => pe.PositionId),
                    j =>
                    {
                        j.Property(pe => pe.Salary)
                            .HasColumnType("decimal(18,2")
                            .HasDefaultValue(300);
                        j.HasKey(t => new { t.PositionId, t.EmployeeId });
                    });


            builder.Property(p => p.TypePositionId)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
