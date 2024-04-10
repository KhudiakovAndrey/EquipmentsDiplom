using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntityTypeConfiguration
{
    public class ProblemTypeConfiguration : IEntityTypeConfiguration<ProblemType>
    {
        public void Configure(EntityTypeBuilder<ProblemType> entity)
        {
            entity.HasKey(e => e.Id)
                  .HasName("ProblemTypes_pkey");

            entity.ToTable("ProblemTypes");

            entity.HasIndex(e => e.Description, "ProblemTypes_ID_INDEX");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Description");

            entity.Property(e => e.IdequipmentType).HasColumnName("IDEquipmentType");

            entity.HasOne(d => d.IdequipmentTypeNavigation)
                .WithMany(p => p.ProblemTypes)
                .HasForeignKey(d => d.IdequipmentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProblemTypes_EquipmentType");
        }
    }
}
