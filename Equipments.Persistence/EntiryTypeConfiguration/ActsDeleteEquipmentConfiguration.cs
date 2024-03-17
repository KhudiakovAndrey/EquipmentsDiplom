using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class ActsDeleteEquipmentConfiguration : IEntityTypeConfiguration<ActsDeleteEquipment>
    {
        public void Configure(EntityTypeBuilder<ActsDeleteEquipment> entity)
        {
            entity.HasKey(e => e.IdActDeleteEquipments)
                                .HasName("acts_delete_equipments_pkey");

            entity.ToTable("acts_delete_equipments");

            entity.Property(e => e.IdActDeleteEquipments).HasColumnName("id_act_delete_equipments");

            entity.Property(e => e.CostRes)
                .HasColumnType("money")
                .HasColumnName("cost_res");

            entity.Property(e => e.CountRes).HasColumnName("count_res");

            entity.Property(e => e.IdEquipment).HasColumnName("id_equipment");

            entity.Property(e => e.NumberAct)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("number_act");

            entity.Property(e => e.ReasonDelete).HasColumnName("reason_delete");

            entity.HasOne(d => d.IdEquipmentNavigation)
                .WithMany(p => p.ActsDeleteEquipments)
                .HasForeignKey(d => d.IdEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipment_fk");

            entity.HasOne(d => d.NumberActNavigation)
                .WithMany(p => p.ActsDeleteEquipments)
                .HasForeignKey(d => d.NumberAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("number_act_fk");
        }
    }
}
