using HR.Department.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.Department.Infrastructure.Data.Config
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {

            builder.Property(p => p.TypePositionId)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
