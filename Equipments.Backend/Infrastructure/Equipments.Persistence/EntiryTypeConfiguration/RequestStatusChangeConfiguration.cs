using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class RequestStatusChangeConfiguration : IEntityTypeConfiguration<RequestStatusChange>
    {
        public void Configure(EntityTypeBuilder<RequestStatusChange> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("RequestStatusChange_pkey");

            entity.ToTable("RequestStatusChange");

            entity.HasIndex(e => new { e.StatusChangeDate, e.WorkDescription }, "RequestStatusChange_index");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.IdequipmentServiceRequest).HasColumnName("IDEquipmentServiceRequest");

            entity.Property(e => e.WorkDescription)
                .HasMaxLength(255)
                .HasColumnName("WorkDescription");

            entity.HasOne(d => d.IdequipmentServiceRequestNavigation)
                .WithMany(p => p.RequestStatusChanges)
                .HasForeignKey(d => d.IdequipmentServiceRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestStatusChange_Status");

            entity.HasOne(d => d.StatusNavigation)
                .WithMany(p => p.RequestStatusChanges)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequestStatusChange_Request");
        }
    }
}
