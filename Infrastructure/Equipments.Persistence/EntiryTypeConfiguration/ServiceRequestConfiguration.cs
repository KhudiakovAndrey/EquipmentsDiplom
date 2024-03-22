using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class ServiceRequestConfiguration : IEntityTypeConfiguration<ServiceRequest>
    {
        public void Configure(EntityTypeBuilder<ServiceRequest> entity)
        {
            entity.HasKey(e => e.IdServiceRequests)
                                .HasName("service_requests_pkey");

            entity.ToTable("service_requests");

            entity.Property(e => e.IdServiceRequests).HasColumnName("id_service_requests");

            entity.Property(e => e.DatetimeAdd)
                .HasColumnName("datetime_add")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.IdEquipment).HasColumnName("id_equipment");

            entity.Property(e => e.IdEquipmentCustodians).HasColumnName("id_equipment_custodians");

            entity.Property(e => e.IdTechnicalSupport).HasColumnName("id_technical_support");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.IdEquipmentNavigation)
                .WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.IdEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipmentt_fk");

            entity.HasOne(d => d.IdEquipmentCustodiansNavigation)
                .WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.IdEquipmentCustodians)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipment_custodians_fk");

            entity.HasOne(d => d.IdTechnicalSupportNavigation)
                .WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.IdTechnicalSupport)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_technical_support_fk");
        }
    }
}
