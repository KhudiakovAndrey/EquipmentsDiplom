using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class AssignedOfficeConfiguration : IEntityTypeConfiguration<AssignedOffice>
    {
        public void Configure(EntityTypeBuilder<AssignedOffice> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("assigned_offices_pkey");

            entity.ToTable("assigned_offices");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnName("number");
        }
    }
}