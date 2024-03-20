using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> entity)
        {
            entity.HasKey(e => e.Idworker)
                    .HasName("workers_pkey");

            entity.ToTable("workers");

            entity.HasIndex(e => e.Fio, "ix_workers_fio");

            entity.Property(e => e.Idworker).HasColumnName("idworker");

            entity.Property(e => e.Fio)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("fio");

            entity.Property(e => e.Iddepartment).HasColumnName("iddepartment");

            entity.Property(e => e.Idpost).HasColumnName("idpost");

            entity.Property(e => e.Image)
                .HasMaxLength(10485760)
                .HasColumnName("image")
                .HasDefaultValueSql("'Unidentity.jpg'::character varying");

            entity.HasOne(d => d.IddepartmentNavigation)
                .WithMany(p => p.Workers)
                .HasForeignKey(d => d.Iddepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("iddepartment_fk");

            entity.HasOne(d => d.IdpostNavigation)
                .WithMany(p => p.Workers)
                .HasForeignKey(d => d.Idpost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idpost_fk");
        }
    }
}
