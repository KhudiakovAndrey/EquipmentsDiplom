using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class InventoryObjectConfiguration : IEntityTypeConfiguration<InventoryObject>
    {
        public void Configure(EntityTypeBuilder<InventoryObject> entity)
        {
            entity.HasKey(e => e.IdAdditionallyEquipment)
                                .HasName("additionally_equipments_pkey");

            entity.ToTable("inventory_objects");

            entity.HasIndex(e => e.InventoryNumber, "additionally_equipments_inventory_number_key")
                .IsUnique();

            entity.HasIndex(e => e.CostEq, "ix_additionally_equipments_cost_eq");

            entity.HasIndex(e => e.InventoryNumber, "ix_additionally_equipments_inventory_number");

            entity.Property(e => e.IdAdditionallyEquipment)
                .HasColumnName("id_additionally_equipment")
                .HasDefaultValueSql("nextval('additionally_equipments_id_additionally_equipment_seq'::regclass)");

            entity.Property(e => e.CostEq)
                .HasColumnType("money")
                .HasColumnName("cost_eq");

            entity.Property(e => e.DateAdd)
                .HasColumnName("date_add")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.DateDelete).HasColumnName("date_delete");

            entity.Property(e => e.DateUse).HasColumnName("date_use");

            entity.Property(e => e.IdEquipment).HasColumnName("id_equipment");

            entity.Property(e => e.IdEquipmentCustodians).HasColumnName("id_equipment_custodians");

            entity.Property(e => e.InventoryNumber)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("inventory_number");

            entity.HasOne(d => d.IdEquipmentNavigation)
                .WithMany(p => p.InventoryObjects)
                .HasForeignKey(d => d.IdEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipment_fk");

            entity.HasOne(d => d.IdEquipmentCustodiansNavigation)
                .WithMany(p => p.InventoryObjects)
                .HasForeignKey(d => d.IdEquipmentCustodians)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipment_custodians_fk");
        }
    }
}
