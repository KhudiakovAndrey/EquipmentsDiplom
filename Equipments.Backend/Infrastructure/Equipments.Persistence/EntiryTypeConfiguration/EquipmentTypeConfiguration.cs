using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class EquipmentTypeConfiguration : IEntityTypeConfiguration<EquipmentType>
    {
        public void Configure(EntityTypeBuilder<EquipmentType> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("equipment_types_pkey");

            entity.ToTable("equipment_types");

            entity.HasIndex(e => e.Name, "equipment_types_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
        }
    }
}
