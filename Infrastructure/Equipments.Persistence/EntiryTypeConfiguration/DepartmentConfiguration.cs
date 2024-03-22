using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
            entity.HasKey(e => e.Iddepartment)
                    .HasName("departments_pkey");

            entity.ToTable("departments");

            entity.Property(e => e.Iddepartment).HasColumnName("iddepartment");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");
        }
    }
}
