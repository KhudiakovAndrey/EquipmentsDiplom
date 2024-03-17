using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class ProgressServiceRequestConfiguration : IEntityTypeConfiguration<ProgressServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ProgressServiceRequest> entity)
        {
            entity.HasKey(e => e.IdProgressServiceRequest)
                                .HasName("progress_service_requests_pkey");

            entity.ToTable("progress_service_requests");

            entity.Property(e => e.IdProgressServiceRequest).HasColumnName("id_progress_service_request");

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.IdServiceRequest).HasColumnName("id_service_request");

            entity.Property(e => e.IdStatusRequest).HasColumnName("id_status_request");

            entity.HasOne(d => d.IdServiceRequestNavigation)
                .WithMany(p => p.ProgressServiceRequests)
                .HasForeignKey(d => d.IdServiceRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_service_request_fk");

            entity.HasOne(d => d.IdStatusRequestNavigation)
                .WithMany(p => p.ProgressServiceRequests)
                .HasForeignKey(d => d.IdStatusRequest)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_status_request_fk");
        }
    }
}
