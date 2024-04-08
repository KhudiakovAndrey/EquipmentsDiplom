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
                  .HasName("problem_types_pkey");

            entity.ToTable("problem_types");

            entity.HasIndex(e => e.Description, "problem_types_index");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("description");

            entity.Property(e => e.IdequipmentType).HasColumnName("idequipment_type");

            entity.HasOne(d => d.IdequipmentTypeNavigation)
                .WithMany(p => p.ProblemTypes)
                .HasForeignKey(d => d.IdequipmentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_problem_types_equipment_type_id");
        }
    }
}
