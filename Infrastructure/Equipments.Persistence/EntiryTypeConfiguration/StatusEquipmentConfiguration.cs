using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class StatusEquipmentConfiguration : IEntityTypeConfiguration<StatusEquipment>
    {
        public void Configure(EntityTypeBuilder<StatusEquipment> entity)
        {
            entity.HasKey(e => e.IdStatusEquipment)
                                .HasName("status_equipments_pkey");

            entity.ToTable("status_equipments");

            entity.Property(e => e.IdStatusEquipment).HasColumnName("id_status_equipment");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");
        }
    }
}
