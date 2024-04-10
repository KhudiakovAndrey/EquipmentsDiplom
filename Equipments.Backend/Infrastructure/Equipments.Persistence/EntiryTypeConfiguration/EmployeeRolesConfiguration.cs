using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class EmployeeRolesConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> entity)
        {
            entity.HasKey(e => e.ID)
              .HasName("EmployeeRoles_pkey");

            entity.ToTable("EmployeeRoles");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");
        }
    }
}

