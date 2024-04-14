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
                  .HasName("PurchasedEquipment_pkey");

            entity.ToTable("PurchasedEquipment");

            entity.HasIndex(e => new { e.EquipmentName, e.MeasurementUnit, e.Quantity, e.AdditionalCondition }, "PurchasedEquipment_index");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.AdditionalCondition)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("AdditionalCondition");

            entity.Property(e => e.EquipmentName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("EquipmentName");

            entity.Property(e => e.IdequipmentPurchaseRequest).HasColumnName("IDEquipmentPurchaseRequest");

            entity.Property(e => e.MeasurementUnit)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("MeasurementUnit");

            entity.HasOne(d => d.IdequipmentPurchaseRequestNavigation)
                .WithMany(p => p.PurchasedEquipments)
                .HasForeignKey(d => d.IdequipmentPurchaseRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchasedEquipment_EquipmentPurchaseRequest");
        }
    }
}
