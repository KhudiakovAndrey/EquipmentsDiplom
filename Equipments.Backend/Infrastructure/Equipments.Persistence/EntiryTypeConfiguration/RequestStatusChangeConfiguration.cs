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
                  .HasName("request_status_changes_pkey");

            entity.ToTable("request_status_changes");

            entity.HasIndex(e => new { e.StatusChangeDate, e.WorkDescription }, "request_status_changes_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdequipmentServiceRequest).HasColumnName("idequipment_service_request");

            entity.Property(e => e.WorkDescription)
                .HasMaxLength(255)
                .HasColumnName("work_description");

            entity.HasOne(d => d.IdequipmentServiceRequestNavigation)
                .WithMany(p => p.RequestStatusChanges)
                .HasForeignKey(d => d.IdequipmentServiceRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_request_status_changes_equipment_service_request_id");

            entity.HasOne(d => d.StatusNavigation)
                .WithMany(p => p.RequestStatusChanges)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_request_status_changes_status_id");
        }
    }
}
