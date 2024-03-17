using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class EquipmentCustodianConfiguration : IEntityTypeConfiguration<EquipmentCustodian>
    {
        public void Configure(EntityTypeBuilder<EquipmentCustodian> entity)
        {
            entity.HasKey(e => e.IdequipmentCustodians)
                                .HasName("equipment_custodians_pkey");

            entity.ToTable("equipment_custodians");

            entity.Property(e => e.IdequipmentCustodians).HasColumnName("idequipment_custodians");

            entity.Property(e => e.Idworker).HasColumnName("idworker");

            entity.Property(e => e.NumberOffice)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnName("number_office");

            entity.HasOne(d => d.IdworkerNavigation)
                .WithMany(p => p.EquipmentCustodians)
                .HasForeignKey(d => d.Idworker)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("pk_idworker");

            entity.HasOne(d => d.NumberOfficeNavigation)
                .WithMany(p => p.EquipmentCustodians)
                .HasForeignKey(d => d.NumberOffice)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("number_office_fk");
        }
    }
}
