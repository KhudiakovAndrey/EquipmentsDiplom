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
                  .HasName("EquipmentPurchaseRequest_pkey");

            entity.ToTable("EquipmentPurchaseRequest");

            entity.HasIndex(e => new { e.PurchaseReason, e.CreationDate, e.PurchaseDeadline }, "EquipmentPurchaseRequest_INDEX");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdsystemAdministrator).HasColumnName("IDSystemAdministrator");

            entity.Property(e => e.PurchaseDeadline)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("PurchaseDeadline");

            entity.Property(e => e.PurchaseReason)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("PurchaseReason");

            entity.HasOne(d => d.IdsystemAdministratorNavigation)
                .WithMany(p => p.EquipmentPurchaseRequests)
                .HasForeignKey(d => d.IdsystemAdministrator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EquipmentPurchaseRequest_SystemAdministrator");
        }
    }
}
