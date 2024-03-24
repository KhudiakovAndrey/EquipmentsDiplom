using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class TypeEquipmentConfiguration : IEntityTypeConfiguration<TypeEquipment>
    {
        public void Configure(EntityTypeBuilder<TypeEquipment> entity)
        {
            entity.HasKey(e => e.IdTypeEquipment)
                     .HasName("type_equipments_pkey");

            entity.ToTable("type_equipments");

            entity.Property(e => e.IdTypeEquipment).HasColumnName("id_type_equipment");

            entity.Property(e => e.Title).HasColumnName("title");
        }
    }
}
