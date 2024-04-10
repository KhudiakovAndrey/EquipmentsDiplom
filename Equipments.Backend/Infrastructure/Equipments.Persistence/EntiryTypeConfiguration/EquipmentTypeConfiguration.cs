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
                  .HasName("EquipmentTypes_pkey");

            entity.ToTable("EquipmentTypes");

            entity.HasIndex(e => e.Name, "EquipmentTypes_ID_INDEX");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Name");
        }
    }
}
