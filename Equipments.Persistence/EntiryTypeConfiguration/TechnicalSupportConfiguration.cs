using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class TechnicalSupportConfiguration : IEntityTypeConfiguration<TechnicalSupport>
    {
        public void Configure(EntityTypeBuilder<TechnicalSupport> entity)
        {
            entity.HasKey(e => e.Idtechnicalsupport)
                                .HasName("technical_support_pkey");

            entity.ToTable("technical_support");

            entity.Property(e => e.Idtechnicalsupport).HasColumnName("idtechnicalsupport");

            entity.Property(e => e.Idworker).HasColumnName("idworker");

            entity.HasOne(d => d.IdworkerNavigation)
                .WithMany(p => p.TechnicalSupports)
                .HasForeignKey(d => d.Idworker)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("technical_support_idworker_fkey");
        }
    }
}
