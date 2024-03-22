using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class EquipmentResourceConfiguration : IEntityTypeConfiguration<EquipmentResource>
    {
        public void Configure(EntityTypeBuilder<EquipmentResource> entity)
        {
            entity.HasKey(e => e.NumberRes)
                                .HasName("number_res_pk");

            entity.ToTable("equipment_resources");

            entity.HasIndex(e => e.NumberRes, "equipment_resources_number_res_key")
                .IsUnique();

            entity.Property(e => e.NumberRes)
                .HasMaxLength(10)
                .HasColumnName("number_res");

            entity.Property(e => e.CostRes)
                .HasColumnType("money")
                .HasColumnName("cost_res");

            entity.Property(e => e.CountRes).HasColumnName("count_res");

            entity.Property(e => e.Fulltitle)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("fulltitle");

            entity.Property(e => e.IdEquipmentsCustodians).HasColumnName("id_equipments_custodians");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.IdEquipmentsCustodiansNavigation)
                .WithMany(p => p.EquipmentResources)
                .HasForeignKey(d => d.IdEquipmentsCustodians)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipment_custodians_fk");
        }
    }
}
