using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class EquipmentPurchaseRequestConfiguration : IEntityTypeConfiguration<EquipmentPurchaseRequest>
    {
        public void Configure(EntityTypeBuilder<EquipmentPurchaseRequest> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("equipment_purchase_requests_pkey");

            entity.ToTable("equipment_purchase_requests");

            entity.HasIndex(e => new { e.PurchaseReason, e.CreationDate, e.PurchaseDeadline }, "equipment_purchase_requests_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdsystemAdministrator).HasColumnName("idsystem_administrator");

            entity.Property(e => e.PurchaseDeadline)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("purchase_deadline");

            entity.Property(e => e.PurchaseReason)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("purchase_reason");

            entity.HasOne(d => d.IdsystemAdministratorNavigation)
                .WithMany(p => p.EquipmentPurchaseRequests)
                .HasForeignKey(d => d.IdsystemAdministrator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipment_purchase_requests_system_administrator_id");
        }
    }
}
