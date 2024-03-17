using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class ActConfiguration : IEntityTypeConfiguration<Act>
    {
        public void Configure(EntityTypeBuilder<Act> entity)
        {
            entity.HasKey(e => e.NumberAct)
                                .HasName("number_act_pk");

            entity.ToTable("acts");

            entity.HasIndex(e => e.NumberAct, "acts_number_act_key")
                .IsUnique();

            entity.HasIndex(e => e.NumberAct, "ix_acts_number_act");

            entity.Property(e => e.NumberAct)
                .HasMaxLength(12)
                .HasColumnName("number_act");

            entity.Property(e => e.DatetimeAdd)
                .HasColumnName("datetime_add")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.IdEquipmentsCustodians).HasColumnName("id_equipments_custodians");

            entity.Property(e => e.IsDelete)
                .HasColumnName("is_delete")
                .HasDefaultValueSql("false");

            entity.HasOne(d => d.IdEquipmentsCustodiansNavigation)
                .WithMany(p => p.Acts)
                .HasForeignKey(d => d.IdEquipmentsCustodians)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_equipment_custodians_fk");
        }
    }
}
