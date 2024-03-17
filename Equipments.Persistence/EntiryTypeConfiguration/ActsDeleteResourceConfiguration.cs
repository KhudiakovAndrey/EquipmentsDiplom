using Equipments.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Persistence.EntiryTypeConfiguration
{
    public class ActsDeleteResourceConfiguration : IEntityTypeConfiguration<ActsDeleteResource>
    {
        public void Configure(EntityTypeBuilder<ActsDeleteResource> entity)
        {
            entity.HasKey(e => e.IdActDeleteResources)
                                .HasName("acts_delete_resources_pkey");

            entity.ToTable("acts_delete_resources");

            entity.Property(e => e.IdActDeleteResources).HasColumnName("id_act_delete_resources");

            entity.Property(e => e.CostRes)
                .HasColumnType("money")
                .HasColumnName("cost_res");

            entity.Property(e => e.CountRes).HasColumnName("count_res");

            entity.Property(e => e.NumberAct)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("number_act");

            entity.Property(e => e.NumberRes)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("number_res");

            entity.Property(e => e.ReasonDelete).HasColumnName("reason_delete");

            entity.HasOne(d => d.NumberActNavigation)
                .WithMany(p => p.ActsDeleteResources)
                .HasForeignKey(d => d.NumberAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("number_act_fk");

            entity.HasOne(d => d.NumberResNavigation)
                .WithMany(p => p.ActsDeleteResources)
                .HasForeignKey(d => d.NumberRes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("number_res_fk");
        }
    }
}
