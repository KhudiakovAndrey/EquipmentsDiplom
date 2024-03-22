using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class ActsAcceptEquipmentConfiguration : IEntityTypeConfiguration<ActsAcceptEquipment>
    {
        public void Configure(EntityTypeBuilder<ActsAcceptEquipment> entity)
        {
            entity.HasKey(e => e.IdActAcceptEquipment)
                                .HasName("acts_accept_equipments_pkey");

            entity.ToTable("acts_accept_equipments");

            entity.Property(e => e.IdActAcceptEquipment).HasColumnName("id_act_accept_equipment");

            entity.Property(e => e.CostRes)
                .HasColumnType("money")
                .HasColumnName("cost_res");

            entity.Property(e => e.CountRes).HasColumnName("count_res");

            entity.Property(e => e.IdEquipment).HasColumnName("id_equipment");

            entity.Property(e => e.NumberAct)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("number_act");

            entity.HasOne(d => d.IdEquipmentNavigation)
                .WithMany(p => p.ActsAcceptEquipments)
                .HasForeignKey(d => d.IdEquipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipment_fk");

            entity.HasOne(d => d.NumberActNavigation)
                .WithMany(p => p.ActsAcceptEquipments)
                .HasForeignKey(d => d.NumberAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("number_act_fk");
        }
    }
}
