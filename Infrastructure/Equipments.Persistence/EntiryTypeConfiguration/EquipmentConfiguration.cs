using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> entity)
        {
            entity.HasKey(e => e.IdEquipment)
                               .HasName("equipments_pkey");

            entity.ToTable("equipments");

            entity.HasIndex(e => e.Title, "ix_equipments_title");

            entity.Property(e => e.IdEquipment).HasColumnName("id_equipment");

            entity.Property(e => e.Fulltitle)
                .IsRequired()
                .HasColumnName("fulltitle");

            entity.Property(e => e.IdStatusEquipment).HasColumnName("id_status_equipment");

            entity.Property(e => e.IdTypeEquipment).HasColumnName("id_type_equipment");

            entity.Property(e => e.Isgroup).HasColumnName("isgroup");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.IdStatusEquipmentNavigation)
                .WithMany(p => p.Equipment)
                .HasForeignKey(d => d.IdStatusEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_status_equipment_fk");

            entity.HasOne(d => d.IdTypeEquipmentNavigation)
                .WithMany(p => p.Equipment)
                .HasForeignKey(d => d.IdTypeEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_type_equipment_fk");
        }
    }
}
