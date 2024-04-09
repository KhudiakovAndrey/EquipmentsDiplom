using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class EquipmentServiceRequestConfiguration : IEntityTypeConfiguration<EquipmentServiceRequest>
    {
        public void Configure(EntityTypeBuilder<EquipmentServiceRequest> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("equipment_service_requests_pkey");

            entity.ToTable("EquipmentServiceRequest");

            entity.HasIndex(e => new { e.DetailedDescription, e.BrokenEquipmentDescription, e.CreationDate }, "equipment_service_requests_index");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.BrokenEquipmentDescription)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("BrokenEquipmentDescription");

            entity.Property(e => e.DetailedDescription)
                .HasMaxLength(255)
                .HasColumnName("DetailedDescription");

            entity.Property(e => e.IdproblemType).HasColumnName("IDProblemType");

            entity.Property(e => e.Idresponsible).HasColumnName("IDResponsible");

            entity.Property(e => e.IdsystemAdministrator).HasColumnName("IDSystemAdministrator");

            entity.HasOne(d => d.IdproblemTypeNavigation)
                .WithMany(p => p.EquipmentServiceRequests)
                .HasForeignKey(d => d.IdproblemType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipment_service_requests_problem_type_id");

            entity.HasOne(d => d.IdresponsibleNavigation)
                .WithMany(p => p.EquipmentServiceRequestIdresponsibleNavigations)
                .HasForeignKey(d => d.Idresponsible)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipment_service_requests_responsible_id");

            entity.HasOne(d => d.IdsystemAdministratorNavigation)
                .WithMany(p => p.EquipmentServiceRequestIdsystemAdministratorNavigations)
                .HasForeignKey(d => d.IdsystemAdministrator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipment_service_requests_system_administrator_id");
        }
    }
}
