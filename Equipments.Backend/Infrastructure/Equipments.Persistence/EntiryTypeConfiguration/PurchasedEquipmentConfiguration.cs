using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class PurchasedEquipmentConfiguration : IEntityTypeConfiguration<PurchasedEquipment>
    {
        public void Configure(EntityTypeBuilder<PurchasedEquipment> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("purchased_equipment_pkey");

            entity.ToTable("purchased_equipment");

            entity.HasIndex(e => new { e.EquipmentName, e.MeasurementUnit, e.Quantity, e.AdditionalCondition }, "purchased_equipment_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.AdditionalCondition)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("additional_condition");

            entity.Property(e => e.EquipmentName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("equipment_name");

            entity.Property(e => e.IdequipmentPurchaseRequest).HasColumnName("idequipment_purchase_request");

            entity.Property(e => e.MeasurementUnit)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("measurement_unit");

            entity.HasOne(d => d.IdequipmentPurchaseRequestNavigation)
                .WithMany(p => p.PurchasedEquipments)
                .HasForeignKey(d => d.IdequipmentPurchaseRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchased_equipment_equipment_purchase_request_id");
        }
    }
}
