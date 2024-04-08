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

            entity.ToTable("equipment_service_requests");

            entity.HasIndex(e => new { e.DetailedDescription, e.BrokenEquipmentDescription, e.CreationDate }, "equipment_service_requests_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.BrokenEquipmentDescription)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("broken_equipment_description");

            entity.Property(e => e.DetailedDescription)
                .HasMaxLength(255)
                .HasColumnName("detailed_description");

            entity.Property(e => e.IdproblemType).HasColumnName("idproblem_type");

            entity.Property(e => e.Idresponsible).HasColumnName("idresponsible");

            entity.Property(e => e.IdsystemAdministrator).HasColumnName("idsystem_administrator");

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
